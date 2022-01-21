using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabuleiro
{
    public partial class Desafio : Form
    {
        Random Num = new Random();
        string[] linha = new string[6];
        string ok;
        public Desafio()
        {
            InitializeComponent();
        }

        private void Desafio_Load(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            richTextBox1.LoadFile("Desafio.txt", RichTextBoxStreamType.PlainText);
            button3.Enabled = true;
            richTextBox1.Visible = true;

            int qual = Num.Next(richTextBox1.Lines.Length);

            linha = richTextBox1.Lines[qual].Split('@');

            richTextBox2.Text = qual + ".";

            richTextBox2.Text = linha[0];
            button1.Text = linha[1];
            button2.Text = linha[2];
            button3.Text = linha[3];
            button4.Text = linha[4];
            ok = linha[5];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ok == "A")
            {
                MessageBox.Show("acertou +2");
                Form1.Ok = true;
            }

            else
            {
                MessageBox.Show("errou -2");
                Form1.Ok = false;
            }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ok == "B")
            {
                MessageBox.Show("acertou +2");
                Form1.Ok = true;
            }

            else
            {
                MessageBox.Show("errou -2");
                Form1.Ok = false;
            }
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (ok == "C")
            {
                MessageBox.Show("acertou +2");
                Form1.Ok = true;
            }

            else
            {
                MessageBox.Show("errou -2");
                Form1.Ok = false;
            }
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (ok == "D")
            {
                MessageBox.Show("acertou +2");
                Form1.Ok = true;
            }
            else
            {
                MessageBox.Show("errou -2");
                Form1.Ok = false;
            }
            this.Close();
        }
    }
}
