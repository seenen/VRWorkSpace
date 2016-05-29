using LibVRGeometry;
using System.Windows.Forms;

namespace VRClient
{
    public partial class CFG_MDForm : Form
    {
        public CFG_MDForm()
        {
            InitializeComponent();
        }

        HDScissorsMessage mS;
        HDTitaniumClampMessage mTC;

        public void InitScissors(ref HDScissorsMessage s)
        {
            mS = s;
            textBox1.Text = s.move_speed.ToString();
            textBox2.Text = s.rotate_speed.ToString();
            textBox3.Text = s.merge_degree.ToString();
            textBox4.Text = s.merge_speed.ToString();
            textBox5.Text = s.id.ToString();
        }

        public void InitTitaniumClamp(ref HDTitaniumClampMessage s)
        {
            mTC = s;
            textBox1.Text = s.move_speed.ToString();
            textBox2.Text = s.rotate_speed.ToString();
            textBox3.Text = s.merge_degree.ToString();
            textBox4.Text = s.merge_speed.ToString();
            textBox5.Text = s.id.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (mS != null)
            {
                mS.move_speed       = float.Parse(textBox1.Text);
                mS.rotate_speed     = float.Parse(textBox2.Text);
                mS.merge_degree     = float.Parse(textBox3.Text);
                mS.merge_speed      = float.Parse(textBox4.Text);
                ((Form1)Owner).UpdateScissors(mS);
            }
            if (mTC != null)
            {
                mTC.move_speed       = float.Parse(textBox1.Text);
                mTC.rotate_speed     = float.Parse(textBox2.Text);
                mTC.merge_degree     = float.Parse(textBox3.Text);
                mTC.merge_speed      = float.Parse(textBox4.Text);
                ((Form1)Owner).UpdateTitaniumClamp(mTC);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
