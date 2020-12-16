using System;
//criação da classe para criar exceptions personalizadas.

namespace tabuleiro {
    class TabuleiroException : Exception{
        public TabuleiroException (string msg) : base(msg) {

        }
    }
}
