using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteThoth.Models;

namespace TesteThoth
{
    public partial class Dados : Form
    {
        private BindingSource _binding = new BindingSource();
        public Dados()
        {
            InitializeComponent();
            dgvComp.DataSource = _binding;
        }


        private async Task LoadAll()
        {
            var lista = await ApiService.GetCompromissosAsync();
            _binding.DataSource = lista;
        }
        private async void Dados_Load(object sender, EventArgs e)
        {
            await LoadAll();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var f = new EditCompromissoForm())
            {

                if (f.ShowDialog() == DialogResult.OK)
                    _ = LoadAll();
            };

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvComp.CurrentRow?.DataBoundItem is Compromisso c)
            {
                using (var f = new EditCompromissoForm(c))
                {

                    if (f.ShowDialog() == DialogResult.OK)
                        _ = LoadAll();
                };

            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvComp.CurrentRow?.DataBoundItem is Compromisso c)
            {
                var ok = await ApiService.DeleteCompromissoAsync(c.Id);
                if (ok) await LoadAll();
            }
        }
    }
}
