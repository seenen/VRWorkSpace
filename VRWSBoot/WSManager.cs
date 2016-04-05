using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace VRWSBoot
{
    class WSManager : IDisposable
    {
        string mMemMaped = string.Empty;
        string mMutex = string.Empty;

        public WSManager(string mm_name, string mutex_name)
        {
            mMemMaped = mm_name;
            mMutex = mutex_name;
        }

        public void Dispose()
        {
            if (pClient != null)
            {
                if (!pClient.HasExited)
                    pClient.Kill();
                pClient = null;
            }

            if (pHost != null)
            {
                pHost.Kill();
                pHost = null;
            }
        }

        #region Host
        Process pHost = null;

        public void StartHost()
        {
            if (pHost != null)
            {
                Console.WriteLine("VRHost 实例已存在");

                return;
            }

            ThreadStart ts = new System.Threading.ThreadStart(this.StartHostThread);

            new System.Threading.Thread(ts).Start();

        }

        void StartHostThread()
        {
            pHost = new System.Diagnostics.Process();
            pHost.StartInfo.FileName = "VRHost.exe";//需要启动的程序名 
            //  -x sourceFile.Arj c:\temp";
            pHost.StartInfo.Arguments = mMemMaped + " " + mMutex;//启动参数
            pHost.StartInfo.UseShellExecute = false;   // 是否使用外壳程序  
            pHost.StartInfo.RedirectStandardOutput = true;
            //pHost.StartInfo.RedirectStandardInput = true;  // 重定向输入流 
            pHost.StartInfo.RedirectStandardError = true;  //重定向错误流 
            pHost.OutputDataReceived += (s, _e) => Console.WriteLine(_e.Data);
            if (pHost.Start())
            {
                Console.WriteLine("调用VRHost.exe成功");

                while (!pHost.HasExited)
                {
                    string line = pHost.StandardOutput.ReadLine();
                    if (line != null)
                        Console.WriteLine(line);
                }
                pHost.WaitForExit();
            }
            else
                Console.WriteLine("调用VRHost.exe失败 - System.Diagnostics.Process().Start() == false");
        }
        #endregion Host

        #region Client
        Process pClient = null;

        public void StartClient()
        {
            if (pClient != null)
            {
                Console.WriteLine("VRClient 实例已存在");

                return;
            }

            ThreadStart ts = new System.Threading.ThreadStart(this.StartClientThread);

            new System.Threading.Thread(ts).Start();

        }

        void StartClientThread()
        {
            pClient = new System.Diagnostics.Process();
            pClient.StartInfo.FileName = "VRClient.exe";//需要启动的程序名 
            //  -x sourceFile.Arj c:\temp";
            pClient.StartInfo.Arguments = mMemMaped + " " + mMutex;//启动参数
            pClient.StartInfo.UseShellExecute = false;   // 是否使用外壳程序  
            pClient.StartInfo.RedirectStandardOutput = true;
            //pHost.StartInfo.RedirectStandardInput = true;  // 重定向输入流 
            pClient.StartInfo.RedirectStandardError = true;  //重定向错误流 
            pClient.OutputDataReceived += (s, _e) => Console.WriteLine(_e.Data);
            if (pClient.Start())
            {
                Console.WriteLine("VRClient.exe成功"); 

                while (!pClient.HasExited)
                {
                    string line = pClient.StandardOutput.ReadLine();
                    if (line != null)
                        Console.WriteLine(line);
                }
                pClient.WaitForExit();
            }
            else
                Console.WriteLine("VRClient.exe失败 - System.Diagnostics.Process().Start() == false");
        }
        #endregion Host

        //void OpenExe()
        //{
        //    System.Diagnostics.Process p = new System.Diagnostics.Process();
        //    p.StartInfo.FileName = "arj.exe";//需要启动的程序名 
        //    p.StartInfo.Arguments = "-x sourceFile.Arj c:\temp";//启动参数 
        //    p.Start();//启动 
        //}
    }
}
