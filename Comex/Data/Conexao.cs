using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comex.Data
{
    public class Conexao
    {
        public readonly string conexaoBd = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComexBd;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public readonly string conexaoEf = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComexEf;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";




    }
}
