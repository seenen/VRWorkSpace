using System.Collections.Generic;

namespace LibVRGeometry
{
    public class _PointAttachmentInfo : System.IDisposable
    {

        public _PointAttachmentInfo()
        {
            VertexAdjacencyList = null;
            TriangleAdjacencyList = null;
        }

        public void Dispose()
        {
            ClearVertexAdj();
            ClearTriangleAdj();
        }

        public void ClearVertexAdj()
        {

            if (VertexAdjacencyList != null)
            {
                VertexAdjacencyList.Clear();
                VertexAdjacencyList = null;
            }
        }

        public void ClearTriangleAdj()
        {
            if (TriangleAdjacencyList != null)
            {
                TriangleAdjacencyList.Clear();
                VertexAdjacencyList = null;
            }
        }

        public List<long> VertexAdjacencyList;

        public List<long> TriangleAdjacencyList;
    }
}
