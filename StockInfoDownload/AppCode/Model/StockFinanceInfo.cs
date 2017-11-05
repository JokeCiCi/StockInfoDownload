using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class StockFinanceInfo
    {
        #region Model
        private int _id;
        private string _type;
        private string _code;
        private string _gblt;
        private string _sssf;
        private string _sshy;
        private DateTime? _cwupdatetime;
        private DateTime? _listingdate;
        private string _allgb;
        private string _gjg;
        private string _fqrfrg;
        private string _frg;
        private string _bg;
        private string _hg;
        private string _zhgg;
        private string _allzc;
        private string _ldzc;
        private string _gdzc;
        private string _wxzc;
        private string _gdrs;
        private string _ldfz;
        private string _cqfz;
        private string _zbgjj;
        private string _jzc;
        private string _zysr;
        private string _zylr;
        private string _yszk;
        private string _yylr;
        private string _tzsy;
        private string _jyxjl;
        private string _zxjl;
        private string _ch;
        private string _lrze;
        private string _shlr;
        private string _jlr;
        private string _wflr;
        private string _unknow1;
        private string _unknow2;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 市场
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 证券代码
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 流通股本
        /// </summary>
        public string GBLT
        {
            set { _gblt = value; }
            get { return _gblt; }
        }
        /// <summary>
        /// 所属省份
        /// </summary>
        public string SSSF
        {
            set { _sssf = value; }
            get { return _sssf; }
        }
        /// <summary>
        /// 所属行业
        /// </summary>
        public string SSHY
        {
            set { _sshy = value; }
            get { return _sshy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CWUpdateTime
        {
            set { _cwupdatetime = value; }
            get { return _cwupdatetime; }
        }
        /// <summary>
        /// 上市日期
        /// </summary>
        public DateTime? ListingDate
        {
            set { _listingdate = value; }
            get { return _listingdate; }
        }
        /// <summary>
        /// 总股本
        /// </summary>
        public string AllGB
        {
            set { _allgb = value; }
            get { return _allgb; }
        }
        /// <summary>
        /// 国家股
        /// </summary>
        public string GJG
        {
            set { _gjg = value; }
            get { return _gjg; }
        }
        /// <summary>
        /// 发起人法人股
        /// </summary>
        public string FQRFRG
        {
            set { _fqrfrg = value; }
            get { return _fqrfrg; }
        }
        /// <summary>
        /// 法人股
        /// </summary>
        public string FRG
        {
            set { _frg = value; }
            get { return _frg; }
        }
        /// <summary>
        /// B股
        /// </summary>
        public string BG
        {
            set { _bg = value; }
            get { return _bg; }
        }
        /// <summary>
        /// H股
        /// </summary>
        public string HG
        {
            set { _hg = value; }
            get { return _hg; }
        }
        /// <summary>
        /// 职工股
        /// </summary>
        public string ZhGG
        {
            set { _zhgg = value; }
            get { return _zhgg; }
        }
        /// <summary>
        /// 总资产
        /// </summary>
        public string AllZC
        {
            set { _allzc = value; }
            get { return _allzc; }
        }
        /// <summary>
        /// 流动资产
        /// </summary>
        public string LDZC
        {
            set { _ldzc = value; }
            get { return _ldzc; }
        }
        /// <summary>
        /// 固定资产
        /// </summary>
        public string GDZC
        {
            set { _gdzc = value; }
            get { return _gdzc; }
        }
        /// <summary>
        /// 无形资产
        /// </summary>
        public string WXZC
        {
            set { _wxzc = value; }
            get { return _wxzc; }
        }
        /// <summary>
        /// 股东人数
        /// </summary>
        public string GDRS
        {
            set { _gdrs = value; }
            get { return _gdrs; }
        }
        /// <summary>
        /// 流动负债
        /// </summary>
        public string LDFZ
        {
            set { _ldfz = value; }
            get { return _ldfz; }
        }
        /// <summary>
        /// 长期负债
        /// </summary>
        public string CQFZ
        {
            set { _cqfz = value; }
            get { return _cqfz; }
        }
        /// <summary>
        /// 资本公积金
        /// </summary>
        public string ZBGJJ
        {
            set { _zbgjj = value; }
            get { return _zbgjj; }
        }
        /// <summary>
        /// 净资产
        /// </summary>
        public string JZC
        {
            set { _jzc = value; }
            get { return _jzc; }
        }
        /// <summary>
        /// 主营收入
        /// </summary>
        public string ZYSR
        {
            set { _zysr = value; }
            get { return _zysr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZYLR
        {
            set { _zylr = value; }
            get { return _zylr; }
        }
        /// <summary>
        /// 应收帐款
        /// </summary>
        public string YSZK
        {
            set { _yszk = value; }
            get { return _yszk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YYLR
        {
            set { _yylr = value; }
            get { return _yylr; }
        }
        /// <summary>
        /// 投资收益
        /// </summary>
        public string TZSY
        {
            set { _tzsy = value; }
            get { return _tzsy; }
        }
        /// <summary>
        /// 经营现金流
        /// </summary>
        public string JYXJL
        {
            set { _jyxjl = value; }
            get { return _jyxjl; }
        }
        /// <summary>
        /// 总现金流
        /// </summary>
        public string ZXJL
        {
            set { _zxjl = value; }
            get { return _zxjl; }
        }
        /// <summary>
        /// 存货
        /// </summary>
        public string CH
        {
            set { _ch = value; }
            get { return _ch; }
        }
        /// <summary>
        /// 利润总额
        /// </summary>
        public string LRZE
        {
            set { _lrze = value; }
            get { return _lrze; }
        }
        /// <summary>
        /// 税后利润
        /// </summary>
        public string SHLR
        {
            set { _shlr = value; }
            get { return _shlr; }
        }
        /// <summary>
        /// 净利润
        /// </summary>
        public string JLR
        {
            set { _jlr = value; }
            get { return _jlr; }
        }
        /// <summary>
        /// 未分利润
        /// </summary>
        public string WFLR
        {
            set { _wflr = value; }
            get { return _wflr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unknow1
        {
            set { _unknow1 = value; }
            get { return _unknow1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string unknow2
        {
            set { _unknow2 = value; }
            get { return _unknow2; }
        }
        #endregion Model
    }
}
