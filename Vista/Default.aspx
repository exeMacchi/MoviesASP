<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MoviƎ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="alertEmtpy" runat="server" CssClass="alert alert-primary" Visible="false">
        <h2 class="alert-heading">¡Oops! parece que no hay películas :(</h2>
        <p>Añada algunas películas para poder ver su información en un formato tabla.<p>
    </asp:Panel>

    <asp:GridView ID="gvMovies" 
                  runat="server"
                  CssClass="col table table-bordered"
                  HeaderStyle-CssClass="table-dark text-center"
                  RowStyle-CssClass="table-light align-middle"
                  AutoGenerateColumns="false"
                  DataKeyNames="ID"
                  OnRowDataBound="gvMovies_RowDataBound"
                  OnSelectedIndexChanged="gvMovies_SelectedIndexChanged"
                  OnRowDeleting="gvMovies_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Título" DataField="Title"/>
            <asp:BoundField HeaderText="Director" DataField="Director"/>
            <asp:BoundField HeaderText="Fecha de estreno" DataField="Release.Year" ItemStyle-CssClass="text-center"/>
            <asp:BoundField HeaderText="Sinopsis" DataField="Synopsis" ItemStyle-CssClass="w-50"/>
            <asp:BoundField HeaderText="Calificación" DataField="Rating" ItemStyle-CssClass="text-center" />
            <asp:TemplateField HeaderText="Oscar">
                <ItemTemplate>
                    <asp:CheckBox ID="ckbxOscar" runat="server" Enabled="false" Checked='<%# Eval("Oscar") %>' CssClass="d-block text-center"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Editar" SelectText="" ShowSelectButton="true" ItemStyle-CssClass="text-center" ControlStyle-CssClass="bi bi-pencil-square text-dark fs-4"/>
            <asp:CommandField HeaderText="Eliminar" DeleteText="" ShowDeleteButton="true" ItemStyle-CssClass="text-center" ControlStyle-CssClass="bi bi-trash-fill text-dark fs-4"/>
        </Columns>
    </asp:GridView>
</asp:Content>
