using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#
//new ByteBankAtendimento().AtendimentoCliente();
//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do array {idades.Length}");

    int acumulador = 0;

    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.WriteLine($"Digite {i + 1}ª palavra: ");
        arrayDePalavras[i] = Console.ReadLine();

    }

    Console.Write("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}");
            break;
        }
    }

}

//Array amostra = Array.CreateInstance(typeof(double), 5);
//amostra.SetValue(5.9, 0);
//amostra.SetValue(1.8, 1);
//amostra.SetValue(7.1, 2);
//amostra.SetValue(10, 3);
//amostra.SetValue(6.9, 4);
//TestaMediana(amostra);

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"A mediana é igual a {mediana}");
}

//int[] valores = { 10, 58, 36, 47 };
//for (int i = 0; i < 4; i++)
//{
//    Console.WriteLine(valores[i]);
//}

//double[] array = new double[3];
//array[0] = 5;
//array[1] = 10;
//array[2] = 6;

//Console.WriteLine(CalculaMedia(array));
double CalculaMedia(double[] array)
{
    double acumulador = 0;

    if ((array.Length == 0) || (array == null))
    {
        return 0;
    }

    for (int i = 0; i < array.Length; i++)
    {
        acumulador += array[i];
    }

    double media = acumulador / array.Length;
    return media;
}

//TestaArrayDeContasCorrentes();
void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "123"));
    listaDeContas.Adicionar(new ContaCorrente(874, "321"));
    listaDeContas.Adicionar(new ContaCorrente(874, "132"));
    listaDeContas.Adicionar(new ContaCorrente(874, "132"));
    listaDeContas.Adicionar(new ContaCorrente(874, "132"));
    listaDeContas.Adicionar(new ContaCorrente(874, "132"));
    //ContaCorrente joao = new ContaCorrente(123, "123");
    //joao.Saldo = 10;
    //ContaCorrente amanda = new ContaCorrente(123, "123");
    //amanda.Saldo = 100;
    //ContaCorrente julia = new ContaCorrente(123, "123");
    //julia.Saldo = 5000;

    //listaDeContas.Adicionar(joao);
    //listaDeContas.Adicionar(amanda);
    //listaDeContas.Adicionar(julia);

    //Console.WriteLine(listaDeContas.VerificarSaldo());

    var contaDoAndre = new ContaCorrente(963, "123456-x");
    listaDeContas.Adicionar(contaDoAndre);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("=========================");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice[{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}
#endregion 

ArrayList listaDeContas = new ArrayList();

AtendimentoCliente();

void AtendimentoCliente()
{
    char opcao = '0';
    while(opcao != '6')
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
        opcao = Console.ReadLine()[0];
        switch(opcao)
        {
            case '1': 
                CadastrarConta();
                break;
            case '2':
                ListarContas();
                break;
            default: 
                Console.WriteLine("Opção não implementada");
                break;
        }
    }
}

void ListarContas()
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

    foreach(ContaCorrente item in listaDeContas)
    {
        Console.WriteLine("===     Dados da conta      ===");
        Console.WriteLine("Numero da conta: " + item.Conta);
        Console.WriteLine("Titular da conta: " + item.Titular.Nome);
        Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
        Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
        Console.WriteLine("===============================");
        Console.ReadKey();
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===    Cadastro de Contas   ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta  ===");
    Console.WriteLine("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.WriteLine("Número da agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

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