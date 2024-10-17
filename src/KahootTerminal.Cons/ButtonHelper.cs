public class ButtonHelper
{
    public static void RenderButtonGroup(int larguraTela, int alturaTela, dynamic[] botoes)
    {
        // Definindo a altura para os botões
        int alturaBotao = 3;
        int espacoEntreBotoes = 2;

        // Calculando a posição vertical para os botões
        int posicaoVertical = (alturaTela - alturaBotao) / 2;

        // Imprimindo os botões
        for (int i = 0; i < alturaBotao; i++)
        {
            Console.SetCursorPosition(1, posicaoVertical + i);

            int posicaoHorizontal = 4; // Começando na posição horizontal

            for (int botaoIndex = 0; botaoIndex < botoes.Length; botaoIndex++)
            {
                var botao = botoes[botaoIndex];

                if (i == 0) // Linha superior do botão
                {
                    Console.SetCursorPosition(posicaoHorizontal, posicaoVertical);
                    Console.Write($"╔{new string('═', botao.Titulo.Length + 2)}╗");
                }
                else if (i == 1) // Linha do meio do botão
                {
                    Console.SetCursorPosition(posicaoHorizontal, posicaoVertical + 1);
                    Console.Write($"║ {botao.Titulo} ║");
                }
                else if (i == 2) // Linha inferior do botão
                {
                    Console.SetCursorPosition(posicaoHorizontal, posicaoVertical + 2);
                    Console.Write($"╚{new string('═', botao.Titulo.Length + 2)}╝");
                }

                // Atualizando a posição horizontal para o próximo botão
                posicaoHorizontal += botao.Titulo.Length + 4 + espacoEntreBotoes; // Inclui espaço entre botões
            }
        }
    }

    public static void RenderBlueButton(int larguraTela, int alturaTela, dynamic button)
    {
        // Definindo a altura para os botões
        int alturaBotao = 3;
        int posicaoHorizontal = 2;

        // Calculando a posição vertical para os botões
        int posicaoVertical = (alturaTela - alturaBotao) / 2;

        // Imprimindo o botao
        for (int i = 0; i < alturaBotao; i++)
        {
            Console.SetCursorPosition(1, posicaoVertical + i);

            if (i == 0) // Linha superior do botão
            {
                Console.SetCursorPosition(posicaoHorizontal, posicaoVertical);
                Console.Write($"╔{new string('═', button.Titulo.Length + 2)}╗");
            }
            else if (i == 1) // Linha do meio do botão
            {
                Console.SetCursorPosition(posicaoHorizontal, posicaoVertical + 1);
                Console.Write($"║ {button.Titulo} ║");
            }
            else if (i == 2) // Linha inferior do botão
            {
                Console.SetCursorPosition(posicaoHorizontal, posicaoVertical + 2);
                Console.Write($"╚{new string('═', button.Titulo.Length + 2)}╝");
            }
        }
    }

    
}