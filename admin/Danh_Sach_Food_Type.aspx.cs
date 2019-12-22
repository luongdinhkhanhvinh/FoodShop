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
    public partial class Danh_Sach_Food_Type : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FoodType m = new FoodType();
                dt = m.dataFood();
                loadData();

            }
        }

        protected void rpt_Food_Type_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string id = e.CommandArgument.ToString();

                string hash = Server.UrlEncode(id);

                Response.Redirect("~/Admin/Food_Type_edit.aspx?id=" + hash);

            }
            if (e.CommandName == "delete")
            {

                string id = e.CommandArgument.ToString();
                Food m = new Food(Convert.ToInt32(id));

                if (m.delect())
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "delete()", true);
                    Response.Redirect("~/Admin/Danh_Sach_Food_Type.aspx");
                }
            }
            loadData();
        }
        public void loadData()
        {

            PagedDataSource pgitem = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(dt);
            pgitem.DataSource = dv;
            pgitem.AllowPaging = true;
            pgitem.PageSize = 3;
            pgitem.CurrentPageIndex = PageNumber;
            if (pgitem.PageCount > 1)
            {

                rptDS.Visible = true;

                if (!pgitem.IsLastPage)
                {
                    //LinkNext.NavigateUrl = 
                }
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i <= pgitem.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                    rptDS.DataSource = pages;
                    rptDS.DataBind();
                }

            }
            else
            {
                rptDS.Visible = false;
            }
            rpt_Food_Type.DataSource = pgitem;
            rpt_Food_Type.DataBind();

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
    }
}