using LibraryMM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            this.unity3dControl1.SendMessage(jsStart);
        }

        #region MMF
        private void Read_Click(object sender, EventArgs e)
        {

        }

        private void ReadMMF_Click(object sender, EventArgs e)
        {
            TestMsg tm = (TestMsg)MMF.ReadObjectFromMMF("TestMsg");

            string str = JsonFx.Json.JsonWriter.Serialize(tm);

            Console.WriteLine("MMF.ReadObjectFromMMF " + str);

            EditorMessage jsStart = new EditorMessage();
            jsStart.name = tm.name;
            jsStart.age = tm.age;
            jsStart.st = tm.st;

            this.unity3dControl1.SendMessage(jsStart);
        }
        #endregion
    }
}
