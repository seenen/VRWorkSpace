using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMM
{
    public class MMF
    {
        #region Generic MMF read/write object functions

        public static void WriteObjectToMMF(string mmfFile, object objectData)
        {
            string mapName = "MyFile";
            if (IsMono())
            {
                mapName = mmfFile;
            }
            // Convert .NET object to byte array
            byte[] buffer = ObjectToByteArray(objectData);
            using (FileStream fs = new FileStream(mmfFile, FileMode.Create, FileAccess.ReadWrite))
            {
                fs.SetLength(buffer.Length);
                // Create a new memory mapped file
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(fs, mapName, buffer.Length,
                    MemoryMappedFileAccess.ReadWrite, new MemoryMappedFileSecurity() { }, HandleInheritability.Inheritable, true))
                {
                    // Create a view accessor into the file to accommmodate binary data size
                    using (MemoryMappedViewAccessor mmfWriter = mmf.CreateViewAccessor(0, buffer.Length))
                    {
                        // Write the data
                        mmfWriter.WriteArray<byte>(0, buffer, 0, buffer.Length);
                    }
                }
            }
        }

        public static object ReadObjectFromMMF(string mmfFile)
        {
            string mapName = "MyFile";
            if (IsMono())
            {
                mapName = mmfFile;
            }
            using (FileStream fs = new FileStream(mmfFile, FileMode.Open, FileAccess.ReadWrite))
            {
                // Get a handle to an existing memory mapped file
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(fs, mapName, fs.Length,
                    MemoryMappedFileAccess.ReadWrite, new MemoryMappedFileSecurity() { }, HandleInheritability.Inheritable, true))
                {
                    // Create a view accessor from which to read the data
                    using (MemoryMappedViewAccessor mmfReader = mmf.CreateViewAccessor())
                    {
                        // Create a data buffer and read entire MMF view into buffer
                        byte[] buffer = new byte[mmfReader.Capacity];
                        mmfReader.ReadArray<byte>(0, buffer, 0, buffer.Length);

                        // Convert the buffer to a .NET object
                        return ByteArrayToObject(buffer);
                    }
                }
            }
        }

        static bool IsMono()
        {
            Type t = Type.GetType("Mono.Runtime");
            return t != null;
        }

        #endregion

        #region Object/Binary serialization

        static object ByteArrayToObject(byte[] buffer)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();    // Create new BinaryFormatter
            MemoryStream memoryStream = new MemoryStream(buffer);       // Convert byte array to memory stream, set position to start
            return binaryFormatter.Deserialize(memoryStream);           // Deserializes memory stream into an object and return
        }

        static byte[] ObjectToByteArray(object inputObject)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();    // Create new BinaryFormatter
            MemoryStream memoryStream = new MemoryStream();             // Create target memory stream
            binaryFormatter.Serialize(memoryStream, inputObject);       // Convert object to memory stream
            return memoryStream.ToArray();                              // Return memory stream as byte array
        }

        #endregion

        static HikingDatabase BuildDatabase(int recordCount, int gpsCoordCount)
        {
            Random rand = new Random();

            HikingDatabase hikingData = new HikingDatabase();
            hikingData.Description = "My hikes, 2010 to 2012";
            hikingData.hikes = new Hike[recordCount];
            for (int i = 0; i < hikingData.hikes.Length; i++)
            {
                hikingData.hikes[i] = new Hike();
                hikingData.hikes[i].Description = "This is a description of this particular record. ";
                hikingData.hikes[i].Date = DateTime.Now.ToLongDateString();
                hikingData.hikes[i].GPSTrack = new Coord[gpsCoordCount];
                for (int j = 0; j < hikingData.hikes[i].GPSTrack.Length; j++)
                {
                    hikingData.hikes[i].GPSTrack[j] = new Coord();
                    hikingData.hikes[i].GPSTrack[j].x = rand.NextDouble() * 1000000;
                    hikingData.hikes[i].GPSTrack[j].y = rand.NextDouble() * 1000000;
                    hikingData.hikes[i].GPSTrack[j].z = rand.NextDouble() * 1000;
                }
            }
            return hikingData;
        }
    }

    #region Sample object for I/O

    [Serializable]
    public class HikingDatabase
    {
        public string Description;
        public Hike[] hikes;
    }

    [Serializable]
    public class Hike
    {
        public string Description;
        public string Date;
        public Coord[] GPSTrack;
    }

    [Serializable]
    public class Coord
    {
        public double x;
        public double y;
        public double z;
    }
    #endregion
}
