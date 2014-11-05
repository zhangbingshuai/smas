/**
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
    /// 数据访问类:TcChanpin
    /// </summary>
    public partial class TcChanpin
    {
        public TcChanpin()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("ID", "TcChanpin");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TcChanpin");
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
        public int Add(Tc.Model.TcChanpin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TcChanpin(");
            strSql.Append("Articleid,Shuxing,Addtime)");
            strSql.Append(" values (");
            strSql.Append("@Articleid,@Shuxing,@Addtime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Articleid", SqlDbType.Int,4),
					new SqlParameter("@Shuxing", SqlDbType.VarChar,0),
					new SqlParameter("@Addtime", SqlDbType.Date)};
            parameters[0].Value = model.Articleid;
            parameters[1].Value = model.Shuxing;
            parameters[2].Value = model.Addtime;

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
        public bool Update(Tc.Model.TcChanpin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TcChanpin set ");
            strSql.Append("Articleid=@Articleid,");
            strSql.Append("Shuxing=@Shuxing,");
            strSql.Append("Addtime=@Addtime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Articleid", SqlDbType.Int,4),
					new SqlParameter("@Shuxing", SqlDbType.VarChar,0),
					new SqlParameter("@Addtime", SqlDbType.Date),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Articleid;
            parameters[1].Value = model.Shuxing;
            parameters[2].Value = model.Addtime;
            parameters[3].Value = model.ID;

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
            strSql.Append("delete from TcChanpin ");
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
            strSql.Append("delete from TcChanpin ");
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
        public Tc.Model.TcChanpin GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Articleid,Shuxing,Addtime from TcChanpin ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Tc.Model.TcChanpin model = new Tc.Model.TcChanpin();
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
        public Tc.Model.TcChanpin DataRowToModel(DataRow row)
        {
            Tc.Model.TcChanpin model = new Tc.Model.TcChanpin();
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
                if (row["Shuxing"] != null)
                {
                    model.Shuxing = row["Shuxing"].ToString();
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
            strSql.Append("select ID,Articleid,Shuxing,Addtime ");
            strSql.Append(" FROM TcChanpin ");
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