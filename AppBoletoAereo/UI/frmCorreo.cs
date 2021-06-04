using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.WinForms.Correo;

namespace UTN.WinForms.UI
{
    public partial class frmCorreo : Form
    {
        public frmCorreo()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SendEmail sendEmail = new SendEmail();
                sendEmail.EsMailValido(txtEmail.Text);
                sendEmail.enviar(txtEmail.Text);
                MessageBox.Show("Mensaje enviado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Debe llenar este campo");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
