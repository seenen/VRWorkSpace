using DataServerCSX86;
using LibVRGeometry;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace VRClient
{
    public class DataServer : IDisposable
    {
        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern void Run(string fileName);

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern void End();

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int GetViSize();

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern void GetVi(out IntPtr fi);

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern int GetSurfacePointCount();

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern void GetSurfacePointAndCalc(out IntPtr fi);

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern void GetVi(out IntPtr fi, out int ptCount);

        //[DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        //static extern void GetDataAndCalc(out IntPtr fi, out int ptCount);

        Unity3dControl unity3dControl2;

        public DataServer(Unity3dControl con)
        {
            this.unity3dControl2 = con;

            //初始化计算器
            Server.StartServer("DataServer/qingxing.dat");

            A();
        }

        public void Dispose()
        {
            Server.EndServer();
        }

        private void SetVi(VBOBufferSingle vbo)
        {
            int viSize = Server.ViSize;
            int[] viArray = new int[viSize];

            Server.SetVi(viArray);

            vbo.faces.Clear();

            for (int i = 0; i < viSize; )
            {
                FaceIndices fi1 = new FaceIndices();
                fi1.vi = viArray[i + 2];
                vbo.faces.Add(fi1);
                FaceIndices fi2 = new FaceIndices();
                fi2.vi = viArray[i + 1];
                vbo.faces.Add(fi2);
                FaceIndices fi3 = new FaceIndices();
                fi3.vi = viArray[i];
                vbo.faces.Add(fi3);

                i = i + 3;
            }
        }

        VBOBufferSingle vbo = null;
        void A()
        {
            //Run("DataServer/qingxing.dat");

            vbo = new VBOBufferSingle();
            vbo.id = 0;
            SetVi(vbo);

            CreateModel();
        }

        void CreateModel()
        {
            float start = System.DateTime.Now.Millisecond;

            {
                SetVi(vbo);

                int sfSize = Server.ViSize;
                float[] sfArray = new float[sfSize];
                Server.SetNewSurfacePoints(sfArray);

                vbo.vertices.Clear();

                for (int i = 0; i < sfSize / 3; i++)
                {
                    int curX = i * 3;
                    vbo.vertices.Add(new _Vector3(sfArray[curX], sfArray[curX + 1], sfArray[curX + 2]));
                }
            }
            //GetDataAndCalc(vbo);
            vbo.id = 0;
            vbo.name = "default";
            vbo.materialName = "default";
            vbo.state = VBOState.Create;
            vbo.vboType = VBOType.DOT_OBJ;
            //for (int i = 0; i < vbo.faces.Count; ++i)
            //{
            //    FaceIndices face = vbo.faces[i];
            //    face.vi += 1;
            //}
            //vbo.faces.Reverse();

            unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

            VBOBufferSingleFile.Output(vbo, "G:/GitHub/VRWorkSpaceForUnity/Assets/DataServerFiles/DataServer_vboBufferSingle.obj");
            start = (System.DateTime.Now.Millisecond - start);

            Console.WriteLine("SendMessage<VBOBufferSingle>." + start / 1000.0f / 1000.0f);
        }

        void UpdateModel()
        {

            {
                SetVi(vbo);

                int sfSize = Server.ViSize;
                float[] sfArray = new float[sfSize];
                Server.SetNewSurfacePoints(sfArray);

                vbo.vertices.Clear();

                for (int i = 0; i < sfSize / 3; i++)
                {
                    int curX = i * 3;
                    vbo.vertices.Add(new _Vector3(sfArray[curX], sfArray[curX + 1], sfArray[curX + 2]));
                }
            }

            //GetDataAndCalc(vbo);
            vbo.id = 0;
            vbo.state = VBOState.Update;
            vbo.vboType = VBOType.DOT_OBJ;
            vbo.name = "default";
            vbo.materialName = "default";

            Console.WriteLine("DataServer.Beta is running in its own thread." + vbo.id);

        }

        int MAX_COUNT = 50;

        public void Beta()
        {
            int index = 0;

            Thread.Sleep(10);

            while (true)
            {
                UpdateModel();

                Thread.Sleep(10);

                index++;

                if (index == MAX_COUNT) break;

                float start = System.DateTime.Now.Millisecond;

                unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);

                VBOBufferSingleFile.Output(vbo, "G:/GitHub/VRWorkSpaceForUnity/Assets/DataServerFiles/DataServer_vboBufferSingle_" + index.ToString() + ".obj");

            }
        }
    }
}
