using System.Text;

class Program
{
    public static int _score = 0;
    public static string _nomeJogo = "Terminal Kahoot";
    public static string _temaJogo = "Linhagem C#";

    static void Main(string[] args)
    {
        int larguraConsole = Console.WindowWidth;
        int alturaConsole = Console.WindowHeight - 1;

        TelaInicial("Kahoot Terminal", "Linguagem C#");

        TelaPergunta(
            pergunta: "1. Qual comando utilizado para escrever no terminal?",
            alternativas: new[] { "a. Console.WriteLine;", "b. Console.ReadLine;", "c. Console.LineWrite;", "d. Console.LineRead;" },
            resposta: "a"
        );

        TelaPergunta(
            pergunta: "2. O C# é uma linguagem de qual categoria?",
            alternativas: new[] { "a. Estruturada;", "b. Orientada a Objetos;", "c. Script;", "d. Marcação;" },
            resposta: "b"
        );

        TelaPergunta(
            pergunta: "3. O C# tem como pai qual outra linguagem?",
            alternativas: new[] { "a. Java;", "b. Python;", "c. HTML;", "d. C;" },
            resposta: "d"
        );

        TelaPergunta(
            pergunta: "4. Qual comando para criar comentários no c#?",
            alternativas: new[] { "a. //;", "b. \\\\;", "c. ||;", "d. !—;" },
            resposta: "a"
        );

        TelaPergunta(
            pergunta: "5. Dentre os tipos de variáveis abaixo, qual consome 1 bit?",
            alternativas: new[] { "a. int;", "b. char;", "c. bool;", "d. string;" },
            resposta: "c"
        );

        TelaPergunta(
            pergunta: "6. Qual operador corresponde ao resto da divisao?",
            alternativas: new[] { "a. #;", "b. $;", "c. &;", "d. %;" },
            resposta: "d"
        );

        TelaPergunta(
            pergunta: "7. Qual comando utilizamos para converter para inteiro?",
            alternativas: new[] { "a. int.Parse;", "b. int.Convert;", "c. Convert.Parse;", "d. Convert.Int;" },
            resposta: "a"
        );

        TelaPergunta(
            pergunta: "8. Qual simbolo usamos para escrever o valor da variavel no terminal??",
            alternativas: new[] { "a. %;", "b. $;", "c. &;", "d. #;" },
            resposta: "b"
        );

        TelaPergunta(
            pergunta: "9. Qual dos nomes de variáveis abaixo é valido?",
            alternativas: new[] { "a. 123var;", "b. nome variavel;", "c. !nome!;", "d. Variavel_123_Ex;" },
            resposta: "d"
        );

        TelaPergunta(
            pergunta: "10. Qual comando para gerar números aleatórios?",
            alternativas: new[] { "a. Console.Random;", "b. Math.Random;", "c. Random;", "d. Random.Round;" },
            resposta: "c"
        );

        TelaFinal();


    }

    static void ImprimirMolduraTela(int largura, int altura)
    {
        // Limpa a tela antes de imprimir a moldura
        Console.Clear();

        // Imprimindo a moldura superior
        Console.WriteLine($"╔{new string('═', largura - 2)}╗");

        // Imprimindo as laterais da moldura
        for (int i = 0; i < altura - 2; i++)
        {
            Console.WriteLine($"║{new string(' ', largura - 2)}║");
        }

        // Imprimindo a moldura inferior
        Console.WriteLine($"╚{new string('═', largura - 2)}╝");
    }

    static void TelaInicial(string titulo, string tema)
    {
        // Calculando a largura e a altura do console
        int larguraConsole = Console.WindowWidth - 2;
        int alturaConsole = Console.WindowHeight - 1;

        ScreenHelper.ImprimirMolduraTela(larguraConsole, alturaConsole);

        // Calculando a posição do meio
        int posicaoMeioHorizontal = larguraConsole / 2;
        int posicaoMeioVertical = alturaConsole / 2;

        // Exibindo o titulo 
        int posicaoTitulo = posicaoMeioHorizontal - (titulo.Length / 2); // - (linhas.Length / 2) + i
        Console.SetCursorPosition(Math.Max(posicaoTitulo, 0), posicaoMeioVertical - 2);
        Console.WriteLine(titulo);

        int posicaoTema = posicaoMeioHorizontal - (tema.Length / 2); // - (linhas.Length / 2) + i
        Console.SetCursorPosition(Math.Max(posicaoTema, 0), posicaoMeioVertical + 1);
        Console.WriteLine(tema);

        // Definindo os títulos dos botões
        var botoes = new dynamic[] { new { Titulo = "Press Esc to close" }, new { Titulo = "Press Enter to continue" } };

        // Imprimindo oo grupo de botões dentro da moldura da tela
        ButtonHelper.RenderButtonGroup(larguraConsole + 15, alturaConsole + 22, botoes);

        Console.CursorVisible = false;

        // Lê a tecla pressionada
        var digit = Console.ReadKey(true);

        int a = 0;

        while (digit.Key != ConsoleKey.Escape || digit.Key != ConsoleKey.Enter)
        {
            switch (digit.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Enter:
                    return;
                default:
                    TelaErro("Tecla invalida", tempo: 5000);
                    TelaInicial(titulo, tema);
                    break;
            }
        }
    }

    static void TelaErro(string mensagem, int tempo)
    {
        ImprimirMolduraTela(Console.WindowWidth, Console.WindowHeight - 1);

        var tituloTela = "Erro";

        // Calculando a largura e a altura do console
        int larguraConsole = Console.WindowWidth;
        int alturaConsole = Console.WindowHeight;

        // Calculando a posição do meio
        int posicaoMeioHorizontal = larguraConsole / 2;
        int posicaoMeioVertical = alturaConsole / 2;

        // Exibindo o titulo 
        int posicaoTitulo = posicaoMeioHorizontal - (tituloTela.Length / 2); // - (linhas.Length / 2) + i
        Console.SetCursorPosition(Math.Max(posicaoTitulo, 0), posicaoMeioVertical - 2);
        Console.WriteLine(tituloTela, ConsoleColor.DarkRed);

        int posicaoMensagem = posicaoMeioHorizontal - (mensagem.Length / 2); // - (linhas.Length / 2) + i
        Console.SetCursorPosition(Math.Max(posicaoMensagem, 0), posicaoMeioVertical + 1);
        Console.WriteLine(mensagem, ConsoleColor.Red);

        Console.CursorVisible = false;

        Thread.Sleep(tempo);
    }

    static string ApresentarBotao(string tituloBotao)
    {
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

    static void TelaPergunta(string pergunta, string[] alternativas, string resposta)
    {
        // Calculando a largura e a altura do console
        int larguraConsole = Console.WindowWidth - 2;
        int alturaConsole = Console.WindowHeight - 1;

        ScreenHelper.ImprimirMolduraTela(larguraConsole, alturaConsole);

        // Calculando a posição do meio
        int posicaoMeioHorizontal = larguraConsole / 2;
        int posicaoMeioVertical = alturaConsole / 2;

        // Exibindo o titulo 
        int posicaoTitulo = posicaoMeioHorizontal - (_nomeJogo.Length / 2);
        Console.SetCursorPosition(Math.Max(posicaoTitulo, 0), posicaoMeioVertical - 10);
        Console.WriteLine(_nomeJogo);

        int posicaoTema = posicaoMeioHorizontal - (_temaJogo.Length / 2);
        Console.SetCursorPosition(Math.Max(posicaoTema, 0), posicaoMeioVertical - 8);
        Console.WriteLine(_temaJogo);

        int posicaoPergunta = 4;
        Console.SetCursorPosition(posicaoPergunta + 2, posicaoMeioVertical - 2);
        Console.WriteLine(pergunta);

        posicaoMeioVertical += 5;

        // Posiciona as alternativas
        for (int index = 0; index < alternativas.Length; index++)
        {
            posicaoMeioVertical++;

            var larguraLinhaPerguntaRestante = alternativas[index].Length + Math.Abs(pergunta.Length - alternativas[index].Length) + 2;

            Console.SetCursorPosition(posicaoPergunta + 2, posicaoMeioVertical - 5);
            Console.WriteLine(alternativas[index]);

            posicaoMeioVertical++;
        }

        Console.CursorVisible = false;

        // Posiciona o label "Score" e a pontuação
        Console.SetCursorPosition((posicaoMeioHorizontal * 3) / 2, posicaoMeioVertical - 3);
        Console.Write($"Score: {_score}");

        // Posiciona o label "Sua resposta" e o cursor
        Console.SetCursorPosition(6, posicaoMeioVertical - 3);
        Console.Write("Sua Resposta: ");


        var opcaoEscolhida = Console.ReadLine();

        if (EhOpcaoInvalida(opcaoEscolhida))
        {
            MessageHelper.TelaErro($"Opcao invalida", 5000);

            TelaPergunta(pergunta, alternativas, resposta);
        }
        else if (opcaoEscolhida.Equals(resposta, StringComparison.CurrentCultureIgnoreCase))
        {
            _score++;

            MessageHelper.TelaSucesso($"Sucesso... resposta correta: {alternativas.First(_ => _.StartsWith(resposta))}", 5000);
        }

        else MessageHelper.TelaErro($"Que pena... não foi dessa vez... resposta correta: {alternativas.First(_ => _.StartsWith(resposta))}", 5000);

        // Metodo auxiliar para verificar se a opcao é invalida
        bool EhOpcaoInvalida(string opcao) => opcao is not "a" && opcao is not "b" && opcao is not "c" && opcao is not "d";

    }

    static void TelaFinal()
    {
        // Calculando a largura e a altura do console
        int larguraConsole = Console.WindowWidth - 2;
        int alturaConsole = Console.WindowHeight - 1;

        ScreenHelper.ImprimirMolduraTela(larguraConsole, alturaConsole);

        // Calculando a posição do meio
        int posicaoMeioHorizontal = larguraConsole / 2;
        int posicaoMeioVertical = alturaConsole / 2;

        // Exibindo o titulo 
        int posicaoTitulo = posicaoMeioHorizontal - (_nomeJogo.Length / 2);
        Console.SetCursorPosition(Math.Max(posicaoTitulo, 0), posicaoMeioVertical - 2);
        Console.WriteLine("Fim de Jogo");

        int posicaoTema = posicaoMeioHorizontal - (_temaJogo.Length / 2)  - 1;
        Console.SetCursorPosition(Math.Max(posicaoTema, 0), posicaoMeioVertical);
        Console.WriteLine("Pontuacao");
        
        int posicaoScore = posicaoMeioHorizontal - (_score.ToString().Length / 2) - 2;
        Console.SetCursorPosition(Math.Max(posicaoScore, 0), posicaoMeioVertical + 2);
        Console.WriteLine(_score);


        // Definindo os títulos dos botões
        var botoes = new dynamic[] { new { Titulo = "Press Esc to close" } };

        // Imprimindo oo grupo de botões dentro da moldura da tela
        ButtonHelper.RenderButtonGroup(larguraConsole + 15, alturaConsole + 22, botoes);

        Console.CursorVisible = false;

        Console.ReadKey();
    }

}
