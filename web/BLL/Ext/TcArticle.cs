using System;
using System.Collections.Generic;
using System.Data;
using Tc.Model;

/**
* Copyright (c) 2013-2020 SMAS. All rights reserved.
*┌──────────────────────────────────┐
*│  作者QQ:599906561  email: 599906561@qq.com
*│  QQ群： 2068911
*│　版权所有：SMAS版权所有 http://www.smas.net.cn　
*└──────────────────────────────────┘
*/

namespace Tc.BLL
{
    /// <summary>
    /// TcArticle
    /// </summary>
    public partial class TcArticle : BLLBase<TcArticle>
    {
        /// <summary>
        /// 获取前多少条数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
    }
}