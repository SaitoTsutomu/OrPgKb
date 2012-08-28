using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace OrPgKb
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var fnam = Server.MapPath("App_Data/info.txt");
			if (File.Exists(fnam))
				Label1.Text = File.ReadAllText(fnam, Encoding.GetEncoding(932));
		}
	}
}