using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aula08_22__ConexaoBD
{
    internal class Conexao
    {
        // SINGLETON: criar apenas uma instância da classe qualquer momento
        // CONSTANTE:dado de um valor predefinido(nunca consegue se mudar)
        const string host = "localhost";
        const string banco = "07_lista_tarefas";
        const string usuario = "root";
        const string senha = "senac";

       const string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
        static MySqlConnection conexao = new MySqlConnection (dadosConexao);
        // STATIC: preserva a conexao de antes, não apaga a conexao, nao pode ter variavel, não acessa variavel global 
        // static só enxerga static 
        public static DataTable executaQuery(string query) // vai rodar comandos dentro do bancos 
         // " public static void..." -> nao vai precisar do new na hora de fazer a ligacao de classes 
        {
            try
            {
                conexao.Open();
                MySqlCommand comando = new MySqlCommand(query, conexao);
                MySqlDataReader dados = comando.ExecuteReader();

                DataTable tabela = new DataTable();
                tabela.Load(dados);

                return tabela;
               
            }
            catch (Exception erro)//catch serve para o tratamento de erros
            {
                Console.WriteLine("Erro a realizar consulta");
                Console.WriteLine(erro.Message);
                return null;
            }
            finally 
            { 
             conexao.Close(); //serve para finalizar a consulta, fecha apenas uma vez 
            }
        }
        // if (!dados.HasRows) { } // ! nega a comparação
        //while (dados.Read()) { } // nao precisa de alguma coisa para comparar,
        //automaticamente ele compara com true


    }
}
