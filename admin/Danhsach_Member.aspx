<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Danhsach_Member.aspx.cs" Inherits="FoodDoAn.danhsachsp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="<%=Page.ResolveUrl("~/admin/") %>vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <style type="text/css">
        .mb-4 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <!-- Page Heading -->
    <div class="card shadow mb-4">
            <div class="card-header py-3">
              <h6 class="m-0 font-weight-bold text-primary">DataTables Example</h6>
            </div>
            <div class="card-body">
              <div class="table-responsive">
                <table class="table table-bordered table-sm" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                    <tr>
                        <th>Tài Khoản</th>
                        <th>Mật Khẩu</th>
                        <th>Tên</th>
                        <th>Số Điện Thoại</th>
                        <th>Chức Vụ</th>
                        <th>Trạng Thái</th>
                        <th></th>
                    </tr>
                  </thead>
                  <tbody>
                     <asp:Repeater ID="rptDSTV" runat="server"   OnItemCommand="rptDSTV_ItemCommand">
                   
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("username")%></td>
                                    <td><%# Eval("pass")%></td>
                                    <td><%# Eval("name")%></td>
                                    <td><%# Eval("phone")%></td>
                                    <td><%# Eval("role")%></td>
                                    <td><%# Eval("status")%></td>
                                    <td>    
                                        <asp:Button ID="btn_edit" CausesValidation="false" CssClass="btn btn-warning" runat="server" Text="Sửa" CommandArgument= '<%#Eval("username") %>' CommandName="edit" />
                                         <asp:Button ID="btn_delete" CausesValidation="false" CssClass="btn btn-danger" runat="server" Text="Xóa" CommandArgument= '<%#Eval("username") %>' OnClientClick="return confirm('hahaha')"  CommandName="delete"  />
                                    </td>
                                </tr>
                            </ItemTemplate>
                         </asp:Repeater>
                  </tbody>
                </table>
              </div>
                <br />
                <div style="overflow: hidden; text-align: center;">
                

                <asp:Repeater ID="Repeater1" runat="server"
                    OnItemCommand="rptDSTV_ItemCommand">
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
     
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Food_SaleConnectionString2 %>" SelectCommand="SELECT * FROM [member]"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
    <!-- Page level plugins -->
    
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>  

    <!-- Page level custom scripts -->
    <script src="<%=Page.ResolveUrl("~/admin/") %>js/demo/datatables-demo.js"></script>
    <script >
        function delete()
        {
            swal.fire({
                Swal.fire({
                icon: 'success',
                title: 'Thêm Thành Công',
            })
        }

        </script>
    
</asp:Content>
