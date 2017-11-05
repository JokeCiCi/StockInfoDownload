using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class StockInfo
    {
        #region Model
        private int _id;
        private string _stockcode;
        private string _type;
        private string _onehand;
        private string _name;
        private string _pointindex;
        private decimal? _yestclose;
        private string _unknow1;
        private string _unknow2;
        private string _unknow3;
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
        public string stockcode
        {
            set { _stockcode = value; }
            get { return _stockcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OneHand
        {
            set { _onehand = value; }
            get { return _onehand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PointIndex
        {
            set { _pointindex = value; }
            get { return _pointindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? YestClose
        {
            set { _yestclose = value; }
            get { return _yestclose; }
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
        public string Unknow2
        {
            set { _unknow2 = value; }
            get { return _unknow2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unknow3
        {
            set { _unknow3 = value; }
            get { return _unknow3; }
        }
        #endregion Model

    }
}
