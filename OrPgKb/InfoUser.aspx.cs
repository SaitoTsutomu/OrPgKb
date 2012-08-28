using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class InfoUser : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			string user = (string)Session["SelUser"];
			if (string.IsNullOrEmpty(user))
			{
				lbResult.Text = "対象がありません";
				return;
			}
			lbUser.Text = user;
			lbResult.Text = "";
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Dictionary<string, object> dic = new Dictionary<string, object>();
				int i0 = 0, i1 = 0, i2 = 0, i3 = 0;
				lstAnswer.Items.Clear();
				foreach (Problem pb in dc.Problems)
				{
					if (!pb.Title.StartsWith("!"))
					{
						++i0;
						if (pb.User == user) ++i1;
					}
				}
				foreach (Answer aw in dc.RAnswers)
				{
					if (aw.User != user) continue;
					++i2;
					lstAnswer.Items.Add(aw.ToString());
					if (!dic.ContainsKey(aw.Title)) dic.Add(aw.Title, null);
				}
				foreach (Comment cm in dc.Comments)
				{
					if (cm.User == user) ++i3;
				}
				lbNProblem.Text = string.Format("{0} 件 / {1} 件", i1, i0);
				lbNAnswer.Text = string.Format("{0} 件 / {1} 件", i2, dc.Answers.Count);
				lbRate.Text = string.Format("{0:F2} %", dic.Count * 100.0 / Math.Max(1, i0));
				lbNComment.Text = string.Format("{0} 件 / {1} 件", i3, dc.Comments.Count);
			}
		}
		protected void lstAnswer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstAnswer.SelectedValue)) return;
			Session["Answer"] = Answer.GetID(lstAnswer.SelectedValue);
			Response.Redirect("ShowAnswer.aspx");
		}
	}
}