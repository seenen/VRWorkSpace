using LibVRGeometry.Message;

namespace LibVRGeometry
{
    public interface IMessage
    {
        void OnVBOBuffer(VBOBuffer buffer);

        void OnEditorMessage(EditorMessage buffer);

        void OnVBOBufferSingle(VBOBufferSingle buffer);
    }
}
