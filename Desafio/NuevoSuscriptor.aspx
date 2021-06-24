<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoSuscriptor.aspx.cs" Inherits="Desafio.NuevoSuscriptor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Suscripcion</title>
    <link rel="Stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" />

    <style>
        body {
            background-color: #F2F3F4
        }

        label {
            font-weight: bold
        }

        #BtnBuscar {
            background-color: forestgreen;
            margin-top: 2px;
        }

        #BtnAceptar {
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            background-color: forestgreen;
            margin-top: 2px;
        }

        #BtnModificar {
            background-color: dodgerblue;
            margin-top: 2px;
        }

        #BtnNuevo {
            background-color: deepskyblue;
            margin-top: 2px;
        }
    </style>
</head>
<body>
    <h1>Suscripcion</h1>
    <h3>Alta de Suscriptor</h3>
    <div class="conteiner">

        <form id="formBuscar" runat="server" class="form-horizontal">

            <hr />
            <p>Buscar Suscriptor</p>
            <div class="row" id="BuscarSuscriptor">
                <div class="col">
                    <asp:Label ID="Label1" class="Label" runat="server" Text="Tipo de Documento"></asp:Label><br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="140px" required="required"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:Label ID="Label2" runat="server" Text="Numero de Documento" placeholder="XXXXXXXX"></asp:Label><br />
                    <asp:TextBox ID="TxtNumeroDocumento" type="number" runat="server" Height="30px" Width="140px" required="required"></asp:TextBox>
              
                </div>
                <div class="col">
                    <asp:Button ID="BtnBuscar" runat="server"  Text="Buscar" />
                    

                </div>
            </div>

            <hr />

            <div class="row" id="DatosSuscriptor">
                <p>Datos Suscriptor</p>
                <div class="col">
                    <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label><br />
                    <asp:TextBox ID="TxtNombre" Enabled="false" runat="server" Height="30px" Width="140px" placeholder="Ingrese el Nombre" required="required"></asp:TextBox><br />
                    <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label><br />
                    <asp:TextBox ID="TxtDireccion" Enabled="false" runat="server" Height="30px" Width="140px" placeholder="Ingrese Domicilio" required="required"></asp:TextBox><br />
                    <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label><br />
                    <asp:TextBox ID="TxtTelefono" Enabled="false" runat="server" Height="30px" Width="140px" placeholder="Ingrese el Telefono" required="required"></asp:TextBox><br />
                </div>
                <div class="col">
                    <asp:Label ID="Label4" runat="server" Text="Apellido"></asp:Label><br />
                    <asp:TextBox ID="TxtApellido" Enabled="false" runat="server" Height="30px" Width="140px" placeholder="Ingrese el Apellido" required="required"></asp:TextBox><br />
                    <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label><br />
                    <asp:TextBox ID="TxtEmail" Enabled="false" runat="server" Height="30px" Width="140px" placeholder="Ingrese el Email" required="required"></asp:TextBox><br />

                </div>
                <div class="col">
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar"/><br />
                    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" /><br />
                </div>
            </div>

            <hr />
            <div class="row" id="Login">
                <div class="col">
                    <asp:Label ID="Label8" runat="server" Text="Nombre de Usuario"></asp:Label><br />
                    <asp:TextBox ID="TxtNombreUsuario" Enabled="false" runat="server" Height="30px" Width="140px" required="required"></asp:TextBox><br />
                    <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click"  />
                    
                    
                </div>
                <div class="col">
                    <asp:Label ID="Label9" runat="server" Text="Password" ></asp:Label><br />
                    <asp:TextBox ID="TxtPassword" Enabled="false" Type="password" runat="server" Height="30px" Width="140px" required="required"></asp:TextBox><br />
                </div>
                <div class="col">
                </div>
            </div>


        </form>
    </div>
</body>
</html>

