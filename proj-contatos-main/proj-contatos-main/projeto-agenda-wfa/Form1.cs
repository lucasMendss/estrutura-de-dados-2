namespace projeto_agenda_wfa
{
    public partial class Form1 : Form
    {
        private static Contatos contatos = new Contatos();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdcionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Data dtNasc = new Data();
            dtNasc.setData(Convert.ToInt32(nupDia.Text), Convert.ToInt32(nupMes.Text), Convert.ToInt32(nupAno.Text));

            Contato contato = new Contato(txtEmail.Text, txtNome.Text, dtNasc);
            contato.adicionarTelefone(new Telefone("celular", txtTelefone.Text, true));

            contatos.adicionar(contato);
            atualizarDataGridView();
            MessageBox.Show("Contato salvo com sucesso.");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Data dtNasc = new Data();
            dtNasc.setData(Convert.ToInt32(nupDia.Text), Convert.ToInt32(nupMes.Text), Convert.ToInt32(nupAno.Text));

            bool alterado = contatos.alterarPorId((int)nupIdAlterar.Value, txtEmail.Text, txtNome.Text, dtNasc, txtTelefone.Text);

            if (!alterado)
            {
                MessageBox.Show("Contato não encontrado para o Id informado.");
                return;
            }

            atualizarDataGridView();
            MessageBox.Show("Contato alterado com sucesso.");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            bool removido = contatos.removerPorId((int)nupIdRemover.Value);

            if (!removido)
            {
                MessageBox.Show("Contato não encontrado para o Id informado.");
                return;
            }

            atualizarDataGridView();
            MessageBox.Show("Contato removido com sucesso.");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Data dtNasc = new Data();
            dtNasc.setData(Convert.ToInt32(nupDia.Text), Convert.ToInt32(nupMes.Text), Convert.ToInt32(nupAno.Text));

            Contato? contatoEncontrado = contatos.pesquisar(txtEmail.Text, txtNome.Text, dtNasc, txtTelefone.Text);

            dgvContatos.Rows.Clear();

            if (contatoEncontrado is null)
            {
                MessageBox.Show("Contato não foi encontrado.");
                return;
            }

            dgvContatos.Rows.Add(contatoEncontrado.Id, contatoEncontrado.Nome, contatoEncontrado.Email, contatoEncontrado.DtNasc.ToString(), contatoEncontrado.getTelefonePrincipal());
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTelefone.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return false;
            }
            string telefoneRegex = @"^\d{11}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefone.Text, telefoneRegex))
            {
                MessageBox.Show("Formato de telefone inválido. Use o formato XXXXXXXXXXX.");
                return false;
            }
            return true;
        }

        private void atualizarDataGridView()
        {
            dgvContatos.Rows.Clear();
            foreach (var contato in contatos.Agenda)
            {
                dgvContatos.Rows.Add(contato.Id, contato.Nome, contato.Email, contato.DtNasc.ToString(), contato.getTelefonePrincipal());
            }
        }

        private void dgvContatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAlterar_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
