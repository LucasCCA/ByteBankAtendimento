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

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = -1;
            for (int i = 0; i < proximaPosicao; i++)
            {
                ContaCorrente contaAtual = itens[i];
                if (contaAtual == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < proximaPosicao - 1; i++)
            {
                itens[i] = itens[i + 1]; 
            }
            proximaPosicao--;
            itens[proximaPosicao] = null;
        }

        public void ExibeLista()
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    var conta = itens[i];
                    Console.WriteLine($"Indice[{i}] = Conta: {conta.Conta} - n° da agência: {conta.Numero_agencia}");
                }
            }
        }

        public ContaCorrente RecuperarContaNoIndice(int indice)
        {
            if (indice < 0 || indice >= proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return itens[indice];
        }

        public int Tamanho 
        { 
            get 
            {
                return proximaPosicao;
            }
        }

        public ContaCorrente this[int indice] 
        {
            get
            {
                return RecuperarContaNoIndice(indice);
            }
        }

    }
}
