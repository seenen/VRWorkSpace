using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryMM
{
    /// <summary>
    /// 通讯操作接口类
    /// </summary>
    public class ComOperate
    {
        protected MmfInfo mMmfInfo = null;

        bool mutexCreated;

        Mutex mMutex = null;

        BinaryWriter mBinaryWriter = null;
        BinaryReader mBinaryReader = null;

        public ComOperate(MmfInfo info)
        {
            mMmfInfo = info;

            //进程间同步
            mMutex = new Mutex(true, info.mMutexName, out mutexCreated);

            //info.mmf.CreateViewStream(); //创建文件内存视图流 基于流的操作
            
            mBinaryWriter = new BinaryWriter(info.mmf.CreateViewStream());

            mBinaryReader = new BinaryReader(info.mmf.CreateViewStream());
        }

        #region 读写操作

        public void WriteString(string content)
        {
            mMutex.WaitOne();

            using (var stream = mMmfInfo.mmf.CreateViewStream()) //创建文件内存视图流 基于流的操作
            {
                var writer = new BinaryWriter(stream);

                writer.Write(content);

                Console.WriteLine("写入内存:" + content);
            }
            mBinaryWriter.Write(content);

            mMutex.ReleaseMutex(); 

        }

        //byte[] readbytes = null;

        //public byte[] ReadBytes(int len)
        //{
        //    mMutex.WaitOne();

        //    readbytes = mBinaryReader.ReadBytes(len);

        //    mMutex.ReleaseMutex();

        //    return readbytes;
        //}

        string readstring = null;

        public string ReadString()
        {
            mMutex.WaitOne();

            using (var stream = mMmfInfo.mmf.CreateViewStream()) //创建文件内存视图流 基于流的操作
            {
                var reader = new BinaryReader(stream);

                readstring = mBinaryReader.ReadString();

                Console.WriteLine("读取内存:" + readstring);
            }

            mMutex.ReleaseMutex();

            return readstring;
        }

        #endregion
    }
}
