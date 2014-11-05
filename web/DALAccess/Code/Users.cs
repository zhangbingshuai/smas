/**  版本信息模板在安装目录下，可自行修改。
* Users.cs
*
* 功 能： N/A
* 类 名： Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/3 21:51:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：sams　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tc.DAL.DBUtility;
namespace Tc.DAL
{
	/// <summary>
	/// 数据访问类:Users
	/// </summary>
	public partial class Users
	{
		public Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = UserID;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Tc.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Users(");
			strSql.Append("UserID,Name,LoginName,Password,IDCard,Sex,Age,PhoneNumber,QQ,Email,WeChat,Address,Resume,Type,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@Name,@LoginName,@Password,@IDCard,@Sex,@Age,@PhoneNumber,@QQ,@Email,@WeChat,@Address,@Resume,@Type,@AddTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@WeChat", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Resume", SqlDbType.NText),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.Name;
			parameters[2].Value = model.LoginName;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.IDCard;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.Age;
			parameters[7].Value = model.PhoneNumber;
			parameters[8].Value = model.QQ;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.WeChat;
			parameters[11].Value = model.Address;
			parameters[12].Value = model.Resume;
			parameters[13].Value = model.Type;
			parameters[14].Value = model.AddTime;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Tc.Model.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("Name=@Name,");
			strSql.Append("LoginName=@LoginName,");
			strSql.Append("Password=@Password,");
			strSql.Append("IDCard=@IDCard,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Age=@Age,");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Email=@Email,");
			strSql.Append("WeChat=@WeChat,");
			strSql.Append("Address=@Address,");
			strSql.Append("Resume=@Resume,");
			strSql.Append("Type=@Type,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@WeChat", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Resume", SqlDbType.NText),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.LoginName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.IDCard;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.Age;
			parameters[6].Value = model.PhoneNumber;
			parameters[7].Value = model.QQ;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.WeChat;
			parameters[10].Value = model.Address;
			parameters[11].Value = model.Resume;
			parameters[12].Value = model.Type;
			parameters[13].Value = model.AddTime;
			parameters[14].Value = model.UserID;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = UserID;

			int rows=DbHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
			int rows=DbHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tc.Model.Users GetModel(Guid UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,Name,LoginName,Password,IDCard,Sex,Age,PhoneNumber,QQ,Email,WeChat,Address,Resume,Type,AddTime from Users ");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = UserID;

			Tc.Model.Users model=new Tc.Model.Users();
			DataSet ds=DbHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tc.Model.Users DataRowToModel(DataRow row)
		{
			Tc.Model.Users model=new Tc.Model.Users();
			if (row != null)
			{
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID= new Guid(row["UserID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["LoginName"]!=null)
				{
					model.LoginName=row["LoginName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["IDCard"]!=null)
				{
					model.IDCard=row["IDCard"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					if((row["Sex"].ToString()=="1")||(row["Sex"].ToString().ToLower()=="true"))
					{
						model.Sex=true;
					}
					else
					{
						model.Sex=false;
					}
				}
				if(row["Age"]!=null && row["Age"].ToString()!="")
				{
					model.Age=int.Parse(row["Age"].ToString());
				}
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["WeChat"]!=null)
				{
					model.WeChat=row["WeChat"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Resume"]!=null)
				{
					model.Resume=row["Resume"].ToString();
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,Name,LoginName,Password,IDCard,Sex,Age,PhoneNumber,QQ,Email,WeChat,Address,Resume,Type,AddTime ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" UserID,Name,LoginName,Password,IDCard,Sex,Age,PhoneNumber,QQ,Email,WeChat,Address,Resume,Type,AddTime ");
			strSql.Append(" FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from Users T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Users";
			parameters[1].Value = "UserID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

