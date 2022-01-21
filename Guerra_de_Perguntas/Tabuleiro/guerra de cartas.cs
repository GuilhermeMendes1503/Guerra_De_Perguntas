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
    public partial class Form1 : Form
    {
        int[] ação_neg = new int[] { 8, 11, 19, 25, 34, 40, 48, 51 };
        int[] ação_posi = new int[] { 4, 6, 24, 28, 31, 35, 53, 55 };
        int[] perg_casa = new int[] { 3, 9, 10, 13, 14, 15, 16, 17, 18, 23, 26, 29, 30, 33, 36, 41, 42, 43, 44, 45, 46, 49, 50, 56 };
        int[] desaf_casa = new int[] { 54, 37, 22, 5, 1 };
        int[] desaf = new int[] { 5, 22, 37, 54, 58 };
        static public string resp;
        bool jog = false, p1 = true, efeito = true, efeito2 = true;
        public static bool Ok = false;
        int Dado, Casa = 1, Casa2 = 57, regra = 1;
        Random Randnum = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile("Dados/dado0.png");
            for (int i = 1; i <= 58; i++)
            {
                Controls["panel" + i].Parent = pictureBox1;
            }
            pictureBox2.Top = 0;
            pictureBox2.Left = 0;
            pictureBox2.Parent = panel1;
            pictureBox3.Top = 0;
            pictureBox3.Left = 0;
            pictureBox3.Parent = panel58;
            button2.Enabled = false;
            button2.Visible = false;
            pictureBox4.Visible = false;
            timer1.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (p1 == true)
            {
                timer1.Enabled = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                button3.Text = "Sair";
                pictureBox5.BringToFront();
                button3.BringToFront();
                button4.BringToFront();
                button5.BringToFront();
                pictureBox4.BringToFront();
                p1 = false;

            }
            else
            {
                timer1.Enabled = true;
                button4.SendToBack();
                button5.SendToBack();
                pictureBox4.Visible = true;
                pictureBox4.BringToFront();
                button3.Text = "Regras";
                pictureBox5.Visible = false;
                p1 = true;
            }
            if (regra == 1)
                button4.Enabled = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (regra <= 3)
            {
                button4.Enabled = true;
                button5.Enabled = true;
                regra++;
                pictureBox5.Image = Image.FromFile("regras/regra" + regra + ".jpg");
            }
            if (regra >= 4)
            {
                button5.Enabled = false;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (regra > 0)
            {
                button5.Enabled = true;
                button4.Enabled = true;
                regra--;
                pictureBox5.Image = Image.FromFile("regras/regra" + regra + ".jpg");
            }
            if (regra == 1)
                button4.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            pictureBox4.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            pictureBox2.Parent = panel1;
            Casa = 0;
            pictureBox3.Parent = panel58;
            Casa2 = 58;
            button2.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            efeito = true;
            efeito2 = true;
            Dado = Randnum.Next(1, 7);
            button1.Image = Image.FromFile("Dados/dado" + Dado + ".png");

            if (jog == true)
            {
                Casa2 = Casa2 - Dado;
                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                for (int i = 0; i <= 4; i++)
                {
                    if (Casa2 <= desaf_casa[i])
                    {
                        Casa2 = desaf_casa[i];

                        MessageBox.Show("Casa de desafio");
                        pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                        if (efeito2 == true)
                        {
                            Form na = new Desafio();
                            na.ShowDialog();
                            if (Ok == true)
                            {
                                desaf_casa[i] = -100;
                                Casa2 += -2;
                                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                efeito2 = false;
                            }
                            else
                            {
                                Casa2 += +2;
                                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                efeito2 = false;
                            }
                            break;
                        }
                    }
                }

                for (int i = 0; i <= 7; i++)
                {
                    if (Casa2 == ação_neg[i])
                    {
                        if (efeito2 == true)
                        {
                            efeito2 = false;
                            Casa2 += +2;
                            MessageBox.Show("-2 volte duas casas");
                        }
                        pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                    }
                    if (Casa2 == ação_posi[i])
                    {
                        if (efeito2 == true)
                        {
                            efeito2 = false;
                            Casa2 += -2;
                            MessageBox.Show("+2 Avançe duas casas");
                            pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                            for (int a = 0; a <= 4; a++)
                            {
                                if (Casa2 <= desaf_casa[a])
                                {
                                    Casa2 = desaf_casa[a];
                                    desaf_casa[a] = -10;
                                    MessageBox.Show("Casa de desafio");
                                    pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                    if (jog == true)
                                    {
                                        Form na = new Desafio();
                                        na.ShowDialog();
                                        if (Ok == true)
                                        {
                                            Casa2 = +-2;
                                            pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i <= 4; i++)
                {
                    if (Casa2 <= desaf_casa[i])
                    {
                        Casa2 = desaf_casa[i];

                        MessageBox.Show("Casa de desafio");
                        pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                        if (efeito2 == true)
                        {
                            Form na = new Desafio();
                            na.ShowDialog();
                            if (Ok == true)
                            {
                                desaf_casa[i] = -100;
                                Casa2 += -2;
                                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                efeito2 = false;
                            }
                            else
                            {
                                Casa2 += +2;
                                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                efeito2 = false;
                            }
                            break;
                        }
                    }
                }

                for (int i = 0; i <= 23; i++)
                {
                    if (jog == true && efeito2 == true)
                    {
                        if (Casa2 == perg_casa[i])
                        {
                            Form na = new perguntas();
                            na.ShowDialog();
                            if(Ok == true)
                            {
                                Casa2 += -2;
                                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                efeito2 = false;
                            }
                            else
                            {
                                Casa2 += +2;
                                pictureBox3.Parent = pictureBox1.Controls["panel" + Casa2];
                                efeito2 = false;
                            }
                            break;
                        }
                    }
                }
                if (Casa2 <= 1)
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button2.Visible = true;
                    label1.Text = "Jogador 1 ganhou";
                }
                jog = false;
                label1.Text = "é a vez do jogador 2";
            }

            else
            {
                Casa = Dado + Casa;
                pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];

                for (int i = 0; i <= 3; i++)
                {
                    if (Casa >= desaf[i])
                    {
                        Casa = desaf[i];
                        MessageBox.Show("Casa de desafio");
                        pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                        if (jog == false && efeito2 == true)
                        {
                            Form na = new Desafio();
                            na.ShowDialog();
                            if (Ok == true)
                            {
                                Casa += +2;
                                pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                efeito = false;
                                desaf[i] = 100;
                            }
                            else
                            {
                                Casa += -2;
                                pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                efeito = false;
                            }
                            break;
                        }
                    }
                }

                for (int i = 0; i <= 7; i++)
                {
                    if (Casa == ação_neg[i])
                    {

                        if (efeito == true)
                        {
                            efeito = false;
                            Casa += -2;
                            MessageBox.Show("-2 volte duas casas");
                        }
                        pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                    }

                    if (Casa == ação_posi[i])
                    {

                        if (efeito == true)
                        {
                            efeito = false;
                            Casa += +2;
                            MessageBox.Show("+2 Avançe duas casas");
                            pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];

                            for (int a = 0; a <= 4; a++)
                            {
                                if (Casa >= desaf[a])
                                {
                                    Casa = desaf[a];
                                    
                                    MessageBox.Show("Casa de desafio");
                                    pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                    if (jog == false)
                                    {
                                        Form na = new Desafio();
                                        na.ShowDialog();
                                        if (Ok == true)
                                        {
                                            desaf[a] = 100;
                                            Casa += 2;
                                            pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                        }

                                        efeito = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i <= 3; i++)
                {
                    if (Casa >= desaf[i])
                    {
                        Casa = desaf[i];
                        MessageBox.Show("Casa de desafio");
                        pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                        if (jog == false && efeito2 == true)
                        {
                            Form na = new Desafio();
                            na.ShowDialog();
                            if (Ok == true)
                            {
                                Casa += +2;
                                pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                efeito = false;
                                desaf[i] = 100;
                            }
                            else
                            {
                                Casa += -2;
                                pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                efeito = false;
                            }
                            break;
                        }
                    }
                }
                for (int i = 0; i <= 23; i++)
                {
                    if (jog == false && efeito == true)
                    {
                        if (Casa == perg_casa[i])
                        {
                            Form na = new perguntas();
                            na.ShowDialog();
                            if (Ok == true)
                            {
                                Casa += +2;
                                efeito = false;
                            }
                            else
                            {
                                Casa += -2;
                                pictureBox2.Parent = pictureBox1.Controls["panel" + Casa];
                                efeito = false;
                            }
                            break;
                        }
                    }
                }
                if (Casa >= 58)
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button2.Visible = true;
                    label1.Text = "Jogador 2 ganhou";
                }
                jog = true;
                label1.Text = "é a vez do jogador 1";
            }
        }
    }
}