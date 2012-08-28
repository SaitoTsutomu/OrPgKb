using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Serialization;
using System.IO;

/*
   c:\Windows\Temp, C:\inetpub\wwwroot\OrPgKb\App_Data に IIS_IUSERSの書き込み権限が必要
 */
namespace OrPgKb
{
	public sealed class DataDoc
	{
		public List<Problem> Problems;
		public List<Answer> Answers;
		public List<Comment> Comments;
		public IEnumerable<Problem> RProblems
		{
			get { for (int i = Problems.Count - 1; i >= 0; --i) yield return Problems[i]; }
		}
		public IEnumerable<Answer> RAnswers
		{
			get { for (int i = Answers.Count - 1; i >= 0; --i) yield return Answers[i]; }
		}
		public IEnumerable<Comment> RComments
		{
			get { for (int i = Comments.Count - 1; i >= 0; --i) yield return Comments[i]; }
		}
		private bool bInitialized;
		public static void Reset()
		{
			lock (_Instance) { _Instance.bInitialized = false; }
		}
		private static string FileName;
		private static DataDoc _Instance = new DataDoc();
		public static DataDoc Instance(HttpServerUtility Server)
		{
			if (!_Instance.bInitialized)
			{
				lock (_Instance)
				{
					if (!_Instance.bInitialized)
					{
						FileName = Server.MapPath("App_Data/data.xml");
						try
						{
							_Instance = Load(FileName);
						}
						catch
						{
							_Instance.Problems = new List<Problem>();
							_Instance.Answers = new List<Answer>();
							_Instance.Comments = new List<Comment>();
						}
						_Instance.bInitialized = true;
					}
				}
			}
			return _Instance;
		}
		/// <summary>コンストラクタ</summary>
		public DataDoc() { bInitialized = false; }
		public static DataDoc Load(string fnam)
		{
			var xs = new XmlSerializer(typeof(DataDoc));
			DataDoc dd = null;
			using (var sr = new StreamReader(fnam))
				dd = (DataDoc)xs.Deserialize(sr);
			return dd;
		}
		public void Save(string fnam)
		{
			if (string.IsNullOrEmpty(fnam)) fnam = FileName;
			var xs = new XmlSerializer(typeof(DataDoc));
			using (var sw = new StreamWriter(fnam))
				xs.Serialize(sw, this);
		}
		public IEnumerable<string> Categories()
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			foreach (Problem pb in Problems)
				if (!dic.ContainsKey(pb.Category)) dic.Add(pb.Category, null);
			return dic.Keys;
		}
		public IEnumerable<string> Users()
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			foreach (Problem pb in Problems)
				if (!dic.ContainsKey(pb.User)) dic.Add(pb.User, null);
			foreach (Answer aw in Answers)
				if (!dic.ContainsKey(aw.User)) dic.Add(aw.User, null);
			foreach (Comment cm in Comments)
				if (!dic.ContainsKey(cm.User)) dic.Add(cm.User, null);
			return dic.Keys;
		}
		public Problem GetProblem(string title)
		{
			foreach (Problem pb in Problems)
				if (pb.Title == title) return pb;
			return null;
		}
		/*
		public Answer GetAnswer(string sid)
		{
			int id;
			if (!int.TryParse(sid, out id)) return null;
			return GetAnswer(id);
		}*/
		public Answer GetAnswer(int? k)
		{
			int id = k ?? -1;
			foreach (Answer aw in Answers)
				if (aw.ID == id) return aw;
			return null;
		}
		public Comment GetComment(int? k)
		{
			int id = k ?? -1;
			foreach (Comment cm in Comments)
				if (cm.ID == id) return cm;
			return null;
		}
		public void AddProblem(string tit, string cat, string usr, string cont)
		{
			Problem pb = new Problem(tit, cat, usr, cont);
			Problems.Add(pb);
		}
		public void AddAnswer(string tit, string usr, string cont)
		{
			Answer aw = new Answer(GetUniqAnswerID(), tit, usr, cont);
			Answers.Add(aw);
		}
		public void AddComment(int aid, string usr, string cont)
		{
			Comment cm = new Comment(GetUniqCommentID(), aid, usr, cont);
			Comments.Add(cm);
		}
		public int GetUniqAnswerID()
		{
			int id = 0;
			foreach (Answer aw in Answers)
				id = Math.Max(id, aw.ID);
			return id + 1;
		}
		public int GetUniqCommentID()
		{
			int id = 0;
			foreach (Comment cm in Comments)
				id = Math.Max(id, cm.ID);
			return id + 1;
		}
	}
	/// <summary></summary>
	public sealed class Problem
	{
		public string Time;
		public string User;
		public string Title;
		public string Category;
		public string Contents;
		/// <summary>コンストラクタ</summary>
		public Problem() { }
		/// <summary>コンストラクタ</summary>
		public Problem(string tit, string cat, string usr, string cont)
		{
			Time = DateTime.Now.ToString();
			User = usr;
			Title = tit;
			Category = cat;
			Contents = cont;
		}
		public override string ToString()
		{
			return string.Format("{0} - {1} - {2} - {3}", Category, Title, User, Time);
		}
		public static string GetTitle(string s)
		{
			string[] tt = s.Replace(" - ", char.MinValue.ToString()).Split(char.MinValue);
			if (tt.Length < 2) return null;
			return tt[1];
		}
	}
	/// <summary></summary>
	public sealed class Answer
	{
		public int ID;
		public string Time;
		public string User;
		public string Title;
		public string Contents;
		/// <summary>コンストラクタ</summary>
		public Answer() { }
		/// <summary>コンストラクタ</summary>
		public Answer(int id, string tit, string usr, string cont)
		{
			Time = DateTime.Now.ToString();
			ID = id;
			User = usr;
			Title = tit;
			Contents = cont;
		}
		public override string ToString()
		{
			return string.Format("({0}) - {1} - {2} - {3}", ID, Title, User, Time);
		}
		public static int GetID(string s)
		{
			string[] tt = s.Replace(" - ", char.MinValue.ToString()).Split(char.MinValue);
			if (tt.Length < 1) return -1;
			int id;
			if (!int.TryParse(tt[0].Trim('(', ')'), out id)) return -1;
			return id;
		}
	}
	/// <summary></summary>
	public sealed class Comment
	{
		public int ID;
		public int AnswerID;
		public string Time;
		public string User;
		public string Contents;
		/// <summary>コンストラクタ</summary>
		public Comment() { }
		/// <summary>コンストラクタ</summary>
		public Comment(int id, int aid, string usr, string cont)
		{
			Time = DateTime.Now.ToString();
			ID = id;
			AnswerID = aid;
			User = usr;
			Contents = cont;
		}
		public override string ToString()
		{
			return string.Format("({0}) - {1} - {2} - {3}", ID, User, Time, Contents);
		}
		public static int GetID(string s)
		{
			string[] tt = s.Replace(" - ", char.MinValue.ToString()).Split(char.MinValue);
			if (tt.Length < 1) return -1;
			int id;
			if (!int.TryParse(tt[0].Trim('(', ')'), out id)) return -1;
			return id;
		}
	}
}