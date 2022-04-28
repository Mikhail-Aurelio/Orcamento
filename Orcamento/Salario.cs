using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento
{
    internal class Salario
    {
        Conexao Con = new Conexao(); 
        SqlCommand Cmd = new SqlCommand();
        public void AlterarSalario(double Valor)
        {
            Cmd.CommandText = "UPDATE SALARIO SET VALOR = @Valor";
            Cmd.Parameters.AddWithValue("@Valor", Valor);
            try
            {
                Cmd.Connection = Con.Conectar();
                Cmd.ExecuteNonQuery();
            }catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Desconectar();
            }

        }
        public string RecuperarSalario()
        {
            Cmd.CommandText = "SELECT VALOR FROM SALARIO";
            
            string Valor = "";
            
            try
            {
                Cmd.Connection = Con.Conectar();
                SqlDataReader Rd = Cmd.ExecuteReader();
                if (Rd.Read())
                {
                    Valor = Rd[0].ToString();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Desconectar();
            }
            return Valor;
        }
    }
}
