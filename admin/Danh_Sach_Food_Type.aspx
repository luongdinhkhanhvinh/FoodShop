<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Danh_Sach_Food_Type.aspx.cs" Inherits="FoodDoAn.admin.Danh_Sach_Food_Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
     <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">DataTables Example</h6>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" ></asp:TextBox>    
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered table-responsive-lg " id="dataTable" width="100%" cellspacing="0">
                    <thead class=".thead-dark">
                        <tr>
                            <th>ID</th>
                            <th>Tên Món</th>
                            <th>Type_Pos</th>
                            <th>Hình Món</th>
                            <th>Trạng Thái</th>
                            <th>UserName</th>
                            <th>Ngày</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        
                        <asp:Repeater ID="rpt_Food_Type" runat="server" OnItemCommand="rpt_Food_Type_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("type_id")%></td>
                                    <td><%# Eval("type_name")%></td>
                                    <td><%# Eval("type_pos")%></td>
                                    <td>
                                        <%--//<%# Eval("img")%>--%>
                                        <asp:Image ID="img" ImageUrl='<%# "img/" + Eval("type_img")%>' Height="100" Width="100" runat="server" />
                                    </td>
                                    
                                    <td><%# Eval("status")%></td>
                                    <td><%# Eval("username")%></td>
                                    <td><%# Eval("modidied")%></td>
                                    <td>
                                        <asp:Button ID="btn_edit" CausesValidation="false" CssClass="btn btn-warning" runat="server" Text="Sửa" CommandArgument='<%#Eval("type_id") %>' CommandName="edit"  />

                                        <asp:Button ID="btn_delete" CausesValidation="false" CssClass="btn btn-danger" runat="server" Text="Xóa" CommandArgument='<%#Eval("type_id") %>' CommandName="delete" />
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                    </tbody>
                </table>

            </div>
            <br />
            <div style="overflow: hidden; text-align: center;">

                <asp:Repeater ID="rptDS" runat="server"
                    OnItemCommand="rpt_Food_Type_ItemCommand">
                    <ItemTemplate>

                        <asp:LinkButton ID="btnPage"
                            Style="margin-left: 20px; color: darkgray; font: 12pt tahoma;"
                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                            runat="server"><%# Container.DataItem %>
                        </asp:LinkButton>

                    </ItemTemplate>

                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
</asp:Content>
