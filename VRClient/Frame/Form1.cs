﻿#define DataServer

using LibVRGeometry;
using LibVRGeometry.Message;
using LibVRGeometry.VRWorld;
using System;
using System.Threading;
using System.Windows.Forms;

namespace VRClient
{
    public partial class Form1 : Form
    {
        static WorldMgr mWorldMgr = null;

        public static MessageInstance mMessageInstance;

        public Form1()
        {
            InitializeComponent();

            CreateMenu();

            mWorldMgr = new WorldMgr(this.unity3dControl2);

            mMessageInstance = new MessageInstance(mWorldMgr);

            VRAPI.SetU3DHandler(mWorldMgr);

            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //LoginForm qform = new LoginForm();
            //qform.Owner = this;      //假设当前窗口是新窗口的拥有者
            //qform.ShowDialog(this);

            #region Test
            VRClient.Test.Test t = new VRClient.Test.Test();
            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
            }

            //return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditorMessage jsStart = new EditorMessage();
            jsStart.name = "我是发送者";
            jsStart.age = "1";
            jsStart.st = System.DateTime.Now;

            this.unity3dControl2.SendMessage<EditorMessage>(jsStart);
        }

        private void threadsendmessage_Click(object sender, EventArgs e)
        {
#if DataServer
            oThread = new Thread(new ThreadStart(oDataServer.Beta));
#else
            oThread = new Thread(new ThreadStart(oAlpha.Beta));
#endif
            try
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                oThread.Start();
            }
            catch (ThreadStateException)
            {
                Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
                Console.WriteLine("Expected since aborted threads cannot be restarted.");
                Console.ReadLine();
            }
        }

#if DataServer
        DataServer oDataServer = null;
#else
        Alpha oAlpha = null;
#endif
        Thread oThread = null;

        private void LoadAllVBO_Click(object sender, EventArgs e)
        {
#if DataServer
            oDataServer = new DataServer(this.unity3dControl2);
#else
            oAlpha = new Alpha(this.unity3dControl2);
#endif

            threadsendmessage.Enabled = true;
            DeleteAllVBO.Enabled = true;
        }

        private void DeleteAllVBO_Click(object sender, EventArgs e)
        {
            oThread.Abort();
            oThread = null;

#if DataServer
            oDataServer = null;
#else
            oAlpha = null;
#endif

            threadsendmessage.Enabled = false;
            DeleteAllVBO.Enabled = false;

            VBOBufferSingle vbo = new VBOBufferSingle();
            vbo.id = 0;
            vbo.state = VBOState.Destory;
            vbo.vboType = VBOType.DOT_OBJ;

            unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

            Console.WriteLine();
            Console.WriteLine("Alpha.Beta has finished");
        }

        #region 胆囊操作流程
        /// <summary>
        /// 初始化一个胆囊拆除场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            InitScene();

            InitHall();

            ((Button)sender).Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deformation();
        }

        /// <summary>
        /// 
        /// </summary>
        void InitScene()
        {
            SceneMessage sm = new SceneMessage();
            sm.scene_name = "这是一个场景";

            this.unity3dControl2.SendMessage<SceneMessage>(sm);
        }

        /// <summary>
        /// 初始化一个胆囊
        /// </summary>
        void InitHall()
        {
#if DataServer
            oDataServer = new DataServer(this.unity3dControl2);
            oThread = new Thread(new ThreadStart(oDataServer.Beta));
#else
            oAlpha = new Alpha(this.unity3dControl2);
            oThread = new Thread(new ThreadStart(oAlpha.Beta));
#endif
        }

        /// <summary>
        /// 初始化钛夹
        /// </summary>
        HDTitaniumClampMessage tc = new HDTitaniumClampMessage();
        void InitTitaniumClamp()
        {
            tc.id = 0;
            tc.state = UnitMessageState.Create;
            tc.type = HDType.TitaniumClamp;
            //tc.move_speed = 0.2f;
            //tc.rotate_speed = 30;
            tc.merge_degree = 10;
            tc.merge_speed = 6;

            this.unity3dControl2.SendMessage<HDTitaniumClampMessage>(tc);
        }

        /// <summary>
        /// 初始化剪
        /// </summary>
        HDScissorsMessage s = new HDScissorsMessage();
        void InitScissors()
        {
            s.id = 1;
            s.state = UnitMessageState.Create;
            s.type = HDType.Scissors;
            //s.move_speed = 0.2f;
            //s.rotate_speed = 30;
            s.merge_degree = 10;
            s.merge_speed = 6;

            this.unity3dControl2.SendMessage<HDScissorsMessage>(s);

        }

        void Deformation()
        {
            oThread.Start();
        }

        /// <summary>
        /// 配置钛夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            CFG_MDForm cfgform = new CFG_MDForm();
            cfgform.InitTitaniumClamp(ref tc);
            cfgform.Owner = this;
            cfgform.ShowDialog(this);
        }

        public void UpdateTitaniumClamp(HDTitaniumClampMessage t)
        {
            tc = t;
            tc.state = UnitMessageState.Modify;
            this.unity3dControl2.SendMessage<HDTitaniumClampMessage>(tc);

        }

        /// <summary>
        /// 配置剪子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            CFG_MDForm cfgform = new CFG_MDForm();
            cfgform.InitScissors(ref s);
            cfgform.Owner = this;
            cfgform.ShowDialog(this);

        }

        public void UpdateScissors(HDScissorsMessage _s)
        {
            s = _s;
            s.state = UnitMessageState.Modify;
            this.unity3dControl2.SendMessage<HDScissorsMessage>(s);
        }
        #endregion

        /// <summary>
        /// 加载器材
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            InitTitaniumClamp();

            InitScissors();

            ((Button)sender).Enabled = false;

            ((Button)button4).Enabled = true;
            ((Button)button5).Enabled = true;
        }

        #region 机械手
        RobotArm mRobotArm = null;
        HDRobotArmMessage mHDRobotArmMessage = new HDRobotArmMessage();

        private void RobotArm_Click(object sender, EventArgs e)
        {
            if (mRobotArm == null)
            {
                mHDRobotArmMessage.id = 100;
                mHDRobotArmMessage.type = HDType.RobotArm;
                mHDRobotArmMessage.state = UnitMessageState.Create;
                mHDRobotArmMessage.mFaceAngle = 30;
                mHDRobotArmMessage.mElbowAngle = 30;
                mHDRobotArmMessage.mShoulderHeight = 50f;
                mHDRobotArmMessage.mUpperarmLen = 50f;
                mHDRobotArmMessage.mForearmLen = 80f;
                mHDRobotArmMessage.mOriginPos = new _Vector3(0, 0, 0);
                mHDRobotArmMessage.length = 220;

                VRAPI.UpdateLeftRobotArm(ref mHDRobotArmMessage, 120);

                trackBar1.Value = (int)mHDRobotArmMessage.mFaceAngle;
                textBox1.Text = trackBar1.Value.ToString();
                trackBar2.Value = (int)mHDRobotArmMessage.mElbowAngle;
                textBox2.Text = trackBar2.Value.ToString();
                trackBar3.Value = (int)120;
                textBox3.Text = trackBar3.Value.ToString();

            }

            ((Button)sender).Enabled = false;
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            trackBar3.Enabled = true;

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            mHDRobotArmMessage.state = UnitMessageState.Modify;
            mHDRobotArmMessage.mFaceAngle = trackBar1.Value;
            textBox1.Text = trackBar1.Value.ToString();

            VRAPI.UpdateLeftRobotArm(ref mHDRobotArmMessage, trackBar3.Value);

            label4.Text =   "   X:" + mHDRobotArmMessage.mToolHead.X +
                            "   Y:" + mHDRobotArmMessage.mToolHead.Y +
                            "   Z:" + mHDRobotArmMessage.mToolHead.Z;
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            mHDRobotArmMessage.state = UnitMessageState.Modify;
            mHDRobotArmMessage.mElbowAngle = trackBar2.Value;
            textBox2.Text = trackBar2.Value.ToString();

            VRAPI.UpdateLeftRobotArm(ref mHDRobotArmMessage, trackBar3.Value);

            label4.Text = "   X:" + mHDRobotArmMessage.mToolHead.X +
                            "   Y:" + mHDRobotArmMessage.mToolHead.Y +
                            "   Z:" + mHDRobotArmMessage.mToolHead.Z;

        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            mHDRobotArmMessage.state = UnitMessageState.Modify;
            textBox3.Text = trackBar3.Value.ToString();

            VRAPI.UpdateLeftRobotArm(ref mHDRobotArmMessage, trackBar3.Value);

            label4.Text = "   X:" + mHDRobotArmMessage.mToolHead.X +
                            "   Y:" + mHDRobotArmMessage.mToolHead.Y +
                            "   Z:" + mHDRobotArmMessage.mToolHead.Z;
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            EnvCfg cfg = new EnvCfg();
            cfg.Log = checkBox1.Checked.ToString();

            this.unity3dControl2.SendMessage<EnvCfg>(cfg);

        }
    }
}
