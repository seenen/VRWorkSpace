using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxUnityWebPlayerAXLib;

namespace VRClient
{
    public partial class Unity3dControl : UserControl
    {
        public Unity3dControl()
        {
            InitializeComponent();

            InitUnity3dControl();
        }

        #region 组件设计器生成的代码

        private System.ComponentModel.IContainer components = null;
        private AxUnityWebPlayerAXLib.AxUnityWebPlayer axUnityWebPlayer1;

        private void InitializeComponent()
        {
            string unitysrc = System.Environment.CurrentDirectory + "\\UserControl\\UserControl.unity3d";
            string dir = System.Environment.CurrentDirectory;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Unity3dControl));
            this.SuspendLayout();
            {
                AxHost.State ocxstate = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUnityWebPlayer1.OcxState")));
                {
                    // Create a ocx state object with the correct path
                    AxUnityWebPlayerAXLib.AxUnityWebPlayer _Unity = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
                    ((System.ComponentModel.ISupportInitialize)(_Unity)).BeginInit();
                    _Unity.OcxState = ocxstate;
                    _Unity.TabIndex = 0;
                    Controls.Add(_Unity);
                    ((System.ComponentModel.ISupportInitialize)(_Unity)).EndInit();
                    _Unity.src = unitysrc;
                    ocxstate = _Unity.OcxState;
                    _Unity.Dispose();
                }
                // 
                // axUnityWebPlayer1
                //
                this.axUnityWebPlayer1 = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
                ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).BeginInit();
                this.axUnityWebPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axUnityWebPlayer1.Enabled = true;
                this.axUnityWebPlayer1.Location = new System.Drawing.Point(0, 0);
                this.axUnityWebPlayer1.Name = "axUnityWebPlayer1";
                this.axUnityWebPlayer1.OcxState = ocxstate;
                this.axUnityWebPlayer1.Size = new System.Drawing.Size(915, 685);
                this.axUnityWebPlayer1.TabIndex = 0;
                this.axUnityWebPlayer1.ReadyStateChange += new AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_ReadyStateChangeEventHandler(this.ReadyStateChange);
                this.axUnityWebPlayer1.OnExternalCall += new AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_OnExternalCallEventHandler(this.OnExternalCall);

                ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).EndInit();
            }
            // 
            // Unity3dControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.axUnityWebPlayer1);
            this.Name = "Unity3dControl";
            this.Size = new System.Drawing.Size(915, 685);
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #endregion 

        #region Unity3dControl
        private void InitUnity3dControl()
        {
            //Debug.WriteLine("InitUnity3dControl");

            this.axUnityWebPlayer1.OnExternalCall += this.OnExternalCall;
            this.axUnityWebPlayer1.ReadyStateChange += this.ReadyStateChange;
        }

        const string Prefix = "OnExternalCall(\"";
        const string Endfix = "\");";
        private void OnExternalCall(object sender, _DUnityWebPlayerAXEvents_OnExternalCallEvent e)
        {

            string str = e.value;

            str = str.Substring(Prefix.Length);
            str = str.Substring(0, str.Length - Endfix.Length);

            Console.WriteLine(str);

            object data = EditorMessageDecoder.DecodeMessage(str);

            RecvMessage(data);

            Response(data);
        }

        private void ReadyStateChange(object sender, _DUnityWebPlayerAXEvents_ReadyStateChangeEvent e)
        {
            Console.WriteLine(e.readyState);
        }

        void Send(string regionmsg)
        {
            axUnityWebPlayer1.SendMessage("_Message_", "_Message_Json_Recv", regionmsg);
        }
        #endregion

        #region IEditorPlugin

        ////public event PluginMessageHandler OnGetPluginMessage;
        ////public event CallAddSceneObject CallAddObject;
        ////public event CallResetSceneObject CallResetObject;

        public Control AsControl()
        {
            return this;
        }

        public bool EnableRight { get { return false; } }

        private void Response(object resp)
        {
            ////if (OnGetPluginMessage != null)
            ////{
            ////    OnGetPluginMessage.Invoke(resp);
            ////}
        }

        public void SendMessage(object data)
        {
            string output = EditorMessageDecoder.EncodeMessage(data);

            Send(output);

            return;
        }

        public void RecvMessage(object data)
        {
            ////if (data is RspOnObjectSelected)
            ////{
            ////    RspOnObjectSelected rsp = data as RspOnObjectSelected;
            ////    rsp.Selected = true;
            ////}
        }


        //------------------------------------------------------------------------------

        #endregion

    }
}
