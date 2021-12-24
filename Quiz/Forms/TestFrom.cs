using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz.Forms
{
    public partial class TestFrom : Form
    {
        private int Score;
        private int MaxScrore;
        private int position = 0;
        private List<QuestionModel> Questions { get; set; }
        private string? CurentAnswer { get; set; }
        public TestFrom(List<QuestionModel> list)
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            Questions = list;
            MaxScrore = Questions.Count();
            SetFields();
        }
        
        private void SetFields()
        {

            var curent = Questions[position];
            richTextBox1.Text = curent.Question;
            radioButton1.Text = curent.Variant1;
            radioButton2.Text = curent.Variant2;
            radioButton3.Text = curent.Variant3;
            radioButton4.Text = curent.Variant4;
            
        }
        private void SetCurentAnswer()
        {
            List<RadioButton> radioButtons = new()
            {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4
            };
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    CurentAnswer = radioButton.Text;
                    return;
                }
                CurentAnswer = null;
            }    
        }
        private void answerButton_Click(object sender, EventArgs e)
        {
            SetCurentAnswer();
            if (string.IsNullOrEmpty(CurentAnswer))
            {
                MessageBox.Show("Ответ не выбран");
                return;
            }
            if (Questions[position].CheckAnswer(CurentAnswer))
            {
                Score++;
            }
            position++;
            if (position == MaxScrore)
            {
                MessageBox.Show($"Рузультат {Score}/{MaxScrore}");
                this.Close();
                return;
            }
            
            
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            SetFields();
        }
    }
}
