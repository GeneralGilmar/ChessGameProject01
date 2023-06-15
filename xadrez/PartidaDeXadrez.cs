using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro tab { get; private set; }
        public  int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }


        public void ExecutaMovimento(Posicao origem,Posicao destino) {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);

        }

        public void RealizarMovimento(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if (tab.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe Peça na posição de origem escolhida!");
            }
            if (JogadorAtual != tab.Peca(origem).Cor)
            {
                throw new TabuleiroException("A peça de Origem escolhida não é sua!");
            }
            if (!tab.Peca(origem).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem,Posicao destino)
        {
            if (!tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invaldo");
            }
        }
        private void MudarJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab,Cor.Branca),new PosicaoXadrez('c',1).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());

            tab.ColocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('c', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.preta), new PosicaoXadrez('c', 8).ToPosicao());


            tab.ColocarPeca(new Rei(tab, Cor.preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
