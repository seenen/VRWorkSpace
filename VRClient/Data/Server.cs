using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace DataServerCSX86
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
        public static int ViSize
        {
            get
            {
                return GetViSize();
            }
        }
        public static void SetVi(int[] indexs)
        {
            int viSize = indexs.Length;
            IntPtr viPtr;
            GetVi(out viPtr);
            Debug.WriteLine("Total VI:" + viSize);
            IntPtr current = viPtr;
            Marshal.Copy(viPtr, indexs, 0, viSize);
        }
        public static int SurfacePointCount
        {
            get
            {
                return GetSurfacePointCount();
            }
        }
        public static void SetNewSurfacePoints(float[] sfArray)
        {
            int sfSize = sfArray.Length;
            IntPtr sfPtr;
            GetSurfacePointAndCalc(out sfPtr);
            Debug.WriteLine("Surface Point Size:" + sfSize);
            Marshal.Copy(sfPtr, sfArray, 0, sfSize);

            //vbo.vertices.Clear();

            //for (int i = 0; i < sfSize; i++)
            //{
            //    int curX = i * 3;
            //    vbo.vertices.Add(new _Vector3(sfArray[curX], sfArray[curX + 1], sfArray[curX + 2]));
            //}
        }
    }
}