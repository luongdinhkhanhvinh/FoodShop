using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;
namespace FoodDoAn.admin
{
    public partial class Food_Type_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                 string id = Request.QueryString["id"];
            FoodType ds = new FoodType(Convert.ToInt32(id));
                DataTable dSFoodType = ds.getId(Convert.ToInt32(id));
                txt_Ngay.Enabled = false;
                foreach (DataRow row in dSFoodType.Rows)
                {
                    txtName.Text = row["type_name"].ToString();
                    txt_pos.Text = row["type_pos"].ToString();
                    Image1.ImageUrl = @"img\" + row["type_img"].ToString();
                    //HiddenField1.Value = row["type_img"].ToString();
                    txt_status.Text = row["status"].ToString();
                    txt_username.Text = row["username"].ToString();
                    txt_Ngay.Text = row["modidied"].ToString();
                };
            }
        }

        protected void btn_capnhat_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/admin/img/");
            string id = Request.QueryString["id"];
            string type_name = txtName.Text;
            int type_pos = Convert.ToInt32(txt_pos.Text);
            DateTime modified = DateTime.Parse(txt_Ngay.Text);
            int status = Convert.ToInt32(txt_status.Text);
            string username = txt_username.Text;
            string filename = FileUpload1.FileName;
            //if (filename != "")
            //{
            //    string path = Server.MapPath("~/admin/img/");
            //    FileUpload1.SaveAs(path + filename);
            //}
            //else
            //{
            //     filename = Image1.ImageUrl;
            //}

            
            FileUpload1.SaveAs(path + filename);

            FoodType food_type = new FoodType(type_name, type_pos, filename, status, username, modified);


            if (food_type.updateFood(Convert.ToInt32(id)))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "key", "alertSuccess()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "alertError()", true);
            }
        }
    }
}