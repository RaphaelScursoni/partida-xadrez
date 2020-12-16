namespace tabuleiro {
    class Tabuleiro {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //leitura da peça na posição dela
        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        //sobrecarga de leitura da peça na posição dela
        public Peca peca(Posicao pos) {
            return pecas[pos.Linha, pos.Coluna];
        }

        //verifica se tem exeption, retorna se tem peça.
        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return peca(pos) is null;
        }
        public void colocarPeca(Peca p, Posicao pos) {
            if (existePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            else {
                pecas[pos.Linha, pos.Coluna] = p;
                p.posicao = pos;
            }
        }
        public bool posicaoValida(Posicao pos) {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas) {
                return false;
            }
            return true;
        }

        //Método para retorno de exception personalizada
        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
