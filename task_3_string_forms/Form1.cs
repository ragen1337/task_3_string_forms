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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = textBox1.Text;
                file = new StreamReader(fileName, Encoding.UTF8);
                success = true;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
                success = false;
            }

            if (success)
            {
                string fileText = file.ReadLine();
                textBox2.Text = fileText;

                textBox3.Text = TextHandler(fileText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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
    }
}
