using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
    public class BLLP : BLLBase<BLLP>
    {
        public DataTable Get_Page_List(string tablename, string orderby, int startrecordindex, int pagesize, string where, out int sumcount)
        {
            Tc.DAL.DALP dal = new DAL.DALP();
            return dal.Get_Page_List(tablename, orderby, startrecordindex, pagesize, where, out sumcount);
        }
    }
}