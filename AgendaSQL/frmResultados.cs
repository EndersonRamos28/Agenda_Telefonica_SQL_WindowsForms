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
    public partial class frmResultados : Form
    {
        int id_contato;
        string item_pesquisa;
        public frmResultados(string item_pesquisa = "")
        {
            InitializeComponent();
            this.item_pesquisa = item_pesquisa;
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmResultados_Load(object sender, EventArgs e)
        {
            construirGrade();
        }
        private void construirGrade()
        {
            //constroi a grade de registros

            //LIGAR A BD
            SqlCeConnection ligacao = new SqlCeConnection("Data source= " + vars.base_dados);
            ligacao.Open();
            string query = "SELECT * FROM contatos";
            if (item_pesquisa != "")
            {
                query = "SELECT * FROM contatos " +
                  "WHERE nome LIKE @item OR telefone LIKE @item";
            }

            SqlCeCommand comando = new SqlCeCommand();
            comando.Parameters.AddWithValue("@item", "%" + item_pesquisa + "%");
            comando.CommandText = query;
            comando.Connection = ligacao;

            SqlCeDataAdapter adaptador = new SqlCeDataAdapter();
            adaptador.SelectCommand = comando;

            DataTable dados = new DataTable();
            adaptador.Fill(dados);
            //PASSA OS VALORES PRA GRID
            GradeResultados.DataSource = dados;

            //APRESENTA O NUMERO DE REGISTRO NA BD

            lblResultados.Text = "Resultados" + "(" + GradeResultados.Rows.Count + ")";

            //ESCONDER COLUNAS NO GRID
            //ID_CONTATO E ATUALIZAÇAO
            GradeResultados.Columns["id_contato"].Visible = false;
            GradeResultados.Columns["atualizacao"].Visible = false;

            //ALTERA AS DIMENSOES DAS COLUNAS
            GradeResultados.Columns["nome"].Width = CalcularLargura(60);
            GradeResultados.Columns["telefone"].Width = CalcularLargura(40);

            //CONTROLA A DISPONIBILIDADE DOS COMANDOS
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            //ELIMAR REGISTRO SELECIONADO
            SqlCeConnection ligacao = new SqlCeConnection("Data source =" + vars.base_dados);
            ligacao.Open();
            SqlCeCommand comando = new SqlCeCommand("DELETE FROM contatos WHERE id_contato= " + id_contato, ligacao);
            comando.ExecuteNonQuery();
            //---------------------------------------------------------------------------------
            //FECHA AS LIGAÇOES
            comando.Dispose();
            ligacao.Dispose();

            //RECONSTROI A GRADE
            construirGrade();
        }

        private void GradeResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_contato = Convert.ToInt16(GradeResultados.Rows[e.RowIndex].Cells["id_contato"].Value);
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //EDITA O REGISTRO
            frmAdicionarEditar f = new frmAdicionarEditar(id_contato);
            f.ShowDialog();

            //ATUALIZA A LISTA APOS EDITAR
            construirGrade();
        }
        
        private void btnVerTudo_Click(object sender, EventArgs e)
        {
            //VOLTA A APRESENTAR TODOS OS REGISTROS DE CONTATOS
            item_pesquisa = "";
            construirGrade();
        }
        
        private int CalcularLargura(int porcentagem)
        {
            int largura_grelha = GradeResultados.Width - 20;
            int resultado = (largura_grelha * porcentagem) / 100;
            return resultado;
        }
    }
}
