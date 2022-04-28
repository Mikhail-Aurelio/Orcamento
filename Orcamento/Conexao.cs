using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento
{
    public class Conexao
    {
        
        SqlConnection Con = new SqlConnection();
        public string StrCon = @"Data Source=LAPTOP-8FVVIA2M\SQLEXPRESS;Initial Catalog=Orcamento;Integrated Security=True";
        public Conexao()
        {
            Con.ConnectionString = StrCon;
             
        }

        public SqlConnection Conectar()
        {
            if(Con.State == System.Data.ConnectionState.Closed)
            {
                Con.Open();
            }
            return Con;
        }
        public void Desconectar()
        {
            if (Con.State == System.Data.ConnectionState.Open)
            {
                Con.Close();
            }
            
        }
    }
}
