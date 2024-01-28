namespace Fusen
{
    public partial class Form1 : Form
    {
        private int mouseX;
        private int mouseY;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mouseX;
                this.Top += e.Y - mouseY;
            }
        }
    }
}
