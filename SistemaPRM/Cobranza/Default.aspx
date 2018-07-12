<%@ Page Title="" Language="C#" MasterPageFile="~/Midas.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Comisiones_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="controlador" runat="server" ActiveViewIndex="0">
        <asp:View ID="">
            <!-- com-->

        </asp:View>
        <asp:View ID="">
            <!-- por Periodo-->
        </asp:View>
        <asp:View>
            <!--  -->
        </asp:View>
    </asp:MultiView>
</asp:Content>

