using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento
{
    internal class Excluir
    {
        Conexao Con = new Conexao();
        SqlCommand Cmd = new SqlCommand();

        public void ExcluirDados(string Nome)
        {
            Cmd.CommandText = "DELETE FROM GASTOS WHERE NOME = @Nome";
            Cmd.Parameters.AddWithValue("@Nome", Nome);

            try
            {
                Cmd.Connection = Con.Conectar();
                Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Desconectar();
            }
        }
        public void ExcluirTudo()
        {
            Cmd.CommandText = "DELETE FROM GASTOS";
            

            try
            {
                Cmd.Connection = Con.Conectar();
                Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Desconectar();
            }
        }
    }
}

