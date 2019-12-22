using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodDoAn.HttpCode;
namespace FoodDoAn
{

    public partial class danhsachsp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadData();
            }
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   

        protected void rptDSTV_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
            if (e.CommandName == "edit")
            {
                string username = e.CommandArgument.ToString();

                string hash = Server.UrlEncode(username);
                
                Response.Redirect("~/Admin/member_edit.aspx?username="+ hash);
                
            }
            if (e.CommandName == "delete")
            {
                
                string UserName = e.CommandArgument.ToString();
                Member m = new Member(UserName);

                if(m.delect())
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "concac", "delete()", true);
                    Response.Redirect("~/Admin/danhsachsp.aspx");
                }
            }
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            loadData();
        }

        public void loadData()
        {
            DataTable dt = new DataTable();
            Member m = new Member();
            dt = m.dataMember();
            PagedDataSource pgitem = new PagedDataSource();
            System.Data.DataView dv = new System.Data.DataView(dt);
            pgitem.DataSource = dv;
            pgitem.AllowPaging = true;
            pgitem.PageSize = 5 ;
            pgitem.CurrentPageIndex = PageNumber;
            if (pgitem.PageCount > 1)
            {
                Repeater1.Visible = true;

                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i <= pgitem.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                    Repeater1.DataSource = pages;
                    Repeater1.DataBind();
                }
                
            }
            else
            {
                Repeater1.Visible = false;
            }
            rptDSTV.DataSource = pgitem;
            rptDSTV.DataBind();
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