using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aula08_22__ConexaoBD
{
    internal class ConexaoFlexivel
    {
       
        string host = "localhost";
        string banco = "07_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        MySqlConnection conexao;

        public ConexaoFlexivel() // Metodo construtor: iniciar a classe e criar a conexão
        {
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
            conexao = new MySqlConnection(dadosConexao);
        }
        public void executaQuery(string query) // vai rodar comandos dentro do bancos 
        {
            conexao.Open();
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader dados = comando.ExecuteReader();

            Console.WriteLine("---------------------------");

            if (dados.HasRows == false )
            {
                Console.WriteLine("Nenhum resultado encontrado :(");
            }
            while (dados.Read() == true)
            {
              
                Console.WriteLine( "tarefas" +dados ["id"] + "-" + dados["descricao"]);
                
              
            }
            conexao.Close();
        }
    }
}
