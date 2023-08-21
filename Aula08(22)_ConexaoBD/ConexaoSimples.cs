using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aula08_22__ConexaoBD
{
    internal class ConexaoSimples
    {
        // variaveis para utilizar no banco(informações de conexões com o banco
        string host = "localhost";
        string banco = "07_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        public ConexaoSimples()
        {
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
            MySqlConnection conexao = new MySqlConnection(dadosConexao);

            conexao.Open();// CONEXÃO:serve para conectar ou desconecatar

            string query= "SELECT * FROM tarefas;";
            MySqlCommand comando = new MySqlCommand(query,conexao);// manda comandos 
            MySqlDataReader dados = comando.ExecuteReader();//ler o comando(leitura)

            while(dados.Read() == true)
            {
                Console.WriteLine("Descrição da tarefa:" + dados["descricao"]);
            }
            conexao.Close();
        }
    }
}
