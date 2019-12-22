using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;
using System.Data;
namespace FoodDoAn.admin
{
    public partial class member_edit : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request.QueryString["username"];
                Member ds = new Member(name);

                DataTable dsuser = ds.getUserName(name);
                foreach (DataRow row in dsuser.Rows)
                {
                    txtName.Text = row["name"].ToString();
                    txtUserName.Enabled = false;
                    txtUserName.Text = row["username"].ToString();
                    txtPassword.Text = row["pass"].ToString();
                    txtPassword.Enabled = false;
                    txtPhone.Text = row["phone"].ToString();

                    ddl_user.SelectedValue = row["role"].ToString();
                    ddl_status.SelectedValue = row["status"].ToString();


                };
            }
            if (Session["check"] != null)
            {
                Response.Redirect("~/Admin/danhsachsp.aspx");
            }
            
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //string name = Request.QueryString["username"];
            string username = txtUserName.Text;
            string pass = txtPassword.Text;
            string name =  txtName.Text;
            string phone = txtPhone.Text;
            int role = Convert.ToInt32(ddl_user.SelectedValue);
            int status = Convert.ToInt32(ddl_status.SelectedValue);
            Member edit_member = new Member(username,name,pass,phone,role,status);
            if (edit_member.updateUser())
            {
                 
                ClientScript.RegisterStartupScript(this.GetType(), "randomkey", "alertSuccess()" , true);
                //Session["check"] = "admin";
            }

        }
    }
}