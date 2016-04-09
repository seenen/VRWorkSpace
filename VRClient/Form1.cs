using LibVRGeometry;
using LibraryMM;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        Alpha oAlpha = null;

        private void LoadAllVBO_Click(object sender, EventArgs e)
        {
            oAlpha = new Alpha(this.unity3dControl2);
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

        void LoadAllData()
        {
            for (int i = 1; i < MAX_COUNT + 1; i++)
            {
                string path = "G:/GitHub/VR/Tools/stl2obj/Resources/DataFileObj/" + i.ToString() + ".obj";

                string content = File.ReadAllText(path);

                listFiles.Add(content);

                GeometryBuffer gb = SetGeometryData(content);
                gb.PopulateMeshes();

                VBOBuffer vbo = new VBOBuffer();
                vbo.objects.AddRange(gb.objects);
                vbo.vertices.AddRange(gb.vertices);
                vbo.uvs.AddRange(gb.uvs);
                vbo.normals.AddRange(gb.normals);
                vbo.triangles.AddRange(gb.triangles);
                vbo.state = ObjModelRawState.Create;

                string output = EditorMessageDecoder.EncodeMessageByProtobuf<VBOBuffer>(vbo);

                listGbs.Add(vbo);
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

                unity3dControl2.SendMessage<VBOBuffer>((VBOBuffer)listGbs[0]);

                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);
            }

            Thread.Sleep(1000);

            while (true)
            {
                VBOBuffer vbo = (VBOBuffer)listGbs[index];
                vbo.id = 0;
                vbo.state = ObjModelRawState.Update;

                Console.WriteLine("Alpha.Beta is running in its own thread." + vbo.id);

                Thread.Sleep(33);

                index++;

                if (index == MAX_COUNT) index = 0;

                float start = System.DateTime.Now.Millisecond;

                unity3dControl2.SendMessage<VBOBuffer>(vbo);


                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);

            }
        }

        public void Beta1()
        {
            int index = 0;

            {
                ObjModelRaw omr = new ObjModelRaw();
                omr.id = 0;
                omr.content = listFiles[index];
                omr.state = ObjModelRawState.Create;
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
                omr.state = ObjModelRawState.Update;

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
