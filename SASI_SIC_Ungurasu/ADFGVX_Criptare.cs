using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appUngurasuCriptography
{
    public partial class ADFGVX_Criptare : Form
    {
        public ADFGVX_Criptare()
        {
            InitializeComponent();
        }

        string[,] matrice1 = new string[7, 7];
        string[,] matrice2;

        public static string InlaturaDuplicate(string p)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < p.Length; i++)
            {
                if (sb.ToString().Contains(p[i]) == false)
                {
                    sb.Append(p[i]);
                }
            }
            return sb.ToString();
        }

        public string Criptare(string text1)
        {
           /* if (textBox4.Text == "")
            {

                MessageBox.Show("Cheia 2 este obligatorie");
            }
           else {*/
                string textCriptat = "";
                string cheie1 = InlaturaDuplicate(textBox2.Text.ToUpper());
                string cheie2 = InlaturaDuplicate(textBox4.Text.ToUpper());
                string[] alfabet1 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                StringBuilder sb = new StringBuilder();
                sb.Append(cheie1);
                for (int i = 0; i < alfabet1.Length; i++)
                {
                    if (!(sb.ToString().ToUpper().Contains(alfabet1[i])))

                        sb.Append(alfabet1[i]);

                }

                textCriptat = sb.ToString().ToUpper();
                int k = 0;

                for (int i = 1; i < 7; i++)
                {
                    for (int j = 1; j < 7; j++)
                    {
                        matrice1[i, j] = textCriptat[k].ToString();
                        k++;
                    }
                }

                matrice1[0, 1] = "A";
                matrice1[0, 2] = "D";
                matrice1[0, 3] = "F";
                matrice1[0, 4] = "G";
                matrice1[0, 5] = "V";
                matrice1[0, 6] = "X";
                matrice1[1, 0] = "A";
                matrice1[2, 0] = "D";
                matrice1[3, 0] = "F";
                matrice1[4, 0] = "G";
                matrice1[5, 0] = "V";
                matrice1[6, 0] = "X";

                StringBuilder sb2 = new StringBuilder();
                foreach (char caracter in text1)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        for (int j = 1; j < 7; j++)
                        {
                            if (Convert.ToString(caracter).ToUpper() == matrice1[i, j])
                            {
                                sb2.Append(matrice1[0, i]);
                                sb2.Append(matrice1[j, 0]);
                            }
                        }
                    }
                }
                matrice2 = new string[cheie2.Length, sb2.Length];
                for (int i = 0; i < cheie2.Length; i++)
                {
                    matrice2[i, 0] = cheie2[i].ToString();
                }
                int col = 1;
                int k1 = 0;

                while (col <= (sb2.Length / cheie2.Length) + 1)
                {
                    for (int i = 0; i < cheie2.Length; i++)
                    {

                        matrice2[i, col] = sb2[k1].ToString();
                        k1++;

                        if (k1 >= sb2.Length)
                        {
                            k1 = sb2.Length - 1;
                        }
                    }
                    col++;

                }
                string[] key2 = new string[cheie2.Length];
                for (int i = 0; i < cheie2.Length; i++)
                {
                    key2[i] = cheie2[i].ToString();
                }
                Array.Sort(key2);
                StringBuilder sy = new StringBuilder();
                try
                {
                    int r = 0;
                    while (r < cheie2.Length)
                    {
                        for (int i = 0; i < cheie2.Length; i++)
                        {
                            if (matrice2[i, 0] == key2[r])
                            {
                                for (int j = 1; j <= (sb2.Length / cheie2.Length) + 1; j++)
                                {
                                    sy.Append(matrice2[i, j]);
                                }
                                r++;
                            }
                        }
                    }
                }
                catch (System.IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                return sy.ToString();
          //
           
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Cheie 2 obligatorie");
            }
            else
            {
                textBox3.Text = Criptare(textBox1.Text);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
