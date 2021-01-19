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
    public partial class initialForm : Form
    {
        public initialForm()
        {
            InitializeComponent();
        }

        

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        

        private void Button3_Click(object sender, EventArgs e)
        {
            ADFGVX_Criptare formDialog = new ADFGVX_Criptare();
            formDialog.Show();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            ADFGVX_Decriptare formDialog = new ADFGVX_Decriptare();
            formDialog.Show();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            PLAYFAIR_Criptare formDialog = new PLAYFAIR_Criptare();
            formDialog.Show();
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            PLAYFAIR_Decriptare formDialog = new PLAYFAIR_Decriptare();
            formDialog.Show();
        }

        
    }
}
