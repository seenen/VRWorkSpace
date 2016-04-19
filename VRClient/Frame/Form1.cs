#define DataServer

using LibraryMM;
using LibVRGeometry;
using LibVRGeometry.Message;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VRClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreateMenu();

            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoginForm qform = new LoginForm();
            qform.Owner = this;      //假设当前窗口是新窗口的拥有者
            qform.ShowDialog(this);
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
            vbo.state = MessageState.Destory;
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
            SceneMessage sm = new SceneMessage();
            sm.scene_name = "这是一个场景";

            this.unity3dControl2.SendMessage<SceneMessage>(sm);

            ((Button)sender).Enabled = false;

        }
#endregion
    }
}
