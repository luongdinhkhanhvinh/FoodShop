    <%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Danhsach_Food.aspx.cs" Inherits="FoodDoAn.Danhsach_Food" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <!-- Page Heading -->
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">DataTables Example</h6>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered table-responsive-lg " id="dataTable" width="100%" cellspacing="0">
                    <thead class=".thead-dark">
                        <tr>
                            <th>ID</th>
                            <th>Tên Món</th>
                            <th>Mô Tả</th>
                            <th>Giá</th>
                            <th>Price Promo</th>
                            <th>Thumb</th>
                            <th>img</th>
                            <th>unit</th>
                            <th>Percent Promo</th>
                            <th>Rating</th>
                            <th>Sold</th>
                            <th>Point</th>
                            <th>Type</th>
                            <th>Status</th>
                            <th>UserName</th>
                            <th>Modified</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--                     //OnItemCommand="rptDSTV_ItemCommand--%>
                        <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptDSTV_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("id")%></td>
                                    <td><%# Eval("name")%></td>
                                    <td><%# Eval("description")%></td>
                                    <td><%# Eval("price")%></td>
                                    <td><%# Eval("price_promo")%></td>
                                    <td><%# Eval("thumb")%></td>
                                    <td>
                                        <%--//<%# Eval("img")%>--%>
                                        <asp:Image ID="img" ImageUrl='<%# "img/" + Eval("img")%>' Height="100" Width="100" runat="server" />
                                    </td>
                                    <td>
                                        <%# Eval("unit")%></td>
                                    <td><%# Eval("percent_promo")%></td>
                                    <td><%# Eval("rating")%></td>
                                    <td><%# Eval("sold")%></td>
                                    <td><%# Eval("point")%></td>
                                    <td><%# Eval("type")%></td>
                                    <td><%# Eval("status")%></td>
                                    <td><%# Eval("username")%></td>
                                    <td><%# Eval("modified")%></td>
                                    <td>
                                        <asp:Button ID="btn_edit" CausesValidation="false" CssClass="btn btn-warning" runat="server" Text="Sửa" CommandArgument='<%#Eval("id") %>' CommandName="edit"  />

                                        <asp:Button ID="btn_delete" CausesValidation="false" CssClass="btn btn-danger" runat="server" Text="Xóa" CommandArgument='<%#Eval("id") %>' CommandName="delete" />
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                    </tbody>
                </table>

            </div>
            <br />
            <div style="overflow: hidden; text-align: center;">

                <asp:Repeater ID="rptDSTV" runat="server"
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
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Food_SaleConnectionString2 %>" SelectCommand="SELECT * FROM [food]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: '/Table/',
                dataType: "json",
                type: "POST",
                contentType: 'application/json; charset=utf-8',
                data: {},
                success: function (data) {
                    var tr;
                    console.log(data);
                    for (var i = 0; i < data.length; i++) {
                        tr = tr + "<tr>";
                        tr = tr + "<td>" + data[i].id;
                        tr = tr + "<td>" + data[i].name;
                        tr = tr + "<td>" + data[i].description;
                        tr = tr + "<td>" + data[i].price;
                        tr = tr + "<td>" + data[i].price_promo;
                        tr = tr + "<td>" + data[i].thumb;
                        tr = tr + "<td>" + data[i].img;
                        tr = tr + "<td>" + data[i].unit;
                        tr = tr + "<td>" + data[i].percent_promo;
                        tr = tr + "<td>" + data[i].rating;
                        tr = tr + "<td>" + data[i].sold;
                        tr = tr + "<td>" + data[i].point;
                        tr = tr + "<td>" + data[i].type;
                        tr = tr + "<td>" + data[i].status;
                        tr = tr + "<td>" + data[i].username;
                        tr = tr + "<td>" + data[i].modified;
                        tr = tr + "</tr>";
                    }
                    $('#rptDSTV').append(tr);

                }
            })
        });
    </script>
</asp:Content>
