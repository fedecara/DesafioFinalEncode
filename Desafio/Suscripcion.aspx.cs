using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace Desafio
{
    public partial class Suscripcion : System.Web.UI.Page
    {
        SuscriptorNegocio sus = new SuscriptorNegocio();
        Suscriptor suscriptor = new Suscriptor();



        protected void Page_Load(object sender, EventArgs e)
        {
            BtnModificar.Visible = false;
            ID.Visible = false;
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
        protected void btnBtnBuscar(object sender, EventArgs e)
        {
            if (TxtNumeroDocumento.Text != "")
            {
                int TipoDocumento = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                long NumeroDocumento = long.Parse(TxtNumeroDocumento.Text);

                suscriptor = sus.ConsultarSuscriptor(TipoDocumento, NumeroDocumento);

                if (suscriptor.Nombre == null)
                {
                    MessageBoxButtons botones = MessageBoxButtons.OKCancel;
                    DialogResult dr = System.Windows.Forms.MessageBox.Show("No se encontro Suscriptor... ¿desea darlo de alta? ", "", botones, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        Response.Redirect("NuevoSuscriptor.aspx");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Se cancelo el alta del Suscriptor");
                        Response.Redirect("Suscripcion.aspx");
                    }
                }


                else
                {
                    System.Windows.MessageBox.Show("Suscriptor Existente");
                    if (sus.ExisteSuscripcion(suscriptor) == true)
                    {
                        System.Windows.MessageBox.Show("Se Tiene Suscripcion Vigente");
                        Response.Redirect("Suscripcion.aspx");


                    }
                    else
                    {

                        System.Windows.MessageBox.Show("No tiene Suscripcion vigente");
                        CargarCampos();
                        BtnModificar.Visible = true;

                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Por favor cargue los campos requeridos");
                Response.Redirect("Suscripcion.aspx");

            }

        }

        //public void ValidarNroDocuemento()
        //{
        //    if (int.Parse(TxtNumeroDocumento.Text) == " " || TxtNumeroDocumento.Text not isNumber )
        //    {

        //    }

        //}

        public void LimpiarCampos()
        {

            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtDireccion.Text = "";
            TxtEmail.Text = "";
            TxtTelefono.Text = "";
            TxtNombreUsuario.Text = "";
            TxtPassword.Text = "";


        }

        public void CargarCampos()
        {
            ID.Text = suscriptor.IdSuscriptor.ToString();
            TxtNombre.Text = suscriptor.Nombre;
            TxtApellido.Text = suscriptor.Apellido;
            TxtDireccion.Text = suscriptor.Direccion;
            TxtEmail.Text = suscriptor.Email;
            TxtTelefono.Text = suscriptor.Telefono.ToString();
            TxtNombreUsuario.Text = suscriptor.NombreUsuario;
            TxtPassword.Text = suscriptor.Password;
        }

        public void HabilitarCampos()
        {
            ID.Enabled = false;
            TxtNombre.Enabled = true;
            TxtApellido.Enabled = true;
            TxtDireccion.Enabled = true;
            TxtEmail.Enabled = true;
            TxtTelefono.Enabled = true;
            TxtNombreUsuario.Enabled = true;
            TxtPassword.Enabled = true;
        }
        public void DeshabilitarCampos()
        {
            TxtNombre.Enabled = false;
            TxtApellido.Enabled = false;
            TxtDireccion.Enabled = false;
            TxtEmail.Enabled = false;
            TxtTelefono.Enabled = false;
            TxtNombreUsuario.Enabled = false;
            TxtPassword.Enabled = false;

        }


        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarSuscriptor.aspx?NumeroDocumento=" + TxtNumeroDocumento.Text + "&TipoDoc=" + DropDownList1.SelectedItem.Value);





        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.OKCancel;
            DialogResult dr = System.Windows.Forms.MessageBox.Show("Acepta Registrar la Suscripcion", "", botones, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                suscriptor.IdSuscriptor = int.Parse(ID.Text);
                DateTime fechaActual = DateTime.Now;
                if (sus.InsertarSuscripcion(suscriptor, fechaActual.ToString()) == true)
                {
                    System.Windows.MessageBox.Show("Se registro la suscripcion");
                    Response.Redirect("Suscripcion.aspx");
                }
                else
                {
                    System.Windows.MessageBox.Show("ERROR No se pudo Registar");
                    Response.Redirect("Suscripcion.aspx");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Se Cancelo la Ssucripcion");
                Response.Redirect("Suscripcion.aspx");
            }

        }




        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarCampos();
            Response.Redirect("Suscripcion.aspx");

        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoSuscriptor.aspx");




        }

    }


}