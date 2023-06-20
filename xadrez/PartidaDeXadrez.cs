using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro tab { get; private set; }
        public  int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }


        public void ExecutaMovimento(Posicao origem,Posicao destino) {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
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

        public void ColocarNovaPecas(char coluna, int linha, Peca peca) {

            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);

        }
        private void ColocarPecas()
        {
            ColocarNovaPecas('c', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPecas('c', 2, new Torre(tab, Cor.Branca));
            ColocarNovaPecas('d', 2, new Torre(tab, Cor.Branca));
            ColocarNovaPecas('e', 2, new Torre(tab, Cor.Branca));
            ColocarNovaPecas('d', 1, new Rei(tab, Cor.Branca));
            ColocarNovaPecas('e', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPecas('c', 7, new Torre(tab, Cor.preta));
            ColocarNovaPecas('c', 8, new Torre(tab, Cor.preta));

            ColocarNovaPecas('d', 8, new Rei(tab, Cor.preta));
        }
    }
}
