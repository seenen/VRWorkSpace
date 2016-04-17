using LibVRGeometry;
using System;
using System.Threading;

namespace VRClient
{
    public class DataServer
    {
        Unity3dControl unity3dControl2;

        public DataServer(Unity3dControl con)
        {
            this.unity3dControl2 = con;

            A();
        }

        VBOBufferSingle vbo = null;
        void A()
        {
            //初始化计算器
            VBOBufferSingleCreator.Run("DataServer/qingxing.dat");

            vbo = new VBOBufferSingle();
            VBOBufferSingleCreator.SetVi(vbo);
        }

        int MAX_COUNT = 25;

        public void Beta()
        {
            int index = 0;

            {
                float start = System.DateTime.Now.Millisecond;

                VBOBufferSingleCreator.GetDataAndCalc(vbo);
                vbo.id = 0;
                vbo.name = "default";
                vbo.materialName = "default";
                vbo.state = MessageState.Create;
                vbo.vboType = VBOType.DOT_OBJ;
                for (int i = 0; i < vbo.faces.Count; ++i)
                {
                    FaceIndices face = vbo.faces[i];
                    face.vi += 1;
                }
                unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

                VBOBufferSingleFile.Output(vbo, "G:/GitHub/VRWorkSpaceForUnity/Assets/DataServer_vboBufferSingle.obj");
                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);
            }

            Thread.Sleep(10);

            while (true)
            {
                VBOBufferSingleCreator.GetDataAndCalc(vbo);
                vbo.id = 0;
                vbo.state = MessageState.Update;
                vbo.vboType = VBOType.DOT_OBJ;
                vbo.name = "default";
                vbo.materialName = "default";
                for (int i = 0; i < vbo.faces.Count; ++i)
                {
                    FaceIndices face = vbo.faces[i];
                    face.vi += 1;
                }
                Console.WriteLine("DataServer.Beta is running in its own thread." + vbo.id);

                Thread.Sleep(20);

                index++;

                if (index == MAX_COUNT) index = 0;

                float start = System.DateTime.Now.Millisecond;

                unity3dControl2.SendMessage<VBOBufferSingle>(vbo);

                start = (System.DateTime.Now.Millisecond - start);

                Console.WriteLine("SendMessage<ObjModelRaw>." + start / 1000.0f / 1000.0f);

            }
        } 
    }
}
