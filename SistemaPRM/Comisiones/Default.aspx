<%@ Page Title="" Language="C#" MasterPageFile="~/Midas.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Comisiones_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1"></div>
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
            <asp:GridView ID="gridComInd" runat="server" CssClass="table-hover">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgVer" runat="server" ImageUrl="../images/icons/view.png" CssClass="Botones" CommandName="verFolio" ToolTip="Ver Folio" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField HeaderText="Folio" DataTextField="dataFolio" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

