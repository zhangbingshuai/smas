/**  版本信息模板在安装目录下，可自行修改。
* Courses.cs
*
* 功 能： N/A
* 类 名： Courses
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
	/// Courses:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Courses
	{
		public Courses()
		{}
		#region Model
		private Guid _courseid;
		private Guid _schoolid;
		private string _coursetitle;
		private int? _classcount;
		private decimal? _price;
		private string _content;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public Guid CourseID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid SchoolID
		{
			set{ _schoolid=value;}
			get{return _schoolid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CourseTitle
		{
			set{ _coursetitle=value;}
			get{return _coursetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassCount
		{
			set{ _classcount=value;}
			get{return _classcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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

