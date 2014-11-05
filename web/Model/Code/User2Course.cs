/**  版本信息模板在安装目录下，可自行修改。
* User2Course.cs
*
* 功 能： N/A
* 类 名： User2Course
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/3 21:51:31   N/A    初版
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
	/// User2Course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User2Course
	{
		public User2Course()
		{}
		#region Model
		private Guid _id;
		private Guid _userid;
		private Guid _courseid;
		private bool _ispayment;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public Guid ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
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
		public bool IsPayment
		{
			set{ _ispayment=value;}
			get{return _ispayment;}
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

