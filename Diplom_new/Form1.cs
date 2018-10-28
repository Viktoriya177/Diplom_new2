using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Diplom_new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
                string[][] jarr = RTB_ToArray(openFile.FileName, "\t");
            }
        }

        public static string[][] RTB_ToArray(string path, string separator = ";")
        {
            List<string[]> temp = new List<string[]>();

            using (var reader = new StreamReader(File.OpenRead(path)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line?.Split(separator.ToCharArray());
                    temp.Add(values);
                }
            }
            return temp.ToArray();
        }
    }
}