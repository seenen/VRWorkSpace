using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 写操作
        private int writeIndex = 0;

        private void MemWriteInit_Click(object sender, EventArgs e)
        {

        }

        private void Write_Click(object sender, EventArgs e)
        {
            VRHostMain.coLocal.WriteString(writeIndex.ToString());

            writeIndex++;
        }
        #endregion

        #region 读操作
        private void MemReadInit_Click(object sender, EventArgs e)
        {

        }

        private void Read_Click(object sender, EventArgs e)
        {
            VRHostMain.coLocal.ReadString();
        }
        #endregion
    }
}
