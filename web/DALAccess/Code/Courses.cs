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
	/// 数据访问类:Courses
	/// </summary>
	public partial class Courses
	{
		public Courses()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid CourseID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Courses");
			strSql.Append(" where CourseID=@CourseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = CourseID;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Tc.Model.Courses model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Courses(");
			strSql.Append("CourseID,SchoolID,CourseTitle,ClassCount,Price,Content,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@CourseID,@SchoolID,@CourseTitle,@ClassCount,@Price,@Content,@AddTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CourseTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassCount", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.CourseTitle;
			parameters[3].Value = model.ClassCount;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.AddTime;

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
		public bool Update(Tc.Model.Courses model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Courses set ");
			strSql.Append("SchoolID=@SchoolID,");
			strSql.Append("CourseTitle=@CourseTitle,");
			strSql.Append("ClassCount=@ClassCount,");
			strSql.Append("Price=@Price,");
			strSql.Append("Content=@Content,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where CourseID=@CourseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CourseTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassCount", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.SchoolID;
			parameters[1].Value = model.CourseTitle;
			parameters[2].Value = model.ClassCount;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.AddTime;
			parameters[6].Value = model.CourseID;

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
		public bool Delete(Guid CourseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Courses ");
			strSql.Append(" where CourseID=@CourseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = CourseID;

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
		public bool DeleteList(string CourseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Courses ");
			strSql.Append(" where CourseID in ("+CourseIDlist + ")  ");
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
		public Tc.Model.Courses GetModel(Guid CourseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CourseID,SchoolID,CourseTitle,ClassCount,Price,Content,AddTime from Courses ");
			strSql.Append(" where CourseID=@CourseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = CourseID;

			Tc.Model.Courses model=new Tc.Model.Courses();
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
		public Tc.Model.Courses DataRowToModel(DataRow row)
		{
			Tc.Model.Courses model=new Tc.Model.Courses();
			if (row != null)
			{
				if(row["CourseID"]!=null && row["CourseID"].ToString()!="")
				{
					model.CourseID= new Guid(row["CourseID"].ToString());
				}
				if(row["SchoolID"]!=null && row["SchoolID"].ToString()!="")
				{
					model.SchoolID= new Guid(row["SchoolID"].ToString());
				}
				if(row["CourseTitle"]!=null)
				{
					model.CourseTitle=row["CourseTitle"].ToString();
				}
				if(row["ClassCount"]!=null && row["ClassCount"].ToString()!="")
				{
					model.ClassCount=int.Parse(row["ClassCount"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
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
			strSql.Append("select CourseID,SchoolID,CourseTitle,ClassCount,Price,Content,AddTime ");
			strSql.Append(" FROM Courses ");
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
			strSql.Append(" CourseID,SchoolID,CourseTitle,ClassCount,Price,Content,AddTime ");
			strSql.Append(" FROM Courses ");
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
			strSql.Append("select count(1) FROM Courses ");
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
				strSql.Append("order by T.CourseID desc");
			}
			strSql.Append(")AS Row, T.*  from Courses T ");
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
			parameters[0].Value = "Courses";
			parameters[1].Value = "CourseID";
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

