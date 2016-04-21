using System;
using LibVRGeometry;
using LibVRGeometry.Message;

namespace VRClient
{
    public class MessageInstance : IMessage
    {
        public void OnMD2HO(IM_MD2HO o)
        {
            throw new NotImplementedException();
        }

        public void OnMDScissors(UM_MDScissors o)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnEditorMessage(EditorMessage buffer)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnMDTitaniumClamp(UM_MDTitaniumClamp o)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnSceneMessage(SceneMessage o)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnVBOBuffer(VBOBuffer buffer)
        {
            throw new NotImplementedException();
        }

        void IMessage.OnVBOBufferSingle(VBOBufferSingle buffer)
        {
            throw new NotImplementedException();
        }
    }
}
