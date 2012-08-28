using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class NotAnswer : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			HttpCookie hc = Request.Cookies["user"];
			string user;
			if (hc == null || string.IsNullOrEmpty(user = MasterPage.UserName(hc)))
			{
				lbResult.Text = "ログインして下さい";
				return;
			}
			lstList.Items.Clear();
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Dictionary<string, object> dic = new Dictionary<string, object>();
				foreach (Answer aw in dc.Answers)
					if (aw.User == user && !dic.ContainsKey(aw.Title))
						dic.Add(aw.Title, null);
				foreach (Problem pb in dc.RProblems)
				{
					if (!pb.Title.StartsWith("!") && !dic.ContainsKey(pb.Title))
						lstList.Items.Add(pb.ToString());
				}
			}
		}
		protected void lstList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstList.SelectedValue)) return;
			Session["Title"] = Problem.GetTitle(lstList.SelectedValue);
			Response.Redirect("ShowProblem.aspx");
		}
	}
}