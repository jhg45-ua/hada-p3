using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropCategory.Items.Add(new ListItem("Computing", "0"));
                dropCategory.Items.Add(new ListItem("Telephony", "1"));
                dropCategory.Items.Add(new ListItem("Gaming", "2"));
                dropCategory.Items.Add(new ListItem("Home appliances", "3"));
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (txtCode.Text.Length < 1 || txtCode.Text.Length > 16)
            {
                lblMessage.Text = "Error: El código debe tener entre 1 y 16 caracteres.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length > 32)
            {
                lblMessage.Text = "Error: El nombre es obligatorio y no puede superar los 32 caracteres.";
                return;
            }

            if (!int.TryParse(txtAmount.Text, out int amount) || amount < 0 ||  amount > 9999)
            {
                lblMessage.Text = "Error: La cantidad debe ser un valor númerico entre 0 y 9999.";
                return;
            }

            if (!float.TryParse(txtPrice.Text, out float price) || price < 0 || price > 9999.99)
            {
                lblMessage.Text = "Error: El precio debe ser un valor númerico entre 0 y 9999,99.";
                return;
            }

            if (!DateTime.TryParseExact(txtDate.Text, "dd/MM/yyyy HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime creationDate))
            {
                lblMessage.Text = "Error: La fecha debe tener el formato dd/mm/aaaa hh:mm:ss.";
                return;
            }

            // Si llegamos aqui, todos los datos son correctos
            // Mas adelante instanciamos ENProduct y Create()

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Validación superada. Listo para enviar a la BD.";
        }
    }
}