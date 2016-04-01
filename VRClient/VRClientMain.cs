using LibraryMM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRClient
{
    static class VRClientMain
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            mMemoryMap = new MemoryMap();

            CreateReaderMemory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static MemoryMap mMemoryMap = null;

        static string MapName = "TestMapName";

        static string MutexName = "TestMutexName";

        public static ComOperate coReader;

        static void CreateReaderMemory()
        {
        }
    }
}
