using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    #nullable disable
    internal class ByteBankAtendimento
    {
        //ArrayList listaDeContas = new ArrayList();
        private List<ContaCorrente> listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "123456-X") { Saldo = 100, Titular = new Cliente{Cpf = "11111", Nome = "Henrique" } },
            new ContaCorrente(95, "654321-X") { Saldo = 200, Titular = new Cliente{Cpf = "22222", Nome = "Pedro" } },
            new ContaCorrente(94, "987654-X") { Saldo = 60, Titular = new Cliente{Cpf = "33333", Nome = "Marisa" } }
        };

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("=== 1 - Cadastrar Conta     ===");
                    Console.WriteLine("=== 2 - Listar Contas       ===");
                    Console.WriteLine("=== 3 - Remover Conta       ===");
                    Console.WriteLine("=== 4 - Ordenar Contas      ===");
                    Console.WriteLine("=== 5 - Pesquisar Conta     ===");
                    Console.WriteLine("=== 6 - Sair do Sistema     ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Digite a opção desejada");

                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new ByteBankException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarConta();
                            break;
                        case '6':
                            EncerrarApliacao();
                            break;
                        default:
                            Console.WriteLine("Opção não implementada");
                            break;
                    }
                }
            }
            catch (ByteBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }

        }

        private void EncerrarApliacao()
        {
            Console.WriteLine("... Encerrando a aplicação ...");
            Console.ReadKey();
        }

        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    Pesquisar contas     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("Deseja pesquisar por (1) NUMERO DA CONTA ou (2) CPF TITULAR ou (3) NUMERO DA AGENCIA ? ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Informe o número da conta");
                    string numeroConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultaPorNumeroConta(numeroConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Informe o CPF do Titular");
                    string cpf = Console.ReadLine();
                    ContaCorrente consultaCpf = ConsultaPorCPFTitular(cpf);
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Informe o N° da Agência");
                    int numeroAgencia = int.Parse(Console.ReadLine());
                    var contasPorAgencia = ConsultaPorAgencia(numeroAgencia);
                    ExibirListaDeContas(contasPorAgencia);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção não implementada");
                    break;
            }
        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A consulta não retornou dados ...");
            }
            else
            {
                foreach (var item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (
                    from conta in listaDeContas
                    where conta.Numero_agencia == numeroAgencia
                    select conta).ToList();

            return consulta;
        }

        private ContaCorrente ConsultaPorCPFTitular(string? cpf)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < listaDeContas.Count; i++)
            //{
            //    if (listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = listaDeContas[i];
            //    }
            //}

            //return conta;

            return listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
        }

        private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < listaDeContas.Count; i++)
            //{
            //    if (listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = listaDeContas[i];
            //    }
            //}

            //return conta;

            return listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }

        private void OrdenarContas()
        {
            listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenada ...");
            Console.ReadKey();
        }

        private void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     Remover Contas      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("Informe o número da conta: ");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;
            foreach (var item in listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     Lista de contas     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }

            foreach (ContaCorrente item in listaDeContas)
            {
                //Console.WriteLine("===     Dados da conta      ===");
                //Console.WriteLine("Numero da conta: " + item.Conta);
                //Console.WriteLine("Saldo da conta: " + item.Saldo);
                //Console.WriteLine("Titular da conta: " + item.Titular.Nome);
                //Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                Console.WriteLine(item.ToString());
                Console.WriteLine("===============================");
                Console.ReadKey();
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    Cadastro de Contas   ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta  ===");

            Console.WriteLine("Número da agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);

            Console.WriteLine($"Numero da conta [NOVA]: {conta.Conta}");

            Console.WriteLine("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o nome do titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.WriteLine("Informe o CPF do titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.WriteLine("Informe a profissão do titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

    }
}
