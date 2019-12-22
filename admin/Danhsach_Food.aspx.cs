using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;
using System.Data;
using System.Data.SqlClient;
namespace FoodDoAn
{
    public partial class Danhsach_Food : System.Web.UI.Page
    {
        //public int PageNumber { get; private set; }
        DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            { 
                
                loadData();
            }
            if(TextBox1.Text == "")
            {
                Food m = new Food();
                dt = m.dataFood();
            }
        }

        protected void rptDSTV_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            
            if (e.CommandName == "edit")
            {
                string id = e.CommandArgument.ToString();
                string hash = Server.UrlEncode(id);

                Response.Redirect("~/Admin/Food_edit.aspx?id=" + hash);

            }
            if (e.CommandName == "delete")
            {

                string id = e.CommandArgument.ToString();
                Food m = new Food(Convert.ToInt32(id));

                if (m.delect())
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "delete()", true);
                    Response.Redirect("~/Admin/Danhsach_Food.aspx");
                }
            }
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            loadData();
        }
        public void loadData()
        {
            Food m = new Food();
            dt = m.dataFood();
            PagedDataSource pgitem = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(dt);
            pgitem.DataSource = dv;
            pgitem.AllowPaging = true;
            pgitem.PageSize = 5;
            pgitem.CurrentPageIndex = PageNumber;
            if (pgitem.PageCount > 1)
            {
                
                rptDSTV.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i <= pgitem.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                    rptDSTV.DataSource = pages;
                    rptDSTV.DataBind();
                }

            }
            else
            {
                rptDSTV.Visible = false;         
            }
            //flag = false;
            rptPages.DataSource = pgitem;
            rptPages.DataBind();
        }
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }

       
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {


            if (TextBox1.Text == "")
            {
                Food m = new Food();
                dt = m.dataFood();
               
                loadData();

            }
            else
            {
                Food f = new Food();
                dt = f.timKiem(TextBox1.Text); 
                loadData();
            }
        }
    }
}