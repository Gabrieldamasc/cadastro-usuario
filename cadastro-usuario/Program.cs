using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_usuario
{
    // Lista que será utilizada para armazenar todos os usuários que foram digitados na memória

    static List<Usuario> usuarios = new List<Usuario>();

    // Método principal que vai mostrar o menu de escolha para o usuário escolher entra as opções (buscar, cadastrar, listar e sair)
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n-------- CADASTRO DE USUÁRIOS --------");
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Inserir um usuário");
            Console.WriteLine("2 - Buscar usuário pelo seu nome");
            Console.WriteLine("3 - Mostrar a lista de todos os usuários");
            Console.WriteLine("4 - Sair da aplicação");
            Console.Write("Escolha uma opção das listadas acima: ");

            string option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    userRegister();
                    break;
                case "2":
                    userSearch();
                    break;
                case "3":
                    userList();
                    break;
                case "4":
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    // Método para cadastrar um usuário com seus dados (nome, idade e email) respectivamente
    static void userRegister()
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a idade: ");
        if (!int.TryParse(Console.ReadLine(), out int idade))
        {
            Console.WriteLine("Idade inválida!");
            return;
        }

        Console.Write("Digite o email: ");
        string email = Console.ReadLine();

        usuarios.Add(new Usuario(nome, idade, email));
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }

    // Método para buscar um usuário pelo nome
    static void userSearch()
    {
        Console.Write("Digite o nome do usuário para busca: ");
        string nomeBusca = Console.ReadLine();

        var usuario = usuarios.FirstOrDefault(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

        if (usuario != null)
        {
            Console.WriteLine("\nUsuário encontrado:");
            Console.WriteLine(usuario);
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }

    // Método para mostrar a lista de todos os usuários
    static void userList()
    {
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }

        Console.WriteLine("Lista de usuários cadastrados:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine(usuario);
        }
    }
}

// Classe que vai representar um usuário
class Usuario
{
    public string Nome { get; }
    public int Idade { get; }
    public string Email { get; }

    public Usuario(string nome, int idade, string email)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
    }

    // Método que sobrescreve o método ToString que vai mostrar as informações do usuário (nome, idade e email) respectivamente
    public override string ToString()
    {
        return $"Nome: {Nome}, Idade: {Idade}, Email: {Email}";
    }
}
