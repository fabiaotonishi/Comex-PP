using Comex.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Data
{
    public class ProdutoDal : Conexao
    {
        public int Incluir(Produto produto)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoBd;
            SqlCommand comando = new SqlCommand();
            string sql = "Insert Into " +
                "Produtos(Nome, Descricao, PrecoUnitario, Quantidade) " +
                "Values(@Nome, @Descricao, @PrecoUnitario, @Quantidade) " +
                "Select SCOPE_IDENTITY();";
            comando.CommandText = sql;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@Nome", produto.Nome);
            comando.Parameters.AddWithValue("@Descricao", produto.Descricao);
            comando.Parameters.AddWithValue("@PrecoUnitario", produto.PrecoUnitario);
            comando.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
            comando.Connection = conexao;
            try
            {
                conexao.Open();
                int codigo = Convert.ToInt32(comando.ExecuteScalar());
                return codigo;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

         public bool Alterar(Produto produto)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoBd;
            SqlCommand comando = new SqlCommand();
            string sql = "Update Produtos Set " +
                "Nome = @Nome, Descricao = @Descricao, PrecoUnitario = @PrecoUnitario, Quantidade = @Quantidade " +
                "Where Id = @Id;";
            comando.CommandText = sql;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@Id", produto.Id);
            comando.Parameters.AddWithValue("@Nome", produto.Nome);
            comando.Parameters.AddWithValue("@Descricao", produto.Descricao);
            comando.Parameters.AddWithValue("@PrecoUnitario", produto.PrecoUnitario);
            comando.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
            comando.Connection = conexao;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public void Excluir(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoBd;
            SqlCommand comando = new SqlCommand();
            string sql = "Delete From Produtos " +
                "Where Id = @Id;";
            comando.CommandText = sql;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@Id", id);
            comando.Connection = conexao;
            try
            {
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public Produto? Obter(int id)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoBd;
            SqlCommand comando = new SqlCommand();
            string sql = "Select * From Produtos Where CodigoProduto=@CodigoProduto;";
            comando.CommandText = sql;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@CodigoProduto", id);
            comando.Connection = conexao;
            try
            {
                conexao.Open();
                SqlDataReader drTabela = comando.ExecuteReader();
                if (drTabela.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(drTabela["CodigoProduto"].ToString());
                    produto.Nome = drTabela["Nome"].ToString();
                    produto.Descricao = drTabela["Descricao"].ToString();
                    produto.PrecoUnitario = Convert.ToDouble(drTabela["PrecoUnitario"]);
                    produto.Quantidade = Convert.ToInt32(drTabela["Quantidade"]);

                    return produto;
                }
                return null;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                //Desconectar do B.D
                conexao.Close();
            }
        }

        public IEnumerable<Produto>? Listar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = this.conexaoBd;
            SqlCommand comando = new SqlCommand();
            string sql = "Select * From Produtos;";
            comando.CommandText = sql;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexao;
            try
            {
                conexao.Open();
                SqlDataReader drTabela = comando.ExecuteReader();
                var listaProdutos = new List<Produto>();
                if (drTabela.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(drTabela["CodigoProduto"].ToString());
                    produto.Nome = drTabela["Nome"].ToString();
                    produto.Descricao = drTabela["Descricao"].ToString();
                    produto.PrecoUnitario = Convert.ToDouble(drTabela["PrecoUnitario"]);
                    produto.Quantidade = Convert.ToInt32(drTabela["Quantidade"]);

                    listaProdutos.Add(produto);
                }
                return listaProdutos;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
