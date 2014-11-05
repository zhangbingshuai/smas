/**
* Copyright (c) 2013-2020 SMAS. All rights reserved.
*┌──────────────────────────────────┐
*│  作者QQ:59990-6-5-6-1  email: 599906561@qq.com
*│　版权所有：SMAS版权所有 http://SMAS
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Tc.DAL.DBUtility;

namespace Tc.DAL
{
    /// <summary>
    /// 数据访问类:TcAdmin
    /// </summary>
    public partial class TcAdmin
    {
        public TcAdmin()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("ID", "TcAdmin");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TcAdmin");
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
        public int Add(Tc.Model.TcAdmin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TcAdmin(");
            strSql.Append("Name,Pwd,Role)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Pwd,@Role)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@Pwd", SqlDbType.VarChar,255),
					new SqlParameter("@Role", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.Role;

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
        public bool Update(Tc.Model.TcAdmin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TcAdmin set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Role=@Role");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@Pwd", SqlDbType.VarChar,255),
					new SqlParameter("@Role", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.Role;
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
            strSql.Append("delete from TcAdmin ");
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
            strSql.Append("delete from TcAdmin ");
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
        public Tc.Model.TcAdmin GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Pwd,Role from TcAdmin ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Tc.Model.TcAdmin model = new Tc.Model.TcAdmin();
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
        public Tc.Model.TcAdmin DataRowToModel(DataRow row)
        {
            Tc.Model.TcAdmin model = new Tc.Model.TcAdmin();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Role"] != null && row["Role"].ToString() != "")
                {
                    model.Role = int.Parse(row["Role"].ToString());
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
            strSql.Append("select ID,Name,Pwd,Role ");
            strSql.Append(" FROM TcAdmin ");
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