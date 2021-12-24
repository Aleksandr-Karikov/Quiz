using Quiz.Forms;
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

namespace Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private readonly string TestsPath = System.IO.Directory.GetCurrentDirectory() + "../../../../" + "Tests";
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
        }
        public void UpdateComboBox()
        {
            if (Directory.Exists(TestsPath))
            {
                testsComboBox.Items.Clear();
                testsComboBox.SelectedIndex = -1;
                testsComboBox.ResetText();
                string[] fileEntries = Directory.GetFiles(TestsPath);
                foreach (string filePath in fileEntries)
                {
                    string fileName = Path.GetFileName(filePath);
                    testsComboBox.Items.Add(fileName.Remove(fileName.Length - 4));
                }
            }
        }
        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (testsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Тест не выбран");
                return;
            }
            var list = await FileHelper.GetQuestions(GetFilePath());
            if (list.Count == 0)
            {
                MessageBox.Show("Тест пустой");
                return;
            }
            new TestFrom(list).Show();
        }
        private string GetFilePath()
        {
            return TestsPath + "/" + testsComboBox.SelectedItem + ".txt";
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите название файла");
                return;
            }
            string newPath = TestsPath + "/" + textBox1.Text + ".txt";
            if (!File.Exists(newPath))
            {
                using (StreamWriter sw = File.CreateText(newPath)) { }
                new EditForm(newPath).Show();
            }
            else
            {
                MessageBox.Show("Такой тест уже существует");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Тест не выбран");
                return;
            }
            FileHelper.DeleteFile(GetFilePath());
            UpdateComboBox();
        }
    }
}
