using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockCwInfo
    {
        #region Model
		private int _id;
        private string _code;
		private DateTime? _reportdate;
		private decimal? _jbmgsy;
		private decimal? _mgjzc;
		private decimal? _mgjyhdcsxjlje;
		private string _zyywsr;
		private string _zyywlr;
		private string _yylr;
		private string _tzsy;
		private string _yyeyszje;
		private string _lrze;
		private string _jlr;
		private string _jlrout;
		private string _jyhdcsdxjlje;
		private string _xjjxjdjwjcje;
		private string _zzc;
		private string _ldzc;
		private string _zfz;
		private string _ldfz;
		private string _gdqybhssgdqy;
		private decimal? _jzcsyljq;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
		/// <summary>
		/// 报告日期
		/// </summary>
		public DateTime? ReportDate
		{
			set{ _reportdate=value;}
			get{return _reportdate;}
		}
		/// <summary>
		/// 基本每股收益(元)
		/// </summary>
		public decimal? JBMGSY
		{
			set{ _jbmgsy=value;}
			get{return _jbmgsy;}
		}
		/// <summary>
		/// 每股净资产(元)
		/// </summary>
		public decimal? MGJZC
		{
			set{ _mgjzc=value;}
			get{return _mgjzc;}
		}
		/// <summary>
		/// 每股经营活动产生的现金流量净额(元)
		/// </summary>
		public decimal? MGJYHDCSXJLJE
		{
			set{ _mgjyhdcsxjlje=value;}
			get{return _mgjyhdcsxjlje;}
		}
		/// <summary>
		/// 主营业务收入(万元)
		/// </summary>
		public string ZYYWSR
		{
			set{ _zyywsr=value;}
			get{return _zyywsr;}
		}
		/// <summary>
		/// 主营业务利润(万元)
		/// </summary>
		public string ZYYWLR
		{
			set{ _zyywlr=value;}
			get{return _zyywlr;}
		}
		/// <summary>
		/// 营业利润(万元)
		/// </summary>
		public string YYLR
		{
			set{ _yylr=value;}
			get{return _yylr;}
		}
		/// <summary>
		/// 投资收益(万元)
		/// </summary>
		public string TZSY
		{
			set{ _tzsy=value;}
			get{return _tzsy;}
		}
		/// <summary>
		/// 营业外收支净额(万元)
		/// </summary>
		public string YYEYSZJE
		{
			set{ _yyeyszje=value;}
			get{return _yyeyszje;}
		}
		/// <summary>
		/// 利润总额(万元)
		/// </summary>
		public string LRZE
		{
			set{ _lrze=value;}
			get{return _lrze;}
		}
		/// <summary>
		/// 净利润(万元)
		/// </summary>
		public string JLR
		{
			set{ _jlr=value;}
			get{return _jlr;}
		}
		/// <summary>
		/// 净利润(扣除非经常性损益后)(万元)
		/// </summary>
		public string JLROUT
		{
			set{ _jlrout=value;}
			get{return _jlrout;}
		}
		/// <summary>
		/// 经营活动产生的现金流量净额(万元)
		/// </summary>
		public string JYHDCSDXJLJE
		{
			set{ _jyhdcsdxjlje=value;}
			get{return _jyhdcsdxjlje;}
		}
		/// <summary>
		/// 现金及现金等价物净增加额(万元)
		/// </summary>
		public string XJJXJDJWJCJE
		{
			set{ _xjjxjdjwjcje=value;}
			get{return _xjjxjdjwjcje;}
		}
		/// <summary>
		/// 总资产(万元)
		/// </summary>
		public string ZZC
		{
			set{ _zzc=value;}
			get{return _zzc;}
		}
		/// <summary>
		/// 流动资产(万元)
		/// </summary>
		public string LDZC
		{
			set{ _ldzc=value;}
			get{return _ldzc;}
		}
		/// <summary>
		/// 总负债(万元)
		/// </summary>
		public string ZFZ
		{
			set{ _zfz=value;}
			get{return _zfz;}
		}
		/// <summary>
		/// 流动负债(万元)
		/// </summary>
		public string LDFZ
		{
			set{ _ldfz=value;}
			get{return _ldfz;}
		}
		/// <summary>
		/// 股东权益不含少数股东权益(万元)
		/// </summary>
		public string GDQYBHSSGDQY
		{
			set{ _gdqybhssgdqy=value;}
			get{return _gdqybhssgdqy;}
		}
		/// <summary>
		/// 净资产收益率加权(%)
		/// </summary>
		public decimal? JZCSYLJQ
		{
			set{ _jzcsyljq=value;}
			get{return _jzcsyljq;}
		}
		#endregion Model


    }
}
