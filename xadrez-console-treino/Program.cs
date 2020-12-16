using System;
using tabuleiro;
using xadrez;

namespace xadrez_console_treino {
    class Program {
        static void Main(string[] args) {

            try {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(2, 0));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 5));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(4, 2));
                Tela.imprimirTabuleiro(tab);
            }
            catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
