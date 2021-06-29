using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using static Desafio.Encriptar;
using Messages = Encode.Funciones.Message;
using System.Web.UI;

namespace Desafio
{
    public partial class Suscripcion : System.Web.UI.Page
    {
        SuscriptorNegocio sus = new SuscriptorNegocio();
        Suscriptor suscriptor = new Suscriptor();
       
        string key = "ABCabc123";

        protected void Page_Load(object sender, EventArgs e)
        {
            Label10.Visible = false;
            TxtDesencriptar.Visible = false;
            BtnDesencriptar.Visible = false;
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
            if (String.IsNullOrEmpty(TxtNumeroDocumento.Text) != true)
            {
                int digitos = (int)Math.Floor(Math.Log10(int.Parse(TxtNumeroDocumento.Text)) + 1);
                if (digitos == 8)
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
                            Response.Redirect("Suscripcion.aspx");
                        }
                    }


                    else
                    {

                        if (sus.ExisteSuscripcion(suscriptor) == true)
                        {

                            Messages.Show("El Suscriptor existe  en BD y tiene una Suscricion Vigente", "info", "Suscripcion");
                            LimpiarCampos();

                        }
                        else
                        {

                            Messages.Show("No tiene Suscripcion Vigente", "info", "Suscripcion");
                            CargarCampos();

                        }
                    }
                }
                else
                {

                    Messages.Show("Por favor colque el numero de documento correctamente", "warning");
                    LimpiarCampos();


                }
            }
            else
            {
                Messages.Show("Por favor cargue los campos", "error");

                LimpiarCampos();

            }

        }


        public void LimpiarCampos()
        {
            TxtNumeroDocumento.Text = "";
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
            BtnModificar.Visible = true;
            Label10.Visible = true;
            TxtDesencriptar.Visible = true;
            BtnDesencriptar.Visible = true;
            ID.Text = suscriptor.IdSuscriptor.ToString();
            TxtNombre.Text = suscriptor.Nombre;
            TxtApellido.Text = suscriptor.Apellido;
            TxtDireccion.Text = suscriptor.Direccion;
            TxtEmail.Text = suscriptor.Email;
            TxtTelefono.Text = suscriptor.Telefono;
            TxtNombreUsuario.Text = suscriptor.NombreUsuario;
            TxtPassword.Text = suscriptor.Password;
            TxtDesencriptar.Text = suscriptor.Password;
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
            if (TxtNumeroDocumento.Text == "")
            {
                Response.Redirect("NuevoSuscriptor.aspx");
            }





        }

        protected void BtnDesencriptar_Click(object sender, EventArgs e)
        {

            int TipoDocumento = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            long NumeroDocumento = long.Parse(TxtNumeroDocumento.Text);

            suscriptor = sus.ConsultarSuscriptor(TipoDocumento, NumeroDocumento);

            CargarCampos();
            TxtDesencriptar.Text = DesencriptarPassword(suscriptor.Password, key);



        }


        private bool validarDatos()
        {
            if (String.IsNullOrEmpty(TxtNombre.Text) == true ||
            String.IsNullOrEmpty(TxtApellido.Text) == true ||
            String.IsNullOrEmpty(TxtTelefono.Text) == true ||
            String.IsNullOrEmpty(TxtEmail.Text) == true ||
            String.IsNullOrEmpty(TxtPassword.Text) == true ||
            String.IsNullOrEmpty(TxtNombreUsuario.Text) == true ||
            String.IsNullOrEmpty(TxtNumeroDocumento.Text) == true)
            {

                return false;
            }
            else
            {
                return true;
            }
        }
        public void Redireccion()
        {
            Response.Redirect("Suscripcion.aspx");
        }

       
    }


}