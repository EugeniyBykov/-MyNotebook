using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form2 : Form
    {
        Form1 f1;
        bool flag;
        int index;
        string f1TBText;
        int q;

        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;
            flag = false;
            f1TBText = null;
            q = 0; 

            textBox1.TextChanged += (s, e) =>
            {
                f1._find = textBox1.Text;
                if (!(String.IsNullOrEmpty(textBox1.Text)))               
                    button1.Enabled = true;
                
                else
                    button1.Enabled = false;
            };
        }

        public TextBox TexBoxTextForm2 { get { return textBox1; } set { textBox1 = value; } }

        private void button1_Click(object sender, EventArgs e)
        {
            B1ClickFunc(); 
        }

        public void B1ClickFunc()
        {
            if (!(String.IsNullOrEmpty(textBox1.Text)))
            {

                if (radioButton1.Checked)
                {
                    index = -1;
                    int start = f1.TexBoxText.SelectionStart;
                    if (String.IsNullOrEmpty(f1TBText))
                        f1TBText = f1.TexBoxText.Text.Substring(0, start);

                    start = 0;
                    if (flag == true)
                    {
                        start = q;
                    }

                    if (checkBox1.Checked)
                    {
                        index = f1TBText.IndexOf(textBox1.Text, start);
                    }
                    else
                    {
                        string s1 = f1TBText.ToLower();
                        string s2 = textBox1.Text.ToLower();

                        index = s1.IndexOf(s2, start);
                    }

                    if (index != -1)
                    {
                        f1.TexBoxText.SelectionStart = index;
                        f1.TexBoxText.SelectionLength = textBox1.Text.Length;
                        f1.TexBoxText.Focus();
                        flag = true;
                        q = index + 1;

                    }
                    else
                        MessageBox.Show($"Не удается найти {textBox1.Text}");
                }

                if (radioButton2.Checked)
                {
                    index = -1;
                    int start = f1.TexBoxText.SelectionStart;
                    if (flag == true)
                        start += 1;

                    if (checkBox1.Checked)
                        index = f1.TexBoxText.Text.IndexOf(textBox1.Text, start);
                    else
                    {
                        string s1 = f1.TexBoxText.Text.ToLower();
                        string s2 = textBox1.Text.ToLower();

                        index = s1.IndexOf(s2, start);
                    }

                    if (index != -1)
                    {
                        f1.TexBoxText.SelectionStart = index;
                        f1.TexBoxText.SelectionLength = textBox1.Text.Length;
                        f1.TexBoxText.Focus();
                        flag = true;

                    }
                    else
                        MessageBox.Show($"Не удается найти {textBox1.Text}");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
