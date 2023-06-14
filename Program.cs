// See https://aka.ms/new-console-template for more information
using tabuleiro;
using xadrez_console;
using xadrez;



try
{
    
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.tab);



        Console.WriteLine("Origem: ");
        Posicao origem = Tela.LerPosicao().ToPosicao();
        Console.WriteLine("Destino");
        Posicao destino = Tela.LerPosicao().ToPosicao();

        partida.ExecutaMovimento(origem, destino);


    }

}
catch(TabuleiroException e)
{
    Console.WriteLine(e.Message);
}
