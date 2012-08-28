using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class Delete : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			lbResult.Text = "";
		}
		protected void btnYes_Click(object sender, EventArgs e)
		{
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				bool bNotFound = true;
				string tgt = (string)Session["DeleteTarget"];
				if (tgt == "Problem")
				{
					Problem pb = dc.GetProblem((string)Session["Title"]);
					if (pb != null)
					{
						bNotFound = false;
						dc.Problems.Remove(pb);
					}
				}
				else if (tgt == "Answer")
				{
					Answer aw = dc.GetAnswer((int?)Session["Answer"]);
					if (aw != null)
					{
						bNotFound = false;
						dc.Answers.Remove(aw);
					}
				}
				else if (tgt == "Comment")
				{
					Comment cm = dc.GetComment((int?)Session["Comment"]);
					if (cm != null)
					{
						bNotFound = false;
						dc.Comments.Remove(cm);
					}
				}
				if (bNotFound)
				{
					lbResult.Text = "対象がありません";
					return;
				}
				dc.Save(null);
			}
			lbResult.Text = "";
			btnNo_Click(null, null);
		}
		protected void btnNo_Click(object sender, EventArgs e)
		{
			string url = (string)Session["ReturnURL"];
			if (string.IsNullOrEmpty(url)) return;
			string[] ss = url.Split('/');
			int k = sender == null ? 0 : 1;
			if (ss.Length <= k) return;
			Response.Redirect(ss[k]);
		}
	}
}