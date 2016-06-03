using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LibVRGeometry
{
    public class Server
    {
        [DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void Run(string fileName);

        [DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void End();

        [DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int GetViSize();

        [DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void GetVi(out IntPtr fi);

        [DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int GetSurfacePointCount();

        [DllImport("DataServer.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void GetSurfacePointAndCalc(out IntPtr fi);

        public static void StartServer(string fileName)
        {
            Run(fileName);
        }

        public static void EndServer()
        {
            End();
        }

        public static void UpdateServer(float deltaTime)
        {
        }

        private static int ViSize
        {
            get
            {
                return GetViSize();
            }
        }

        private static void SetVi(int[] indexs)
        {
            int viSize = indexs.Length;
            IntPtr viPtr;
            GetVi(out viPtr);
            //Debug.WriteLine("Total VI:" + viSize);
            IntPtr current = viPtr;
            Marshal.Copy(viPtr, indexs, 0, viSize);
        }

        private static int SurfacePointCount
        {
            get
            {
                return GetSurfacePointCount();
            }
        }

        private static void SetNewSurfacePoints(float[] sfArray)
        {
            int sfSize = sfArray.Length;
            IntPtr sfPtr;
            GetSurfacePointAndCalc(out sfPtr);
            //Debug.WriteLine("Surface Point Size:" + sfSize);
            Marshal.Copy(sfPtr, sfArray, 0, sfSize);

        }

        #region VBO

        public static void Pull(ref VBOBufferSingle vbo)
        {
            SetVi(vbo);

            int sfSize = ViSize;
            float[] sfArray = new float[sfSize];
            SetNewSurfacePoints(sfArray);

            vbo.vertices.Clear();

            for (int i = 0; i < sfSize / 3; i++)
            {
                int curX = i * 3;
                vbo.vertices.Add(new _Vector3(sfArray[curX], sfArray[curX + 1], sfArray[curX + 2]));
            }

            return;
        }

        private static void SetVi(VBOBufferSingle vbo)
        {
            int viSize = Server.ViSize;
            int[] viArray = new int[viSize];

            Server.SetVi(viArray);

            vbo.faces.Clear();

            for (int i = 0; i < viSize;)
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

        #endregion
    }
}