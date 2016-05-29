using System;
using ProtoBuf;
using System.IO;
using LibVRGeometry.Message;

namespace LibVRGeometry
{
    public class MessageDecoder
    {
        #region Json序列化和反序列化
        public static object DecodeMessage(string text)
        {
            object obj = JsonFx.Json.JsonReader.Deserialize(text);
            return obj;
        }


        public static T DecodeMessage<T>(string text)
        {
            T t = JsonFx.Json.JsonReader.Deserialize<T>(text);

            return t;
        }

        public static string EncodeMessage(object msg)
        {
            string str = JsonFx.Json.JsonWriter.Serialize(msg);

            return str;
        }
        #endregion Json的序列化和反序列化

        #region Protobuf序列化和反序列化

        static int HEAD_LEN = 128;

        public static string EncodeMessageByProtobuf<T>(T msg)
        {
            byte[] bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                //  数据类型对象
                Serializer.Serialize<T>(ms, msg); //ms流对象，instance转换成byte数组会存储在ms里面。《序列化》  
                bytes = new byte[ms.Position]; //为bytes实例化一个长度（传递过来的类型转换成（byte）数组之后的长度）ms.position(ms流对象的长度）  
                var fullBytes = ms.GetBuffer(); //获取储存在内存流里面的字节数据  
                Array.Copy(fullBytes, bytes, bytes.Length); //将保存在 fullBytes内存流里的数据拷贝到bytes里。  
                bytes = CompressionHelper.Compress(bytes);

                //  加一个类型的头
                byte[] tbytes = System.Text.Encoding.UTF8.GetBytes(typeof(T).ToString());
                byte[] headbytes = new byte[HEAD_LEN];
                Array.Copy(tbytes, headbytes, tbytes.Length);

                //  合并2个buff
                var all = new byte[bytes.Length + headbytes.Length];
                Buffer.BlockCopy(headbytes, 0, all, 0, headbytes.Length);
                Buffer.BlockCopy(bytes, 0, all, headbytes.Length * sizeof(byte), bytes.Length);

                //
                string json = Convert.ToBase64String(all);
                ms.Close();
                ms.Dispose();

                return json;
            }
        }

        public static T DecodeMessageByProtobuf<T>(string text)
        {
            byte[] all = Convert.FromBase64String(text);

            //  拆分
            byte[] headbytes = new byte[HEAD_LEN];
            Buffer.BlockCopy(all, 0, headbytes, 0, headbytes.Length);
            string str = System.Text.Encoding.UTF8.GetString(headbytes);

            byte[] bytes = new byte[all.Length - HEAD_LEN];
            Buffer.BlockCopy(all, HEAD_LEN, bytes, 0, bytes.Length);

            bytes = CompressionHelper.DeCompress(bytes);

            using (var ms = new MemoryStream(bytes)) //(声明一个内存流对象)  
            {
                return Serializer.Deserialize<T>(ms); //《反序列化》  
            }
        }

        public static void DecodeMessageWithHeader(string text, IMessage callback)
        {
            if (callback == null)
            {
                throw new Exception("callback == null");
            }

            byte[] all = Convert.FromBase64String(text);

            //  拆分
            byte[] headbytes = new byte[HEAD_LEN];
            Buffer.BlockCopy(all, 0, headbytes, 0, headbytes.Length);
            string str = System.Text.Encoding.UTF8.GetString(headbytes);

            byte[] bytes = new byte[all.Length - HEAD_LEN];
            Buffer.BlockCopy(all, HEAD_LEN, bytes, 0, bytes.Length);

            bytes = CompressionHelper.DeCompress(bytes);

            using (var ms = new MemoryStream(bytes)) //(声明一个内存流对象)  
            {
                #region 变形
                if (str.Contains(typeof(VBOBufferSingle).ToString()))
                    callback.OnVBOBufferSingle(Serializer.Deserialize<VBOBufferSingle>(ms));

                else if (str.Contains(typeof(VBOBuffer).ToString()))
                    callback.OnVBOBuffer(Serializer.Deserialize<VBOBuffer>(ms));

                #endregion 变形

                #region 场景和单位
                else if (str.Contains(typeof(EditorMessage).ToString()))
                    callback.OnEditorMessage(Serializer.Deserialize<EditorMessage>(ms));

                else if (str.Contains(typeof(HDTitaniumClampMessage).ToString()))
                    callback.OnMDTitaniumClamp(Serializer.Deserialize<HDTitaniumClampMessage>(ms));

                else if (str.Contains(typeof(HDScissorsMessage).ToString()))
                    callback.OnMDScissors(Serializer.Deserialize<HDScissorsMessage>(ms));

                else if (str.Contains(typeof(SceneMessage).ToString()))
                    callback.OnSceneMessage(Serializer.Deserialize<SceneMessage>(ms));

                #endregion 场景和单位

                #region U3D发到Winform

                else if (str.Contains(typeof(IM_MD2HO).ToString()))
                    callback.OnMD2HO(Serializer.Deserialize<IM_MD2HO>(ms));
                #endregion
                else
                    throw new Exception("No Paired Object [head:]" + str + " []");
            }
        }
        #endregion Protobuf的序列化和反序列化

        #region Base64
        /// <summary>
        /// 转换成Base64的字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertToBase64(string text)
        {
            byte[] tbytes = System.Text.Encoding.UTF8.GetBytes(text);

            string json = Convert.ToBase64String(tbytes);

            return json;
        }

        /// <summary>
        /// 还原Base64字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertFromBase64(string text)
        {
            byte[] all = Convert.FromBase64String(text);

            string str = System.Text.Encoding.UTF8.GetString(all);

            return str;
        }

        /// <summary>
        /// 还原Base64字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetHeaderFromBase64(string text)
        {
            byte[] all = Convert.FromBase64String(text);

            //  拆分
            byte[] headbytes = new byte[HEAD_LEN];
            Buffer.BlockCopy(all, 0, headbytes, 0, headbytes.Length);
            string str = System.Text.Encoding.UTF8.GetString(headbytes);

            return str;
        }
        #endregion
    }
}
