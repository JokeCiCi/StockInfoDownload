using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using StockInfoDownload.AppCode;
using System.IO;
using Model;
using BLL;
namespace StockInfoDownload
{
    public partial class BackGroundForm : Form
    {
        StringBuilder Result = new StringBuilder(1024 * 1024);
        StringBuilder ErrInfo = new StringBuilder(256);
        private BackgroundWorker _demoBGWorker = new BackgroundWorker();
        private static List<int> ALLlistCon = new List<int>();
        private static List<int> OverlistCon = new List<int>();
        StockInfoService _Stockservice = new StockInfoService();
        Stock5MinInfoService _Stock5MinService = new Stock5MinInfoService();
        StockFinanceInfoService _StockFinanceService = new StockFinanceInfoService();
        static bool ShStockCompleted = false;
        static bool SzStockCompleted = false;
        static bool FinanceWorkCompleted = false;
        static bool IsSz5MinWork = false;
        static bool IsSh5MinWork = false;
        static bool IsFinanceWork = false;
        static bool IsDownStockCode = false;
        public BackGroundForm()
        {
            InitializeComponent();
            
        }

        private void BackGroundForm_Load(object sender, EventArgs e)
        {
            Get5MinTimer.Start();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
            
            StringBuilder Result = new StringBuilder(1024 * 1024);
            StringBuilder ErrInfo = new StringBuilder(256);

            #region 连接tdx服务器
            bool bool1 = TdxApi.OpenTdx(ErrInfo);
            int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            int ConnectionID2 = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            ALLlistCon.Add(ConnectionID);
            OverlistCon.Add(ConnectionID);
            #endregion

            int conSZ = OverlistCon[0];
            OverlistCon.RemoveAt(0);
            short Count = 0;
            //SZ 后台查询Count
            bool1 = TdxApi.TdxHq_Multi_GetSecurityCount(conSZ, 0, ref Count, ErrInfo);
            Dictionary<string, string> DicCon = new Dictionary<string, string>();
            DicCon.Add("Con", conSZ.ToString());
            DicCon.Add("Count", Count.ToString());

            //SZ 后台执行
            this.progressBarSZ.Maximum = Count;
            bk_GetStockInfoSZ.RunWorkerAsync(DicCon);



            ALLlistCon.Add(ConnectionID2);
            OverlistCon.Add(ConnectionID2);

            int conSH = OverlistCon[0];
            OverlistCon.RemoveAt(0);
            //SH 后台查询Count
            bool1 = TdxApi.TdxHq_Multi_GetSecurityCount(conSH, 1, ref Count, ErrInfo);
            Dictionary<string, string> DicConSH = new Dictionary<string, string>();
            DicConSH.Add("Con", conSH.ToString());
            DicConSH.Add("Count", Count.ToString());

            //SZ 后台执行
            this.progressBarSH.Maximum = Count;
            bk_GetStockInfoSH.RunWorkerAsync(DicConSH);

            DownStockInfo.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (int i in ALLlistCon)
            {
                TdxApi.TdxHq_Multi_Disconnect(i);
            }
            TdxApi.CloseTdx();
        }

        private void GetStockMinInfoSZ_DoWork(object sender, DoWorkEventArgs e)
        {
            IsDownStockCode = true;
            Dictionary<string,string> dic;
            int con=0;
            short shortResult = 0;
            if(e.Argument != null)
            {
                dic = (Dictionary<string,string>)e.Argument;
                con=Convert.ToInt32(dic["Con"]);
                shortResult=(short)Convert.ToInt32(dic["Count"]);
            }

            bool bool1;

            short Count;
            //bool bool1 =TdxApi.TdxHq_Multi_GetSecurityCount(con, 0, ref shortResult, ErrInfo); 
            //Console.WriteLine(bool1 ? shortResult.ToString() : ErrInfo.ToString());
            int num=shortResult / 1000;
            int sum = 0;
            for (int x = 0; x <=num ; x++ )
            {
                int start = x * 1000;
                Count = shortResult;
                bool1 = TdxApi.TdxHq_Multi_GetSecurityList(con, 0, (short)start, ref Count, Result, ErrInfo);
                string[] strRow = Result.ToString().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);   //分解行的字符串
                //string[] strCol=strRow[0].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> Message = new Dictionary<string, string>();
                Message.Add("Result", "");
                Message.Add("ErrInfo", "");
                for (int i = 1; i < strRow.Length; i++)
                {
                    //分解行的字符串
                    //StockInfo属性 每列数据
                    string[] strCol = strRow[i].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (strCol[6] == "0" || strCol[2].Contains("指数"))
                    {
                        continue;
                    }
                    StockInfo stock = new StockInfo();
                    stock.stockcode = strCol[0];
                    stock.Type = "0";
                    stock.OneHand = strCol[1];
                    stock.Name = strCol[2];
                    stock.PointIndex = strCol[4];
                    stock.YestClose = decimal.Parse(strCol[5]);
                    stock.Unknow1 = strCol[3];
                    stock.Unknow2 = strCol[6];
                    stock.Unknow3 = strCol[7];
                    int ID=_Stockservice.Add(stock);
                    if (ID > 0)
                    {
                        sum += 1;
                        string message = "Current sum is: " + start.ToString();
                        //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                        //第一个参数类型为 int，表示执行进度。
                        //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                        //这里我们给第二个参数传进去一条消息。
                        Message["Result"] = Result.ToString();
                        Message["ErrInfo"] = ErrInfo.ToString();
                        bk_GetStockInfoSZ.ReportProgress(sum, Message);
                    }
                    else
                    {
                        //记录日志
                        Message["Result"] = Result.ToString();
                        Message["ErrInfo"] = ErrInfo.ToString();
                        bk_GetStockInfoSZ.ReportProgress(sum, Message);
                        continue;
                    }
                }
            }
            SzStockCompleted = true;
        }

        private void bk_GetStockMinInfoSZ_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //修改进度条的显示。
            this.progressBarSZ.Value = e.ProgressPercentage;
            //如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            //这是一个 object 类型的对象，您可以通过它传递任何类型。
            //我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            Dictionary<string, string> message;
            string Result;
            string ErrInfo="";
            if (e.UserState != null)
            {
                message = (Dictionary<string, string>)e.UserState;
                Result = message["Result"];
                ErrInfo = message["ErrInfo"];
            }

            this.SZSum.Text = "SZ:"+e.ProgressPercentage.ToString()+"/"+this.progressBarSZ.Maximum.ToString();
        }

        private void bk_GetStockMinInfoSH_DoWork(object sender, DoWorkEventArgs e)
        {
            IsDownStockCode = true;
            Dictionary<string, string> dic;
            int con = 0;
            short shortResult = 0;
            if (e.Argument != null)
            {
                dic = (Dictionary<string, string>)e.Argument;
                con = Convert.ToInt32(dic["Con"]);
                shortResult = (short)Convert.ToInt32(dic["Count"]);
            }

            bool bool1;

            short Count;
            //bool bool1 =TdxApi.TdxHq_Multi_GetSecurityCount(con, 0, ref shortResult, ErrInfo); 
            //Console.WriteLine(bool1 ? shortResult.ToString() : ErrInfo.ToString());
            int num = shortResult / 1000;
            int sum = 0;
            for (int x = 0; x <= num; x++)
            {
                int start = x * 1000;
                Count = shortResult;
                bool1 = TdxApi.TdxHq_Multi_GetSecurityList(con, 1, (short)start, ref Count, Result, ErrInfo);
                string[] strRow = Result.ToString().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);   //分解行的字符串
                //string[] strCol=strRow[0].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> Message = new Dictionary<string, string>();
                Message.Add("Result", "");
                Message.Add("ErrInfo","");
                for (int i = 1; i < strRow.Length; i++)
                {
                    //分解行的字符串
                    //StockInfo属性 每列数据
                    string[] strCol = strRow[i].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (strCol[6] == "0" || strCol[2].Contains("指数"))
                    {
                        continue;
                    }
                    StockInfo stock = new StockInfo();
                    stock.stockcode = strCol[0];
                    stock.Type = "1";
                    stock.OneHand = strCol[1];
                    stock.Name = strCol[2];
                    stock.PointIndex = strCol[4];
                    stock.YestClose = decimal.Parse(strCol[5]);
                    stock.Unknow1 = strCol[3];
                    stock.Unknow2 = strCol[6];
                    stock.Unknow3 = strCol[7];
                    int ID = _Stockservice.Add(stock);
                    if (ID > 0)
                    {
                        sum += 1;
                        string message = "Current sum is: " + start.ToString();
                        //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                        //第一个参数类型为 int，表示执行进度。
                        //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                        //这里我们给第二个参数传进去一条消息。
                        Message["Result"]= Result.ToString();
                        Message["ErrInfo"]= ErrInfo.ToString();
                        bk_GetStockInfoSH.ReportProgress(sum, Message);
                    }
                    else
                    {
                        //记录日志
                        Message["Result"] = Result.ToString();
                        Message["ErrInfo"] = ErrInfo.ToString();
                        bk_GetStockInfoSH.ReportProgress(sum, Message);
                        continue;
                    }
                }
            }
            ShStockCompleted = true;
        }

        private void bk_GetStockMinInfoSH_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //修改进度条的显示。
            this.progressBarSH.Value = e.ProgressPercentage;
            //如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            //这是一个 object 类型的对象，您可以通过它传递任何类型。
            //我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            Dictionary<string, string> message;
            string Result;
            string ErrInfo = "";
            if (e.UserState != null)
            {
                message = (Dictionary<string, string>)e.UserState;
                Result = message["Result"];
                ErrInfo = message["ErrInfo"];
            }

            this.SHSum.Text = "SH:" + e.ProgressPercentage.ToString() + "/" + this.progressBarSH.Maximum.ToString();
        }

        private void bk_GetStock5MinInfoSZ_DoWork(object sender, DoWorkEventArgs e)
        {
            int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            ALLlistCon.Add(ConnectionID);
            OverlistCon.Add(ConnectionID);
            
            //设置 这个bk 在工作
            IsSz5MinWork = true;
           
            List<StockInfo> stockList = _Stockservice.GetStockCodeList("TYPE=0");
            Dictionary<string, string> Message = new Dictionary<string, string>();
            Message.Add("Result", "");
            Message.Add("ErrInfo", "");
            bool bool1;
            foreach (StockInfo s in stockList)
            {
                try
                {
                    short Count = 10;
                    bool1 = TdxApi.TdxHq_Multi_GetSecurityBars(ConnectionID, 0, 0, s.stockcode, 0, ref Count, Result, ErrInfo);
                    if (Count != 0)
                    {
                        string[] strRow = Result.ToString().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);   //分解行的字符串
                        //string[] strColX = strRow[1].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        //时间	开盘价	收盘价	最高价	最低价	成交量	成交额	涨家数	跌家数
                        for (int i = 1; i < strRow.Length; i++)
                        {
                            string[] strCol = strRow[i].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            Stock5MinInfo stock = new Stock5MinInfo();
                            if (!PublicTool.CanDateTime(strCol[0].Replace("--", "-")))
                            {
                                continue;
                            }
                            int IsHave = _Stock5MinService.GetRecordCount("StockCode='" + s.stockcode + "' and Time=CONVERT(datetime,'" + strCol[0].Replace("--", "-") + "',102)");
                            if (IsHave > 0)
                            {
                                continue;
                            }

                            stock.StockCode = s.stockcode;
                            stock.Time = Convert.ToDateTime(strCol[0].Replace("--", "-"));
                            stock.open = decimal.Parse(PublicTool.IsNumElseToZero(strCol[1]));
                            stock.Close = decimal.Parse(PublicTool.IsNumElseToZero(strCol[2]));
                            stock.High = decimal.Parse(PublicTool.IsNumElseToZero(strCol[3]));
                            stock.Low = decimal.Parse(PublicTool.IsNumElseToZero(strCol[4]));
                            stock.Volume = strCol[5];
                            stock.Turnover = strCol[6];
                            //stock.UpNum = strCol[7];
                            //stock.DownNum = strCol[8];
                            int ID = _Stock5MinService.Add(stock);
                            if (ID > 0)
                            {
                                string message = "Current tiem is: " + Convert.ToDateTime(strCol[0].Replace("--", "-"));
                                //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                                //第一个参数类型为 int，表示执行进度。
                                //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                                //这里我们给第二个参数传进去一条消息。
                                Message["Result"] = Result.ToString();
                                Message["ErrInfo"] = ErrInfo.ToString();
                                Message["Message"] = message.ToString();
                                bk_GetStock5MinInfoSZ.ReportProgress(i, Message);
                            }
                            else
                            {
                                //记录日志
                                Message["Result"] = Result.ToString();
                                Message["ErrInfo"] = ErrInfo.ToString();
                                Message["Message"] = "";
                                bk_GetStock5MinInfoSZ.ReportProgress(i, Message);
                                continue;
                            }


                        }
                    }
                    else
                    {
                        Count = 10;
                        bool1 = TdxApi.TdxHq_Multi_GetSecurityBars(ConnectionID, 0, 0, s.stockcode, 0, ref Count, Result, ErrInfo);
                    }
                }
                catch
                {
                    //记录日志
                    continue;
                }
                finally
                {
                }
            }
            ALLlistCon.Remove(ConnectionID);
            OverlistCon.Remove(ConnectionID);
            TdxApi.TdxHq_Multi_Disconnect(ConnectionID);
            IsSz5MinWork = false;
        }

        private void DownStock5MinInfo_Click(object sender, EventArgs e)
        {
            Get5MinTimer.Start();
        }

        private void bk_GetStock5MinInfoSZ_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, string> message;
            string Result;
            string ErrInfo = "";
            string Message="";

            if (e.UserState != null)
            {
                message = (Dictionary<string, string>)e.UserState;
                Result = message["Result"];
                ErrInfo = message["ErrInfo"];
                Message = message["Message"];
            }
            this.SZSum.Text = Message;
        }

        private void Get5MinTimer_Tick(object sender, EventArgs e)
        {
            DateTime startTime = Convert.ToDateTime("9:00");
            DateTime endTime = Convert.ToDateTime("15:00");
            if (!IsDownStockCode)
            {
            StringBuilder Result = new StringBuilder(1024 * 1024);
            StringBuilder ErrInfo = new StringBuilder(256);

            #region 连接tdx服务器
            bool bool1 = TdxApi.OpenTdx(ErrInfo);
            int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            int ConnectionID2 = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            ALLlistCon.Add(ConnectionID);
            OverlistCon.Add(ConnectionID);
            #endregion

            int conSZ = OverlistCon[0];
            OverlistCon.RemoveAt(0);
            short Count = 0;
            //SZ 后台查询Count
            bool1 = TdxApi.TdxHq_Multi_GetSecurityCount(conSZ, 0, ref Count, ErrInfo);
            Dictionary<string, string> DicCon = new Dictionary<string, string>();
            DicCon.Add("Con", conSZ.ToString());
            DicCon.Add("Count", Count.ToString());

            //SZ 后台执行
            this.progressBarSZ.Maximum = Count;
            bk_GetStockInfoSZ.RunWorkerAsync(DicCon);



            ALLlistCon.Add(ConnectionID2);
            OverlistCon.Add(ConnectionID2);

            int conSH = OverlistCon[0];
            OverlistCon.RemoveAt(0);
            //SH 后台查询Count
            bool1 = TdxApi.TdxHq_Multi_GetSecurityCount(conSH, 1, ref Count, ErrInfo);
            Dictionary<string, string> DicConSH = new Dictionary<string, string>();
            DicConSH.Add("Con", conSH.ToString());
            DicConSH.Add("Count", Count.ToString());

            //SZ 后台执行
            this.progressBarSH.Maximum = Count;
            bk_GetStockInfoSH.RunWorkerAsync(DicConSH);
            }
            else if(ShStockCompleted&&SzStockCompleted)
            {
                if (DateTime.Compare(DateTime.Now, startTime) > 0&&DateTime.Compare(DateTime.Now,   endTime)< 0)
                {
                    if (DateTime.Now.ToString("mm").Substring(1,1) == "5"||DateTime.Now.ToString("mm").Substring(1,1) == "0")
                    {

                        if (!IsSz5MinWork)
                        {
                            bk_GetStock5MinInfoSZ.RunWorkerAsync();
                        }
                        if (!IsSh5MinWork)
                        {
                            bk_GetStock5MinInfoSH.RunWorkerAsync();
                        }

                    }
                }
                if (DateTime.Compare(DateTime.Now, endTime) > 0 && !FinanceWorkCompleted && !IsFinanceWork)
                {
                    bk_FinanceInfo.RunWorkerAsync();
                }
            }


        }

        private void bk_GetStock5MinInfoSH_DoWork(object sender, DoWorkEventArgs e)
        {


            int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            ALLlistCon.Add(ConnectionID);
            OverlistCon.Add(ConnectionID);

            
            //设置 这个bk 在工作
            IsSh5MinWork = true;

            List<StockInfo> stockList = _Stockservice.GetStockCodeList("TYPE=1");
            Dictionary<string, string> Message = new Dictionary<string, string>();
            Message.Add("Result", "");
            Message.Add("ErrInfo", "");
            bool bool1;
            #region foreach
            foreach (StockInfo s in stockList)
            {
                try
                {
                    short Count = 10;
                    bool1 = TdxApi.TdxHq_Multi_GetSecurityBars(ConnectionID, 0, 1, s.stockcode, 0, ref Count, Result, ErrInfo);
                    if (Count != 0)
                    {
                        string[] strRow = Result.ToString().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);   //分解行的字符串
                        //string[] strColX = strRow[1].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        //时间	开盘价	收盘价	最高价	最低价	成交量	成交额	涨家数	跌家数
                        for (int i = 1; i < strRow.Length; i++)
                        {
                            string[] strCol = strRow[i].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            Stock5MinInfo stock = new Stock5MinInfo();
                            if (!PublicTool.CanDateTime(strCol[0].Replace("--", "-")))
                            {
                                continue;
                            }
                            int IsHave = _Stock5MinService.GetRecordCount("StockCode='" + s.stockcode + "' and Time=CONVERT(datetime,'" + strCol[0].Replace("--", "-") + "',102)");
                            if (IsHave > 0)
                            {
                                continue;
                            }
                            stock.StockCode = s.stockcode;
                            stock.Time = Convert.ToDateTime(strCol[0].Replace("--", "-"));
                            stock.open = decimal.Parse(PublicTool.IsNumElseToZero(strCol[1]));
                            stock.Close = decimal.Parse(PublicTool.IsNumElseToZero(strCol[2]));
                            stock.High = decimal.Parse(PublicTool.IsNumElseToZero(strCol[3]));
                            stock.Low = decimal.Parse(PublicTool.IsNumElseToZero(strCol[4]));
                            stock.Volume = strCol[5];
                            stock.Turnover = strCol[6];
                            //stock.UpNum = strCol[7];
                            //stock.DownNum = strCol[8];
                            int ID = _Stock5MinService.Add(stock);
                            if (ID > 0)
                            {
                                string message = "Current tiem is: " + Convert.ToDateTime(strCol[0].Replace("--", "-"));
                                //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                                //第一个参数类型为 int，表示执行进度。
                                //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                                //这里我们给第二个参数传进去一条消息。
                                Message["Result"] = Result.ToString();
                                Message["ErrInfo"] = ErrInfo.ToString();
                                Message["Message"] = message.ToString();
                                bk_GetStock5MinInfoSH.ReportProgress(i, Message);
                            }
                            else
                            {
                                //记录日志
                                Message["Result"] = Result.ToString();
                                Message["ErrInfo"] = ErrInfo.ToString();
                                Message["Message"] = "";
                                bk_GetStock5MinInfoSH.ReportProgress(i, Message);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Count = 10;
                        bool1 = TdxApi.TdxHq_Multi_GetSecurityBars(ConnectionID, 0, 1, s.stockcode, 0, ref Count, Result, ErrInfo);
                    }
                }
                catch
                {
                    //记录日志
                    continue;
                }
                finally
                {
                }
            }
            #endregion foreach
            ALLlistCon.Remove(ConnectionID);
            OverlistCon.Remove(ConnectionID);
            TdxApi.TdxHq_Multi_Disconnect(ConnectionID);
            IsSh5MinWork = false;

        }

        private void bk_GetStock5MinInfoSH_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, string> message;
            string Result;
            string ErrInfo = "";
            string Message = "";

            if (e.UserState != null)
            {
                message = (Dictionary<string, string>)e.UserState;
                Result = message["Result"];
                ErrInfo = message["ErrInfo"];
                Message = message["Message"];
            }
            this.SHSum.Text = Message;
        }

        private void DownFinanceInfo_Click(object sender, EventArgs e)
        {
            //int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            //ALLlistCon.Add(ConnectionID);
            //OverlistCon.Add(ConnectionID);
            //int conSZ = OverlistCon[0];
            //OverlistCon.RemoveAt(0);

            //bool bool1 = TdxApi.TdxHq_Multi_GetFinanceInfo(ConnectionID, 0, "000002", Result, ErrInfo); 
            //Console.WriteLine(bool1 ? Result.ToString() : ErrInfo.ToString());
            bk_FinanceInfo.RunWorkerAsync();

        }

        private void bk_FinanceInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            IsFinanceWork = true;
            int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
            ALLlistCon.Add(ConnectionID);
            OverlistCon.Add(ConnectionID);

            List<StockInfo> stockList = _Stockservice.GetStockCodeList("");
            Dictionary<string, string> Message = new Dictionary<string, string>();
            Message.Add("Result", "");
            Message.Add("ErrInfo", "");
            bool bool1;

            #region foreach
            foreach(StockInfo s in stockList){
                try
                {
                    bool1 = TdxApi.TdxHq_Multi_GetFinanceInfo(ConnectionID,Convert.ToByte(s.Type),s.stockcode, Result, ErrInfo);
                    ///出错
                    if (!bool1 || Result.ToString() == "")
                    {
                        //记录日志
                        continue;
                    }
                    string[] strRow = Result.ToString().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);   //分解行的字符串
                    string[] strColX = strRow[1].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int i = 1; i < strRow.Length; i++)
                    {
                        string[] strCol = strRow[i].Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (!(strCol[5].Replace("--", "-") != "0" && strCol[6].Replace("--", "-") != "0"))
                        {
                            continue;
                        }
                        int IsHave = _StockFinanceService.GetRecordCount("Code='" + s.stockcode + "' and CWUpdateTime=CONVERT(datetime,'" + strCol[5].Replace("--", "-") + "',102)");
                        if (IsHave > 0)
                        {
                            continue;
                        }
                        StockFinanceInfo stock = new StockFinanceInfo();
                        stock.Type = strCol[0];
                        stock.Code = strCol[1];
                        stock.GBLT = strCol[2];
                        stock.SSSF =strCol[3];
                        stock.SSHY =strCol[4];
                        stock.CWUpdateTime = DateTime.ParseExact(strCol[5], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                        stock.ListingDate = DateTime.ParseExact(strCol[6], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                        stock.AllGB=strCol[7];
                        stock.GJG=strCol[8];
                        stock.FQRFRG=strCol[9];
                        stock.FRG=strCol[10];
                        stock.BG=strCol[11];
                        stock.HG=strCol[12];
                        stock.ZhGG=strCol[13];
                        stock.AllZC=strCol[14];
                        stock.LDZC=strCol[15];
                        stock.GDZC=strCol[16];
                        stock.WXZC=strCol[17];
                        stock.GDRS=strCol[18];
                        stock.LDFZ=strCol[19];
                        stock.CQFZ=strCol[20];
                        stock.ZBGJJ=strCol[21];
                        stock.JZC=strCol[22];
                        stock.ZYSR=strCol[23];
                        stock.ZYLR=strCol[24];
                        stock.YSZK=strCol[25];
                        stock.YYLR=strCol[26];
                        stock.TZSY=strCol[27];
                        stock.JYXJL=strCol[28];
                        stock.ZXJL=strCol[29];
                        stock.CH=strCol[20];
                        stock.LRZE=strCol[31];
                        stock.SHLR=strCol[32];
                        stock.JLR=strCol[33];
                        stock.WFLR=strCol[34];
                        stock.Unknow1=strCol[35];
                        stock.unknow2 = strCol[36];
                        int ID = _StockFinanceService.Add(stock);
                        if (ID > 0)
                        {
                            string message = "Current tiem is: " + s.stockcode+" type:"+s.Type;
                            //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                            //第一个参数类型为 int，表示执行进度。
                            //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                            //这里我们给第二个参数传进去一条消息。
                            Message["Result"] = Result.ToString();
                            Message["ErrInfo"] = ErrInfo.ToString();
                            Message["Message"] = message.ToString();
                            bk_FinanceInfo.ReportProgress(i, Message);
                        }
                        else
                        {
                            //记录日志
                            Message["Result"] = Result.ToString();
                            Message["ErrInfo"] = ErrInfo.ToString();
                            Message["Message"] = "";
                            bk_FinanceInfo.ReportProgress(i, Message);
                            continue;
                        }
                    }



                }
                catch
                {
                    //记录日志

                    continue;
                }
                finally
                {
                }

            }

            #endregion 

            ALLlistCon.Remove(ConnectionID);
            OverlistCon.Remove(ConnectionID);
            TdxApi.TdxHq_Multi_Disconnect(ConnectionID);
            IsFinanceWork = false;
        }

        private void bk_FinanceInfo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dictionary<string, string> message;
            string Result;
            string ErrInfo = "";
            string Message = "";

            if (e.UserState != null)
            {
                message = (Dictionary<string, string>)e.UserState;
                Result = message["Result"];
                ErrInfo = message["ErrInfo"];
                Message = message["Message"];
            }
            this.lblFinance.Text = Message;
        }
    }
}
