using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeOVNI
{
    public partial class Gerenciador : Form
    {
        // OVNI "global":
        BibliotecaOVNI.OVNI ovni;
        
        // Construtor:
        public Gerenciador(BibliotecaOVNI.OVNI ovni)
        {
            InitializeComponent();
            // Atribuir o ovni local para o global:
            this.ovni = ovni;
            AtualizarInterface();
            // Popular o combobox:
            cmbPlaneta.DataSource = BibliotecaOVNI.OVNI.PlanetasValidos;
        }

        private void AtualizarInterface()
        {
            // Exibir ou ocultar os groupBoxes:
            grbTripulacao.Visible = ovni.Situacao;
            grbPlaneta.Visible = ovni.Situacao;
            grbEstatisticas.Visible = ovni.Situacao;
            grbAbduzidos.Visible = ovni.Situacao;
            // Exibir ou ocultar o botão desligar e ligar:
            btnDesligar.Visible = ovni.Situacao;
            btnLigar.Visible = !ovni.Situacao;

            // Atualizar o planeta do Combobox:
            cmbPlaneta.SelectedItem = ovni.PlanetaAtual;

            // Atualizar as estatísticas:
            lblTripulantes.Text = "Tripulantes: " + ovni.QtdTripulantes;
            lblPlaneta.Text = "Planeta Atual: " + ovni.PlanetaAtual;
        }

        private void btnLigar_Click(object sender, EventArgs e)
        {
            ovni.Ligar();
            AtualizarInterface();
        }

        private void btnDesligar_Click(object sender, EventArgs e)
        {
            ovni.Desligar();
            AtualizarInterface();
        }

        private void btnAddTripulante_Click(object sender, EventArgs e)
        {
            // if(ovni.AdicionarTripulante() == false) é o mesmo que:
            if (!ovni.AdicionarTripulante())
            {
                MessageBox.Show("Número máximo atingido!","Erro!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            AtualizarInterface();
        }
    }
}
