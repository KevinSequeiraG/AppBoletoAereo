using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using UTN.WinForms.Clases;
using UTN.WinForms.Correo;
using UTN.WinForms.Enums;
using UTN.WinForms.Gestor;

namespace UTN.WinForms.UI
{
    public partial class frmPrincipal : Form
    {
        Usuario user;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            List<Pais> listaPaises = new List<Pais>();
            Pais pais1 = new Pais("USA", 700);
            Pais pais2 = new Pais("MEX", 450);
            Pais pais3 = new Pais("CAN", 950);

            listaPaises.Add(pais1);
            listaPaises.Add(pais2);
            listaPaises.Add(pais3);

            foreach (Pais pais in listaPaises)
            {
                cboDestino.Items.Add(pais);
                cboNacionalidad.Items.Add(pais);
            }

            cboNacionalidad.SelectedIndex = 0;
            cboDestino.SelectedIndex = 0;
            txtID.Focus();
            chkAnimales.Enabled = false;
            chkEquipaje.Enabled = false;
            chkOtros.Enabled = false;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtImpuesto.Text = "";
            txtMonto.Text = "";
            txtNombre.Text = "";
            txtTotal.Text = "";
            chkAnimales.Checked = false;
            chkEquipaje.Checked = false;
            chkOtros.Checked = false;
            rdbFemenino.Checked = false;
            rdbMasculino.Checked = false;
            rdbNormal.Checked = false;
            rdbPrimeraClase.Checked = false;
            cboDestino.SelectedIndex = 0;
            cboNacionalidad.SelectedIndex = 0;
            dgvDetalles.Rows.Clear();
            wbInformation.DocumentText = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtID.Text) || (rdbFemenino.Checked == false && rdbMasculino.Checked == false) || (rdbNormal.Checked == false && rdbPrimeraClase.Checked == false))
            {
                MessageBox.Show("Debe llenar toda la informacion necesaria");
                return;
            }
            else
            {
                TipoBoleto tipo = new TipoBoleto();
                user = new Usuario();
                if (rdbNormal.Checked)
                {
                    tipo = TipoBoleto.Normal;
                }
                else if (rdbPrimeraClase.Checked)
                {
                    tipo = TipoBoleto.PrimeraClase;
                }
                if (rdbFemenino.Checked)
                {
                    user.genero = rdbFemenino.ToString();
                }
                else
                {
                    user.genero = rdbMasculino.ToString();
                }
                user._Boleto = FactoryBoleto.CreateBoleto(tipo, (Pais)cboDestino.SelectedItem, chkEquipaje.Checked, tipo.ToString(), chkAnimales.Checked, chkOtros.Checked);
                user.nombre = txtNombre.Text;
                user.id = txtID.Text;
                user.nacionalidad = cboNacionalidad.SelectedItem.ToString();

                Gestor1 gestor = new Gestor1(user);

                txtMonto.Text = gestor.GetMonto().ToString();
                txtImpuesto.Text = gestor.GetTax().ToString();
                txtTotal.Text = gestor.GetTotal().ToString();

                XML doc = new XML();
                doc.CrearArchivoXML(user);
                dgvDetalles.Rows.Clear();
                dgvDetalles.Rows.Add(gestor.GetMonto(), gestor.GetTax(), gestor.GetTotal());

                XmlTextReader xmlTextReader = new XmlTextReader(doc.Ruta);

                try
                {
                    this.wbInformation.Url = new Uri(doc.Ruta);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error :" + er.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Focus();
                errNameAndID.SetError(txtID, "Favor ingresar el ID correctamente");
            }
            else
            {
                errNameAndID.Clear();
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.Focus();
                errNameAndID.SetError(txtNombre, "Favor ingresar el ID correctamente");
            }
            else
            {
                errNameAndID.Clear();
            }
        }

        private void rdbPrimeraClase_CheckedChanged(object sender, EventArgs e)
        {
            chkAnimales.Enabled = true;
            chkEquipaje.Enabled = true;
            chkOtros.Enabled = true;
        }

        private void rdbNormal_CheckedChanged(object sender, EventArgs e)
        {
            chkEquipaje.Enabled = true;
            chkAnimales.Enabled = false;
            chkOtros.Enabled = false;
            chkAnimales.Checked = false;
            chkOtros.Checked = false;
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            frmCorreo ventana = new frmCorreo();
            ventana.Show();
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            txtID.Focus();
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            frmQR ventana = new frmQR();
            ventana.Show();

        }
    }
}
