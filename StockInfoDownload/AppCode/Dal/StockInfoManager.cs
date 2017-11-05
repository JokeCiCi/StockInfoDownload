using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using System.Data;
using Model;

namespace Dal
{
    class StockInfoManager
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockInfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.StockInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockInfo(");
            strSql.Append("stockcode,Type,OneHand,Name,PointIndex,YestClose,Unknow1,Unknow2,Unknow3)");
            strSql.Append(" values (");
            strSql.Append("@stockcode,@Type,@OneHand,@Name,@PointIndex,@YestClose,@Unknow1,@Unknow2,@Unknow3)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@stockcode", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@OneHand", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@PointIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@YestClose", SqlDbType.Decimal,9),
					new SqlParameter("@Unknow1", SqlDbType.NVarChar,50),
					new SqlParameter("@Unknow2", SqlDbType.NVarChar,50),
					new SqlParameter("@Unknow3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.stockcode;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.OneHand;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.PointIndex;
            parameters[5].Value = model.YestClose;
            parameters[6].Value = model.Unknow1;
            parameters[7].Value = model.Unknow2;
            parameters[8].Value = model.Unknow3;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.StockInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockInfo set ");
            strSql.Append("stockcode=@stockcode,");
            strSql.Append("Type=@Type,");
            strSql.Append("OneHand=@OneHand,");
            strSql.Append("Name=@Name,");
            strSql.Append("PointIndex=@PointIndex,");
            strSql.Append("YestClose=@YestClose,");
            strSql.Append("Unknow1=@Unknow1,");
            strSql.Append("Unknow2=@Unknow2,");
            strSql.Append("Unknow3=@Unknow3");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@stockcode", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@OneHand", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@PointIndex", SqlDbType.NVarChar,50),
					new SqlParameter("@YestClose", SqlDbType.Decimal,9),
					new SqlParameter("@Unknow1", SqlDbType.NVarChar,50),
					new SqlParameter("@Unknow2", SqlDbType.NVarChar,50),
					new SqlParameter("@Unknow3", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.stockcode;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.OneHand;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.PointIndex;
            parameters[5].Value = model.YestClose;
            parameters[6].Value = model.Unknow1;
            parameters[7].Value = model.Unknow2;
            parameters[8].Value = model.Unknow3;
            parameters[9].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stockinfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stockinfo ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.StockInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,stockcode,Type,OneHand,Name,PointIndex,YestClose,Unknow1,Unknow2,Unknow3 from StockInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.StockInfo model = new Model.StockInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public Model.StockInfo DataRowToModel(DataRow row)
        {
            Model.StockInfo model = new Model.StockInfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["stockcode"] != null)
                {
                    model.stockcode = row["stockcode"].ToString();
                }
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["OneHand"] != null)
                {
                    model.OneHand = row["OneHand"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["PointIndex"] != null)
                {
                    model.PointIndex = row["PointIndex"].ToString();
                }
                if (row["YestClose"] != null && row["YestClose"].ToString() != "")
                {
                    model.YestClose = decimal.Parse(row["YestClose"].ToString());
                }
                if (row["Unknow1"] != null)
                {
                    model.Unknow1 = row["Unknow1"].ToString();
                }
                if (row["Unknow2"] != null)
                {
                    model.Unknow2 = row["Unknow2"].ToString();
                }
                if (row["Unknow3"] != null)
                {
                    model.Unknow3 = row["Unknow3"].ToString();
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
            strSql.Append("select id,stockcode,Type,OneHand,Name,PointIndex,YestClose,Unknow1,Unknow2,Unknow3 ");
            strSql.Append(" FROM StockInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,stockcode,Type,OneHand,Name,PointIndex,YestClose,Unknow1,Unknow2,Unknow3 ");
            strSql.Append(" FROM StockInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM StockInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from StockInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "StockInfo";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetStockCodeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct stockcode , Name ,[TYPE],'0' as id ,''as OneHand,''as PointIndex,''as YestClose,''as Unknow1,''as Unknow2,''as Unknow3");
            strSql.Append(" FROM stockinfo ");
            strSql.Append("where Unknow2<>0 and Name not like '%指数%' ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
