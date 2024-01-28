namespace Fusen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textFusenMemo = new TextBox();
            colorDialogFusen = new ColorDialog();
            SuspendLayout();
            // 
            // textFusenMemo
            // 
            textFusenMemo.BackColor = Color.FromArgb(255, 255, 192);
            textFusenMemo.Dock = DockStyle.Fill;
            textFusenMemo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textFusenMemo.Location = new Point(0, 0);
            textFusenMemo.Multiline = true;
            textFusenMemo.Name = "textFusenMemo";
            textFusenMemo.Size = new Size(800, 450);
            textFusenMemo.TabIndex = 0;
            textFusenMemo.KeyDown += Form1_KeyDown;
            textFusenMemo.MouseDown += Form1_MouseDown;
            textFusenMemo.MouseMove += Form1_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textFusenMemo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Opacity = 0.6D;
            Text = "Form1";
            TopMost = true;
            KeyDown += Form1_KeyDown;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textFusenMemo;
        private ColorDialog colorDialogFusen;
    }
}
