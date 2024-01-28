using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fusen
{
    public partial class Form1 : Form
    {
        //===========================================
        //　定数
        //===========================================
        private const int FormWidthDefault = 500;
        private const int FormHeightDefault = 500;

        //===========================================
        //　変数
        //===========================================
        Match match;
        private int mouseX;
        private int mouseY;

        private String settingString;
        private int settingFormWidth;
        private int settingFormHeight;

        //===========================================
        //　コンポーネント
        //===========================================
        public Form1()
        {
            // 初期化
            InitializeComponent();
            // データファイルを読み込む
            if (File.Exists(@"fusenData.txt"))
            {
                textFusenMemo.Text = File.ReadAllText(@"fusenData.txt");
            }
            // 設定ファイルを探す
            if (File.Exists(@"fusenSetting.txt"))
            {
                // 設定ファイルを読み込む
                settingString = File.ReadAllText(@"fusenSetting.txt");
                // 各項目を抜き出す
                settingFormWidth = ReadSettingValue(settingString, "width", FormWidthDefault);
                settingFormHeight = ReadSettingValue(settingString, "height", FormHeightDefault);
            }
            // 設定ファイルがないときはデフォルトサイズを使用する
            else
            {
                settingFormWidth = FormWidthDefault;
                settingFormHeight = FormHeightDefault;
            }
            // 設定を反映する
            this.Size = new System.Drawing.Size(settingFormWidth, settingFormHeight);
        }

        //===========================================
        //　イベント
        //===========================================
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // テキストファイルに保存して終了
                File.WriteAllText(@"fusenData.txt", textFusenMemo.Text);
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
            else // 右クリックされた場合
            if (e.Button == MouseButtons.Right)
            {
                // 新しいフォームを作成
                Form resizeForm = new Form();
                resizeForm.TopMost = true;
                resizeForm.Text = "設定";
                resizeForm.Size = new System.Drawing.Size(300, 300);

                // ラベルとテキストボックス
                Label widthLabel = new Label();
                widthLabel.Text = "幅:";
                widthLabel.Height = 30;
                widthLabel.Width = 80;
                widthLabel.Location = new System.Drawing.Point(20, 20);
                resizeForm.Controls.Add(widthLabel);

                TextBox widthTextBox = new TextBox();
                widthTextBox.Location = new System.Drawing.Point(100, 20);
                widthTextBox.Text = this.Width.ToString();
                widthTextBox.TextAlign = HorizontalAlignment.Right;
                widthTextBox.SelectionStart = widthTextBox.Text.Length;
                resizeForm.Controls.Add(widthTextBox);

                Label heightLabel = new Label();
                heightLabel.Text = "高さ:";
                heightLabel.Height = 30;
                heightLabel.Width = 80;
                heightLabel.Location = new System.Drawing.Point(20, 70);
                resizeForm.Controls.Add(heightLabel);

                TextBox heightTextBox = new TextBox();
                heightTextBox.Location = new System.Drawing.Point(100, 70);
                heightTextBox.Text = this.Height.ToString();
                heightTextBox.TextAlign = HorizontalAlignment.Right;
                heightTextBox.SelectionStart = heightLabel.Text.Length;
                resizeForm.Controls.Add(heightTextBox);

                // OKボタン
                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Height = 50;
                okButton.Width = 100;
                // ボタンの幅と高さを取得
                int buttonWidth = okButton.Width;
                int buttonHeight = okButton.Height;
                // フォームの幅と高さを取得
                int formWidth = resizeForm.ClientSize.Width;
                int formHeight = resizeForm.ClientSize.Height;
                // タイトルバーの高さを取得
                int titleBarHeight = SystemInformation.CaptionHeight;
                // ボタンの位置を計算して設定
                okButton.Location = new System.Drawing.Point((formWidth - buttonWidth) / 2, formHeight - titleBarHeight - (buttonHeight / 2));
                // ボタン押下時の処理
                okButton.Click += (s, ev) =>
                {
                    int width, height;
                    string settingString = "";
                    if (int.TryParse(widthTextBox.Text, out width) && int.TryParse(heightTextBox.Text, out height))
                    {
                        this.Size = new System.Drawing.Size(width, height);
                        settingFormWidth = width;
                        settingFormHeight = height;
                    }
                    // 設定ファイルの更新
                    settingString += "<width>" + settingFormWidth.ToString() + "</width>";
                    settingString += "<height>" + settingFormHeight.ToString() + "</height>";
                    File.WriteAllText(@"fusenSetting.txt", settingString);
                    resizeForm.Close();
                };
                resizeForm.Controls.Add(okButton);

                // フォームを表示
                resizeForm.ShowDialog();
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

        //===========================================
        //　内部関数
        //===========================================
        //===========================================================================
        //　設定ファイルから各項目を抜き出す関数
        //===========================================================================
        private int ReadSettingValue(string settingString, string item, int defaultValue)
        {
            int result;

            // 正規表現パターンでタグの値を検索
            string targetString = "<" + item + ">(.*?)</" + item + ">";
            match = Regex.Match(settingString, @targetString);
            // タグが見つかった場合は値を取得
            if (match.Success)
            {
                string value = match.Groups[1].Value;
                if (int.TryParse(value, out result) != true)
                {
                    result = defaultValue; // int型への変換に失敗した場合はデフォルト値を使う
                }
            }
            // タグが見つからなかった場合はデフォルト値を使う
            else
            {
                result = defaultValue;
            }
            return result;
        }
    }
}
