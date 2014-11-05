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
    /// 数据访问类:TcFenlei
    /// </summary>
    public partial class TcFenlei
    {
        public TcFenlei()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelper.GetMaxID("ID", "TcFenlei");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TcFenlei");
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
        public int Add(Tc.Model.TcFenlei model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TcFenlei(");
            strSql.Append("Name,Types,Pid,Paixu,Url,Miaoshu,SeoTitle,SeoKeyword,SeoDescription)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Types,@Pid,@Paixu,@Url,@Miaoshu,@SeoTitle,@SeoKeyword,@SeoDescription)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@Types", SqlDbType.VarChar,255),
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Paixu", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@Miaoshu", SqlDbType.VarChar,0),
					new SqlParameter("@SeoTitle", SqlDbType.VarChar,255),
					new SqlParameter("@SeoKeyword", SqlDbType.VarChar,255),
					new SqlParameter("@SeoDescription", SqlDbType.VarChar,255)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Types;
            parameters[2].Value = model.Pid;
            parameters[3].Value = model.Paixu;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.Miaoshu;
            parameters[6].Value = model.SeoTitle;
            parameters[7].Value = model.SeoKeyword;
            parameters[8].Value = model.SeoDescription;

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
        public bool Update(Tc.Model.TcFenlei model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TcFenlei set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Types=@Types,");
            strSql.Append("Pid=@Pid,");
            strSql.Append("Paixu=@Paixu,");
            strSql.Append("Url=@Url,");
            strSql.Append("Miaoshu=@Miaoshu,");
            strSql.Append("SeoTitle=@SeoTitle,");
            strSql.Append("SeoKeyword=@SeoKeyword,");
            strSql.Append("SeoDescription=@SeoDescription");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,255),
					new SqlParameter("@Types", SqlDbType.VarChar,255),
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Paixu", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,255),
					new SqlParameter("@Miaoshu", SqlDbType.VarChar,0),
					new SqlParameter("@SeoTitle", SqlDbType.VarChar,255),
					new SqlParameter("@SeoKeyword", SqlDbType.VarChar,255),
					new SqlParameter("@SeoDescription", SqlDbType.VarChar,255),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Types;
            parameters[2].Value = model.Pid;
            parameters[3].Value = model.Paixu;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.Miaoshu;
            parameters[6].Value = model.SeoTitle;
            parameters[7].Value = model.SeoKeyword;
            parameters[8].Value = model.SeoDescription;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from TcFenlei ");
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
            strSql.Append("delete from TcFenlei ");
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
        public Tc.Model.TcFenlei GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Types,Pid,Paixu,Url,Miaoshu,SeoTitle,SeoKeyword,SeoDescription from TcFenlei ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Tc.Model.TcFenlei model = new Tc.Model.TcFenlei();
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
        public Tc.Model.TcFenlei DataRowToModel(DataRow row)
        {
            Tc.Model.TcFenlei model = new Tc.Model.TcFenlei();
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
                if (row["Types"] != null)
                {
                    model.Types = row["Types"].ToString();
                }
                if (row["Pid"] != null && row["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(row["Pid"].ToString());
                }
                if (row["Paixu"] != null && row["Paixu"].ToString() != "")
                {
                    model.Paixu = int.Parse(row["Paixu"].ToString());
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["Miaoshu"] != null)
                {
                    model.Miaoshu = row["Miaoshu"].ToString();
                }
                if (row["SeoTitle"] != null)
                {
                    model.SeoTitle = row["SeoTitle"].ToString();
                }
                if (row["SeoKeyword"] != null)
                {
                    model.SeoKeyword = row["SeoKeyword"].ToString();
                }
                if (row["SeoDescription"] != null)
                {
                    model.SeoDescription = row["SeoDescription"].ToString();
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
            strSql.Append("select ID,Name,Types,Pid,Paixu,Url,Miaoshu,SeoTitle,SeoKeyword,SeoDescription ");
            strSql.Append(" FROM TcFenlei ");
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