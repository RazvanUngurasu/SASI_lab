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
    public partial class ADFGVX_Decriptare : Form
    {
        public ADFGVX_Decriptare()
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

        public string Decriptare(string text2)
        {
            
            string cheie1 = InlaturaDuplicate(textBox2.Text.ToUpper());
            string cheie2 = InlaturaDuplicate(textBox4.Text.ToUpper());
            text2 = text2.ToUpper();
            string[] alfa1 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] key2 = new string[cheie2.Length];
            for (int i = 0; i < cheie2.Length; i++)
            {
                key2[i] = cheie2[i].ToString();
            }
            Array.Sort(key2);
            matrice2 = new string[cheie2.Length, (text2.Length / key2.Length) + 1];
            for (int i = 0; i < key2.GetLength(0); i++)
            {
                matrice2[i, 0] = key2[i].ToString();
            }

            int k = 0;
            while (k < text2.Length)
            {
                for (int i = 0; i < key2.GetLength(0); i++)
                {
                    for (int j = 1; j < (text2.Length / key2.Length) + 1; j++)
                    {
                        matrice2[i, j] = text2[k].ToString();
                        k++;
                    }
                }
            }
            StringBuilder stringb = new StringBuilder();
            try
            {
                int r = 0;
                while (r < cheie2.Length)
                {
                    for (int i = 0; i < cheie2.Length; i++)
                    {
                        if (matrice2[i, 0] == cheie2[r].ToString())
                        {
                            for (int j = 1; j < (text2.Length / key2.Length) + 1; j++)
                            {
                                stringb.Append(matrice2[i, j]);
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

            for (int i = 0; i < cheie2.Length; i++)
            {
                matrice2[i, 0] = cheie2[i].ToString();
            }

            int k1 = 0;
            while (k1 < text2.Length)
            {
                for (int i = 0; i < key2.GetLength(0); i++)
                {
                    for (int j = 1; j < (text2.Length / key2.Length) + 1; j++)
                    {
                        matrice2[i, j] = stringb[k1].ToString();
                        k1++;
                    }
                }
            }

            StringBuilder stringbl = new StringBuilder();
            int col = 1;
            while (col <= (stringb.Length / cheie2.Length))
            {
                for (int lin = 0; lin < cheie2.Length; lin++)
                {
                    stringbl.Append(matrice2[lin, col]);

                }
                col++;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(cheie1);
            for (int i = 0; i < alfa1.Length; i++)
            {
                if (!(sb.ToString().ToUpper().Contains(alfa1[i])))

                    sb.Append(alfa1[i]);

            }
            int k2 = 0;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    matrice1[i, j] = sb[k2].ToString();
                    k2++;
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

            StringBuilder stringbld = new StringBuilder();
            for (int i = 0; i < stringbl.Length - 1; i = i + 2)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int l = 1; l < 7; l++)
                    {
                        if (matrice1[j, 0] == stringbl[i].ToString() && matrice1[0, l] == stringbl[i + 1].ToString())
                        {
                            stringbld.Append(matrice1[j, l]);
                        }
                    }
                }
            }
            return stringbld.ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Cheie 2 obligatorie");
            }
            else
            {
                textBox1.Text = Decriptare(textBox3.Text);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
