using System;
using System.IO;

namespace Fusen
{
    public partial class Form1 : Form
    {
        private int mouseX;
        private int mouseY;

        public Form1()
        {
            // 初期化
            InitializeComponent();
            // 最初に保存ファイルを読み込む
            if (File.Exists(@"fusen.txt"))
            {
                textFusenMemo.Text = File.ReadAllText(@"fusen.txt");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // テキストファイルに保存して終了
                File.WriteAllText(@"fusen.txt", textFusenMemo.Text);
                this.Close();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                this.Left += e.X - mouseX;
                this.Top += e.Y - mouseY;
            }
        }
    }
}
