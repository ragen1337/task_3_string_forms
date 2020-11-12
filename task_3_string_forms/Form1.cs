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

namespace task_3_string_forms
{
    public partial class Form1 : Form
    {
        bool success = false;
        StreamReader file = null;

        public Form1()
        {
            InitializeComponent();

            try
            {
                string fileName = "file.txt";
                file = new StreamReader(fileName, Encoding.UTF8);
                success = true;
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
                success = false;
            }


            if (success)
            {
                string fileText;
                while (file.Peek() >= 0)
                {
                    fileText = file.ReadLine();
                    textBox2.Text += fileText + Environment.NewLine;

                    textBox3.Text += TextHandler(fileText) + Environment.NewLine;
                }
            }
        }

        static string TextHandler(string text)
        {
            string[] TextSplitArr = text.Split(' ');

            string HandledText = "";
            foreach (string Word in TextSplitArr)
            {
                char[] CharArray = Word.ToCharArray();
                Array.Reverse(CharArray);

                HandledText += String.Concat(CharArray) + " ";
            }

            return HandledText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string[] NewLineArr = text.Split('\n');
            string textBoxHandledtext = "";

            foreach(string str in NewLineArr){
                textBoxHandledtext += TextHandler(str) + Environment.NewLine;
            }

            textBox4.Text = textBoxHandledtext;
        }
    }
}
