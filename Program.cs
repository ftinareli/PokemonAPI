using PokemonAPI.Model;
using PokemonAPI.Service;
using PokemonAPI.View;
using System.Security;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var mascote = new List<Mascote>();

        string nome = "";
        var condicao = true;
        while (condicao)
        {
            Console.Clear();
            Console.WriteLine(Menu.MenuLogo());
            Console.WriteLine(Menu.MenuLateral('-'));
            Console.WriteLine("Qual o seu nome?");
            nome = Console.ReadLine().Trim();

            condicao = VerificaNome(nome);
        }

        string opcaoUsuario;
        int jogar = 1;

        while (jogar == 1)
        {
            Console.WriteLine(Menu.MenuLateral('-'));
            Console.WriteLine($"{nome}, você deseja:");
            Console.WriteLine("1 - Adotar um Mascote");
            Console.WriteLine("2 - Ver seus Mascotes");
            Console.WriteLine("3 - Sair");
            opcaoUsuario = Console.ReadLine();


            switch (opcaoUsuario)
            {
                case "1":
                    Console.WriteLine(Menu.MenuLateral('-'));
                    Console.WriteLine($"{nome}, escolha uma espécie:");
                    Console.WriteLine("1 - Charmander");
                    Console.WriteLine("2 - Pikachu");
                    Console.WriteLine("3 - Blastoise");

                    var escolha = Console.ReadLine().Trim().ToLower();

                    try
                    {
                        var poke = Enum.GetName(typeof(Mascote.Mascotes), int.Parse(escolha));

                        if (poke == null)
                        {
                            Console.WriteLine("Espécie Inválida!");
                            break;
                        }

                        var pokeSearch = MascoteService.BuscarMascote(poke);
                        mascote.Add(pokeSearch.Result);
                        Console.WriteLine("Mascote adotado com sucesso!");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Espécie Inválida!");
                        break;
                    }

                case "2":
                    if (mascote.Count <= 0)
                    {
                        Console.WriteLine("Nenhum mascote encontrado. Adote um Mascote!");
                        break;
                    }

                    Console.WriteLine(Menu.MenuLateral('-'));
                    Console.WriteLine($"{nome}, qual mascote você deseja visualizar?");
                    
                    int cont = 1;
                    foreach (var poke in mascote)
                    {
                        Console.WriteLine($"{cont} - {poke.Name.ToUpper()}");
                        cont++;
                    }
                    var opcaoSub = Console.ReadLine().Trim();

                    try
                    {
                        Console.WriteLine(Menu.MenuLogo());
                        Console.WriteLine(Menu.MenuLateral('-'));

                        Mascote pokemon = mascote[int.Parse(opcaoSub) - 1];

                        Console.WriteLine(Menu.MenuComString($"Nome: {pokemon.Name.ToUpper()}", ' '));
                        Console.WriteLine(Menu.MenuComString($"Altura: {pokemon.Height}", ' '));
                        Console.WriteLine(Menu.MenuComString($"Peso: {pokemon.Weight}", ' '));

                        Console.WriteLine(Menu.MenuComString("Habilidades:", ' '));
                        foreach (Abilities habilidade in pokemon.abilities)
                        {
                            Console.WriteLine(Menu.MenuComString(habilidade.ability.name.ToUpper(), ' '));
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Mascote Inválido!");
                        break;
                    }

                case "3":
                    jogar = 3;
                    break;

                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
        }
    }
    public static bool VerificaNome(string nome)
    {
        Regex regex = new Regex(@"[\d\W]");
        if (nome.Length < 1 || regex.IsMatch(nome))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}