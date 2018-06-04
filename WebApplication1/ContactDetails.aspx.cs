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
    public partial class ContactDetails : System.Web.UI.Page
    {
        string apiUrl = string.Empty;
        WebClient client = new WebClient();
        public ContactDetails()
        {
            apiUrl = "http://localhost:33072/api/Contacts";
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlStatus.Items.Add("Active");
                ddlStatus.Items.Add("InActive");
                if (Request.QueryString["id"] != null)
                {
                    Session["id"] = Convert.ToInt32(Request.QueryString["id"]);
                    loadContactDetails(Convert.ToInt32(Session["id"]));
                }
            }


        }

        private void loadContactDetails(int id)
        {
            try
            {
                string json = client.DownloadString(apiUrl + "/" + Session["id"]);

                ContactModel contact = new ContactModel();
                contact = (new JavaScriptSerializer()).Deserialize<ContactModel>(json);
                txtFirstName.Text = contact.firstName;
                txtLastName.Text = contact.lastName;
                txtEmail.Text = contact.email;
                txtphno.Text = contact.phoneNumber;
                ddlStatus.SelectedValue = contact.status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_SaveClick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["id"]) > 0)
            {
                Edit();
                Session.Remove("id");
            }
            else
            {
                Save();
            }
            Response.Redirect("Contacts.aspx");
        }

        protected void btn_CancelClick(object sender, EventArgs e)
        {
            Response.Redirect("Contacts.aspx");
        }

        private void Save()
        {
            try
            {
                object input = new
                {

                    firstName = txtFirstName.Text.Trim(),
                    lastName = txtLastName.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    phoneNumber = txtphno.Text.Trim(),
                    status = ddlStatus.SelectedValue.ToString()
                };
                string inputJson = (new JavaScriptSerializer()).Serialize(input);

                string json = client.UploadString(apiUrl, inputJson);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Edit()
        {
            try
            {
                object input = new
                {
                    id = Convert.ToInt32(Session["id"]),
                    firstName = txtFirstName.Text.Trim(),
                    lastName = txtLastName.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    phoneNumber = txtphno.Text.Trim(),
                    status = ddlStatus.SelectedValue.ToString()
                };
                string inputJson = (new JavaScriptSerializer()).Serialize(input);

                string json = client.UploadString(apiUrl + "/" + Session["id"], "PUT", inputJson);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}