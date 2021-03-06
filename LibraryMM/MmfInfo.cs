﻿using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMM
{
    public enum COErrorCode
    {
        //  没有错误
        No_Error,
        //  初始化写失败
        Init_Write_Error,
        //  
        Init_Reader_Error,
    }

    public enum COStatusCode
    {
        None,
        //  已创建
        Created,
    }

    /// <summary>
    /// 内存的一些相关信息
    /// </summary>
    public class MmfInfo
    {
        public string mMappedName = string.Empty;

        //  默认1M
        public long mMappedCapacity = 1024 * 1024;

        public string mMutexName = string.Empty;

        public COStatusCode stateCode = COStatusCode.None;

        public COErrorCode errorCode = COErrorCode.No_Error;

        public MemoryMappedFile mmf;

        //  是否是持久化内存读写
        public bool IsPersistent = false;

        public string PersistentFilePath = string.Empty;
    }

    /// <summary>
    /// 数据信息
    /// </summary>
    public struct Msg
    {
        public int Id;

        public long NowTime;
    }

}
