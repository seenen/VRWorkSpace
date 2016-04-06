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

            LoadAllData();

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

        #region OBJFile
        static int MAX_COUNT = 1;//30;

        //  所有的文件
        static List<ObjFile> listFiles = new List<ObjFile>();

        static void LoadAllData()
        {
            for (int i = 1; i < MAX_COUNT + 1; i++)
            {
                string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/" + i.ToString() + ".obj";

                ObjFile of = ObjFile.Load(path);

                listFiles.Add(of);
            }

        }

        #endregion
    }
}
