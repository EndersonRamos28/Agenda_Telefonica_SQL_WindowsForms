using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;

namespace AgendaSQL
{
    public static partial class vars
    {
        public static string versao = "V.1.0.1";
        public static string pasta_dados;
        public static string base_dados;

        public static void Iniciar()
        {
            pasta_dados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\AgendaSQL\";

            //VERIFICA SE A PASTA EXISTE, SE NÃO EXISTIR CRIA]
            if (!Directory.Exists(pasta_dados))
                Directory.CreateDirectory(pasta_dados);

            //VERIFICA SE A BASE DE DADOS EXISTE
            base_dados = pasta_dados + "dados.sdf; Password= 'tK&qVYM'";
            if (!File.Exists(pasta_dados + "dados.sdf"))
                //CHAMA O METEDO PRA CRIAR A BASE DE DADOS
                CriarBaseDados();
        }
        
        public static void CriarBaseDados()
        {
            //CRIAÇAO DA BASE DE DADOS
            SqlCeEngine motor = new SqlCeEngine("Data source = " + base_dados);
            motor.CreateDatabase();

            //CRIAR ESTRUTURA PARA BASE DE DADOS
            SqlCeConnection connec = new SqlCeConnection();
            connec.ConnectionString = "Data source = " + base_dados;
            connec.Open();

            SqlCeCommand comando = new SqlCeCommand();
            comando.CommandText =
                "CREATE TABLE contatos(" +
                "id_contato       int not  null primary key, " +
                "nome              nvarchar(50) not null, " +
                "telefone          nvarchar(20), " +
                "atualizacao       datetime)";

            comando.Connection = connec;
            comando.ExecuteNonQuery();
            //FECHANDO AS VARIAVEIS DA MEMORIA
            comando.Dispose();
            connec.Dispose();
        }
    }

}
