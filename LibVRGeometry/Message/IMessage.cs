using LibVRGeometry.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibVRGeometry
{
    public interface IMessage
    {
        void OnVBOBuffer(VBOBuffer buffer);

        void EditorMessage(EditorMessage buffer);
    }
}
