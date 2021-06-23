using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidades;
using System.Windows;
namespace Desafio
{
    public partial class NuevoSuscriptor : System.Web.UI.Page
    {
        SuscriptorNegocio sus = new SuscriptorNegocio();
        Suscriptor suscriptor = new Suscriptor();

        protected void Page_Load(object sender, EventArgs e)
        {
            HabilitarCampos();
            if (!IsPostBack)
            {
                DisplayData();
            }

        }
        private void DisplayData()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("Dni", "0"));
            items.Add(new ListItem("Libreta Civica", "1"));
            DropDownList1.DataSource = items;
            DropDownList1.DataValueField = "Value";
            DropDownList1.DataTextField = "Text";
            DropDownList1.DataBind();
        }

        public void HabilitarCampos()
        {
            BtnBuscar.Visible = false;
            BtnModificar.Visible = false;
            BtnNuevo.Visible = false;
            DropDownList1.Enabled = true;
            TxtNumeroDocumento.Enabled = true;
            TxtNombre.Enabled = true;
            TxtApellido.Enabled = true;
            TxtDireccion.Enabled = true;
            TxtEmail.Enabled = true;
            TxtTelefono.Enabled = true;
            TxtNombreUsuario.Enabled = true;
            TxtPassword.Enabled = true;
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text != "" || TxtApellido.Text != "" || TxtDireccion.Text != "" || TxtEmail.Text != "" || TxtNombreUsuario.Text != "" || TxtPassword.Text != "" || TxtNumeroDocumento.Text != "" || TxtTelefono.Text != "")
            {

                Suscriptor suscriptorNuevo = new Suscriptor();
                suscriptorNuevo.Nombre = TxtNombre.Text;
                suscriptorNuevo.Apellido = TxtApellido.Text;
                suscriptorNuevo.TipoDocumento = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                suscriptorNuevo.NumeroDocumento = long.Parse(TxtNumeroDocumento.Text);
                suscriptorNuevo.Direccion = TxtDireccion.Text;
                suscriptorNuevo.Email = TxtEmail.Text;
                suscriptorNuevo.Telefono = long.Parse(TxtTelefono.Text);
                suscriptorNuevo.NombreUsuario = TxtNombreUsuario.Text;
                suscriptorNuevo.Password = TxtPassword.Text;

                if (sus.ExisteSuscriptor(suscriptorNuevo) == true)
                {
                    MessageBox.Show("Usuario Existente");
                    Response.Redirect("NuevoSuscriptor.aspx");

                }
                else
                {

                    if (sus.InsertarSuscriptor(suscriptorNuevo) == true)
                    {
                        MessageBox.Show("Se Agrego un nuevo Suscriptor " + " " + "Nombre de Usuario: " + suscriptorNuevo.NombreUsuario + "  " + "Password: " + suscriptorNuevo.Password);
                        Response.Redirect("Suscripcion.aspx");
                    }
                    else
                    {
                        MessageBox.Show("No se Pudo agregar un Nuevo Suscriptor");
                        Response.Redirect("Suscripcion.aspx");

                    }
                }
            }
            else{
                System.Windows.MessageBox.Show("Por favor Cargue todos los campos");
            }

        }
    }
}