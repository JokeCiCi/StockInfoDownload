using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Stock5MinInfo
    {
        #region Model
        private int _id;
        private string _stockcode;
        private DateTime? _time;
        private decimal? _open;
        private decimal? _close;
        private decimal? _high;
        private decimal? _low;
        private string _volume;
        private string _turnover;
        private string _upnum;
        private string _downnum;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StockCode
        {
            set { _stockcode = value; }
            get { return _stockcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? open
        {
            set { _open = value; }
            get { return _open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Close
        {
            set { _close = value; }
            get { return _close; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? High
        {
            set { _high = value; }
            get { return _high; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Low
        {
            set { _low = value; }
            get { return _low; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Volume
        {
            set { _volume = value; }
            get { return _volume; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Turnover
        {
            set { _turnover = value; }
            get { return _turnover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpNum
        {
            set { _upnum = value; }
            get { return _upnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DownNum
        {
            set { _downnum = value; }
            get { return _downnum; }
        }
        #endregion Model

    }
}
