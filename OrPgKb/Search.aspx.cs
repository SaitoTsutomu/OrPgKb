using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class Search : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			string key = (string)Session["Search"];
			lbSearch.Text = key;
			Regex re = new Regex(key ?? "", RegexOptions.Compiled);
			int i1 = 0, i2 = 0, i3 = 0;
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				foreach (Problem pb in dc.Problems)
				{
					if (re.IsMatch(pb.Contents))
					{
						lstProblem.Items.Add(pb.ToString());
						++i1;
					}
				}
				foreach (Answer aw in dc.Answers)
				{
					if (re.IsMatch(aw.Contents))
					{
						lstAnswer.Items.Add(aw.ToString());
						++i2;
					}
				}
				foreach (Comment cm in dc.Comments)
				{
					if (re.IsMatch(cm.Contents))
					{
						lstComment.Items.Add(cm.ToString());
						++i3;
					}
				}
				lbRes1.Text = "全 " + i1 + " 件";
				lbRes2.Text = "全 " + i2 + " 件";
				lbRes3.Text = "全 " + i3 + " 件";
			}
		}
		protected void lstProblem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstProblem.SelectedValue)) return;
			Session["Title"] = Problem.GetTitle(lstProblem.SelectedValue);
			Response.Redirect("ShowProblem.aspx");
		}
		protected void lstAnswer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstAnswer.SelectedValue)) return;
			Session["Answer"] = Answer.GetID(lstAnswer.SelectedValue);
			Response.Redirect("ShowAnswer.aspx");
		}
		protected void lstComment_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(lstComment.SelectedValue)) return;
			Session["Comment"] = Answer.GetID(lstComment.SelectedValue);
			Response.Redirect("ShowComment.aspx");
		}
	}
}