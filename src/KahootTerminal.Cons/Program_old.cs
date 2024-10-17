using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace KahootTerminal.Cons;

public class Program_old
{
    static void Main_old()
    {
        // Inicializa o jogo
        Initialize();

        TelaInicial("Terminal Kahoot", "tema", "Linguagem C#");

        var alternativa1 = "Console.WriteLine;";
        var alternativa2 = "Console.ReadLine;";
        var alternativa3 = "Console.LineWrite;";
        var alternativa4 = "Console.LineRead;";

        TelaPergunta("Qual comando utilizado para escrever no terminal?", alternativa1, alternativa2, alternativa3, alternativa4);

    }

    static void Initialize()
    {
        Console.WindowWidth = 150; // Última coluna
        Console.WindowHeight = Console.WindowHeight / 2; // Última linha
        Console.Clear();
    }

    static string ApresentarBotao(string tituloBotao)
    {
        //var larguraBotao = tituloBotao.Length + 20;

        //var botaoStrBuilder = new StringBuilder();
        // botaoStrBuilder.AppendLine($"╔{new string('═', larguraBotao)}╗".PadLeft(35).PadRight(35));
        // botaoStrBuilder.AppendLine($"║{tituloBotao.PadLeft(larguraBotao - 5).PadRight(larguraBotao - 5)}║");
        // botaoStrBuilder.AppendLine($"╚{new string('═', larguraBotao)}╝".PadLeft(35).PadRight(35));

        var botaoStrBuilder = new StringBuilder();

        // Definindo o tamanho do botão com base no título
        int largura = tituloBotao.Length + 4; // 2 espaços nas laterais e 2 para a moldura

        // montando a moldura superior
        botaoStrBuilder.AppendLine($"╔{new string('═', largura - 2)}╗");

        // Imprimindo o título centralizado entre as molduras laterais
        botaoStrBuilder.AppendLine($"║ {tituloBotao} ║");

        // montando a moldura inferior
        botaoStrBuilder.AppendLine($"╚{new string('═', largura - 2)}╝");

        return botaoStrBuilder.ToString();
    }

    static void TelaPadrao()
    {
        string titulo = "";
        var conteudo = new List<string>();
        var largura = Console.WindowWidth - 45;//40; // Largura total da telinha

        var linhaHorizontal = new string('═', largura);

        Console.WriteLine($"╔{linhaHorizontal}╗");

        for (int index = 0; index < Console.WindowHeight; index++)
        {
            Console.WriteLine($"║{new string(' ', largura)}║"); // Linha em branco

            if (index == Console.WindowHeight / 2)
            {
                Console.WriteLine($"║{titulo.PadLeft((largura + titulo.Length) / 2).PadRight(largura)}║");

                foreach (var item in conteudo)
                {
                    Console.WriteLine($"║{new string(' ', largura)}║"); // Linha em branco
                    Console.WriteLine($"║{new string(' ', largura)}║"); // Linha em branco
                    Console.WriteLine($"║{item.PadLeft((largura + item.Length) / 2).PadRight(largura)}║");
                }
            }
        }

    }

    static void TelaInicial(string titulo, params string[] conteudo)
    {
        var largura = Console.WindowWidth - 45;//40; // Largura total da telinha
        var linhaHorizontal = new string('═', largura);
        var linhaEmBranco = $"║{new string(' ', largura)}║";

        // Imprimir a moldura
        Console.WriteLine($"╔{linhaHorizontal}╗");

        for (int index = 0; index < Console.WindowHeight; index++)
        {
            Console.WriteLine(linhaEmBranco);

            if (index == Console.WindowHeight / 2)
            {
                Console.WriteLine($"║{titulo.PadLeft((largura + titulo.Length) / 2).PadRight(largura)}║");

                foreach (var item in conteudo)
                {
                    Console.WriteLine(linhaEmBranco);
                    Console.WriteLine(linhaEmBranco);
                    Console.WriteLine($"║{item.PadLeft((largura + item.Length) / 2).PadRight(largura)}║");
                }
            }
        }
        var tituloBotao = "Pressione enter para condinuar";

        // Console.SetCursorPosition(6, Console.WindowHeight - 2); // Posiciona o cursor abaixo das alternativas

        Console.WriteLine($"║{ApresentarBotao(tituloBotao).PadLeft((largura + titulo.Length) / 2)}║");

        Console.WriteLine(linhaEmBranco); // Linha em branco
        Console.WriteLine(linhaEmBranco); // Linha em branco
        Console.WriteLine($"╚{linhaHorizontal}╝");






        Console.CursorVisible = false;
         Console.SetCursorPosition(6, Console.WindowHeight - 1); // Posiciona o cursor abaixo das alternativas

        Console.ReadKey();


    }

    static string TelaPergunta(string pergunta, params string[] alternativas)
    {
        // Console.Clear();

        var largura = Console.WindowWidth - 5;

        // var largura = pergunta.Length > alternativas.OrderByDescending(p => p.Length).First().Length 
        //     ? pergunta.Length + 10 
        //     : alternativas.OrderByDescending(p => p.Length).First().Length + 10; // Largura total da telinha

        var telaStrBuilder = new StringBuilder();
        var linhaHorizontal = new string('═', largura);

        telaStrBuilder.AppendLine($"╔{linhaHorizontal}╗");
        telaStrBuilder.AppendLine($"╔{linhaHorizontal}╗");
        telaStrBuilder.AppendLine($"║{new string(' ', largura)}║"); // Linha em branco
        telaStrBuilder.AppendLine($"║{pergunta.PadLeft((largura + pergunta.Length) / 2).PadRight((largura))}║");
        telaStrBuilder.AppendLine($"║{new string(' ', largura)}║"); // Linha em branco


        // Console.WriteLine($"╔{linhaHorizontal}╗");
        // Console.WriteLine($"║{new string(' ', largura )}║"); // Linha em branco
        // Console.WriteLine($"║{pergunta.PadLeft((largura + pergunta.Length) / 2).PadRight((largura))}║");
        // Console.WriteLine($"║{new string(' ', largura)}║"); // Linha em branco

        for (int index = 0; index < alternativas.Length; index++)
        {
            var larguraLinhaPerguntaRestante = alternativas[index].Length + Math.Abs(pergunta.Length - alternativas[index].Length) + 2;

            //Console.WriteLine($"Largura linha alternnativa: {alternativas[index].Length}");
            //Console.WriteLine($"largura Linha Pergunta Restante: {larguraLinhaPerguntaRestante}");

            telaStrBuilder.AppendLine($"║{new string(' ', 5) + (char)('a' + index)}. {alternativas[index].PadLeft((alternativas[index].Length) / 2).PadRight(larguraLinhaPerguntaRestante)}║"); // Linha em branco
            telaStrBuilder.AppendLine($"║{new string(' ', largura)}║"); // Linha em branco

            // Console.WriteLine($"║{new string(' ', 5) + (char)('a' + index)}. { alternativas[index].PadLeft((alternativas[index].Length) / 2).PadRight(larguraLinhaPerguntaRestante)}║");
            // Console.WriteLine($"║{new string(' ', largura)}║"); // Linha em branco
        }

        telaStrBuilder.AppendLine($"║{new string(' ', largura)}║"); // Linha em branco
        telaStrBuilder.AppendLine($"║{new string(' ', largura)}║"); // Linha em branco
        telaStrBuilder.AppendLine($"╚{linhaHorizontal}╝"); // Linha em branco

        // Console.WriteLine($"║{new string(' ', largura)}║"); // Linha em branco
        // Console.WriteLine($"╚{linhaHorizontal}╝");

        Console.WriteLine(telaStrBuilder.ToString());

        Console.CursorVisible = false; // Oculta o cursor

        Console.SetCursorPosition(6, Console.WindowHeight - 5); // Posiciona o cursor abaixo das alternativas

        Console.Write("Sua Resposta: ");

        return Console.ReadLine();
    }
}