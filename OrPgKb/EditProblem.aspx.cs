using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class EditProblem : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lbResult.Text = "";
			if (IsPostBack) return;
			if ((string)Session["Mode"] == "new")
			{
				HttpCookie hc = Request.Cookies["user"];
				if (hc != null)
					tbUser.Text = MasterPage.UserName(hc);
				string selCate = (string)Session["SelCate"];
				if (!string.IsNullOrEmpty(selCate))
					tbCate.Text = selCate;
			}
			else
			{
				string ttl = (string)Session["Title"];
				DataDoc dc = DataDoc.Instance(Server);
				lock (dc)
				{
					Problem pb = dc.GetProblem(ttl);
					if (pb == null)
					{
						lbResult.Text = "対象がありません";
						return;
					}
					tbTitle.Text = pb.Title;
					tbCate.Text = pb.Category;
					tbUser.Text = pb.User;
					tbProblem.Text = pb.Contents;
				}
				lbMode.Text = "編集";
				tbTitle.ReadOnly = tbCate.ReadOnly = tbUser.ReadOnly = true;
				tbTitle.BackColor = tbCate.BackColor = tbUser.BackColor = SystemColors.Control;
				btnAdd.Visible = false;
				btnUpdate.Visible = btnShowProblem.Visible = true;
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
			if (string.IsNullOrEmpty(tbCate.Text))
			{
				lbResult.Text = "カテゴリを入力して下さい";
				return;
			}
			if (string.IsNullOrEmpty(tbProblem.Text))
			{
				lbResult.Text = "内容を入力して下さい";
				return;
			}
			lbResult.Text = "";
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Problem pb = dc.GetProblem(tbTitle.Text);
				if (pb != null)
				{
					lbResult.Text = "カテゴリ(" + pb.Category + ")に同じタイトルがあります";
					return;
				}
				dc.AddProblem(tbTitle.Text, tbCate.Text, tbUser.Text, tbProblem.Text);
				dc.Save(null);
				lbResult.Text = "追加しました";
			}
			Encoding enc = Encoding.UTF8;
			MasterPage mp = (MasterPage)Master;
			mp.SetUser(Convert.ToBase64String(enc.GetBytes(tbUser.Text)));
			mp.SetCateUser();
		}
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			DataDoc dc = DataDoc.Instance(Server);
			lock (dc)
			{
				Problem pb = dc.GetProblem(tbTitle.Text);
				if (pb == null)
				{
					lbResult.Text = "対象がありません";
					return;
				}
				pb.Contents = tbProblem.Text;
				pb.Time = DateTime.Now.ToString();
				dc.Save(null);
				lbResult.Text = "更新しました";
			}
		}
		protected void btnShowProblem_Click(object sender, EventArgs e)
		{
			Response.Redirect("ShowProblem.aspx");
		}
	}

}