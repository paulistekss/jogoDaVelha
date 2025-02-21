using System;

namespace JogoDaVelha 
{
    class Program 
    {
        static char[,] tabuleiro = new char[3, 3];
        static char jogadorAtual = 'X';
        static bool jogoAcabou = false;

        static void Main(string[] args) 
        {
            InicializarTabuleiro();

            while (!jogoAcabou) 
            {
                ExibirTabuleiro();
                FazerJogada();
                VerificarFimDeJogo();
                AlternarJogador();
            }
        }

        static void InicializarTabuleiro() 
        {
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++) 
                {
                    tabuleiro[i, j] = '-';
                }
            }
        }

        static void ExibirTabuleiro() 
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine(" -------");
            for (int i = 0; i < 3; i++) 
            {
                Console.Write(i + "|");
                for (int j = 0; j < 3; j++) 
                {
                    Console.Write(tabuleiro[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine(" -------");
            }
        }

        static void FazerJogada() 
        {
            int linha, coluna;

            while (true) {
                Console.WriteLine("Jogador " + jogadorAtual + ", faça sua jogada.");
                Console.Write("Digite a linha (0, 1 ou 2): ");
                if (!int.TryParse(Console.ReadLine(), out linha) || linha < 0 || linha > 2) 
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                    continue;
                }

                Console.Write("Digite a coluna (0, 1 ou 2): ");
                if (!int.TryParse(Console.ReadLine(), out coluna) || coluna < 0 || coluna > 2) 
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                    continue;
                }

                if (tabuleiro[linha, coluna] == '-') 
                {
                    tabuleiro[linha, coluna] = jogadorAtual;
                    break;
                }
                else 
                {
                    Console.WriteLine("Essa posição já está ocupada. Tente novamente.");
                }
            }
        }

        static void VerificarFimDeJogo() 
        {
            if (VerificarVencedor()) 
            {
                ExibirTabuleiro();
                Console.WriteLine("Jogador " + jogadorAtual + " venceu!");
                jogoAcabou = true;
            }
            else if (VerificarEmpate()) 
            {
                ExibirTabuleiro();
                Console.WriteLine("O jogo empatou.");
                jogoAcabou = true;
            }
        }

        static bool VerificarVencedor() 
        {
            // Verificar linhas
            for (int i = 0; i < 3; i++) 
            {
                if (tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual) 
                {
                    return true;
                }
            }

            // Verificar colunas
            for (int i = 0; i < 3; i++) 
            {
                if (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual) 
                {
                    return true;
                }
            }

            // Verificar diagonais
            if ((tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual) ||
                (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual)) 
            {
                return true;
            }

            return false;
        }

        static bool VerificarEmpate() 
        {
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++) 
                {
                    if (tabuleiro[i, j] == '-') 
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void AlternarJogador() 
        {
            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
        }
    }
}