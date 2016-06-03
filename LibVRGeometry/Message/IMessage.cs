﻿using LibVRGeometry.Message;

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

        void OnMDTitaniumClamp(HDTitaniumClampMessage o);

        void OnMDScissors(HDScissorsMessage o);

        void OnMDRobotArm(HDRobotArmMessage o);

        void OnSceneMessage(SceneMessage o);
        #endregion 场景和单位

        #region U3D发到Winform
        void OnMD2HO(IM_MD2HO o);
        #endregion
    }
}
