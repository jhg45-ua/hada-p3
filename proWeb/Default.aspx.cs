using library;
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
                //dropCategory.Items.Add(new ListItem("Computing", "0"));
                //dropCategory.Items.Add(new ListItem("Telephony", "1"));
                //dropCategory.Items.Add(new ListItem("Gaming", "2"));
                //dropCategory.Items.Add(new ListItem("Home appliances", "3"));

                ENCategory enCategory = new ENCategory();
                List<ENCategory> listCategories = enCategory.ReadAll();

                dropCategory.Items.Clear();
                foreach (ENCategory cat in listCategories)
                {
                    dropCategory.Items.Add(new ListItem(cat.Name, cat.Id.ToString()));
                }
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

            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.Read())
                {
                    lblMessage.Text = "Error: Ya existe un producto con ese Code en la base de datos.";
                    return;
                }

                en.Name = txtName.Text;
                en.Amount = amount;
                en.Price = price;
                en.Category = int.Parse(dropCategory.SelectedValue);

                en.CreationDate = creationDate;

                if (en.Create())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Producto creado con éxito.";
                }
                else
                {
                    lblMessage.Text = "Error: No se ha podido crear el producto.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar crear el producto";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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

            if (!int.TryParse(txtAmount.Text, out int amount) || amount < 0 || amount > 9999)
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

            try
            {
                // TODO 2: Instanciar ENProduct con los datos del formulario.
                // TODO 3: Llamar a en.Read() para comprobar que el código SÍ existe en la BD antes de actualizar.
                // TODO 4: Si existe, llamar a en.Update().
                // TODO 5: Si todo va bien, poner lblMessage en verde indicando el éxito.

                ENProduct en = new ENProduct();

                if (!en.Read())
                {
                    lblMessage.Text = "Error: No existe ningún producto con ese Code en la base de datos.";
                    return;
                }

                en.Name = txtName.Text;
                en.Amount = amount;
                en.Price = price;
                en.Category = int.Parse(dropCategory.SelectedValue);
                en.CreationDate = creationDate;

                if (en.Update())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Producto actualizado con éxito.";
                }
                else
                {
                    lblMessage.Text = "Error: No se ha podido actualizar el producto.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar actualizar el producto";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtCode.Text) || txtCode.Text.Length > 16)
            {
                lblMessage.Text = "Error: Introduce un código valido (1-16 caracteres) para borrar.";
                return;
            }

            try
            {
                // TODO 1: Instanciar ENProduct solo con el Code.
                // TODO 2: Llamar a en.Delete().
                // TODO 3: Si devuelve true, limpiar los TextBox de la pantalla y mostrar mensaje de éxito en verde.

                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.Delete())
                {
                    txtName.Text = "";
                    txtAmount.Text = "";
                    txtPrice.Text = "";
                    txtDate.Text = "";
                    dropCategory.SelectedIndex = 0;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Producto borrado con éxito.";
                }
                else
                {
                    lblMessage.Text = "Error: No se ha podido borrar el producto.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar borrar el producto";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtCode.Text) || txtCode.Text.Length > 16)
            {
                lblMessage.Text = "Error: Introduce un código valido (1-16 caracteres) para leer.";
                return;
            }

            try
            {
                // TODO 1: Instanciar ENProduct con el Code.
                // TODO 2: Llamar a en.Read().
                // TODO 3: Si devuelve true, rellenar txtName, txtAmount, ddlCategory, txtPrice y txtCreationDate con las propiedades del objeto 'en'.
                // TODO 4: Mensaje de éxito.

                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.Read())
                {
                    txtName.Text = en.Name;
                    txtAmount.Text = en.Amount.ToString();
                    txtPrice.Text = en.Price.ToString("0.00");
                    txtDate.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    dropCategory.SelectedValue = en.Category.ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Producto leído con éxito.";
                }
                else
                {
                    lblMessage.Text = "Error: No existe ningún producto con ese Code en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar leer el producto";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtCode.Text) || txtCode.Text.Length > 16)
            {
                lblMessage.Text = "Error: Introduce un código valido (1-16 caracteres) para borrar.";
                return;
            }

            try
            {
                // TODO 1: Instanciar ENProduct vacío.
                // TODO 2: Llamar a en.ReadFirst().
                // TODO 3: Si devuelve true, rellenar TODOS los TextBox y el DropDownList de la interfaz gráfica.

                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.ReadFirst())
                {
                    txtName.Text = en.Name;
                    txtAmount.Text = en.Amount.ToString();
                    txtPrice.Text = en.Price.ToString("0.00");
                    txtDate.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    dropCategory.SelectedValue = en.Category.ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Primer producto leído con éxito.";
                }
                else
                {
                    lblMessage.Text = "Error: No se ha podido leer el primer producto.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar leer el primer producto";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                lblMessage.Text = "Error: Introduce un código de referencia para buscar el anterior.";
                return;
            }

            try
            {
                // TODO 1: Instanciar ENProduct con el Code.
                // TODO 2: Llamar a en.ReadPrev().
                // TODO 3: Si devuelve true, actualizar la interfaz gráfica con los nuevos datos.

                ENProduct current = new ENProduct();
                current.Code = txtCode.Text;

                if (current.Read())
                {
                    if (current.ReadPrev())
                    {
                        txtCode.Text = current.Code;
                        txtName.Text = current.Name;
                        txtAmount.Text = current.Amount.ToString();
                        txtPrice.Text = current.Price.ToString("0.00");
                        txtDate.Text = current.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                        dropCategory.SelectedValue = current.Category.ToString();
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Producto anterior leído con éxito.";
                    }
                    else
                    {
                        lblMessage.Text = "Error: No se ha podido leer el producto anterior.";
                    }
                }
                else
                {
                    lblMessage.Text = "Error: No existe ningún producto con ese Code en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar leer el producto anterior";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                lblMessage.Text = "Error: Introduce un código de referencia para buscar el siguiente.";
                return;
            }

            try
            {
                // TODO 1: Instanciar ENProduct con el Code.
                // TODO 2: Llamar a en.ReadNext().
                // TODO 3: Si devuelve true, actualizar la interfaz gráfica con los nuevos datos.

                ENProduct current = new ENProduct();
                current.Code = txtCode.Text;

                if (current.Read())
                {
                    if (current.ReadNext())
                    {
                        txtCode.Text = current.Code;
                        txtName.Text = current.Name;
                        txtAmount.Text = current.Amount.ToString();
                        txtPrice.Text = current.Price.ToString("0.00");
                        txtDate.Text = current.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                        dropCategory.SelectedValue = current.Category.ToString();
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Producto siguiente leído con éxito.";
                    }
                    else
                    {
                        lblMessage.Text = "Error: No se ha podido leer el producto siguiente.";
                    }
                }
                else
                {
                    lblMessage.Text = "Error: No existe ningún producto con ese Code en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al intentar leer el producto siguiente";
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
    }
}
