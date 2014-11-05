﻿/**
* Copyright (c) 2013-2020 SMAS. All rights reserved.
*┌──────────────────────────────────┐
*│  作者QQ:599906561  email: 599906561@qq.com
*│　版权所有：SMAS版权所有(http://www.smas.net.cn)　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tc.Model
{
    //TcAd
    public partial class TcAd
    {
        public TcAd()
        {
            _id = 0;
            _title = "";
            _types = 0;
            _kuan = 0;
            _gao = 0;
            _tupian = "";
            _shuoming = "";
            _url = "";
            _code = "";
        }

        /// <summary>
        /// ID
        /// </summary>
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Title
        /// </summary>
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Types
        /// </summary>
        private int? _types;

        public int? Types
        {
            get { return _types; }
            set { _types = value; }
        }

        /// <summary>
        /// Kuan
        /// </summary>
        private decimal? _kuan;

        public decimal? Kuan
        {
            get { return _kuan; }
            set { _kuan = value; }
        }

        /// <summary>
        /// Gao
        /// </summary>
        private decimal? _gao;

        public decimal? Gao
        {
            get { return _gao; }
            set { _gao = value; }
        }

        /// <summary>
        /// Tupian
        /// </summary>
        private string _tupian;

        public string Tupian
        {
            get { return _tupian; }
            set { _tupian = value; }
        }

        /// <summary>
        /// Shuoming
        /// </summary>
        private string _shuoming;

        public string Shuoming
        {
            get { return _shuoming; }
            set { _shuoming = value; }
        }

        /// <summary>
        /// Url
        /// </summary>
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// Code
        /// </summary>
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
    }
}