﻿/** 
* Copyright (c) 2013-2020 SMAS. All rights reserved.
*┌──────────────────────────────────┐
*│  作者QQ:599906561  email: 599906561@qq.com
*│  QQ群： 2068911
*│　版权所有：SMAS版权所有 http://www.smas.net.cn　
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using Tc.Model;

namespace Tc.BLL
{
    /// <summary>
    /// TcFenlei
    /// </summary>
    public partial class TcFenlei : BLLBase<TcFenlei>
    {
        private readonly Tc.DAL.TcFenlei dal = new Tc.DAL.TcFenlei();

        public TcFenlei()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tc.Model.TcFenlei model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tc.Model.TcFenlei model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tc.Model.TcFenlei GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tc.Model.TcFenlei> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tc.Model.TcFenlei> DataTableToList(DataTable dt)
        {
            List<Tc.Model.TcFenlei> modelList = new List<Tc.Model.TcFenlei>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tc.Model.TcFenlei model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        #endregion BasicMethod

        #region ExtensionMethod

        #endregion ExtensionMethod
    }
}