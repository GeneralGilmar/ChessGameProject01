// See https://aka.ms/new-console-template for more information
using tabuleiro;
using xadrez_console;
using xadrez;



try
{
    
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {

        try
        {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            Console.WriteLine("Turno:" + partida.Turno);
            Console.WriteLine("Aguradando a jogada: " + partida.JogadorAtual);

            Console.WriteLine("Origem: ");
            Posicao origem = Tela.LerPosicao().ToPosicao();
            partida.ValidarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.tab.Peca(origem).MovimentosPossiveis();
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

            Console.WriteLine("Destino");
            Posicao destino = Tela.LerPosicao().ToPosicao();
            partida.ValidarPosicaoDeDestino(origem, destino);

            partida.RealizarMovimento(origem, destino);
        }catch(TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

    }

}
catch(TabuleiroException e)
{
    Console.WriteLine(e.Message);
}
