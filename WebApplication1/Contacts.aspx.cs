using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Contacts : System.Web.UI.Page
    {
        string apiUrl = string.Empty;
        WebClient client = new WebClient();
        public Contacts()
        {
            apiUrl = "http://localhost:33072/api/Contacts";
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }
        private void PopulateGridView()
        {
            try
            {
                string json = client.DownloadString(apiUrl);

                grdContacts.DataSource = (new JavaScriptSerializer()).Deserialize<List<ContactModel>>(json);
                grdContacts.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdContacts_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                try
                {
                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    Label lblId = (Label)row.FindControl("lblID");
                    Response.Redirect("~/ContactDetails.aspx?id=" + lblId.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ContactDetails.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in grdContacts.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");

                    if (chk != null && chk.Checked)
                    {
                        Label lblId = (Label)gvrow.FindControl("lblID");
                        string json = client.UploadString(apiUrl + "/" + lblId.Text, "DELETE", lblId.Text);
                    }
                }
                PopulateGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}