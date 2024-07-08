using Comex.Modelos;

namespace Comex.Data
{
    public class ProdutoData : Connection
    {
        Database? database;

        public Produto Incluir(Produto produto)
        {
            try
            {
                if (produto.Id == 0)
                {
                    using (database = new Database(this.conexaoEf))
                    {
                        database.Produtos.Add(produto);
                        database.SaveChanges();
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
                    using (database = new Database(this.conexaoEf))
                    {
                        database.Produtos.Update(produto);
                        database.SaveChanges();
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
                    using (database = new Database(this.conexaoEf))
                    {
                        var produto = database.Produtos.FirstOrDefault(e => e.Id == id);
                        database.Produtos.Remove(produto);
                        database.SaveChanges();
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
                using (database = new Database(this.conexaoEf))
                {
                    var produto = database.Produtos.FirstOrDefault(e => e.Id == id);
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
                using (database = new Database(this.conexaoEf))
                {
                    var produtos = database.Produtos.ToList();
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
