/**  版本信息模板在安装目录下，可自行修改。
* Right2User.cs
*
* 功 能： N/A
* 类 名： Right2User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/3 21:51:30   N/A    初版
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
	/// Right2User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Right2User
	{
		public Right2User()
		{}
		#region Model
		private Guid _id;
		private Guid _rightid;
		private Guid _userid;
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
		public Guid RightID
		{
			set{ _rightid=value;}
			get{return _rightid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

