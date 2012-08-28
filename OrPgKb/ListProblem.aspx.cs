using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class ListProblem : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			lstList.Items.Clear();
			string selCate = (string)Session["SelCate"];
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				foreach (Problem pb in dc.RProblems)
				{
					if (selCate != null && pb.Category != selCate) continue;
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