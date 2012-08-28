using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class ShowProblem : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			lbResult.Text = "";
			string ttl = (string)Session["Title"];
			if (string.IsNullOrEmpty(ttl))
			{
				lbResult.Text = "対象がありません";
				return;
			}
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Problem pb = dc.GetProblem(ttl);
				if (pb == null)
				{
					lbResult.Text = "対象がありません";
					return;
				}
				lbTitle.Text = pb.Title;
				lbCate.Text = pb.Category;
				lbUser.Text = pb.User;
				lbTime.Text = pb.Time;
				lbProblem.Text = pb.Contents;
				HttpCookie hc = Request.Cookies["user"];
				if (hc != null && pb.User == MasterPage.UserName(hc))
				{
					btnEdit.Visible = btnDel.Visible = true;
				}
				lstAnswer.Items.Clear();
				foreach (Answer aw in dc.RAnswers)
				{
					if (ttl != null && aw.Title != ttl) continue;
					lstAnswer.Items.Add(aw.ToString());
				}
			}
		}
		protected void btnEdit_Click(object sender, EventArgs e)
		{
			Session["Mode"] = "edit";
			Response.Redirect("EditProblem.aspx");
		}
		protected void btnDel_Click(object sender, EventArgs e)
		{
			Session["ReturnURL"] = "ListProblem.aspx/ShowProblem.aspx";
			Session["DeleteTarget"] = "Problem";
			Response.Redirect("Delete.aspx");
		}
		protected void btnAnswer_Click(object sender, EventArgs e)
		{
			Session["Mode"] = "new";
			Response.Redirect("EditAnswer.aspx");
		}
		protected void lstAnswer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstAnswer.SelectedValue)) return;
			Session["Answer"] = Answer.GetID(lstAnswer.SelectedValue);
			Response.Redirect("ShowAnswer.aspx");
		}
		protected void btnListProblem_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListProblem.aspx");
		}
	}
}