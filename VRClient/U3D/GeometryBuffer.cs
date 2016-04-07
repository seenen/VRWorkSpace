#define zsn

using System.Collections.Generic;
using LibraryGeometryFormat;

namespace VRClient
{

    public class GeometryBuffer
    {
        //  物体
        public List<ObjectData> objects;
        //  顶点
        public List<_Vector3> vertices;
        //  UV
        public List<_Vector2> uvs;
        //  法线
        public List<_Vector3> normals;

        public List<int> triangles;

        //
        private ObjectData current;

        public GroupData curgr;

        public GeometryBuffer()
        {
            objects = new List<ObjectData>();
            ObjectData d = new ObjectData();
            d.name = "default";
            objects.Add(d);
            current = d;

            GroupData g = new GroupData();
            g.name = "default";
            d.groups.Add(g);
            curgr = g;

            vertices = new List<_Vector3>();
            uvs = new List<_Vector2>();
            normals = new List<_Vector3>();
        }

        public void PushObject(string name)
        {
            if (isEmpty) objects.Remove(current);

            ObjectData n = new ObjectData();
            n.name = name;
            objects.Add(n);

            GroupData g = new GroupData();
            g.name = "default";
            n.groups.Add(g);

            curgr = g;
            current = n;
        }

        public void PushGroup(string name)
        {
            if (curgr.isEmpty) current.groups.Remove(curgr);
            GroupData g = new GroupData();
            g.name = name;
            current.groups.Add(g);
            curgr = g;
        }

        public void PushMaterialName(string name)
        {
            //Debuger.Log("Pushing new material " + name + " with curgr.empty=" + curgr.isEmpty);
            if (!curgr.isEmpty) PushGroup(name);
            if (curgr.name == "default") curgr.name = name;
            curgr.materialName = name;
        }

        public void PushVertex(_Vector3 v)
        {
            vertices.Add(v);
        }

        public void PushUV(_Vector2 v)
        {
            uvs.Add(v);
        }

        public void PushNormal(_Vector3 v)
        {
            normals.Add(v);
        }

        public void PushFace(FaceIndices f)
        {
            curgr.faces.Add(f);
            current.allFaces.Add(f);
        }

        public int numObjects { get { return objects.Count; } }

        public bool isEmpty { get { return vertices.Count == 0; } }

        public bool hasUVs { get { return uvs.Count > 0; } }

        public bool hasNormals { get { return normals.Count > 0; } }

        public void PopulateMeshes()
        {
            for (int i = 0; i < numObjects; i++)
            {
                ObjectData od = objects[i];

                //if (od.name != "default") gs[i].name = od.name;

                _Vector3[] tvertices = new _Vector3[od.allFaces.Count];
                _Vector2[] tuvs = new _Vector2[od.allFaces.Count];
                _Vector3[] tnormals = new _Vector3[od.allFaces.Count];

                int k = 0;
                foreach (FaceIndices fi in od.allFaces)
                {
                    tvertices[k] = vertices[fi.vi];
                    if (hasUVs) tuvs[k] = uvs[fi.vu];
                    if (hasNormals) tnormals[k] = normals[fi.vn];
                    k++;
                }

                if (od.groups.Count == 1)
                {
                    GroupData gd = od.groups[0];

                    triangles = new List<int>();
                    triangles.Capacity = gd.faces.Count;
                    for (int j = 0; j < triangles.Count; j++) triangles[j] = j;

                    for (int j = 0; j < triangles.Count; j++)
                        triangles[j] = gd.faces[j].vi;

                }
                else
                {
                    int gl = od.groups.Count;
                    int c = 0;

                    for (int j = 0; j < gl; j++)
                    {
                        int[] triangles = new int[od.groups[j].faces.Count];
                        int l = od.groups[j].faces.Count + c;
                        int s = 0;
                        for (; c < l; c++, s++) triangles[s] = c;
                    }
                }
            }

            return;
        }
    }
}



























