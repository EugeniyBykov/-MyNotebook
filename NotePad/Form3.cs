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
    public partial class Form3 : Form
    {
        int index;
        bool flag;
        Form1 f1; 

        public Form3(Form1 f)
        {
            InitializeComponent();
            index = -1;
            flag = false;
            f1 = f;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

            if (! (String.IsNullOrEmpty(f1.TexBoxText.SelectedText)))
            f1.TexBoxText.SelectedText = textBox2.Text; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
                f1.TexBoxText.Text = f1.TexBoxText.Text.Replace(textBox1.Text, textBox2.Text);     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
