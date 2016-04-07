using LibraryGeometryFormat;
using LibraryMM;
using System;
using System.Collections.Generic;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditorMessage jsStart = new EditorMessage();
            jsStart.name = "我是发送者";
            jsStart.age = "1";
            jsStart.st = System.DateTime.Now;

            this.unity3dControl2.SendMessage<EditorMessage>(jsStart);
        }

        #region MMF
        private void Read_Click(object sender, EventArgs e)
        {
            TestMsg tm = (TestMsg)MMF.ReadObjectFromMMF("TestMsg");

            string str = JsonFx.Json.JsonWriter.Serialize(tm);

            Console.WriteLine("MMF.ReadObjectFromMMF " + str);

            EditorMessage jsStart = new EditorMessage();
            jsStart.name = tm.name;
            jsStart.age = tm.age;
            jsStart.st = tm.st;

            this.unity3dControl2.SendMessage<EditorMessage>(jsStart);

        }

        private void ReadMMF_Click(object sender, EventArgs e)
        {
            ObjModelRaw omr = (ObjModelRaw)MMF.ReadObjectFromMMF("ObjFileRaw");
            string str = JsonFx.Json.JsonWriter.Serialize(omr);

            //ObjModel tm = (ObjModel)MMF.ReadObjectFromMMF("ObjFile");
            //string str = JsonFx.Json.JsonWriter.Serialize(tm);

            Console.WriteLine("MMF.ReadObjectFromMMF " + str);

            this.unity3dControl2.SendMessage<ObjModelRaw>(omr);
        }
        #endregion

        void StartRecvThread()
        {
            Alpha oAlpha = new Alpha(this.unity3dControl2);
            Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));
            oThread.Start();
            //while (!oThread.IsAlive)
            //    Thread.Sleep(1);
            //oThread.Abort();
            //oThread.Join();
            //Console.WriteLine();
            //Console.WriteLine("Alpha.Beta has finished");
            //try
            //{
            //    Console.WriteLine("Try to restart the Alpha.Beta thread");
            //    oThread.Start();
            //}
            //catch (ThreadStateException)
            //{
            //    Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
            //    Console.WriteLine("Expected since aborted threads cannot be restarted.");
            //    Console.ReadLine();
            //}
        }

        private void threadsendmessage_Click(object sender, EventArgs e)
        {

            StartRecvThread();

        }
    }

    public class Alpha
    {
        Unity3dControl unity3dControl2;

        public Alpha(Unity3dControl con)
        {
            this.unity3dControl2 = con;

            LoadAllData();
        }

        int MAX_COUNT = 30;

        //  所有的文件
        List<string> listFiles = new List<string>();

        void LoadAllData()
        {
            for (int i = 1; i < MAX_COUNT + 1; i++)
            {
                string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/" + i.ToString() + ".obj";

                string content = File.ReadAllText(path);

                listFiles.Add(content);
            }
        }


        public void Beta()
        {
            int index = 0;

            {
                ObjModelRaw omr = new ObjModelRaw();
                omr.id = 0;
                omr.content = listFiles[index];
                omr.state = ObjModelRawState.Create;

                unity3dControl2.SendMessage<ObjModelRaw>(omr);
            }

            Thread.Sleep(1000);

            while (true)
            {
                ObjModelRaw omr = new ObjModelRaw();
                omr.id = 0;
                omr.content = listFiles[index];
                omr.state = ObjModelRawState.Update;

                Console.WriteLine("Alpha.Beta is running in its own thread." + omr.id);

                Thread.Sleep(10);

                index++;

                if (index == MAX_COUNT) index = 0;

                unity3dControl2.SendMessage<ObjModelRaw>(omr);

            }
        }
    }
}
