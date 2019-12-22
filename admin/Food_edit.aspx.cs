using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;
using System.Data;
using System.Data.SqlClient;
namespace FoodDoAn.admin
{
    public partial class Food_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                Food ds = new Food(Convert.ToInt32(id));
                
                DataTable dsuser = ds.getId(Convert.ToInt32(id));

                foreach (DataRow row in dsuser.Rows)
                {
                    txtName.Text = row["name"].ToString();
                    txt_Description.Enabled = false;
                    txt_Description.Text = row["description"].ToString();
                    txt_Price.Text = row["price"].ToString();          
                    txt_Price_Promo.Text = row["price_promo"].ToString();
                    txt_thumb.Text = row["thumb"].ToString();
                    Image1.ImageUrl = @"img\"+ row["img"].ToString();
                    txt_unit.Text = row["unit"].ToString();
                    txt_percent_promo.Text = row["percent_promo"].ToString();
                    txt_rating.Text = row["rating"].ToString();
                    txt_sold.Text = row["sold"].ToString();
                    txt_point.Text = row["point"].ToString();
                    txt_type.Text = row["type"].ToString();
                    txt_status.Text = row["status"].ToString();
                    txt_UserName.Text = row["username"].ToString();
                    txt_modified.Text = row["modified"].ToString();

                };
            }
        }

        protected void btn_cap_nhat_food_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/admin/img/");
            
            string name = txtName.Text;
            string description = txt_Description.Text;
            decimal price = decimal.Parse(txt_Price.Text);
            decimal price_promo = decimal.Parse(txt_Price_Promo.Text);
            string thumb = txt_thumb.Text;
            string img = FileUpload1.FileName;
            string unit = txt_unit.Text;
            decimal percent_promo = decimal.Parse(txt_percent_promo.Text);
            int rating = int.Parse(txt_rating.Text);
            int sold = int.Parse(txt_sold.Text);
            decimal point = decimal.Parse(txt_point.Text);
            int type = int.Parse(txt_type.Text);
            int status = int.Parse(txt_status.Text);
            string username = txt_UserName.Text;
            string modified = txt_modified.Text;
            int id = int.Parse(Request.QueryString["id"]);
            FileUpload1.SaveAs(path + img);
            Food food_edit = new Food(
name, description, price, price_promo, thumb, img, unit, percent_promo, rating, sold, point, type, status, username, modified);

            if (food_edit.updateFood(id))
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