public static class ScreenHelper
{
    public static void ImprimirMolduraTela(int largura, int altura)
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
}