<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="FoodDoAn.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h2 text-gray-900 mb-4">THÊM THÀNH VIÊN</h1>
                    <br />
                </div>
                
                    <div class="user">
                        <div class="form-group row">
                            <div class=" col-lg-4 col-sm-4">
                                <asp:TextBox ID="txtName" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Tên"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="rfvName" runat="server" CssClass="text-danger " ErrorMessage="Bạn Chưa Nhập Name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4">
                                <asp:TextBox ID="txtUserName" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Tài Khoản"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="rfvUserName" runat="server" ErrorMessage="Bạn Chưa Nhập User Name" ControlToValidate="txtUserName" CssClass="text-danger  "></asp:RequiredFieldValidator><br />
                                <asp:RegularExpressionValidator ID="revUserName" runat="server" ErrorMessage="Bạn Phải Nhập Chữ" ValidationExpression="^[a-zA-Z\\s]+\w{3,20}$" ControlToValidate="txtUserName" CssClass="text-danger"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-4  mb-3 mb-sm-0">
                                <asp:TextBox ID="txtPhone" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Số Điện Thoại"></asp:TextBox>
                                <asp:RegularExpressionValidator ValidationGroup="vsNotification" ID="revPhone" runat="server" ErrorMessage="Bạn Phải Nhập 10 số" ControlToValidate="txtPhone" ValidationExpression="[0-9]{10}" CssClass="text-danger  "></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">

                            <div class="col-sm-6 mb-3 mb-sm-0">

                                <asp:TextBox ID="txtPassword" runat="server" type="password" CssClass="form-control form-control-user" placeholder="Mật Khẩu"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="rvPass" runat="server" ErrorMessage="Bạn Chưa Nhập Password" ControlToValidate="txtPassword" CssClass="text-danger  "></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ValidationGroup="vsNotification" ID="revPassword" runat="server" ErrorMessage="Mật Khẩu 8 kí tự và có 1 Chữ và 1 Số" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" CssClass="text-danger "></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-6  mb-3 mb-sm-0">

                                <asp:TextBox ID="txtRepass" runat="server" type="password" CssClass="form-control form-control-user" placeholder="Nhập Lại Mật Khẩu"></asp:TextBox>
                                <asp:CompareValidator ValidationGroup="vsNotification" ID="cvRepass" runat="server" ErrorMessage="rePass Chưa giống pass" ControlToCompare="txtPassword" ControlToValidate="txtRepass" Type="String" CssClass="text-danger "></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <asp:DropDownList ID="ddl_status" runat="server" CssClass="form-control form-control-user">
                                    <asp:ListItem Enabled="true">Trạng Thái</asp:ListItem>
                                    <asp:ListItem Value="0">Ngừng Hoạt Động</asp:ListItem>
                                    <asp:ListItem Value="1">Đang Hoạt Động</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class=" col-lg-8  col-sm-4 mb-3 mb-sm-0">
                                <asp:DropDownList ID="ddl_user" runat="server" CssClass="form-control form-control-user">
                                    <asp:ListItem Enabled="true">--Role--</asp:ListItem>
                                    <asp:ListItem Value="0">User</asp:ListItem>
                                    <asp:ListItem Value="1">Admin</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row">
                            <div class="col-lg-12     col-sm-4  mb-3 mb-sm-0">
                                <asp:Button ValidationGroup="vsNotification" ID="btn_register" runat="server" Text="Thêm Thành Viên" CssClass="btn btn-primary btn-user btn-block" OnClick="btn_register_Click" />
                            </div>
                            <br>
                            <hr>
                        </div>

                    </div>
                <hr />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>

    <script>
       
        function alertSuccess() {
            Swal.fire({
                icon: 'success',
                title: 'Thêm Thành Công',
            })
        }
        function alertError() {
            Swal.fire({
                icon: 'error',
                title: 'Tài Khoản Đã Tồn Tại',      
                text: 'Vui Lòng Nhập Lại Tài Khoản',
                
            })
        }
    </script>
</asp:Content>
