using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidades;
using Encode.Funciones;
using System.Windows;
using System.Windows.Forms;
namespace Desafio
{
    public partial class ModificarSuscriptor : System.Web.UI.Page
    {
        SuscriptorNegocio sus = new SuscriptorNegocio();
        Suscriptor suscriptor = new Suscriptor();

        protected void Page_Load(object sender, EventArgs e)
        {




            ID.Visible = false;


            if (!IsPostBack)
            {
                DisplayData();
                Buscar();

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
        public void CargarCampos()
        {
            ID.Text = suscriptor.IdSuscriptor.ToString();
            TxtNombre.Text = suscriptor.Nombre;
            TxtApellido.Text = suscriptor.Apellido;
            TxtDireccion.Text = suscriptor.Direccion;
            TxtEmail.Text = suscriptor.Email;
            TxtTelefono.Text = suscriptor.Telefono;
            TxtNombreUsuario.Text = suscriptor.NombreUsuario;
            TxtPassword.Text = suscriptor.Password;
            HabilitarCampos();

        }
        public void HabilitarCampos()
        {
            BtnBuscar.Visible = false;
            BtnModificar.Visible = false;
            BtnNuevo.Visible = false;
            DropDownList1.Enabled = false;
            TxtNumeroDocumento.Enabled = false;
            TxtNombre.Enabled = true;
            TxtApellido.Enabled = true;
            TxtDireccion.Enabled = true;
            TxtEmail.Enabled = true;
            TxtTelefono.Enabled = true;
            TxtNombreUsuario.Enabled = true;
            TxtPassword.Enabled = true;
        }
        public void Buscar()
        {
            TxtNumeroDocumento.Text = Request.QueryString["NumeroDocumento"];
            long NumeroDocumento = long.Parse(TxtNumeroDocumento.Text);
            DropDownList1.SelectedValue = Request.QueryString["TipoDoc"];
            int TipoDocumento = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            suscriptor = sus.ConsultarSuscriptor(TipoDocumento, NumeroDocumento);
            CargarCampos();
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text != "" || TxtApellido.Text !="" || TxtDireccion.Text!="" || TxtEmail.Text != "" || TxtNombreUsuario.Text != "" || TxtPassword.Text != "")
            {

                try
                {

                    suscriptor.IdSuscriptor = int.Parse(ID.Text);
                    suscriptor.Nombre = TxtNombre.Text;
                    suscriptor.Apellido = TxtApellido.Text;
                    suscriptor.Direccion = TxtDireccion.Text;
                    suscriptor.Email = TxtEmail.Text;
                    suscriptor.Telefono = TxtTelefono.Text;
                    suscriptor.NombreUsuario = TxtNombreUsuario.Text;
                    suscriptor.Password = TxtPassword.Text;

                 

                    
                    MessageBoxButtons botones = MessageBoxButtons.OKCancel;
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("Esta Seguro de Modificar Datos Suscriptor ", "", botones, MessageBoxIcon.Warning);

                    if (dr == DialogResult.OK)
                    {
                        if (sus.ActualizarSuscriptor(suscriptor) == true)
                        {

                            System.Windows.MessageBox.Show("Se actualizo correctamente");
                            Session.RemoveAll();
                            Response.Redirect("Suscripcion.aspx");

                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error de Actualización de datos");
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Se cancelo La modificacion del Suscriptor");
                        Response.Redirect("Suscripcion.aspx");
                    }

                }



                catch (Exception)
                {

                }

            }
            else
            {
                System.Windows.MessageBox.Show("Por favor Cargue todos los campos");
            }
        }

    }
}