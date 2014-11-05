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
    /// 数据访问类:TcShi
    /// </summary>
    public partial class TcShi
    {
        public TcShi()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("ID", "TcShi");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TcShi");
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
        public int Add(Tc.Model.TcShi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TcShi(");
            strSql.Append("Code,Name,ShengCode,Paixu)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Name,@ShengCode,@Paixu)");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,255),
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@ShengCode", SqlDbType.VarChar,255),
					new SqlParameter("@Paixu", SqlDbType.Int,4)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ShengCode;
            parameters[3].Value = model.Paixu;

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
        public bool Update(Tc.Model.TcShi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TcShi set ");
            strSql.Append("Code=@Code,");
            strSql.Append("Name=@Name,");
            strSql.Append("ShengCode=@ShengCode,");
            strSql.Append("Paixu=@Paixu");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,255),
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@ShengCode", SqlDbType.VarChar,255),
					new SqlParameter("@Paixu", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ShengCode;
            parameters[3].Value = model.Paixu;
            parameters[4].Value = model.ID;

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
            strSql.Append("delete from TcShi ");
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
            strSql.Append("delete from TcShi ");
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
        public Tc.Model.TcShi GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Code,Name,ShengCode,Paixu from TcShi ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Tc.Model.TcShi model = new Tc.Model.TcShi();
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
        public Tc.Model.TcShi DataRowToModel(DataRow row)
        {
            Tc.Model.TcShi model = new Tc.Model.TcShi();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["ShengCode"] != null)
                {
                    model.ShengCode = row["ShengCode"].ToString();
                }
                if (row["Paixu"] != null && row["Paixu"].ToString() != "")
                {
                    model.Paixu = int.Parse(row["Paixu"].ToString());
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
            strSql.Append("select ID,Code,Name,ShengCode,Paixu ");
            strSql.Append(" FROM TcShi ");
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