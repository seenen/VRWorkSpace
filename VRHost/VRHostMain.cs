using System;
using System.Windows.Forms;
using LibraryMM;

namespace VRHost
{
    static class VRHostMain
    {
        static string MapName = "TestMapName";

        static string MutexName = "TestMutexName";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //mSec = new MemoryMappedFileSecurity();
            //SecurityIdentifier si = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            //AccessRule<MemoryMappedFileRights> ar = new AccessRule<MemoryMappedFileRights>(si, MemoryMappedFileRights.FullControl, AccessControlType.Allow);
            //mSec.AddAccessRule(ar);

            string[] arg = Environment.GetCommandLineArgs();

            MapName = arg[0];
            MutexName = arg[1];

            Console.WriteLine(MapName + " " + MutexName);

            mMemoryMap = new MemoryMap();

            CreateWriteMemory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static MemoryMap mMemoryMap = null;

        public static ComOperate coLocal;

        static void CreateWriteMemory()
        {
            try
            {
                coLocal = mMemoryMap.CreateNonPersistentMappedFile(MapName, MutexName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
