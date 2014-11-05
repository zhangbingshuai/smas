﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Tc.DAL.DBUtility;

namespace Tc.DAL
{
    /// <summary>
    /// 数据访问类:TcAd
    /// </summary>
    public partial class TcAd
    {
        public TcAd()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("ID", "TcAd");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TcAd");
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
        public int Add(Tc.Model.TcAd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TcAd(");
            strSql.Append("Title,Types,Kuan,Gao,Tupian,Shuoming,Url,Code)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Types,@Kuan,@Gao,@Tupian,@Shuoming,@Url,@Code)");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,255),
					new SqlParameter("@Types", SqlDbType.Int,4),
					new SqlParameter("@Kuan", SqlDbType.Float),
					new SqlParameter("@Gao", SqlDbType.Float),
					new SqlParameter("@Tupian", SqlDbType.VarChar,255),
					new SqlParameter("@Shuoming", SqlDbType.VarChar,0),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@Code", SqlDbType.VarChar,0)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Types;
            parameters[2].Value = model.Kuan;
            parameters[3].Value = model.Gao;
            parameters[4].Value = model.Tupian;
            parameters[5].Value = model.Shuoming;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.Code;

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
        public bool Update(Tc.Model.TcAd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TcAd set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Types=@Types,");
            strSql.Append("Kuan=@Kuan,");
            strSql.Append("Gao=@Gao,");
            strSql.Append("Tupian=@Tupian,");
            strSql.Append("Shuoming=@Shuoming,");
            strSql.Append("Url=@Url,");
            strSql.Append("Code=@Code");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,255),
					new SqlParameter("@Types", SqlDbType.Int,4),
					new SqlParameter("@Kuan", SqlDbType.Float),
					new SqlParameter("@Gao", SqlDbType.Float),
					new SqlParameter("@Tupian", SqlDbType.VarChar,255),
					new SqlParameter("@Shuoming", SqlDbType.VarChar,0),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@Code", SqlDbType.VarChar,0),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Types;
            parameters[2].Value = model.Kuan;
            parameters[3].Value = model.Gao;
            parameters[4].Value = model.Tupian;
            parameters[5].Value = model.Shuoming;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.Code;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from TcAd ");
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
            strSql.Append("delete from TcAd ");
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
        public Tc.Model.TcAd GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,Types,Kuan,Gao,Tupian,Shuoming,Url,Code from TcAd ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Tc.Model.TcAd model = new Tc.Model.TcAd();
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
        public Tc.Model.TcAd DataRowToModel(DataRow row)
        {
            Tc.Model.TcAd model = new Tc.Model.TcAd();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Types"] != null && row["Types"].ToString() != "")
                {
                    model.Types = int.Parse(row["Types"].ToString());
                }

                //model.Kuan=row["Kuan"].ToString();
                //model.Gao=row["Gao"].ToString();
                if (row["Tupian"] != null)
                {
                    model.Tupian = row["Tupian"].ToString();
                }
                if (row["Shuoming"] != null)
                {
                    model.Shuoming = row["Shuoming"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
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
            strSql.Append("select ID,Title,Types,Kuan,Gao,Tupian,Shuoming,Url,Code ");
            strSql.Append(" FROM TcAd ");
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