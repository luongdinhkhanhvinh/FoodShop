<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Food_edit.aspx.cs" Inherits="FoodDoAn.admin.Food_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
         <div class="row">
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h2 text-gray-900 mb-4">CẬP NHẬT MÓN ĂN!</h1>
                    <br />
                </div>
                <div class="user">
                    <div class="form-group row">
                       
                        <div class=" col-lg-4 col-sm-4">
                            <asp:TextBox ID="txtName" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Tên Món"></asp:TextBox>
                        </div>

                        <div class="col-sm-4">
                            <asp:TextBox ID="txt_Description" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Miêu Tả Món Ăn"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_Price" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Giá Tiền"></asp:TextBox>
                        </div>
                    </div>
                    <br>
                    <div class="form-group row">

                        <div class="col-sm-4 mb-3 mb-sm-0">

                            <asp:TextBox ID="txt_Price_Promo" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Giá Khuyến Mãi"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">

                            <asp:TextBox ID="txt_thumb" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Thumb"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                           <%-- <asp:TextBox ID="txt_img" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Img"></asp:TextBox>--%>
                            <asp:Image ID="Image1" runat="server" Height="200px" Width="370px"/>
                            <asp:FileUpload ID="FileUpload1" runat="server" type="text" onchange="showImage(this)"/>
                        </div>
                    </div>
                    <br />
                    <div class="form-group row">
                        
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_unit" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Unit"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_percent_promo" runat="server" type="text" CssClass="form-control form-control-user" placeholder="percent_promo"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_rating" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Rating"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group row">
                        
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_sold" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Sold"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_point" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Point"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_type" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Type"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group row">
                        
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_status" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Status"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_UserName" runat="server" type="text" CssClass="form-control form-control-user" placeholder="UserName"></asp:TextBox>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox ID="txt_modified" runat="server" type="text" CssClass="form-control form-control-user" placeholder="Modified"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    
                    <div class="form-group row">
                        <div class="col-lg-12     col-sm-4  mb-3 mb-sm-0">
                            <asp:Button ID="btn_cap_nhat_food" runat="server" Text="Cập Nhật Món Ăn" CssClass="btn btn-primary btn-user btn-block" OnClick="btn_cap_nhat_food_Click" />
                        </div>

                        <hr>
                    </div>

                </div>
                <hr>

                <div class="text-center">
                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                </div>
                <div class="text-center">
                    <a class="small" href="login.html">Already have an account? Login!</a>
                </div>


                <div id="txtKQ" runat="server">KQ...</div>
            </div>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>

    <script type="text/javascript">
        function showImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .height(200)
                        .width(370);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function alertSuccess() {
            Swal.fire({
                icon: 'success',
                title: 'Cập Nhật Thành Công',

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
