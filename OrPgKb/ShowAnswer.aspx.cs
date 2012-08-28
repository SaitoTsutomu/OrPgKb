using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class ShowAnswer : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			SetData();
		}
		private void SetData()
		{
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Answer aw = dc.GetAnswer((int?)Session["Answer"]);
				if (aw == null)
				{
					lbResult.Text = "対象がありません";
					return;
				}
				lbTitle.Text = aw.Title;
				Session["Title"] = aw.Title;
				lbUser.Text = aw.User;
				lbTime.Text = aw.Time;
				tbAnswer.Text = aw.Contents;
				HttpCookie hc = Request.Cookies["user"];
				if (hc != null)
				{
					string user = MasterPage.UserName(hc);
					if (user == aw.User)
						btnEdit.Visible = btnDel.Visible = true;
					pnlCommentAdd.Visible = !string.IsNullOrEmpty(user);
				}
				lstComment.Items.Clear();
				foreach (Comment cm in dc.RComments)
				{
					if (cm.AnswerID != aw.ID) continue;
					lstComment.Items.Add(cm.ToString());
				}
			}
			lbResult.Text = "";
		}
		protected void btnEdit_Click(object sender, EventArgs e)
		{
			Session["Mode"] = "edit";
			Response.Redirect("EditAnswer.aspx");
		}
		protected void btnDel_Click(object sender, EventArgs e)
		{
			Session["ReturnURL"] = "ShowProblem.aspx/ShowAnswer.aspx";
			Session["DeleteTarget"] = "Answer";
			Response.Redirect("Delete.aspx");
		}
		protected void btnShowProblem_Click(object sender, EventArgs e)
		{
			Response.Redirect("ShowProblem.aspx");
		}
		protected void lstComment_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstComment.SelectedValue)) return;
			Session["Comment"] = Comment.GetID(lstComment.SelectedValue);
			Response.Redirect("ShowComment.aspx");
		}
		protected void btnAddComment_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbComment.Text))
			{
				lbResult.Text = "コメントを入力して下さい";
				return;
			}
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				HttpCookie hc = Request.Cookies["user"];
				string user;
				if (hc == null || string.IsNullOrEmpty(user = MasterPage.UserName(hc)))
				{
					lbResult.Text = "ログインして下さい";
					return;
				}
				Answer aw = dc.GetAnswer((int?)Session["Answer"]);
				if (aw == null)
				{
					lbResult.Text = "対象がありません";
					return;
				}
				dc.AddComment(aw.ID, user, tbComment.Text);
				dc.Save(null);
			}
			SetData();
		}
	}
}