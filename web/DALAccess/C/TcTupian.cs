﻿/**
* Copyright (c) 2013-2020 SMAS. All rights reserved.
*┌──────────────────────────────────┐
*│  作者QQ:59990-6-5-6-1  email: 599906561@qq.com
*│　版权所有：SMAS版权所有 http://SMAS
*└──────────────────────────────────┘
*/

using Tc.DAL.DBUtility;//Please add references

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Tc.DAL
{
    /// <summary>
    /// 数据访问类:TcTupian
    /// </summary>
    public partial class TcTupian
    {
        public TcTupian()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("ID", "TcTupian");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TcTupian");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tc.Model.TcTupian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TcTupian(");
            strSql.Append("Articleid,Title,Tupian,Content,Addtime)");
            strSql.Append(" values (");
            strSql.Append("@Articleid,@Title,@Tupian,@Content,@Addtime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Articleid", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,255),
					new SqlParameter("@Tupian", SqlDbType.VarChar,255),
					new SqlParameter("@Content", SqlDbType.VarChar,0),
					new SqlParameter("@Addtime", SqlDbType.Date)};
            parameters[0].Value = model.Articleid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Tupian;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Addtime;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return GetMaxId();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tc.Model.TcTupian model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TcTupian set ");
            strSql.Append("Articleid=@Articleid,");
            strSql.Append("Title=@Title,");
            strSql.Append("Tupian=@Tupian,");
            strSql.Append("Content=@Content,");
            strSql.Append("Addtime=@Addtime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Articleid", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,255),
					new SqlParameter("@Tupian", SqlDbType.VarChar,255),
					new SqlParameter("@Content", SqlDbType.VarChar,0),
					new SqlParameter("@Addtime", SqlDbType.Date),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Articleid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Tupian;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Addtime;
            parameters[5].Value = model.ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TcTupian ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TcTupian ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelper.ExecuteSql(strSql.ToString());
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
        public Tc.Model.TcTupian GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Articleid,Title,Tupian,Content,Addtime from TcTupian ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Tc.Model.TcTupian model = new Tc.Model.TcTupian();
            DataSet ds = DbHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Tc.Model.TcTupian DataRowToModel(DataRow row)
        {
            Tc.Model.TcTupian model = new Tc.Model.TcTupian();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Articleid"] != null && row["Articleid"].ToString() != "")
                {
                    model.Articleid = int.Parse(row["Articleid"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Tupian"] != null)
                {
                    model.Tupian = row["Tupian"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["Addtime"] != null && row["Addtime"].ToString() != "")
                {
                    model.Addtime = DateTime.Parse(row["Addtime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Articleid,Title,Tupian,Content,Addtime ");
            strSql.Append(" FROM TcTupian ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.Query(strSql.ToString());
        }

        #endregion BasicMethod

        #region ExtensionMethod

        #endregion ExtensionMethod
    }
}