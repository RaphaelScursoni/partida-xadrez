using tabuleiro;

namespace xadrez {
    class Rei : Peca {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }
        public override string ToString() {
            return "R";
        }

        public bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimento == 0;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Nordeste
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sudeste
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Abaixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Sudoeste
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Noroeste
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #jogadaespecial ROQUE
            if(qtdMovimento==0 && !partida.xeque) {

                // #jogadaespecial Roque pequeno

                Posicao posT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
                    if(tab.peca(p1)==null && tab.peca(p2) == null) {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }
                // #jogadaespecial Roque grande

                Posicao posT2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
                if (testeTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null) {
                        mat[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }

            }



            return mat;

        }
    }
}
