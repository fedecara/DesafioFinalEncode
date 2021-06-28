<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suscripcion.aspx.cs" Inherits="Desafio.Suscripcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Suscripcion</title>
    <link rel="Stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" />

    <script src="C:\Users\fedec\OneDrive\Escritorio\GitHub\DesafioFinalEncode\Desafio\Scripts\Sweet.js"></script>

    <style>
        #HomepageBody {
            background-image: url("/Img/Fondo.jpg" );
            background-repeat: no-repeat;
            background-position: center;
        }

        body {
        
            margin-left: 60px;
            margin-right:60px;
            margin-top:50px;
            align-items: center;
            justify-content: center;
           
        }

        label {
            font-weight: bold;
        }

        h1 {
            text-shadow: 3px 3px 1px red;
            text-align: center;
        }

        #BtnBuscar {
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            margin-top: 2px;
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
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            margin-top: 2px;
            background-color: dodgerblue;
            margin-top: 2px;
        }

        #BtnNuevo {
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            margin-top: 2px;
            background-color: deepskyblue;
            margin-top: 2px;
        }

        #BtnModificar {
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            margin-top: 2px;
            background-color: dodgerblue;
            margin-top: 2px;
        }

        #BtnDesencriptar {
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            margin-top: 2px;
            background-color: dodgerblue;
            margin-top: 2px;
            margin-left: 2px;
        }

        #BtnCancelar {
            padding: .375rem .75rem;
            border-radius: .25rem;
            color: #fff;
            transition: background-color .15s ease-in-out;
            margin-top: 2px;
            background-color: red;
            margin-top: 2px;
            margin-left: 2px;
        }

        #botones {
            margin-top: 10px;
        }
    </style>
</head>
<body id="HomepageBody">
    <h1>Suscripcion</h1>
    <h5>Para Realizar la suscripcion complete los siguientes datos</h5>
    <div class="conteiner">

        <form id="formBuscar" runat="server" class="form-horizontal">

            <hr />
            <p>Buscar Suscriptor</p>
            <div class="row" id="BuscarSuscriptor">
                <div class="col">
                    <asp:Label ID="Label1" class="Label" runat="server" Text="Tipo de Documento"></asp:Label><br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="140px"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:Label ID="Label2" runat="server" Text="Numero de Documento"></asp:Label><br />
                    <asp:TextBox ID="TxtNumeroDocumento" type="number" runat="server" Height="30px" Width="140px" placeholder="XXXXXXXX" TabIndex="1"></asp:TextBox>

                </div>
                <div class="col">
                    <asp:Button ID="BtnBuscar" runat="server" OnClick="btnBtnBuscar" Text="Buscar" />
                    <asp:TextBox ID="ID" runat="server"></asp:TextBox>

                </div>
            </div>

            <hr />

            <div class="row" id="DatosSuscriptor">
                <p>Datos Suscriptor</p>
                <div class="col">
                    <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label><br />
                    <asp:TextBox ID="TxtNombre" type="text" Enabled="false" runat="server" Height="30px" Width="140px"></asp:TextBox><br />
                    <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label><br />
                    <asp:TextBox ID="TxtDireccion" Enabled="false" runat="server" Height="30px" Width="140px"></asp:TextBox><br />
                    <asp:Label ID="Label6" runat="server" Text="Telefono"></asp:Label><br />
                    <asp:TextBox ID="TxtTelefono" type="number" Enabled="false" runat="server" Height="30px" Width="140px" MinLenght="10" MaxLength="10"></asp:TextBox><br />
                </div>
                <div class="col">
                    <asp:Label ID="Label4" runat="server" Text="Apellido"></asp:Label><br />
                    <asp:TextBox ID="TxtApellido" Enabled="false" runat="server" Height="30px" Width="140px"></asp:TextBox><br />
                    <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label><br />
                    <asp:TextBox ID="TxtEmail" type="text" Enabled="false" runat="server" Height="30px" Width="140px"></asp:TextBox><br />

                </div>
                <div class="col">
                    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" OnClick="BtnModificar_Click" /><br />
                    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" OnClick="BtnNuevo_Click" /><br />
                </div>
            </div>

            <hr />
            <div class="row" id="Login">
                <div class="col">
                    <asp:Label ID="Label8" runat="server" Text="Nombre de Usuario"></asp:Label><br />
                    <asp:TextBox ID="TxtNombreUsuario" Enabled="false" runat="server" Height="30px" Width="140px"></asp:TextBox><br />

                </div>
                <div class="col">
                    <asp:Label ID="Label9" runat="server" Text="Password"></asp:Label><br />
                    <asp:TextBox ID="TxtPassword" Enabled="false" Type="password" runat="server" Height="30px" Width="140px"></asp:TextBox><br />
                </div>
                <div class="col">
                    <asp:Label ID="Label10" runat="server" Text="Password Encriptado"></asp:Label><br />
                    <asp:TextBox ID="TxtDesencriptar" Enabled="false" runat="server" Height="30px" Width="140px"></asp:TextBox>
                    <asp:Button ID="BtnDesencriptar" runat="server" Text="Desencriptar" OnClick="BtnDesencriptar_Click" />
                </div>
            </div>
            <div class="row " id="botones">
                <div class="col">
                    <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click" />
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
                </div>
            </div>

        </form>
    </div>
</body>
</html>
