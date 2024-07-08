using Comex.Modelos;

namespace Comex.Data
{
    public class ProdutoData : Conexao
    {
        BancoDados? bancoDados;

        public Produto Incluir(Produto produto)
        {
            try
            {
                if (produto.Id == 0)
                {
                    using (bancoDados = new BancoDados(this.conexaoEf))
                    {
                        bancoDados.Produtos.Add(produto);
                        bancoDados.SaveChanges();
                    }
                }
                return produto;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Produto Alterar(Produto produto)
        {
            try
            {
                if (produto.Id > 0)
                {
                    using (bancoDados = new BancoDados(this.conexaoEf))
                    {
                        bancoDados.Produtos.Update(produto);
                        bancoDados.SaveChanges();
                    }
                }
                return produto;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public bool Excluir(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (bancoDados = new BancoDados(this.conexaoEf))
                    {
                        var produto = bancoDados.Produtos.FirstOrDefault(e => e.Id == id);
                        bancoDados.Produtos.Remove(produto);
                        bancoDados.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            
        }

        public Produto? Obter(int id) 
        {
            try
            {
                using (bancoDados = new BancoDados(this.conexaoEf))
                {
                    var produto = bancoDados.Produtos.FirstOrDefault(e => e.Id == id);
                    return produto;
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }


        }

        public IEnumerable<Produto> Listar()
        {
            try
            {
                using (bancoDados = new BancoDados(this.conexaoEf))
                {
                    var produtos = bancoDados.Produtos.ToList();
                    return produtos;
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

    }
}
