using QRCoder;
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

namespace UTN.WinForms.UI
{
    public partial class frmQR : Form
    {
        public frmQR()
        {
            InitializeComponent();
        }

        private void frmQR_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XML docXML = new XML();

            doc.Load(docXML.Ruta);
            XmlNodeList elemList = doc.GetElementsByTagName("identificacion");
            string x = elemList[0].InnerXml;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData info = qr.CreateQrCode(x, QRCodeGenerator.ECCLevel.Q);
            QRCode codigo = new QRCode(info);
            pctQR.Image = codigo.GetGraphic(9);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
