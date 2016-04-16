using System.IO;
using System.Text;

namespace LibVRGeometry
{
    /// <summary>
    /// Obj文件的操作类
    /// </summary>
    public sealed class VBOBufferSingleFile
    {
        /// <summary>
        /// 把对象m输出到文件filename
        /// </summary>
        /// <param name="m"></param>
        /// <param name="filename"></param>
        public static void Output(VBOBufferSingle m, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(VBOBufferSingleToString(m));
            }
        }

        /// <summary>
        /// 把对象m转成obj格式的文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string VBOBufferSingleToString(VBOBufferSingle m)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("# {0} vertex {1} face\n", m.vertices.Count, m.faces.Count / 3));
            sb.Append("g ").Append(m.name).Append("\n");
            foreach (_Vector3 v in m.vertices)
            {
                sb.Append(string.Format("v {0} {1} {2}\n", v.X, v.Y, v.Z));
            }
            foreach (_Vector3 v in m.normals)
            {
                sb.Append(string.Format("vn {0} {1} {2}\n", v.X, v.Y, v.Z));
            }
            foreach (_Vector2 v in m.uvs)
            {
                sb.Append(string.Format("vt {0} {1}\n", v.X, v.Y));
            }
            for (int i = 0; i < m.faces.Count; i += 3)
            {
                string face_i = string.Format("{0}{1}{2}", IndiceV2(m.faces[i].vi + 1),    IndiceUorN2(m.faces[i].vu),     IndiceUorN2(m.faces[i].vn));
                string face_u = string.Format("{0}{1}{2}", IndiceV2(m.faces[i + 1].vi + 1),IndiceUorN2(m.faces[i + 1].vu), IndiceUorN2(m.faces[i + 1].vn));
                string face_n = string.Format("{0}{1}{2}", IndiceV2(m.faces[i + 2].vi + 1),IndiceUorN2(m.faces[i + 2].vu), IndiceUorN2(m.faces[i + 2].vn));
                string face = string.Format("f {0} {1} {2}\n", face_i, face_u, face_n);
                sb.Append(face);
            }
            //for (int material = 0; material < m.subMeshCount; material++)
            //{
            //    sb.Append("\n");
            //    sb.Append("usemtl ").Append(mats[material].name).Append("\n");
            //    sb.Append("usemap ").Append(mats[material].name).Append("\n");

            //int[] triangles = m.GetTriangles(material);
            //for (int i = 0; i < triangles.Length; i += 3)
            //{
            //    sb.Append(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n",
            //        triangles[i] + 1, triangles[i + 1] + 1, triangles[i + 2] + 1));
            //}
            //}
            return sb.ToString();
        }

        static string IndiceV2(int index)
        {
            if (index == 0)
            {
                return "";
            }

            return index.ToString();
        }

        static string IndiceUorN2(int index)
        {
            if (index == 0)
            {
                return "";
            }

            return "/" + index.ToString();
        }
    }

}
