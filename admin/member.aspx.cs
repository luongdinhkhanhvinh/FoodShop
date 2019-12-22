using FoodDoAn.HttpCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodDoAn
{   
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //string firstName = txtFirstName.Text;
            string name = txtName.Text;
            string username = txtUserName.Text;
            //string email = txtEmail.Text;8
            string phone = txtPhone.Text;
            string pass = txtPassword.Text;
            int role = Convert.ToInt32(ddl_user.SelectedValue);
            int status = Convert.ToInt32(ddl_status.SelectedValue);
            Member member = new Member(username, name, pass, phone, role, status);

            if (member.addMember())
            {

                ClientScript.RegisterStartupScript(this.GetType(), "randomkey", "alertSuccess()", true);
            }
            else if(member.checkUser(username))
            {
                
                ClientScript.RegisterStartupScript(this.GetType(), "randomkey", "alertError()", true);
            }
            else
            {
               
                ClientScript.RegisterStartupScript(this.GetType(), "randomkey", "alertError()", true);
            }


        }
        
    }
}