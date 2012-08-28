using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace OrPgKb
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			SetUserName(Request.Cookies["user"]);
			SetCateUser();
			//lstCate.SelectedValue = (string)Session["SelCate"];
			//lstUser.SelectedValue = (string)Session["SelUser"];
			tbSearch.Text = (string)Session["Search"];
		}
		public void SetCateUser()
		{
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				lstCate.Items.Clear();
				lstUser.Items.Clear();
				lstCate.Items.Add("[全て]");
				foreach (string cate in dc.Categories())
					lstCate.Items.Add(cate);
				foreach (string usr in dc.Users())
					lstUser.Items.Add(usr);
			}
		}
		public void SetUserName(HttpCookie hc)
		{
			string usr;
			if (hc != null && !string.IsNullOrEmpty(usr = MasterPage.UserName(hc)))
			{
				lbUser.Text = usr + " さん";
				btnLogout.Visible = btnNotAnswer.Visible = true;
			}
			else
			{
				lbUser.Text = "";
				btnLogout.Visible = btnNotAnswer.Visible = false;
			}
		}
		public void SetUser(string usr)
		{
			HttpCookie hc = new HttpCookie("user", usr);
			hc.Expires = DateTime.Now.AddYears(1);
			Response.Cookies.Add(hc);
			SetUserName(hc);
		}
		protected void btnLogin_Click(object sender, EventArgs e)
		{
			//Encoding enc = Encoding.GetEncoding(932);
			Encoding enc = Encoding.UTF8;
			SetUser(Convert.ToBase64String(enc.GetBytes(tbLogin.Text)));
		}
		public static string UserName(HttpCookie hc)
		{
			//Encoding enc = Encoding.GetEncoding(932);
			Encoding enc = Encoding.UTF8;
			try
			{
				return enc.GetString(Convert.FromBase64String(hc.Value));
			}
			catch
			{
				return hc.Value;
			}
		}
		protected void btnLogout_Click(object sender, EventArgs e)
		{
			SetUser("");
		}
		protected void btnRegist_Click(object sender, EventArgs e)
		{
			Session["Mode"] = "new";
			Response.Redirect("EditProblem.aspx");
		}
		protected void btnNotAnswer_Click(object sender, EventArgs e)
		{
			Response.Redirect("NotAnswer.aspx");
		}
		protected void lstCate_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["SelCate"] = lstCate.SelectedIndex <= 0 ? null : lstCate.SelectedValue;
			Response.Redirect("ListProblem.aspx");
		}
		protected void lstUser_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["SelUser"] = lstUser.SelectedValue;
			Response.Redirect("InfoUser.aspx");
		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			Session["Search"] = tbSearch.Text;
			Response.Redirect("Search.aspx");
		}
		protected void btnReset_Click(object sender, EventArgs e)
		{
			DataDoc.Reset();
		}
	}
}