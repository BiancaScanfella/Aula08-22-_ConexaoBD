// See https://aka.ms/new-console-template for more information
using Aula08_22__ConexaoBD;
using System.Data;

//ConexaoSimples conexaoSimples = new ConexaoSimples();

//ConexaoSegura conexaoFlexivel = new ConexaoSegura();
//conexaoFlexivel.executaQuery("SELECT * FROM tarefos");
//conexaoFlexivel.executaQuery("SELECT * FROM tarefas WHERE id=4;");
//conexaoFlexivel.executaQuery("SELECT * FROM tarefas WHERE id=10;");

Tarefa tarefa = new Tarefa();

Console.WriteLine("Seja bem-vindo ao sistema do Conradito Consultinhas");

 List<Tarefa> tarefas = tarefa.BuscaTodos();//-> serve para listar ou salvar 
foreach (Tarefa t in tarefas )// serve para nao ter que usar posição
{
    Console.WriteLine($"Tarefa{t.id} - {t.descricao} - criado em {t.criado_em}") ;
}

Console.WriteLine("Digite 1 para consltar ID ou 2 para consultar DESCRIÇÃO ou 3 para CADASTRAR:");
string opcao = Console.ReadLine();

if (opcao == "3" )
{
    Console.WriteLine("\n Bem-vindo ao cadastro de tarefas! \n");

    Console.WriteLine("Digite a descrição da tarefa:");
    string descricao = Console.ReadLine();

    Console.WriteLine("Tarefa concluida? Digite 1 para sim ou 2 para não");
    bool concluido = Console.ReadLine() == "1";

    Tarefa t = new Tarefa();
    t.descricao = descricao;
    t.concluido = concluido;

    tarefa.Insere(t);

    Console.WriteLine("Cadastro concluido!");
}

/***
if (opcao == "1")
{
    Console.WriteLine("Digite o ID da tarefa que deseja consultar:");
    int id = int.Parse(Console.ReadLine());

    tarefa = tarefa.BuscaPorId(id);

}
else
{
    Console.WriteLine("Digite a DESCRIÇÃO que deseja encontrar:");
    string descricao = Console.ReadLine();
    tarefa = tarefa.BuscaPorDescricao(descricao);
}

Console.WriteLine("\nResultados encontrados:");
Console.WriteLine($"Tarefa {tarefa.id} -  {tarefa.descricao}");
Console.WriteLine($"Criado em {tarefa.criado_em}");
*/