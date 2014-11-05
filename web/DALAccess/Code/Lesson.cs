/**  版本信息模板在安装目录下，可自行修改。
* Lesson.cs
*
* 功 能： N/A
* 类 名： Lesson
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
	/// 数据访问类:Lesson
	/// </summary>
	public partial class Lesson
	{
		public Lesson()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid LessonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Lesson");
			strSql.Append(" where LessonID=@LessonID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LessonID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = LessonID;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Tc.Model.Lesson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Lesson(");
			strSql.Append("LessonID,CourseID,TeacherID,Name,ID,Year,Month,Day,BeginTime,EndTime,Content,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@LessonID,@CourseID,@TeacherID,@Name,@ID,@Year,@Month,@Day,@BeginTime,@EndTime,@Content,@AddTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@LessonID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@TeacherID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Year", SqlDbType.NVarChar,4),
					new SqlParameter("@Month", SqlDbType.NVarChar,2),
					new SqlParameter("@Day", SqlDbType.NVarChar,2),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = Guid.NewGuid();
			parameters[3].Value = model.Name;
			parameters[4].Value = model.ID;
			parameters[5].Value = model.Year;
			parameters[6].Value = model.Month;
			parameters[7].Value = model.Day;
			parameters[8].Value = model.BeginTime;
			parameters[9].Value = model.EndTime;
			parameters[10].Value = model.Content;
			parameters[11].Value = model.AddTime;

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
		public bool Update(Tc.Model.Lesson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Lesson set ");
			strSql.Append("CourseID=@CourseID,");
			strSql.Append("TeacherID=@TeacherID,");
			strSql.Append("Name=@Name,");
			strSql.Append("ID=@ID,");
			strSql.Append("Year=@Year,");
			strSql.Append("Month=@Month,");
			strSql.Append("Day=@Day,");
			strSql.Append("BeginTime=@BeginTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("Content=@Content,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where LessonID=@LessonID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@TeacherID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Year", SqlDbType.NVarChar,4),
					new SqlParameter("@Month", SqlDbType.NVarChar,2),
					new SqlParameter("@Day", SqlDbType.NVarChar,2),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@LessonID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.CourseID;
			parameters[1].Value = model.TeacherID;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.ID;
			parameters[4].Value = model.Year;
			parameters[5].Value = model.Month;
			parameters[6].Value = model.Day;
			parameters[7].Value = model.BeginTime;
			parameters[8].Value = model.EndTime;
			parameters[9].Value = model.Content;
			parameters[10].Value = model.AddTime;
			parameters[11].Value = model.LessonID;

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
		public bool Delete(Guid LessonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Lesson ");
			strSql.Append(" where LessonID=@LessonID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LessonID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = LessonID;

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
		public bool DeleteList(string LessonIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Lesson ");
			strSql.Append(" where LessonID in ("+LessonIDlist + ")  ");
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
		public Tc.Model.Lesson GetModel(Guid LessonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LessonID,CourseID,TeacherID,Name,ID,Year,Month,Day,BeginTime,EndTime,Content,AddTime from Lesson ");
			strSql.Append(" where LessonID=@LessonID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LessonID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = LessonID;

			Tc.Model.Lesson model=new Tc.Model.Lesson();
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
		public Tc.Model.Lesson DataRowToModel(DataRow row)
		{
			Tc.Model.Lesson model=new Tc.Model.Lesson();
			if (row != null)
			{
				if(row["LessonID"]!=null && row["LessonID"].ToString()!="")
				{
					model.LessonID= new Guid(row["LessonID"].ToString());
				}
				if(row["CourseID"]!=null && row["CourseID"].ToString()!="")
				{
					model.CourseID= new Guid(row["CourseID"].ToString());
				}
				if(row["TeacherID"]!=null && row["TeacherID"].ToString()!="")
				{
					model.TeacherID= new Guid(row["TeacherID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Year"]!=null)
				{
					model.Year=row["Year"].ToString();
				}
				if(row["Month"]!=null)
				{
					model.Month=row["Month"].ToString();
				}
				if(row["Day"]!=null)
				{
					model.Day=row["Day"].ToString();
				}
				if(row["BeginTime"]!=null && row["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(row["BeginTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
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
			strSql.Append("select LessonID,CourseID,TeacherID,Name,ID,Year,Month,Day,BeginTime,EndTime,Content,AddTime ");
			strSql.Append(" FROM Lesson ");
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
			strSql.Append(" LessonID,CourseID,TeacherID,Name,ID,Year,Month,Day,BeginTime,EndTime,Content,AddTime ");
			strSql.Append(" FROM Lesson ");
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
			strSql.Append("select count(1) FROM Lesson ");
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
				strSql.Append("order by T.LessonID desc");
			}
			strSql.Append(")AS Row, T.*  from Lesson T ");
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
			parameters[0].Value = "Lesson";
			parameters[1].Value = "LessonID";
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

