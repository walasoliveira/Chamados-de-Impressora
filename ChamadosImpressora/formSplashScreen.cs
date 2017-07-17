using System.Windows.Forms;

namespace ChamadosImpressora
{
    public partial class formSplashScreen : Form
    {
        public formSplashScreen()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 3000;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Start();
            this.Close();
        }
    }
}
