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
            var okRegister = await ApiService.RegisterAsync(txtNome.Text, txtSenha.Text);
            var okLogin = await ApiService.LoginAsync(txtNome.Text, txtSenha.Text);

            lblStatus.Text = okRegister ? "Cadastro OK" : "Falha no cadastro";
            btnRegister.Enabled = true;
            if (okRegister || okLogin)
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
