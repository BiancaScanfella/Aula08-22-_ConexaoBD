using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aula08_22__ConexaoBD
{
    internal class Tarefa
    {
        // id, descricao, concluido, criado_em

        public int id;
        public string descricao;
        public bool concluido;
        public string criado_em;

        public Tarefa()
        {

        }

        public Tarefa(int id, string descricao, bool concluido, string criado_em)
        {
            this.id = id;
            this.descricao = descricao;
            this.concluido = concluido;
            this.criado_em = criado_em;
        }

        public List <Tarefa> BuscaTodos ()
        {
            string query = "SELECT * FROM tarefas;";
            DataTable tabela = Conexao.executaQuery(query);
            List <Tarefa>tarefas= new List <Tarefa>();
            // Para cada LINHA dentro de tabela.rows
            // Guarda na variavel linha o valor do loop atual dentro da tabela
            foreach (DataRow linha in tabela.Rows)// facilita comandos
            {
                Tarefa tarefa = carregaDados(linha);
                tarefas.Add(tarefa);
            }
            return tarefas;
        }
        public Tarefa BuscaPorId( int id )
        {
           string query = $"SELECT * FROM tarefas WHERE id ={id};";
           DataTable tabela = Conexao.executaQuery( query );

            Tarefa tarefa = carregaDados(tabela.Rows[0]);
            return tarefa;
            

           //Console.WriteLine("A tarefa é: " + tabela.Rows[0]["descricao"]);
        }
        // recebe a linha de uma tabela e retorna ela no formato de classe



        public void Insere( Tarefa tarefa )
        {
            int concluido = tarefa.concluido == true ? 1 : 0;   
            string query = $"INSERT INTO tarefas (descricao, concluido) VALUES ( '{tarefa.descricao}', {concluido} );";
            Conexao.executaQuery(query);

        }


        public Tarefa carregaDados(DataRow linha)
        {
            int id = int.Parse(linha["id"].ToString());
            string descricao = linha["descricao"].ToString();
            bool concluido = linha["concluido"].ToString() == "1" ? true : false;
            string criado_em = linha["criado_em"].ToString();

            Tarefa tarefa = new Tarefa(id, descricao, concluido, criado_em);
            return tarefa;

        }

        public Tarefa BuscaPorDescricao(string descricao)
        {
            
            string query = $"SELECT * FROM tarefas WHERE descricao LIKE '%{descricao}%';";
            DataTable tabela = Conexao.executaQuery(query);
            Tarefa tarefa = carregaDados(tabela.Rows[0]);
            return tarefa;
        }
    }


}
