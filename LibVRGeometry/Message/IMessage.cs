using LibVRGeometry.Message;

namespace LibVRGeometry
{
    public interface IMessage : IMessage_C2U, IMessage_U2C
    {

    }

    /// <summary>
    /// Winform发送到U3D
    /// </summary>
    public interface IMessage_C2U
    {
        #region 变形
        void OnVBOBuffer(VBOBuffer buffer);

        void OnVBOBufferSingle(VBOBufferSingle buffer);
        #endregion 变形

        #region 场景和单位
        void OnEditorMessage(EditorMessage buffer);

        void OnMDTitaniumClamp(HDTitaniumClampMessage o);

        void OnMDScissors(HDScissorsMessage o);

        void OnMDRobotArm(HDRobotArmMessage o);

        void OnSceneMessage(SceneMessage o);
        #endregion 场景和单位

        #region 配置
        void OnEnvCfg(EnvCfg o);
        #endregion
    }

    /// <summary>
    /// U3D发到Winform的消息 用于接收碰撞等引擎内消息
    /// </summary>
    public interface IMessage_U2C
    {
        #region 器材和器官的碰撞
        /// <summary>
        /// 器材和器官的碰撞
        /// </summary>
        /// <param name="o"></param>
        void OnMD2HO(IM_MD2HO o);
        #endregion
    }
}
