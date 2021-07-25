using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace AgendaSQL
{
    //============================================================================
    public partial class frmMenu : Form
    {
        //============================================================================
        public frmMenu()
        {
          
            InitializeComponent();
            //Apresentar Versao
            lblVersao.Text = vars.versao;
        }
        //============================================================================
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
          if(  MessageBox.Show("Deseja Realmente Sair da Aplicação?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No) return;
            Application.Exit();
        }
        //============================================================================
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //ABRIR O QUADRO PARA ADICIONAR NOVOS REGISTROS
            frmAdicionarEditar registros = new frmAdicionarEditar();
            registros.ShowDialog();
           
        }

        private void btnVerTudo_Click(object sender, EventArgs e)
        {
            //ABRIR UM QUADRO COM A GRIDVIEW

            frmResultados f = new frmResultados();
            f.ShowDialog();
        }
        //============================================================================

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //ABRE O QUADRO PARA PESQUISA
            frmPesquisar f = new frmPesquisar();
            f.ShowDialog();
            //EXECUTA A PESQUISA SE O QUADRO NAO FOI CANCELADO
            if (f.cancelado)
            {
                f.Dispose();
                return;
            }

            //EXECUTA A PESQUISA

            frmResultados ff = new frmResultados(f.texto_pesquisa);
            ff.ShowDialog();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //APAGA TODOS OS REGISTROS DA BASE DE DADOS
            if (MessageBox.Show("DESEJA REALMENTE ELIMAR TODOS OS REGISTROS SALVOS PERMANENTIMENTE?", "ATENCAO",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            else
            {
                //ELIMINA TODA BASE DE DADOS
                SqlCeConnection ligacao = new SqlCeConnection("Data source="+vars.base_dados);
                ligacao.Open();
                SqlCeCommand comando = new SqlCeCommand("DELETE FROM contatos",ligacao);
                comando.ExecuteNonQuery();
                ligacao.Dispose();

                //MENSAGEM PARA INFORMAR QUE TODOS OS CONTATOS FORAM DELETADOS :')
                MessageBox.Show("Todos os dados foram deletados com sucesso!"); 

            }
        }
    }
}
