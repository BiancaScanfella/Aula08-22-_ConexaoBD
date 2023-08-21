using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aula08_22__ConexaoBD
{
    internal class ConexaoSegura
    {
        //SINGLETON: criar apenas uma instância da classe qualquer momento

        string host = "localhost";
        string banco = "07_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        static MySqlConnection conexao;// static: preserva a conexao de antes, não apaga a conexao
        MySqlCommand comando;
        MySqlDataReader dados;

        public ConexaoSegura() // Metodo construtor: iniciar a classe e criar a conexão
        {
            if (conexao == null)//serve para criar apenas uma conexao
            {
             string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
             conexao = new MySqlConnection(dadosConexao);
            }
        }
        public void executaQuery(string query) // vai rodar comandos dentro do bancos 
        {

            try
            {
                conexao.Open();
                comando = new MySqlCommand(query, conexao);
                dados = comando.ExecuteReader();

                Console.WriteLine("---------------------------");

                if (!dados.HasRows) // ! nega a comparação
                {
                    Console.WriteLine("Nenhum resultado encontrado :(");
                }
                while (dados.Read()) // nao precisa de alguma coisa para comparar, automaticamente ele compara com true
                {

                    Console.WriteLine("tarefas" + dados["id"] + "-" + dados["descricao"]);


                }
            }
            catch (Exception erro)//catch serve para o tratamento de erros
            {
                Console.WriteLine("Erro a realizar consulta");
                Console.WriteLine(erro.Message);
            }
            finally 
            { 
             conexao.Close(); //serve para finalizar a consulta, fecha apenas uma vez 

            }
        }
    }
}
