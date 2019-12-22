using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;
namespace FoodDoAn
{
    public partial class Food_Type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_Ngay.Text = DateTime.Now.ToString();
            txt_Ngay.Enabled = false;
        }

        protected void btn_Them_Click(object sender, EventArgs e)
        {
            string type_name = txtName.Text;
            int type_pos = Convert.ToInt32(txt_pos.Text);
            DateTime modified = DateTime.Parse(txt_Ngay.Text);
            int status = Convert.ToInt32(txt_status.Text);
            string username = txt_username.Text;
            string path = Server.MapPath("~/admin/img/");
            string filename = FileUpload1.FileName;
            FileUpload1.SaveAs(path + filename);
            
            FoodType food = new FoodType(type_name,type_pos,filename,status,username,modified);

            if (food.AddFoodType())
            {

                ClientScript.RegisterStartupScript(this.GetType(), "randomkey", "alertSuccess()", true);
            }
            else
            {


            }
        }
    }
}