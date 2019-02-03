using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        bool _textChanged;
        bool wrap; 
        string path = @"C:\";
        string _fileName;
        string _fullFileName;
        Form2 f2;
        Form3 f3;
        public string _find; 

      
        public Form1()
        {
            InitializeComponent();
            _textChanged = true;
            _fileName = "Безымянный";
            _find = null;
            wrap = false; 

            textBox1.TextChanged += (s, e) => { _textChanged = false;
                отменитьToolStripMenuItem.Enabled = true;         
            };
          
            this.Closing += new CancelEventHandler(this.Form1_Closing);
           
        }
        public TextBox TexBoxText { get { return textBox1; }  set { textBox1 = value; } }
  
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            //fd.ShowColor = true;
            if (fd.ShowDialog() == DialogResult.OK)
                textBox1.Font = fd.Font;
            //  textBox1.ForeColor = fd.Color;        
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_textChanged == false)
            {
                string tmp = $"Вы хотите сохранить изменения в файле {_fileName}?";
                DialogResult dr = MessageBox.Show(tmp, _fileName, MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes)
                {
                    var save = new SaveFileDialog();
                    save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        using (var write = new StreamWriter(save.FileName, false, Encoding.GetEncoding(1251)))
                        {
                            write.Write(textBox1.Text);
                        }

                    }
                    textBox1.Text = "";
           
                }
                if (dr == DialogResult.No)
                {
                    textBox1.Text = "";
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_textChanged == true)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = path;
                open.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader read = new StreamReader(open.FileName, Encoding.GetEncoding(1251));
                    textBox1.Text = read.ReadToEnd();
                    _fileName = Path.GetFileNameWithoutExtension(open.FileName);
                    _fullFileName = open.FileName.ToString();
                    read.Close();
                }
            }
            else
            {
                string tmp = $"Вы хотите сохранить изменения в файле {_fileName}?";
                DialogResult dr = MessageBox.Show(tmp, _fileName, MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes)
                {
                    var save = new SaveFileDialog();
                    save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        using (var write = new StreamWriter(save.FileName, false, Encoding.GetEncoding(1251)))
                        {
                            write.Write(textBox1.Text);
                        }

                    }
                }
                if (dr == DialogResult.No)
                {
                    OpenFileDialog open = new OpenFileDialog();
                    open.InitialDirectory = path;
                    open.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        StreamReader read = new StreamReader(open.FileName, Encoding.GetEncoding(1251));
                        textBox1.Text = read.ReadToEnd();
                        _fileName = Path.GetFileNameWithoutExtension(open.FileName);
                        read.Close();
                    }
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileName == "Безымянный")
            {
                var save = new SaveFileDialog();
                save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (var write = new StreamWriter(save.FileName, false, Encoding.GetEncoding(1251)))
                    {
                        write.Write(textBox1.Text);
                    }

                }
            }
            else
            {

                using (var write = new StreamWriter(_fullFileName, false, Encoding.GetEncoding(1251)))
                {
                    write.Write(textBox1.Text);
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (var write = new StreamWriter(save.FileName, false, Encoding.GetEncoding(1251)))
                {
                    write.Write(textBox1.Text);
                }

            }
        }

        private void параметрыСтраницыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция доступна в платной версии программы", "Печать", MessageBoxButtons.OK);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Closing(Object sender, CancelEventArgs e)
        {
            if (_textChanged == false)
            {
                string tmp = $"Вы хотите сохранить изменения в файле {_fileName}?";
                DialogResult dr = MessageBox.Show(tmp, _fileName, MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes)
                {
                    var save = new SaveFileDialog();
                    save.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        using (var write = new StreamWriter(save.FileName, false, Encoding.GetEncoding(1251)))
                        {
                            write.Write(textBox1.Text);
                        }
                    }

                    else
                        e.Cancel = true;
                }


                if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            textBox1.Undo(); 
        }      

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( ! (String.IsNullOrEmpty(textBox1.SelectedText)) )       
                textBox1.Cut(); 
            
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(textBox1.SelectedText)))
                textBox1.Copy();
            
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
                textBox1.Paste();          
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2 = new Form2(this);
            f2.Show(); 
        }

        private void найтиДалееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( ! (String.IsNullOrEmpty(_find)) )
            {
                f2 = new Form2(this);
                f2.TexBoxTextForm2.Text = _find;
                f2.B1ClickFunc(); 
            }
            else
            {
                f2 = new Form2(this);
                f2.Show();
            }
        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3(this);
            f3.Show();
        }

        private void перейтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция доступна в платной версии программы", "Печать", MessageBoxButtons.OK);
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
            textBox1.Focus();
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            d = DateTime.Now;
            textBox1.Text += d.ToLocalTime();  
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked == true)
                textBox1.WordWrap = true;

            else
                textBox1.WordWrap = false;
        }

        private void строкаСостоянияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция доступна в платной версии программы", "Печать", MessageBoxButtons.OK);
        }

        private void просмотретьСправкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Блокнот", "Справка");
        }

        private void оПрограмеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Блокнот", "О Программе"); 
        }
    }
     
}

