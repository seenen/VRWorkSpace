using LibVRGeometry;
using System;
using System.Threading;

namespace VRClient
{
    public class DataServer : IDisposable
    {
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

        VBOBufferSingle vbo = null;
        void A()
        {
            //Run("DataServer/qingxing.dat");

            vbo = new VBOBufferSingle();
            vbo.id = 0;

            CreateModel();
        }

        void CreateModel()
        {
            float start = System.DateTime.Now.Millisecond;

            Server.Pull(ref vbo);
            vbo.id = 0;
            vbo.name = "default";
            vbo.materialName = "default";
            vbo.state = VBOState.Create;
            vbo.vboType = VBOType.DOT_OBJ;

            unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

            VBOBufferSingleFile.Output(vbo, "G:/GitHub/VRWorkSpaceForUnity/Assets/DataServerFiles/DataServer_vboBufferSingle.obj");
            start = (System.DateTime.Now.Millisecond - start);

            Console.WriteLine("SendMessage<VBOBufferSingle>." + start / 1000.0f / 1000.0f);
        }

        void UpdateModel()
        {
            Server.Pull(ref vbo);
            vbo.id = 0;
            vbo.state = VBOState.Update;
            vbo.vboType = VBOType.DOT_OBJ;
            vbo.name = "default";
            vbo.materialName = "default";

            Console.WriteLine("DataServer.Beta is running in its own thread." + vbo.id);

        }

        int MAX_COUNT = 100;

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

                //VBOBufferSingleFile.Output(vbo, "G:/GitHub/VRWorkSpaceForUnity/Assets/DataServerFiles/DataServer_vboBufferSingle_" + index.ToString() + ".obj");

            }
        }
         
        public void Push()
        {
            UpdateModel();
        }
    }
}
