﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace appUngurasuCriptography
{
    public partial class PLAYFAIR_Decriptare : Form
    {
        public PLAYFAIR_Decriptare()
        {
            InitializeComponent();
        }
        static string[,] matrice = new string[5, 5];
        static string[] litere = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[,] matrice_f = new string[27, 27];
        string[,] matrice_i = new string[27, 27];
        string key = "";

        public void creareMatrice(string key)
        {

            
            key = key.ToUpper();
            key = stergereDuplicate(key);
            int[] vector = new int[26];
            int nr = 0;
            nr = key.Length;
            string m = "a";
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j <= 25; j++)
                    matrice_i[i, j] = litere[j];
                m = litere[0];
                for (int k = 0; k < 25; k++)
                    litere[k] = litere[k + 1];
                litere[25] = m;
            }

            for (int i = 0; i < nr; i++)
                for (int j = 0; j < 26; j++)
                    if (litere[j] == key[i].ToString())
                        vector[i] = j;

            for (int i = 0; i < nr; i++)
                for (int j = 0; j < 26; j++)
                    matrice_f[i, j] = matrice_i[vector[i], j];

        }

        public static string stergereCaractere(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {

                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public static void matrix(string cheie)
        {
            cheie = cheie.ToUpper();
            cheie = cheie.Replace("J", "I");
            cheie = stergereDuplicate(cheie);
            cheie = stergereCaractere(cheie);
            StringBuilder sb = new StringBuilder();
            sb.Append(cheie);
            
            for (int i = 0; i < litere.Length; i++)
            {
                if (sb.ToString().Contains(litere[i]) == false)
                {
                    sb.Append(litere[i]);
                }
            }
            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrice[i, j] = sb[k].ToString();
                    k++;
                }
            }
            


        }

        public static string stergereDuplicate(string p)
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



        public string DecriptarePlayfair(string textCriptat, string cheie)
        {
           
            matrix(cheie);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < textCriptat.Length - 1; i = i + 2)
            {

                char a = textCriptat[i];
                char b = textCriptat[i + 1];
                int a_i = 0;
                int a_j = 0;
                int b_i = 0;
                int b_j = 0;
                for (int n = 0; n < 5; n++)
                {
                    for (int m = 0; m < 5; m++)
                    {
                        if (matrice[n, m] == a.ToString())
                        {
                            a_i = n;
                            a_j = m;
                        }
                        if (matrice[n, m] == b.ToString())
                        {
                            b_i = n;
                            b_j = m;
                        }
                    }
                }
                if (a_i == b_i)
                {
                    if (a_j == 0)
                    {
                        sb.Append(matrice[a_i, 4]);
                        sb.Append(matrice[b_i, b_j - 1]);
                    }
                    else if (b_j == 0)
                    {
                        sb.Append(matrice[a_i, a_j - 1]);
                        sb.Append(matrice[b_i, 4]);
                    }
                    else
                    {
                        sb.Append(matrice[a_i, a_j - 1]);
                        sb.Append(matrice[b_i, b_j - 1]);
                    }
                }
                else if (a_j == b_j)
                {
                    if (a_i == 0)
                    {
                        sb.Append(matrice[4, a_j]);
                        sb.Append(matrice[b_i - 1, b_j]);
                    }
                    else if (b_i == 0)
                    {
                        sb.Append(matrice[a_i - 1, a_j]);
                        sb.Append(matrice[4, b_j]);
                    }
                    else
                    {
                        sb.Append(matrice[a_i - 1, a_j]);
                        sb.Append(matrice[b_i - 1, b_j]);
                    }
                }
                else
                {

                    sb.Append(matrice[a_i, b_j]);
                    sb.Append(matrice[b_i, a_j]);

                }

            }
            return sb.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DecriptarePlayfair(textBox2.Text, textBox3.Text);
        }
    }
}
