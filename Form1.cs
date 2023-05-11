using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemDeAprovaçãodeAlunos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvAlunos.ColumnCount = 5;
            dgvAlunos.Columns[0].Name = "Nome";
            dgvAlunos.Columns[1].Name = "Data de Nascimento";
            dgvAlunos.Columns[2].Name = "Idade";
            dgvAlunos.Columns[3].Name = "Nota Final";
            dgvAlunos.Columns[4].Name = "Situação";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            DateTime dataNascimento = DateTime.Parse(mskDataNascimento.Text);
            int idade = DateTime.Today.Year - dataNascimento.Year;

            double notaFinal = double.Parse(txtNotaFinal.Text);
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(mskDataNascimento.Text) || string.IsNullOrEmpty(txtIdade.Text) || string.IsNullOrEmpty(txtNotaFinal.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de adicionar o aluno.", "Campos em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double média = double.Parse(txtNotaInicial.Text);
            if (notaFinal >= média)
            {
                dgvAlunos.Rows.Add(nome, dataNascimento.ToShortDateString(), idade, notaFinal, "Aprovado");
                MessageBox.Show("Aluno adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dgvAlunos.Rows.Add(nome, dataNascimento.ToShortDateString(), idade, notaFinal, "Reprovado");

            }
            LimpaCampos();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dgvAlunos.SelectedCells[0].RowIndex;
            double notaFinal = double.Parse(txtNotaFinal.Text);
            double média = double.Parse(txtNotaInicial.Text);

            if (notaFinal >= média)
            {
                dgvAlunos.Rows[index].Cells[3].Value = notaFinal;
                dgvAlunos.Rows[index].Cells[4].Value = "Aprovado";
            }
            else
            {
                dgvAlunos.Rows[index].Cells[3].Value = notaFinal;
                dgvAlunos.Rows[index].Cells[4].Value = "Reprovado";
            }
        }
        private void LimpaCampos()
        {
            txtNome.Clear();
            txtIdade.Clear();
            txtNotaFinal.Clear();
            mskDataNascimento.Clear();
            txtNome.Focus();
        }
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            DateTime dataNascimento;
            if (DateTime.TryParse(mskDataNascimento.Text, out dataNascimento))
            {
                int idade = DateTime.Today.Year - dataNascimento.Year;
                if (DateTime.Today < dataNascimento.AddYears(idade))
                {
                    idade--;
                }
                
                txtIdade.Text = idade.ToString();

            }
            else
            {
                MessageBox.Show("Digite uma data valida");
                mskDataNascimento.Clear();
                mskDataNascimento.Focus();
                return;
            }


        }
        
    }
}
