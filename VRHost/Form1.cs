using LibVRGeometry;
using LibraryMM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VRHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ViewList(string content)
        {
            writeView.Items.Add(content, 0);
        }

        #region 写操作
        private int writeIndex = 0;

        private void MemWriteInit_Click(object sender, EventArgs e)
        {
            TestMsg tm = (TestMsg)MMF.ReadObjectFromMMF("TestMsg");

            string str = JsonFx.Json.JsonWriter.Serialize(tm);

            ViewList("MMF.ReadObjectFromMMF " + str);
        }

        private void Write_Click(object sender, EventArgs e)
        {
            ViewList("Write_Click " + writeIndex.ToString());

            VRHostMain.nonePersistent.WriteString(writeIndex.ToString());

            writeIndex++;
        }
        #endregion

        #region 读操作
        private void MemReadInit_Click(object sender, EventArgs e)
        {

        }

        private void Read_Click(object sender, EventArgs e)
        {
            string content = VRHostMain.nonePersistent.ReadString();

            ViewList("Read_Click " + content);

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            TestMsg tm = new TestMsg();
            tm.age = "123";
            tm.name = "456";
            tm.st = System.DateTime.Now;

            MMF.WriteObjectToMMF("TestMsg", tm);

            string str = JsonFx.Json.JsonWriter.Serialize(tm);

            ViewList("MMF.WriteObjectToMMF " + str);
        }

        private void WriteBat_Click(object sender, EventArgs e)
        {
            LoadAllData();

        }

        #region OBJFile
        int MAX_COUNT = 30;

        //  所有的文件
        List<ObjFile> listFiles = new List<ObjFile>();

        int index = 1;

        void LoadAllData()
        {
            for (int i = 1; i < MAX_COUNT + 1; i++)
            {
                string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/" + i.ToString() + ".obj";

                ObjFile of = ObjFile.Load(path);

                listFiles.Add(of);
            }

            Timer t1 = new Timer();
            t1.Interval = 10;
            t1.Tick += new EventHandler(t1_Tick);//定时器每次触发引起的工作

            t1.Start();//start启用定时器
        }

        protected void t1_Tick(object sender, EventArgs e)
        {
            string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/" + index.ToString() +".obj";

            ObjModelRaw omr = new ObjModelRaw();
            omr.id = 0;
            omr.content = File.ReadAllText(path);
            omr.state = ObjModelRawState.Create;

            MMF.WriteObjectToMMF("t1_Tick", omr);

            ViewList("t1_Tick index: " + index);

            index++;

            if (index == MAX_COUNT) index = 1;
        }


        #endregion
        private void WriteObj_Click(object sender, EventArgs e)
        {
            string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/1.obj";

            ObjModelRaw omr = new ObjModelRaw();
            omr.id = 0;
            omr.content = File.ReadAllText(path);
            omr.state = ObjModelRawState.Create;

            MMF.WriteObjectToMMF("ObjFileRaw", omr);

            string str = JsonFx.Json.JsonWriter.Serialize(omr);
            ViewList("MMF.WriteObjectToMMF " + str);

            ////ObjFile of = ObjFile.Load(path);
            ////ObjModel om = of.Models[0];
            ////MMF.WriteObjectToMMF("ObjFile", om);

            ////string str = JsonFx.Json.JsonWriter.Serialize(om);
            ////ViewList("MMF.WriteObjectToMMF " + str);
        }

        private void ReadObj_Click(object sender, EventArgs e)
        {
            ////ObjModel om = (ObjModel)MMF.ReadObjectFromMMF("ObjFile");
            ////string str = JsonFx.Json.JsonWriter.Serialize(om);

            ObjModelRaw omr = (ObjModelRaw)MMF.ReadObjectFromMMF("ObjFileRaw");
            string str = JsonFx.Json.JsonWriter.Serialize(omr);
            ViewList("MMF.ReadObjectFromMMF " + str);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PipeStart_Click(object sender, EventArgs e)
        {
            Pipe.PipeServer("VRClient.exe");
        }
    }
}
