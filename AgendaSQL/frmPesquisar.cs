using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgendaSQL
{
    public partial class frmPesquisar : Form
    {
        public string texto_pesquisa { get; set; }
        public bool cancelado { get; set; }
        //===================================================================================
        public frmPesquisar()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmPesquisar_Load(object sender, EventArgs e)
        {

        }
        //===================================================================================
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //EXECUTA A PESQUISA, MAS APENAS SE EXISTIR TEXTO NA TEXTBOX
            if (tbxPesquisa.Text == "")
            {
                cancelado = true;
            }
            else
            {
                texto_pesquisa = tbxPesquisa.Text;
            }
            this.Close();
           
        }
        //===================================================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //FECHA O QUADRO, CANCELANDO A OPERACAO DE PESQUISA
            cancelado = true;
            this.Close();
        }
    }
}
