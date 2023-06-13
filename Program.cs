// See https://aka.ms/new-console-template for more information
using tabuleiro;
using xadrez_console;
using xadrez;



try
{
    Tabuleiro tab = new Tabuleiro(8, 8);



    tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 0));
    tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(1, 3));
    tab.ColocarPeca(new Rei(tab, Cor.preta), new Posicao(1, 5));

    tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(7, 5));
    Tela.ImprimirTabuleiro(tab);

}
catch(TabuleiroException e)
{
    Console.WriteLine(e.Message);
}
