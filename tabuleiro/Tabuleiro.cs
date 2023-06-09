﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace tabuleiro
{
    class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;

            Pecas = new Peca[Linhas, Colunas];
        }


        public Peca Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha,pos.Coluna];
        }
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
        
              return Peca(pos)!=null;
        }
        public void ColocarPeca(Peca p,Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe peça nesta Posição");
            }

            Pecas[pos.Linha, pos.Coluna] = p;
           // p.Posicao = pos;

        }

       public bool PosicaoValida(Posicao pos)
        {
            if(pos.Linha>=Linhas || pos.Linha<0 || pos.Coluna>Colunas || pos.Coluna<0)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posiçao Invalida");
            }
        }


    }
}
