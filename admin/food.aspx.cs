using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;

namespace FoodDoAn.admin
{
    public partial class food : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_modified.Text = DateTime.Now.ToString();
            txt_modified.Enabled = false;
            
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //path file img
            string path = Server.MapPath("~/admin/img/");
            string name = txtName.Text;
            string description = txt_Description.Text;
            decimal price = decimal.Parse(txt_Price.Text);
            decimal price_promo = decimal.Parse(txt_Price_Promo.Text);
            string thumb = txt_thumb.Text;
            string filename = FileUpload1.FileName;
            string unit = txt_unit.Text;
            decimal percent_promo = decimal.Parse(txt_percent_promo.Text);
            int rating = int.Parse(txt_rating.Text);
            int sold = int.Parse(txt_sold.Text);
            decimal point = decimal.Parse(txt_point.Text);
            int type = int.Parse(txt_type.Text);
            int status = int.Parse(txt_status.Text);
            string username = txt_UserName.Text;
            FileUpload1.SaveAs(path + filename);
            string modified = txt_modified.Text;
            Food food = new Food(name,description,price,price_promo,thumb,filename,unit,percent_promo,rating,sold,point,type,status,username,modified);

            if (food.AddFood())
            {

                ClientScript.RegisterStartupScript(this.GetType(), "randomkey", "alertSuccess()", true);
            }
            else
            {

                
            }        
        }
    }
}