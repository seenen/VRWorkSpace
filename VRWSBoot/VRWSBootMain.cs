using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRWSBoot
{
    class VRWSBootMain
    {
        static string MutexName = "TestMutexName";

        static string MapName = "TestMapName";

        static WSManager mWSManager = null;

        static void Main(string[] args)
        {
            mWSManager = new WSManager(MapName, MutexName);
            mWSManager.StartHost();
            mWSManager.StartClient();

            Console.ReadLine();

            mWSManager.Dispose();
            mWSManager = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
