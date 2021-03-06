﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryMM
{
    public class ReadOperate
    {
        protected MmfInfo mMmfInfo = null;

        BinaryReader mBinaryReader = null;

        Mutex mMutex = null;

        MemoryMappedViewStream stream;

        public ReadOperate(MmfInfo info)
        {
            mMmfInfo = info;

            mMutex = Mutex.OpenExisting(info.mMutexName);

            stream = info.mmf.CreateViewStream(1, 0);
        }

        string readstring = null;

        public string ReadString()
        {
            mMutex.WaitOne();

            readstring = mBinaryReader.ReadString();

            Console.WriteLine("读取内存:" + readstring);

            mMutex.ReleaseMutex();

            return readstring;
        }

        //public void ReadString()
        //{
        //    int colorSize = Marshal.SizeOf(typeof(Msg));
        //    var color = new Msg();

        //    for (int i = 0; i < colorSize * 5; i += colorSize)
        //    {
        //        color.Id = i;
        //        color.NowTime = DateTime.Now.Ticks;

        //        accessor.Write(i, ref color);

        //        Console.WriteLine("{1}\tNowTime:{0}", new DateTime(color.NowTime), color.Id);
        //    }
        //}
    }
}
