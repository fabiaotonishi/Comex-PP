using Comex.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Comex.Servicos
{
    public static class ProdutoServico
    {

        public static void CriarProdutos(List<Produto> listaDeProdutos)
        {
            Console.Clear();
            Console.WriteLine("Registro de Produto");

            Console.Write("Digite o nome do Produto: ");
            string nomeDoProduto = Console.ReadLine();
            var produto = new Produto(nomeDoProduto);

            Console.Write("Digite a descrição do Produto: ");
            string descricaoDoProduto = Console.ReadLine();
            produto.Descricao = descricaoDoProduto;

            Console.Write("Digite o preço do Produto: ");
            string preçoDoProduto = Console.ReadLine();
            produto.PrecoUnitario = double.Parse(preçoDoProduto);

            Console.Write("Digite a quantidade do Produto: ");
            string quantidadeDoProduto = Console.ReadLine();
            produto.Quantidade = int.Parse(quantidadeDoProduto);

            listaDeProdutos.Add(produto);
            Console.WriteLine($"O Produto {produto.Nome} foi registrado com sucesso!");
        }

        public static void ExibirProdutos(List<Produto> listaDeProdutos)
        {
            Console.Clear();
            //ExibirTituloDaOpcao("Exibindo todos os produtos registradoss na nossa aplicação");
            Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");

            for (int i = 0; i < listaDeProdutos.Count; i++)
            {
                Console.WriteLine($"Produto: {listaDeProdutos[i].Nome}, Preço: {listaDeProdutos[i].PrecoUnitario:F2}");
            }
        }

        public static async Task BuscarProdutosNaApiAsync(List<Produto> listaDeProdutos, string mensagemDeBoasVindas)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nExibindo Produtos\n");
                    string resposta = await client.GetStringAsync("http://fakestoreapi.com/products");
                    var produtos = JsonSerializer.Deserialize<List<Produto>>(resposta)!;
                    for (int i = 0; i < produtos.Count; i++)
                    {
                        Console.WriteLine($"Nome: {produtos[i].Nome}, " +
                            $"Descrição: {produtos[i].Descricao}, " +
                            $"Preço {produtos[i].PrecoUnitario} \n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Temos um problema: {ex.Message}");
                }
            }
        }

        public static void OrdenarProdutosPeloTitulo(List<Produto> listaDeProdutos)
        {
            var produtosOrdenados = listaDeProdutos.OrderBy(p => p.Nome).ToList();
            Console.Clear();
            Console.WriteLine("Produtos ordenados pelo título:");
            for (int i = 0; i < produtosOrdenados.Count; i++)
            {
                Console.WriteLine($"Produto: {produtosOrdenados[i].Nome}, Preço: {produtosOrdenados[i].PrecoUnitario:F2}");
            }
        }

        public static void OrdenarProdutosPeloPreco(List<Produto> listaDeProdutos)
        {
            var produtosOrdenadosPorPreco = listaDeProdutos.OrderBy(p => p.PrecoUnitario).ToList();
            Console.Clear();
            Console.WriteLine("Produtos ordenados pelo preço:");
            for (int i = 0; i < produtosOrdenadosPorPreco.Count; i++)
            {
                Console.WriteLine($"Produto: {produtosOrdenadosPorPreco[i].Nome}, Preço: {produtosOrdenadosPorPreco[i].PrecoUnitario:F2}");
            }
        }
    }
}
