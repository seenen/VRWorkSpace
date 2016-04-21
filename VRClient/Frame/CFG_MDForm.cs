using LibVRGeometry.Message;
using System.Windows.Forms;

namespace VRClient
{
    public partial class CFG_MDForm : Form
    {
        public CFG_MDForm()
        {
            InitializeComponent();
        }

        UM_MDScissors mS;
        UM_MDTitaniumClamp mTC;

        public void InitScissors(ref UM_MDScissors s)
        {
            mS = s;
            textBox1.Text = s.move_speed.ToString();
            textBox2.Text = s.rotate_speed.ToString();
            textBox3.Text = s.open_degree.ToString();
            textBox4.Text = s.merge_speed.ToString();
            textBox5.Text = s.id.ToString();
        }

        public void InitTitaniumClamp(ref UM_MDTitaniumClamp s)
        {
            mTC = s;
            textBox1.Text = s.move_speed.ToString();
            textBox2.Text = s.rotate_speed.ToString();
            textBox3.Text = s.open_degree.ToString();
            textBox4.Text = s.merge_speed.ToString();
            textBox5.Text = s.id.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (mS != null)
                ((Form1)Owner).UpdateScissors();
            if (mTC != null)
                ((Form1)Owner).UpdateTitaniumClamp();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
