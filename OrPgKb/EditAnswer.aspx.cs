using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class EditAnswer : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lbResult.Text = "";
			if (IsPostBack) return;
			string ttl = (string)Session["Title"];
			if (!string.IsNullOrEmpty(ttl))
				tbTitle.Text = ttl;
			if ((string)Session["Mode"] == "new")
			{
				HttpCookie hc = Request.Cookies["user"];
				if (hc != null)
					tbUser.Text = MasterPage.UserName(hc);
			}
			else
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
					tbUser.Text = aw.User;
					tbAnswer.Text = aw.Contents;
				}
				lbMode.Text = "編集";
				tbTitle.ReadOnly = tbUser.ReadOnly = true;
				tbTitle.BackColor = tbUser.BackColor = SystemColors.Control;
				btnAdd.Visible = false;
				btnUpdate.Visible = btnShowAnswer.Visible = true;
			}
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbUser.Text))
			{
				lbResult.Text = "作成者を入力して下さい";
				return;
			}
			if (string.IsNullOrEmpty(tbTitle.Text))
			{
				lbResult.Text = "タイトルを入力して下さい";
				return;
			}
			if (string.IsNullOrEmpty(tbAnswer.Text))
			{
				lbResult.Text = "内容を入力して下さい";
				return;
			}
			lbResult.Text = "";
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				dc.AddAnswer(tbTitle.Text, tbUser.Text, tbAnswer.Text);
				dc.Save(null);
				lbResult.Text = "追加しました";
			}
		}
		protected void btnUpdate_Click(object sender, EventArgs e)
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
				aw.Contents = tbAnswer.Text;
				aw.Time = DateTime.Now.ToString();
				dc.Save(null);
				lbResult.Text = "更新しました";
			}
		}
		protected void btnShowProblem_Click(object sender, EventArgs e)
		{
			Response.Redirect("ShowProblem.aspx");
		}
		protected void btnShowAnswer_Click(object sender, EventArgs e)
		{
			Response.Redirect("ShowAnswer.aspx");
		}
	}
}