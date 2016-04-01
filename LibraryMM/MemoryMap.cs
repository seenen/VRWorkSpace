using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;

namespace LibraryMM
{
    public class MemoryMap
    {
        public MemoryMap()
        {
        }

        //#region 持久内存映射文件:基于现有文件创建一个具有指定公用名的内存映射文件
        ///// <summary>
        ///// 持久映射
        ///// </summary>
        //public void CreatePersistentMappedFile(string filepath, string mapped_name)
        //{
        //    //using (mMemoryMappedFile = MemoryMappedFile.CreateFromFile(@"c:\内存映射文件.data", FileMode.Open, "公用名"))
        //    using (mMemoryMappedFile = MemoryMappedFile.CreateFromFile(filepath, FileMode.Open, mapped_name))
        //    {
        //        //通过指定的 偏移量和大小 创建内存映射文件视图服务器
        //        using (var accessor = mMemoryMappedFile.CreateViewAccessor(offset, length)) //偏移量，可以控制数据存储的内存位置；大小，用来控制存储所占用的空间
        //        {
        //            //Marshal提供了一个方法集，这些方法用于分配非托管内存、复制非托管内存块、将托管类型转换为非托管类型，此外还提供了在与非托管代码交互时使用的其他杂项方法。

        //            int size = Marshal.SizeOf(typeof(char));

        //            //修改内存映射文件视图
        //            for (long i = 0; i < length; i += size)
        //            {
        //                char c = accessor.ReadChar(i);
        //                accessor.Write(i, ref c);
        //            }
        //        }
        //    }
        //}

        //public void OpenPersistentMappedFile()
        //{
        //    //另一个进程或线程可以，在系统内存中打开一个具有指定名称的现有内存映射文件
        //    using (var mmf = MemoryMappedFile.OpenExisting("公用名"))
        //    {
        //        using (var accessor = mmf.CreateViewAccessor(4000000, 2000000))
        //        {
        //            int size = Marshal.SizeOf(typeof(char));
        //            for (long i = 0; i < length; i += size)
        //            {
        //                char c = accessor.ReadChar(i);
        //                accessor.Write(i, ref c);
        //            }
        //        }
        //    }
        //}
        //#endregion

        #region 非持久内存映射文件：未映射到磁盘上的现有文件的内存映射文件

        /// <summary>
        /// 创建一个非持久化数据的写接口
        /// </summary>
        /// <param name="mapped_name">内存名</param>
        /// <param name="mapped_capacity">默认 1M 大小</param>
        public ComOperate CreateNonPersistentMappedFile(string mapped_name, string mutexName, long mapped_capacity = 1024 * 1024)
        {
            MmfInfo info = new MmfInfo();
            info.mMappedName = mapped_name;
            info.mMappedCapacity = mapped_capacity;
            info.mMutexName = mutexName;

            using (info.mmf = MemoryMappedFile.CreateNew(mapped_name, mapped_capacity))
            {
                Console.WriteLine("启动 创建接口 状态服务");

                ComOperate mComOperate = new ComOperate(info);

                return mComOperate;
            }
        }

        //public ComOperate OpenNonPersistentMappedFile(ComOperate co)
        //{
        //    mutex.WaitOne();
        //    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
        //    {
        //        var reader = new BinaryReader(stream);
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Console.WriteLine("{1}位置:{0}", reader.ReadInt32(), i);
        //        }
        //    }

        //    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor(1024, 10240))
        //    {
        //        int colorSize = Marshal.SizeOf(typeof(ServiceMsg));
        //        ServiceMsg color;
        //        for (int i = 0; i < 50; i += colorSize)
        //        {
        //            accessor.Read(i, out color);
        //            Console.WriteLine("{1}\tNowTime:{0}", new DateTime(color.NowTime), color.Id);
        //        }
        //    }
        //    mutex.ReleaseMutex();


        //    return co;
        //}

        /// <summary>
        /// 打开一个非持久化数据的写接口
        /// </summary>
        /// <param name="mapped_name">内存名</param>
        public ReadOperate OpenNonPersistentMappedFile(  string existed_mapped_name, 
                                                        string existed_mutexName)
        {
            if (string.IsNullOrEmpty(existed_mapped_name) ||
                string.IsNullOrEmpty(existed_mutexName))
            {
                throw new FormatException("Param is Empty 0: " + existed_mapped_name + " 1: " + existed_mutexName);
            }

            MmfInfo info = new MmfInfo();
            info.mMappedName = existed_mapped_name;
            info.mMappedCapacity = -1;
            info.mMutexName = existed_mutexName;

            using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(    existed_mapped_name, 
                                                                            MemoryMappedFileRights.Read))
            {
                Console.WriteLine("启动 打开接口 状态服务");

                ReadOperate mComOperate = new ReadOperate(info);

                return mComOperate;
            }
        }

        #endregion
    }
}
