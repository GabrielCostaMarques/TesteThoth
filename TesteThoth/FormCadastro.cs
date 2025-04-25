using System;
using System.Windows.Forms;

namespace TesteThoth
{
    public partial class FormCadastro: Form
    {
        public FormCadastro()
        {
            InitializeComponent();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void linkLogin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();

            formLogin.Show();
            this.Hide();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            Dados dados = new Dados();

            btnRegister.Enabled = false;
            lblStatus.Text = "Cadastrando…";
            var ok = await ApiService.RegisterAsync(txtNome.Text, txtSenha.Text);
            lblStatus.Text = ok ? "Cadastro OK" : "Falha no cadastro";
            btnRegister.Enabled = true;
            if (ok)
            {
                Close();
                dados.Show();
            }
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
