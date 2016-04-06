using LibraryMM;
using System;
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
            string[] arg = Environment.GetCommandLineArgs();

            if (arg.Length == 3)
            {
                MapName = arg[0];
                MutexName = arg[1];
            }

            Console.WriteLine("VRClientMain " + MapName + " " + MutexName);

            mMemoryMap = new MemoryMap();

            //CreateReaderMemory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static MemoryMap mMemoryMap = null;

        static string MapName = "TestMapName";

        static string MutexName = "TestMutexName";

        public static ReadOperate coReader;

        static void CreateReaderMemory()
        {
            try
            {
                coReader = mMemoryMap.OpenNonPersistentMappedFile(MapName, MutexName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
