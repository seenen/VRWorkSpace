using LibVRGeometry;
using LibVRGeometry.VRWorld;
using System;

namespace VRClient.Test
{
    public class Test
    {
        Ins ins = new Ins();

        public Test()
        {
            VRAPI.AddMessage(ins);
        }
    }

    public class Ins : IMessage_U2C
    {
        public void OnMD2HO(IM_MD2HO o)
        {
            //  这里记录器官和器材交互的消息

            //  从OnWorldCreate里的回调信息去找对应的数据
        }

        public void OnAddMessage(HDScissorsMessage sm, HDTitaniumClampMessage tc)
        {
            //  这里记录创建世界后的消息回调
        }
    }
}
