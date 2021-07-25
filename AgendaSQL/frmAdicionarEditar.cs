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
    public partial class frmAdicionarEditar : Form
    {
        int id_contato;
        bool editar;
        
        public frmAdicionarEditar(int id_contato = -1)
        {

            InitializeComponent();
            this.id_contato = id_contato;
            //DEFINE SE VOU EDITAR OU ADICIONAR REGISTRO
            editar = id_contato == -1 ? false : true;
        }
        
        private void frmAdicionarEditar_Load(object sender, EventArgs e)
        {
            //APRESENTA OS DADOS DO CONTATO SE NECESSARIO "SE VAI EDITAR"
            if (editar)
                ApresentaContato();

        }
        
        private void ApresentaContato()
        {
            //APRESENTA O CONTATO QUE VAI SER EDITADO
            SqlCeConnection ligacao = new SqlCeConnection("Data source= " + vars.base_dados);
            ligacao.Open();
            DataTable dados = new DataTable();
            SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT * FROM contatos WHERE id_contato= " + id_contato, ligacao);
            adaptador.Fill(dados);
            //FECHA A LIGACAO
            ligacao.Dispose();
            //COLOCA DADOS NA TEXTBOX
            tbxNome.Text = dados.Rows[0]["nome"].ToString();
            tbxNumero.Text = dados.Rows[0]["telefone"].ToString();
        }
        
        private void btnGravar_Click(object sender, EventArgs e)
        {
            SqlCeConnection ligacao = new SqlCeConnection("Data source= " + vars.base_dados);
            ligacao.Open();


            //GRAVA NOVO REGISTRO OU EDITA EXISTENTE

            //VERIFICAÇOES...

            #region VERIFICAÇÔES
            if (tbxNome.Text == "" || tbxNumero.Text == "")
            {
                MessageBox.Show("Nenhum dos campos foram preenchidos!");
                return;
            }

            #endregion
          
            #region NOVO CONTATO
            if (!editar)
            {
                //BUSCAR O ID_CONTATO DISPONIVEL
                SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT MAX(id_contato) AS maxid FROM contatos", ligacao);
                DataTable dados = new DataTable();
                adaptador.Fill(dados);

                //VERIFICA SE O VALOR È NULO
                if (DBNull.Value.Equals(dados.Rows[0][0]))
                    id_contato = 0;
                else
                    id_contato = Convert.ToInt16(dados.Rows[0][0]) + 1;
                //GRAVAR O NOVO CONTATO NA BASE DE DADOS
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = ligacao;

                //PARAMETROS
                comando.Parameters.AddWithValue("@id_contato", id_contato);
                comando.Parameters.AddWithValue("@nome", tbxNome.Text);
                comando.Parameters.AddWithValue("@telefone", tbxNumero.Text);
                comando.Parameters.AddWithValue("@atualizacao", DateTime.Now);

                //PREVINE A DUPLICAGEM DE DADOS(REPETIÇAO DE VALORES)
                adaptador = new SqlCeDataAdapter();
                dados = new DataTable();
                comando.CommandText = "SELECT * FROM contatos WHERE nome=@nome AND telefone=@telefone";
                adaptador.SelectCommand = comando;
                adaptador.Fill(dados);

                if (dados.Rows.Count != 0)
                {
                    //INFORMA QUE JA EXISTRE UM REGISTRO IDENTICO
                    if (MessageBox.Show("Já existe um registro com o mesmo nome e telefone." + Environment.NewLine +
                        "Dejesa gravar mesmo assim?", "ATENCAO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No)
                        return;

                }
                //TEXTO DA QUERY
                comando.CommandText = "INSERT INTO contatos VALUES(" +
                    "@id_contato, @nome, @telefone, @atualizacao)";

                comando.ExecuteNonQuery();
                //SO FECHANDO AS LIGAÇOES
                comando.Dispose();
                ligacao.Dispose();

                MessageBox.Show("contato salvo com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LIMPA CAMPOS
                tbxNome.Text = "";
                tbxNumero.Text = "";
                tbxNome.Focus();

            }
            #endregion
            
            #region EDITAR CONTATO
            else
            {
                //EDITA O CONTATO NA BASE DE DADOS
                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = ligacao;

                //PARAMETROS
                comando.Parameters.AddWithValue("@id_contato", id_contato);
                comando.Parameters.AddWithValue("@nome", tbxNome.Text);
                comando.Parameters.AddWithValue("@telefone", tbxNumero.Text);
                comando.Parameters.AddWithValue("@atualizacao", DateTime.Now);

                //VERIFICA SE EXISTE REGISTRO COM O MESMO NOME DE REGISTRO COM O ID CONTATO DIFERENTE
                DataTable dados = new DataTable();
                comando.CommandText = "SELECT * FROM contatos WHERE nome=@nome AND id_contato <> @id_contato";
                SqlCeDataAdapter adaptador = new SqlCeDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(dados);

                if (dados.Rows.Count != 0)
                {
                    //FOI ENCONTRADO UM REGISTRO COM O MESMO NOME
                    if (MessageBox.Show("Já existe um registro com o mesmo nome." + Environment.NewLine +
                       "Dejesa gravar mesmo assim?", "ATENCAO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                       == DialogResult.No)
                        return;
                }
                //EDITAR O REGISTRO SELECIONADO
                comando.CommandText = "UPDATE contatos SET " +
                                      "nome= @nome," +
                                      "telefone= @telefone," +
                                      "atualizacao= @atualizacao " +
                                      "WHERE id_contato= @id_contato";
                comando.ExecuteNonQuery();
                //FECHA O QUADRO
                this.Close();
                //FECHA LIGACOES
                ligacao.Dispose();
                comando.Dispose();

            }
            #endregion

        }
        
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
