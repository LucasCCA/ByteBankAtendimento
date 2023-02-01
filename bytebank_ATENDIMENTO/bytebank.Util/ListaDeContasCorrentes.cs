using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] itens = null;
        private int proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            itens = new ContaCorrente[tamanhoInicial];
        }
     
        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando item na posição {proximaPosicao}");
            VerificarCapacidade(proximaPosicao + 1);
            itens[proximaPosicao] = item;
            proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < itens.Length; i++)
            {
                novoArray[i] = itens[i];
            }

            itens = novoArray;
        }

        public ContaCorrente VerificarSaldo()
        {
            double maiorSaldo = 0;
            ContaCorrente conta = null;

            for(int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    if (itens[i].Saldo >= maiorSaldo)
                    {
                        conta = itens[i];
                        maiorSaldo = itens[i].Saldo;
                    }
                }
            }

            return conta;
        }
    }
}
