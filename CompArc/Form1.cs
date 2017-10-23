using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CompArc
{
    public partial class Form1 : Form
    {
        optimizer abbas;

        public Form1()
        {
            InitializeComponent();
            abbas = new optimizer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = richTextBox1.Text;
            abbas = new optimizer(code);


            richTextBox2.Text = abbas.kod;
            textBox1.Text = abbas.loopcounter().ToString() + " loops";

        }

        private void hasNestedLoops_CheckedChanged(object sender, EventArgs e)
        {
            if(hasNestedLoops.Checked)
            {
                abbas.hasnestedLoops = true;
            }
            else
            {
                abbas.hasnestedLoops = false;
            }
        }

        private void loopOptimize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(loopOptimize.SelectedIndex)
            {
                case 0:
                    richTextBox2.Text = abbas.loopFision();
                    break;
                case 1:
                    
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = new string[3];
            lines[0] = System.IO.File.ReadAllText(@"..\elapsed\1.txt");
            lines[1] = richTextBox1.Text;
            lines[2] = System.IO.File.ReadAllText(@"..\elapsed\3.txt");

            System.IO.File.WriteAllLines(@"..\elapsed\Program.cs" ,lines);

            Process proc = null;
            string targetDir = string.Format(@"..\elapsed");
            proc = new Process();
            proc.StartInfo.WorkingDirectory = targetDir;
            proc.StartInfo.FileName = "run.bat";
            proc.Start();
            proc.WaitForExit();

            textBox2.Text = System.IO.File.ReadAllText(@"..\elapsed\elapsedoutput.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines = new string[3];
            lines[0] = System.IO.File.ReadAllText(@"..\elapsed\1.txt");
            lines[1] = richTextBox2.Text;
            lines[2] = System.IO.File.ReadAllText(@"..\elapsed\3.txt");

            System.IO.File.WriteAllLines(@"..\elapsed\Program.cs", lines);

            Process proc = null;
            string targetDir = string.Format(@"..\elapsed");
            proc = new Process();
            proc.StartInfo.WorkingDirectory = targetDir;
            proc.StartInfo.FileName = "run.bat";
            proc.Start();
            proc.WaitForExit();

            textBox3.Text = System.IO.File.ReadAllText(@"..\elapsed\elapsedoutput.txt");
        }

        
    }
}
