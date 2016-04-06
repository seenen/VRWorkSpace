using System;
using System.Text;

namespace VRClient
{
    class EditorMessageDecoder
    {
        public static object DecodeMessage(string text)
        {
            //byte[] buffer = Convert.FromBase64String(text);
            //string json = Encoding.UTF8.GetString(buffer);

            //object obj = JsonFx.Json.JsonReader.Deserialize(json);

            object obj = JsonFx.Json.JsonReader.Deserialize(text);
            return obj;
        }


        public static T DecodeMessage<T>(string text)
        {
            //byte[] buffer = Convert.FromBase64String(text);
            //string json = Encoding.UTF8.GetString(buffer);

            //object obj = JsonFx.Json.JsonReader.Deserialize(json);
            T t = JsonFx.Json.JsonReader.Deserialize<T>(text);

            return t;
        }

        public static string EncodeMessage(object msg)
        {
            //string text = JsonFx.Json.JsonWriter.Serialize(msg);
            //string str = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));

            string str = JsonFx.Json.JsonWriter.Serialize(msg);
            return str;
        }
    }
}
