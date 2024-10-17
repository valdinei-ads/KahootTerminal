public static class MessageHelper
{
    internal static void TelaSucesso(string mensagem, int tempo) 
    {
        ScreenHelper.ImprimirMolduraTela(Console.WindowWidth, Console.WindowHeight - 1);

        var tituloTela = "Sucesso";

        // Calculando a largura e a altura do console
        int larguraConsole = Console.WindowWidth;
        int alturaConsole = Console.WindowHeight;

        // Calculando a posição do meio
        int posicaoMeioHorizontal = larguraConsole / 2;
        int posicaoMeioVertical = alturaConsole / 2;

        // Exibindo o titulo 
        int posicaoTitulo = posicaoMeioHorizontal - (tituloTela.Length / 2);
        Console.SetCursorPosition(Math.Max(posicaoTitulo, 0), posicaoMeioVertical - 2);
        Console.WriteLine(tituloTela, ConsoleColor.DarkGreen);

        int posicaoMensagem = posicaoMeioHorizontal - (mensagem.Length / 2);
        Console.SetCursorPosition(Math.Max(posicaoMensagem, 0), posicaoMeioVertical + 1);
        Console.WriteLine(mensagem, ConsoleColor.Green);

        Console.CursorVisible = false;

        Thread.Sleep(tempo);
    }

    internal static void TelaErro(string mensagem, int tempo)
    {
        ScreenHelper.ImprimirMolduraTela(Console.WindowWidth, Console.WindowHeight - 1);

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
}