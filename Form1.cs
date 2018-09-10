using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Change_TXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> line = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            line.Clear();
            openFileDialog1.Filter = "(*.txt)|*.txt|(*.dat)|*.dat";
            openFileDialog1.FileName = "";
            DialogResult r = openFileDialog1.ShowDialog();
            int counter = 0;
            int i = 0;
            if (r == DialogResult.OK)
            {
                string line1;
                System.IO.StreamReader file =   new System.IO.StreamReader(openFileDialog1.FileName);
                while ((line1 = file.ReadLine()) != null)
                {
                    line.Add(line1);
                    counter++;
                }
                MessageBox.Show(counter.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text File (*.txt)|*.txt";
            DialogResult r = saveFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                try
                {
                    string[] ln = line.ToArray();
                    for (int i = 0; i < ln.Length; i++)
                    {
                        int aval = 0;
                        int dovom = 0;
                        string fin = ln[i].Substring(int.Parse(textBox3.Text) - 1, (int.Parse(textBox4.Text) - int.Parse(textBox3.Text) + 1));
                        string rep = ln[i].Substring(int.Parse(textBox1.Text) - 1, (int.Parse(textBox2.Text) - int.Parse(textBox1.Text) + 1));
                        for (int j = 0; j < fin.Length; j++)
                        {
                            if (fin[j] != ' ')
                                dovom++;
                        }
                        for (int j = 0; j < fin.Length; j++)
                        {
                            if (rep[j] != ' ')
                                aval++;
                        }
                        MessageBox.Show("تعداد کاراکتر موجود در بازه اول :" + aval.ToString());
                        MessageBox.Show("تعداد کاراکتر موجود در بازه دوم :" + dovom.ToString());
                        if (aval != 0 && dovom == 0)
                        {

                            ln[i] = ln[i].Remove(int.Parse(textBox3.Text) - 1, (int.Parse(textBox4.Text) - int.Parse(textBox3.Text) + 1)).Insert(int.Parse(textBox3.Text) - 1, rep);
                        }
                    }
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, ln);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
