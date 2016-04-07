using System;
using System.Windows.Forms;
using LibraryMM;
using System.Collections.Generic;
using System.IO;
using LibraryGeometryFormat;

namespace VRHost
{
    static class VRHostMain
    {
        static string MapName = "TestMapName";

        static string MutexName = "TestMutexName";

        public static Form1 mForm1 = null;

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

            Console.WriteLine("VRHostMain " + MapName + " " + MutexName);

            //mMemoryMap = new MemoryMap();

            //CreateWriteMemory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mForm1 = new Form1();
            Application.Run(mForm1);
        }

        static MemoryMap mMemoryMap = null;

        public static ComOperate nonePersistent;

        static void CreateWriteMemory()
        {
            try
            {
                nonePersistent = mMemoryMap.CreateNonPersistentMappedFile(MapName, MutexName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
