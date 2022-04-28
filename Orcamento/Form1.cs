using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orcamento
{
    public partial class Orcamento : Form
    {
        Salario Valor = new Salario();
        Gastos Itens = new Gastos();
        public Orcamento()
        {
            InitializeComponent();
        }

        private void AtualizarRestante()
        {
           
                double GastoTotal = Convert.ToDouble(lblTotal.Text) - Itens.CalcularTotal();
                lblSobra.Text = GastoTotal.ToString();
            
        }
        private void Orcamento_Load(object sender, EventArgs e)
        {
            lblTotal.Text = Valor.RecuperarSalario();
            dataGridView.DataSource = Itens.RecuperarValores();
            AtualizarRestante();
        }
        
        private void btnSalario_Click(object sender, EventArgs e)
        {
            double Resultado;
            if (double.TryParse(textBoxSalario.Text, out Resultado))
            {
                Valor.AlterarSalario(Convert.ToDouble(textBoxSalario.Text));
                lblTotal.Text = textBoxSalario.Text;
                AtualizarRestante();
            }
            else
            {
                MessageBox.Show("Campo Salário deve ser numérico");
            }
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            double Valor;
            if ((textBoxGasto.Text != "" || textBoxValor.Text != "") && double.TryParse(textBoxValor.Text,out Valor))
            {
                Itens.InserirGastos(textBoxGasto.Text, textBoxValor.Text);
                dataGridView.DataSource = Itens.RecuperarValores();
                AtualizarRestante();
            }
            else
            {
                MessageBox.Show("Campo Valor deve ser numérico");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir Exclusao = new Excluir();

            if (dataGridView.Rows.Count > 0) 
            {
                Exclusao.ExcluirDados(dataGridView.CurrentCell.Value.ToString());
                lblTotal.Text = Valor.RecuperarSalario();
                dataGridView.DataSource = Itens.RecuperarValores();
                AtualizarRestante();
                MessageBox.Show("Excluído com Sucesso");
            }
        }

        private void btnLimparTduo_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem Certeza?", "Aviso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Excluir Exclusao = new Excluir();
                Exclusao.ExcluirTudo();
                Valor.AlterarSalario(0.00);
                lblTotal.Text = Valor.RecuperarSalario();
                dataGridView.DataSource = Itens.RecuperarValores();
                lblTotal.Text = "0,00";
                lblSobra.Text = "0,00";
                textBoxGasto.Text = "";
                textBoxSalario.Text = "";
                textBoxValor.Text = "";
                MessageBox.Show("Excluído com Sucesso");
            }
        }
    }
}
