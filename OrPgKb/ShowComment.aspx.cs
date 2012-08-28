using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class ShowComment : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			lbResult.Text = "";
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Comment cm = dc.GetComment((int?)Session["Comment"]);
				if (cm == null)
				{
					lbResult.Text = "対象がありません";
					return;
				}
				lbUser.Text = cm.User;
				lbTime.Text = cm.Time;
				lbComment.Text = cm.Contents;
				HttpCookie hc = Request.Cookies["user"];
				if (hc != null && cm.User == MasterPage.UserName(hc))
				{
					btnDel.Visible = true;
				}
			}
		}
		protected void btnDel_Click(object sender, EventArgs e)
		{
			Session["ReturnURL"] = "ShowAnswer.aspx/ShowComment.aspx";
			Session["DeleteTarget"] = "Comment";
			Response.Redirect("Delete.aspx");
		}
		protected void btnShowAnswer_Click(object sender, EventArgs e)
		{
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Comment cm = dc.GetComment((int?)Session["Comment"]);
				if (cm != null)
				{
					Session["Answer"] = cm.AnswerID;
					Response.Redirect("ShowAnswer.aspx");
				}
			}
		}
	}
}