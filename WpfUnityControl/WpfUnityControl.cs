using AxUnityWebPlayerAXLib;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WpfUnityControl.Properties;

namespace WpfUC
{
    public partial class WpfUnityControl : UserControl
    {
        public WpfUnityControl()
        {
            InitializeComponent();

            Modify();

            this.Load += UnityControl_Load;

        }

        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);

        private void UnityControl_Load(object sender, EventArgs e)
        {
            try
            {
                process = new Process();
                process.StartInfo.FileName = Application.StartupPath + @"\UnityApp\Child.exe";
                process.StartInfo.Arguments = "-parentHWND " + " " + Environment.CommandLine;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                process.WaitForInputIdle();
                // Doesn't work for some reason ?!
                //unityHWND = process.MainWindowHandle;
                //EnumChildWindows(panel1.Handle, WindowEnum, IntPtr.Zero);

                //unityHWNDLabel.Text = "Unity HWND: 0x" + unityHWND.ToString("X8");
            }
            catch (Exception ex)
            {
                //unityHWNDLabel.Text = ex.Message;
                //MessageBox.Show(ex.Message);
            }
        }

        internal void ActivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
        }

        internal void DeactivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
        }

        AxUnityWebPlayer axUnityWebPlayer2;

        void Modify()
        {
            string unitysrc = System.Environment.CurrentDirectory + "/VREditor/VREditor.unity3d";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WpfUnityControl));
            this.SuspendLayout();
            {
                AxHost.State ocxstate = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUnityWebPlayer2.OcxState")));
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
                // axUnityWebPlayer2
                // 
                this.axUnityWebPlayer2 = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
                ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer2)).BeginInit();
                this.axUnityWebPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axUnityWebPlayer2.Enabled = true;
                this.axUnityWebPlayer2.Location = new System.Drawing.Point(0, 0);
                this.axUnityWebPlayer2.Name = "axUnityWebPlayer1";
                this.axUnityWebPlayer2.OcxState = ocxstate;
                this.axUnityWebPlayer2.Size = new System.Drawing.Size(915, 685);
                this.axUnityWebPlayer2.TabIndex = 0;
                this.axUnityWebPlayer2.ReadyStateChange += new AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_ReadyStateChangeEventHandler(this.ReadyStateChange);
                this.axUnityWebPlayer2.OnExternalCall += new AxUnityWebPlayerAXLib._DUnityWebPlayerAXEvents_OnExternalCallEventHandler(this.OnExternalCall);

                ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer2)).EndInit();
            }
            // 
            // Unity3dControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.axUnityWebPlayer2);
            this.Name = "Unity3dControl";
            this.ResumeLayout(false);
        }

        private void OnExternalCall(object sender, _DUnityWebPlayerAXEvents_OnExternalCallEvent e)
        {

            //string str = e.value;

            //str = str.Substring(Prefix.Length);
            //str = str.Substring(0, str.Length - Endfix.Length);

            //Console.WriteLine(str);

            //MessageDecoder.DecodeMessageWithHeader(str, Form1.mMessageInstance);

            //object data = MessageDecoder.DecodeMessage(str);

            //RecvMessage(data);

            //Response(data);
        }

        private void ReadyStateChange(object sender, _DUnityWebPlayerAXEvents_ReadyStateChangeEvent e)
        {
            Console.WriteLine(e.readyState);
        }


    }
}
