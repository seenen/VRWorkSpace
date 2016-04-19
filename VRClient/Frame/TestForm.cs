#define DataServer

using LibraryMM;
using LibVRGeometry;
using LibVRGeometry.Message;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VRClient
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoginForm qform = new LoginForm();
            qform.Owner = this;      //假设当前窗口是新窗口的拥有者
            qform.ShowDialog(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
            }

            //return true;
            return base.ProcessCmdKey(ref msg, keyData);
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

        private void threadsendmessage_Click(object sender, EventArgs e)
        {
#if DataServer
            oThread = new Thread(new ThreadStart(oDataServer.Beta));
#else
            oThread = new Thread(new ThreadStart(oAlpha.Beta));
#endif
            try
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                oThread.Start();
            }
            catch (ThreadStateException)
            {
                Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
                Console.WriteLine("Expected since aborted threads cannot be restarted.");
                Console.ReadLine();
            }
        }

#if DataServer
        DataServer oDataServer = null;
#else
        Alpha oAlpha = null;
#endif
        Thread oThread = null;

        private void LoadAllVBO_Click(object sender, EventArgs e)
        {
#if DataServer
            oDataServer = new DataServer(this.unity3dControl2);
#else
            oAlpha = new Alpha(this.unity3dControl2);
#endif

            threadsendmessage.Enabled = true;
            DeleteAllVBO.Enabled = true;
        }

        private void DeleteAllVBO_Click(object sender, EventArgs e)
        {
            oThread.Abort();
            oThread = null;

#if DataServer
            oDataServer = null;
#else
            oAlpha = null;
#endif

            threadsendmessage.Enabled = false;
            DeleteAllVBO.Enabled = false;

            VBOBufferSingle vbo = new VBOBufferSingle();
            vbo.id = 0;
            vbo.state = MessageState.Destory;
            vbo.vboType = VBOType.DOT_OBJ;

            unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

            Console.WriteLine();
            Console.WriteLine("Alpha.Beta has finished");
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
        List<VBOBuffer> listGbs = new List<VBOBuffer>();
        List<VBOBufferSingle> listGbSs = new List<VBOBufferSingle>();

        void LoadAllData()
        {
            for (int i = 1; i < MAX_COUNT + 1; i++)
            {
                string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/" + i.ToString() + ".obj";

                string content = File.ReadAllText(path);

                listFiles.Add(content);

                GeometryBuffer buffer = SetGeometryData(content);

                VBOBufferSingle vbo = new VBOBufferSingle();
                vbo.vertices.AddRange(buffer.vertices);
                vbo.uvs.AddRange(buffer.uvs);
                vbo.normals.AddRange(buffer.normals);
                vbo.state = MessageState.Create;

                vbo.name = buffer.objects[0].name;
                vbo.faces = buffer.objects[0].allFaces;
                vbo.materialName = "default";

                listGbSs.Add(vbo);

                //VBOBuffer vbo = new VBOBuffer();
                //vbo.id = 0;
                //vbo.objects.AddRange(gb.objects);
                //vbo.vertices.AddRange(gb.vertices);
                //vbo.uvs.AddRange(gb.uvs);
                //vbo.normals.AddRange(gb.normals);
                ////vbo.triangles.AddRange(gb.triangles);
                //vbo.state = MessageState.Create;

                //string output = MessageDecoder.EncodeMessageByProtobuf<VBOBuffer>(vbo);

                //listGbs.Add(vbo);
           }
        }

#region obj的解析过程
        /* OBJ file tags */
        private const string O = "o";
        private const string G = "g";
        private const string V = "v";
        private const string VT = "vt";
        private const string VN = "vn";
        private const string F = "f";
        private const string MTL = "mtllib";
        private const string UML = "usemtl";
        private string mtllib;

        /// <summary>
        /// 缓存好序列化文件
        /// </summary>
        /// <param name="data"></param>
        public GeometryBuffer SetGeometryData(string data)
        {
            GeometryBuffer buffer = new GeometryBuffer();

            string[] lines = data.Split("\n\r".ToCharArray());

            for (int i = 0; i < lines.Length; i++)
            {
                string l = lines[i];

                if (l.IndexOf("#") != -1) l = l.Substring(0, l.IndexOf("#"));
                string[] p = l.Split(" ".ToCharArray());

                switch (p[0])
                {
                    case O:
                        buffer.PushObject(p[1].Trim());
                        break;
                    case G:
                        buffer.PushGroup(p[1].Trim());
                        break;
                    case V:
                        buffer.PushVertex(new _Vector3(cf(p[1]), cf(p[2]), cf(p[3])));
                        break;
                    case VT:
                        buffer.PushUV(new _Vector2(cf(p[1]), cf(p[2])));
                        break;
                    case VN:
                        buffer.PushNormal(new _Vector3(cf(p[1]), cf(p[2]), cf(p[3])));
                        break;
                    case F:
                        for (int j = 1; j < p.Length; j++)
                        {
                            string[] c = p[j].Trim().Split("/".ToCharArray());
                            FaceIndices fi = new FaceIndices();
                            fi.vi = ci(c[0]) - 1;
                            if (c.Length > 1 && c[1] != "") fi.vu = ci(c[1]) - 1;
                            if (c.Length > 2 && c[2] != "") fi.vn = ci(c[2]) - 1;
                            buffer.PushFace(fi);
                        }
                        break;
                    case MTL:
                        mtllib = p[1].Trim();
                        break;
                    case UML:
                        buffer.PushMaterialName(p[1].Trim());
                        break;
                }
            }

            return buffer;
            // buffer.Trace();
        }

        private float cf(string v)
        {
            return Convert.ToSingle(v.Trim(), new CultureInfo("en-US"));
        }

        private int ci(string v)
        {
            return Convert.ToInt32(v.Trim(), new CultureInfo("en-US"));
        }

#endregion
        public void Beta()
        {
            int index = 0;

            {
                float start = System.DateTime.Now.Millisecond;

                unity3dControl2.SendMessage<VBOBufferSingle>((VBOBufferSingle)listGbSs[0]);
                //unity3dControl2.SendMessage<VBOBuffer>((VBOBuffer)listGbs[0]);
                VBOBufferSingleFile.Output(listGbSs[0], "G:/GitHub/VRWorkSpaceForUnity/Assets/Test_vboBufferSingle.obj");

                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);
            }

            Thread.Sleep(10);

            //while (true)
            //{
            //    VBOBufferSingle vbo = (VBOBufferSingle)listGbSs[index];
            //    vbo.id = 0;
            //    vbo.state = MessageState.Update;

            //    Console.WriteLine("Alpha.Beta is running in its own thread." + vbo.id);

            //    Thread.Sleep(33);

            //    index++;

            //    if (index == MAX_COUNT) index = 0;

            //    float start = System.DateTime.Now.Millisecond;

            //    unity3dControl2.SendMessage<VBOBufferSingle>(vbo);
            //    //unity3dControl2.SendMessage<VBOBuffer>(vbo);


            //    start = (System.DateTime.Now.Millisecond - start);

            //    Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);

            //}


        }

        public void Beta1()
        {
            int index = 0;

            {
                ObjModelRaw omr = new ObjModelRaw();
                omr.id = 0;
                omr.content = listFiles[index];
                omr.state = MessageState.Create;
                omr.t = System.DateTime.Now.Millisecond;

                float start = System.DateTime.Now.Millisecond;

                unity3dControl2.SendMessage<ObjModelRaw>(omr);

                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f );
            }

            Thread.Sleep(1000);

            while (true)
            {
                ObjModelRaw omr = new ObjModelRaw();
                omr.id = 0;
                omr.content = listFiles[index];
                omr.state = MessageState.Update;

                Console.WriteLine("Alpha.Beta is running in its own thread." + omr.id);

                Thread.Sleep(10);

                index++;

                if (index == MAX_COUNT) index = 0;

                float start = System.DateTime.Now.Millisecond;

                unity3dControl2.SendMessage<ObjModelRaw>(omr);


                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);

            }
        }
    }
}
