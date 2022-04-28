using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento
{
    internal class Gastos
    {
        Conexao Con = new Conexao();
        SqlCommand Cmd = new SqlCommand();
        
        public void InserirGastos(string Nome,string Valor)
        {
            Cmd.CommandText = "INSERT INTO GASTOS (NOME,VALOR) VALUES (@Nome,@Valor)";
            Cmd.Parameters.AddWithValue("@Nome", Nome);
            Cmd.Parameters.AddWithValue("@Valor", Convert.ToDouble(Valor));

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
                Cmd.Parameters.Clear();
            }
        }
        public DataTable RecuperarValores()
        {

            DataTable Resultado = new DataTable();
            Cmd.CommandText = "SELECT NOME,VALOR FROM GASTOS";

            try
            {
                Cmd.Connection = Con.Conectar();

                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);

                Adapter.Fill(Resultado);

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Desconectar();
            }
            return Resultado;
        }
        public double CalcularTotal()
        {
            double Total = 0;

            DataTable Resultado = RecuperarValores();

            foreach(DataRow Row in Resultado.Rows)
            {
                Total += Convert.ToDouble(Row["VALOR"]);
            }
            return Total;
        }
    }
}
