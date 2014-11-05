/**  版本信息模板在安装目录下，可自行修改。
* School.cs
*
* 功 能： N/A
* 类 名： School
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/3 21:51:31   N/A    初版
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
	/// 数据访问类:School
	/// </summary>
	public partial class School
	{
		public School()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid SchoolID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from School");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = SchoolID;

			return DbHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Tc.Model.School model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into School(");
			strSql.Append("SchoolID,SchoolName,Content,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@SchoolID,@SchoolName,@Content,@AddTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.SchoolName;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.AddTime;

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
		public bool Update(Tc.Model.School model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update School set ");
			strSql.Append("SchoolName=@SchoolName,");
			strSql.Append("Content=@Content,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolName", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.SchoolName;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.AddTime;
			parameters[3].Value = model.SchoolID;

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
		public bool Delete(Guid SchoolID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from School ");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = SchoolID;

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
		public bool DeleteList(string SchoolIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from School ");
			strSql.Append(" where SchoolID in ("+SchoolIDlist + ")  ");
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
		public Tc.Model.School GetModel(Guid SchoolID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SchoolID,SchoolName,Content,AddTime from School ");
			strSql.Append(" where SchoolID=@SchoolID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SchoolID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = SchoolID;

			Tc.Model.School model=new Tc.Model.School();
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
		public Tc.Model.School DataRowToModel(DataRow row)
		{
			Tc.Model.School model=new Tc.Model.School();
			if (row != null)
			{
				if(row["SchoolID"]!=null && row["SchoolID"].ToString()!="")
				{
					model.SchoolID= new Guid(row["SchoolID"].ToString());
				}
				if(row["SchoolName"]!=null)
				{
					model.SchoolName=row["SchoolName"].ToString();
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
			strSql.Append("select SchoolID,SchoolName,Content,AddTime ");
			strSql.Append(" FROM School ");
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
			strSql.Append(" SchoolID,SchoolName,Content,AddTime ");
			strSql.Append(" FROM School ");
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
			strSql.Append("select count(1) FROM School ");
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
				strSql.Append("order by T.SchoolID desc");
			}
			strSql.Append(")AS Row, T.*  from School T ");
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
			parameters[0].Value = "School";
			parameters[1].Value = "SchoolID";
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

