<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="Vista.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <% if (Request.QueryString["id"] != null) { %>
            <title>Modificar película</title>
    <% } else { %>
            <title>Agregar película</title>
    <% } %> 
    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center border border-3 border-dark rounded bg-light py-4 gap-3">
        <!-- Título -->
        <div class="col-7">
            <asp:Label runat="server" CssClass="form-label fw-medium" Text="Título:" AssociatedControlID="txbxTitle"></asp:Label>
            <asp:TextBox ID="txbxTitle" runat="server" CssClass="form-control" Required="true" OnTextChanged="VerifyInformation" AutoPostBack="true"></asp:TextBox>
        </div>

        <!-- Director -->
        <div class="col-7">
            <asp:Label runat="server" CssClass="form-label fw-medium" Text="Director:" AssociatedControlID="txbxDirector"></asp:Label>
            <asp:TextBox ID="txbxDirector" runat="server" CssClass="form-control" Required="true" OnTextChanged="VerifyInformation" AutoPostBack="true"></asp:TextBox>
        </div>

        <!-- Sinopsis -->
        <div class="col-7">
            <asp:Label runat="server" CssClass="form-label fw-medium" Text="Sinopsis:" AssociatedControlID="txbxSynopsis"></asp:Label>
            <asp:TextBox ID="txbxSynopsis" runat="server" TextMode="MultiLine" Rows="7" CssClass="form-control" style="resize:none;" Required="true" OnTextChanged="VerifyInformation" AutoPostBack="true"></asp:TextBox>
        </div>

        <!-- Fecha de estreno -->
        <div class="col-7">
            <asp:Label runat="server" CssClass="form-label fw-medium" Text="Fecha de estreno:" AssociatedControlID="txbxRelease"></asp:Label>
            <asp:TextBox ID="txbxRelease" runat="server" TextMode="Date" CssClass="form-control" Required="true" OnTextChanged="VerifyInformation" AutoPostBack="true"></asp:TextBox>
        </div>

        <!-- Calificación -->
        <div class="col-7 d-flex flex-column">
            <asp:Label runat="server" Text="Calificación:" CssClass="form-label fw-medium"></asp:Label>
            <div class="d-flex justify-content-between">
                <asp:RadioButton ID="rb1" runat="server" Text="1" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb2" runat="server" Text="2" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb3" runat="server" Text="3" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb4" runat="server" Text="4" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb5" runat="server" Text="5" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true" Checked="true"/>
                <asp:RadioButton ID="rb6" runat="server" Text="6" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb7" runat="server" Text="7" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb8" runat="server" Text="8" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb9" runat="server" Text="9" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <asp:RadioButton ID="rb10" runat="server" Text="10" GroupName="rbRating" CssClass="form-check" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
            </div>
        </div>

        <!-- Oscar -->
        <div class="col-7 d-flex align-items-center gap-2">
            <asp:Label runat="server" Text="¿Ganó algún Oscar?" AssociatedControlID="ckbxOscar" CssClass="form-label fw-medium"></asp:Label>
            <asp:CheckBox ID="ckbxOscar" runat="server" CssClass="input-check ms-3"/>
        </div>

        <!-- Botones -->
        <div class="col-7 d-flex gap-5">
            <% if (Request.QueryString["id"] != null) { %>
                <asp:Button ID="btModify" runat="server" Text="MODIFICAR" CssClass="btn btn-warning w-50" OnClick="Submit_Click"/>
            <% } else { %>
                <asp:Button ID="btAdd" runat="server" Text="AGREGAR" CssClass="btn btn-warning w-50" OnClick="Submit_Click"/>
            <% } %>
            <a href="Default.aspx" class="btn btn-warning w-50">CANCELAR</a>
        </div>
    </div>
</asp:Content>
