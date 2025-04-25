using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteThoth.Models;

namespace TesteThoth
{
    public partial class EditCompromissoForm : Form
    {
        private Compromisso _orig;
        public EditCompromissoForm()
        {
            InitializeComponent();
            Text = "Novo";
        }

        public EditCompromissoForm(Compromisso c) : this()
        {
            _orig = c;
            Text = "Editar";
            txtNome.Text = c.Nome;
            txtDesc.Text = c.Descricao;
            dtpData.Value = c.Data;
        }

        private void EditCompromissoForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var c = new Compromisso
            {
                Nome = txtNome.Text,
                Descricao = txtDesc.Text,
                Data = dtpData.Value,
                UsuarioId = ApiService.UserId
            };

            bool ok;
            if (_orig == null)
                ok = (await ApiService.CreateCompromissoAsync(c)) != null;
            else
                ok = await ApiService.UpdateCompromissoAsync(_orig.Id, c);

            if (ok) DialogResult = DialogResult.OK;
            else MessageBox.Show("Erro ao salvar");
        }
    }
}
