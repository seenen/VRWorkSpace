using LibVRGeometry.Message;

namespace LibVRGeometry
{
    /// <summary>
    /// 信息通知
    /// </summary>
    public interface IMessage
    {
        #region 变形
        void OnVBOBuffer(VBOBuffer buffer);

        void OnVBOBufferSingle(VBOBufferSingle buffer);
        #endregion 变形

        #region 场景和单位
        void OnEditorMessage(EditorMessage buffer);

        void OnMDTitaniumClamp(MDTitaniumClamp o);

        void OnSceneMessage(SceneMessage o);
        #endregion 场景和单位
    }
}
