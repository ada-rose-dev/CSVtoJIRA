using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVtoJIRA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
            else if (res != DialogResult.Abort && res != DialogResult.Cancel)
            {
                MessageBox.Show("Please select a .CSV file!", "File Select Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var t = textBox1.Text;

            t = t.Replace(",", " | ");

            var arr = t.Split('\n');

            t = "";

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "" || arr[i] == "\r" || arr[i] == "\n" || arr[i] == System.Environment.NewLine) continue;

                var bar = " | ";
                if (i == 0 && checkBox1.Checked)
                {
                    arr[i] = arr[i].Replace("|", "||");
                    bar = " || ";
                }

                var j = 0;
                arr[i] = arr[i].Replace("\n", "");
                arr[i] = arr[i].Replace("\r", "");
                arr[i] = bar + arr[i].Substring(0,arr[i].Length-j)+bar+System.Environment.NewLine;
                t += arr[i];
            }

            textBox2.Text = t;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
            }
            else
            {
                MessageBox.Show("File not saved!", "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
