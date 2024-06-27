// See https://aka.ms/new-console-template for more information
using Comex.Modelos;
using Comex.Servicos;
using Comex.Util;
using System.Runtime.CompilerServices;
using System.Text.Json;

var listaDeProdutosTestes = new List<Produto>
{
    new Produto("Notebook")
    {
        Descricao = "Notebook Dell Inspiron",
        PrecoUnitario = 3500.00,
        Quantidade = 10
    },
    new Produto("Smartphone")
    {
        Descricao = "Smartphone Samsung Galaxy",
        PrecoUnitario = 1200.00,
        Quantidade = 25
    },
    new Produto("Monitor")
    {
        Descricao = "Monitor LG Ultrawide",
        PrecoUnitario = 800.00,
        Quantidade = 15
    },
    new Produto("Teclado")
    {
        Descricao = "Teclado Mecânico RGB",
        PrecoUnitario = 250.00,
        Quantidade = 50
    }
};

var listaDePedidosTestes = new List<Pedido>();

string mensagemDeBoasVindas = "Boas vindas ao COMEX";

async Task ExibirOpcoesDoMenu()
{
    SistemaUtil.ExibirLogo(mensagemDeBoasVindas);
    Console.WriteLine("\nDigite 1 Criar Produto");
    Console.WriteLine("Digite 2 Listar Produtos");
    Console.WriteLine("Digite 3 Consultar API Externa");
    Console.WriteLine("Digite 4 Ordenar Produtos pelo Título");
    Console.WriteLine("Digite 5 Ordenar Produtos pelo Preço");
    Console.WriteLine("Digite 6 Criar Pedido");
    Console.WriteLine("Digite 7 Listar Pedidos");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:            
            ProdutoServico.CriarProdutos(listaDeProdutosTestes);
            break;
        case 2:
            ProdutoServico.ExibirProdutos(listaDeProdutosTestes);
            break;
        case 3:
            await ProdutoServico.BuscarProdutosNaApiAsync(listaDeProdutosTestes, mensagemDeBoasVindas);
            break;
        case 4:
            ProdutoServico.OrdenarProdutosPeloTitulo(listaDeProdutosTestes);
            break;
        case 5:
            ProdutoServico.OrdenarProdutosPeloPreco(listaDeProdutosTestes);
            break;
        case 6:
            PedidoServico.CriarPedido(listaDeProdutosTestes, listaDePedidosTestes);            
            break;
        case 7:
            PedidoServico.ExibirPedidos(listaDePedidosTestes);
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");            
            return;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    await ExibirOpcoesDoMenu();
}

await ExibirOpcoesDoMenu();