using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrPgKb
{
	public partial class Upload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
			lbResult.Text = "";
		}
		protected void btnUpload_Click(object sender, EventArgs e)
		{
			lbResult.Text = "";
			string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
			if (ext != ".gif" && ext != ".jpg" && ext != ".png" && ext != ".txt")
			{
				lbResult.Text = "拡張子は、gif,jpg,png,txt の何れかにして下さい";
				return;
			}
			string dir = MapPath("img") + "\\";
			string fnam = dir + Path.GetFileName(FileUpload1.FileName);
			if (File.Exists(fnam))
			{
				lbResult.Text = "既に存在します";
				return;
			}
			try
			{
				FileUpload1.SaveAs(fnam);
			}
			catch (Exception ee)
			{
				lbResult.Text = ee.Message;
				return;
			}
			lbResult.Text = "アップロードしました";
		}
	}
}