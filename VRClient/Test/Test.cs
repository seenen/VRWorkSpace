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
        }
    }
}
