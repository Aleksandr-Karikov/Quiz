using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz.Forms
{
    public partial class EditForm : Form
    {
        private string Path { get; set; }
        public EditForm(string path)
        {
            InitializeComponent();
            Path = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Поля не заполнены");
                return;
            }
            if (!int.TryParse(textBox5.Text,out var temp))
            {
                MessageBox.Show("Номер правильного ответа введен не верно");
                return;
            }
            if (temp>4 || temp <=0)
            {
                MessageBox.Show("Номер правильного ответа введен не верно");
                return;
            }
            var list = new List<string>()
            {
                richTextBox1.Text,
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
            };
            FileHelper.CreateQustion(new QuestionModel()
            {
                 Answer = list[temp],
                 Question = list[0],
                 Variant1 = list[1],
                 Variant2 = list[2],
                 Variant3 = list[3],
                 Variant4 = list[4]
            }, Path
            );
            richTextBox1.Text = String.Empty;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form1 = Application.OpenForms["Form1"];
            ((Form1)form1).UpdateComboBox();
        }
    }
}
