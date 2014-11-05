/**  版本信息模板在安装目录下，可自行修改。
* Links.cs
*
* 功 能： N/A
* 类 名： Links
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/3 21:51:29   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：sams　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Tc.Model
{
	/// <summary>
	/// Links:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Links
	{
		public Links()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _url;
		private string _logourl;
		private bool _isdisplay;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogoUrl
		{
			set{ _logourl=value;}
			get{return _logourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDisplay
		{
			set{ _isdisplay=value;}
			get{return _isdisplay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

