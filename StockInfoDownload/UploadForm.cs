using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SufeiUtil;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BLL;
using Model;
using System.Data.SqlClient;



namespace StockInfoDownload
{
    public partial class UploadForm : Form
    {

        StockMinInfoService _StockMinservice = new StockMinInfoService();
        StockInfoService _Stockservice = new StockInfoService();
        StockCwInfoService _StockCwservice = new StockCwInfoService();
        StockZCFZInfoService _StockZCFZService = new StockZCFZInfoService();
        public UploadForm()
        {
            InitializeComponent();
        }
        //读取每分钟数据
        private void button1_Click(object sender, EventArgs e)
        {
            List<StockInfo> stocklist=_Stockservice.GetModelList("");
            string a= DateTime.Now.ToString();

            int y = stocklist.Count / 100 + 1;
            for (int num = 0; num < y;num++ )
            {
                int c = 100+num*100;
                if (c > stocklist.Count)
                {
                    c=stocklist.Count;
                }
                List<string> stocklist2 = new List<string>();
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem();
                item.URL = "http://api.money.126.net/data/feed/";
                
                for (int stockCount = num * 100; stockCount < c; stockCount++)
                {
                    string x = stocklist[stockCount].ToString();
                    switch (stocklist[stockCount].stockcode.Substring(0, 1))
                    {
                        //3-sz
                        //0-sz
                        //6-sh
                        default:
                            MessageBox.Show("1到5之外的数");
                            break;
                        case "0":
                            item.URL += "1" + stocklist[stockCount].stockcode + ",";
                            stocklist2.Add("1" + stocklist[stockCount].stockcode);
                            break;
                        case "3":
                            item.URL += "1" + stocklist[stockCount].stockcode + ",";
                            stocklist2.Add("1" + stocklist[stockCount].stockcode);
                            break;
                        case "6":
                            item.URL += "0" + stocklist[stockCount].stockcode + ",";
                            stocklist2.Add("0" + stocklist[stockCount].stockcode);
                            break;
                        case"1":
                            item.URL += "1" + stocklist[stockCount].stockcode + ",";
                            stocklist2.Add("1" + stocklist[stockCount].stockcode);
                            break;
                        case "2":
                            item.URL += "1" + stocklist[stockCount].stockcode + ",";
                            stocklist2.Add("1" + stocklist[stockCount].stockcode);
                            break;

                    }

                }
                item.URL += "money.api";

                item.Encoding = Encoding.UTF8;
                item.Method = "GET";
                item.Timeout = 100000;
                item.ReadWriteTimeout = 30000;//写入Post数据超时时间，可选项默认为30000

                HttpResult result = http.GetHtml(item);

                string html = result.Html;

                string statusCodeDescription = result.StatusDescription;
                //示例：
                //_ntes_quote_callback({"0601398":{"code": "0601398", "percent": 0.02314, "share": "1", "high": 6.26, "askvol3": 2000, "askvol2": 117612, "askvol5": 1075200, "askvol4": 1098800, "price": 6.19, "open": 6.05, "bid5": 6.13, "bid4": 6.14, "bid3": 6.15, "bid2": 6.16, "bid1": 6.17, "low": 6.02, "updown": 0.14, "type": "SH", "symbol": "601398", "status": 0, "ask4": 6.21, "bidvol3": 759900, "bidvol2": 762600, "bidvol1": 320900, "update": "2017/10/27 15:59:49", "bidvol5": 1270500, "bidvol4": 613200, "yestclose": 6.05, "askvol1": 66800, "ask5": 6.22, "volume": 456396456, "ask1": 6.18, "name": "\u5de5\u5546\u94f6\u884c", "ask3": 6.2, "ask2": 6.19, "arrow": "\u2191", "time": "2017/10/27 15:30:00", "turnover": 2808909770} });
                html = html.Replace("_ntes_quote_callback(", "");
                html = html.Replace(");", "");
                //object b = JsonConvert.DeserializeObject(html);

                JObject ja = (JObject)JsonConvert.DeserializeObject(html);
                JObject jb = (JObject)ja["0601398"];
                JObject jb2 = (JObject)ja["1000002"];
                //StockMinInfo stock2 = JsonConvert.DeserializeObject<StockMinInfo>(jb.ToString());
                //StockMinInfo stock3 = JsonConvert.DeserializeObject<StockMinInfo>(ja["10000002"].ToString());
                foreach(string x in stocklist2){
                    StockMinInfo stock4 = JsonConvert.DeserializeObject<StockMinInfo>(ja[x].ToString());
                    int ID = _StockMinservice.Add(stock4);
                    if (ID > 0)
                    {
                    

                    }
                    else
                    {
                        MessageBox.Show(x.ToString());
                    }
                }
            }
            MessageBox.Show(a +"   "+ DateTime.Now.ToString());
            

        }
        //财务指标
        private void button2_Click(object sender, EventArgs e)
        {
            List<StockInfo> stocklist=_Stockservice.GetModelList("");
            foreach(StockInfo s in stocklist){
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem();
                item.URL = "http://quotes.money.163.com/service/zycwzb_"+s.stockcode+".html?type=report";

                item.Encoding = Encoding.UTF8;
                item.Method = "GET";
                item.Timeout = 100000;
                item.ReadWriteTimeout = 30000;//写入Post数据超时时间，可选项默认为30000

                HttpResult result = http.GetHtml(item);

                string Result = result.Html.Replace("\r\n\t", "").Replace(" ","");
                //string[] arrTemp = result.Html.Split('\r\n');
                string[] strlist = Result.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (strlist.Length == 1)
                {
                    continue;
                }
                string[] reportDate = strlist[0].Substring(0,strlist[0].Length - 1).Split(',');
                string[] JBMGSY = strlist[1].Substring(0, strlist[1].Length - 1).Split(',');
                string[] MGJZC = strlist[2].Substring(0, strlist[2].Length - 1).Split(',');
                string[] MGJYHDCSXJLJE = strlist[3].Substring(0, strlist[3].Length - 1).Split(',');
                string[] ZYYWSR = strlist[4].Substring(0, strlist[4].Length - 1).Split(',');

                string[] ZYYWLR = strlist[5].Substring(0, strlist[5].Length - 1).Split(',');
                string[] YYLR = strlist[6].Substring(0, strlist[6].Length - 1).Split(',');
                string[] TZSY = strlist[7].Substring(0, strlist[7].Length - 1).Split(',');
                string[] YYEYSZJE = strlist[8].Substring(0, strlist[8].Length - 1).Split(',');
                string[] LRZE = strlist[9].Substring(0, strlist[9].Length - 1).Split(',');

                string[] JLR = strlist[10].Substring(0, strlist[10].Length - 1).Split(',');
                string[] JLROUT = strlist[11].Substring(0, strlist[11].Length - 1).Split(',');
                string[] JYHDCSDXJLJE = strlist[12].Substring(0, strlist[12].Length - 1).Split(',');
                string[] XJJXJDJWJCJE = strlist[13].Substring(0, strlist[13].Length - 1).Split(',');
                string[] ZZC = strlist[14].Substring(0, strlist[14].Length - 1).Split(',');

                string[] LDZC = strlist[15].Substring(0, strlist[15].Length - 1).Split(',');
                string[] ZFZ = strlist[16].Substring(0, strlist[16].Length - 1).Split(',');
                string[] LDFZ = strlist[17].Substring(0, strlist[17].Length - 1).Split(',');
                string[] GDQYBHSSGDQY = strlist[18].Substring(0, strlist[18].Length - 1).Split(',');
                string strlist19 = strlist[19].Replace("\t", "");
                string[] JZCSYLJQ = strlist19.Substring(0, strlist19.Length - 1).Split(',');

                for (int num = 1; num < reportDate.Length;num++ )
                {
                    int IsHave = _StockCwservice.GetRecordCount("Code='" + s.stockcode + "' AND ReportDate=CONVERT(datetime,'" + reportDate[num].ToString() + "',102)");
                    if (IsHave != 0)
                    {
                        continue;
                    }
                    StockCwInfo cw = new StockCwInfo();
                    cw.Code=s.stockcode;
                    cw.ReportDate = Convert.ToDateTime(reportDate[num].ToString());
                    cw.JBMGSY = decimal.Parse(PublicTool.IsNumElseToZero( JBMGSY[num].ToString()));
                    cw.MGJZC = decimal.Parse(PublicTool.IsNumElseToZero( MGJZC[num].ToString()));
                    cw.MGJYHDCSXJLJE = decimal.Parse(PublicTool.IsNumElseToZero( MGJYHDCSXJLJE[num].ToString()));
                    cw.ZYYWSR =PublicTool.IsNumElseToZero( ZYYWSR[num].ToString());

                    cw.ZYYWLR = PublicTool.IsNumElseToZero( ZYYWLR[num].ToString());
                    cw.YYLR =PublicTool.IsNumElseToZero(  YYLR[num].ToString());
                    cw.TZSY = PublicTool.IsNumElseToZero( TZSY[num].ToString());
                    cw.YYEYSZJE =PublicTool.IsNumElseToZero(  YYEYSZJE[num].ToString());
                    cw.LRZE =PublicTool.IsNumElseToZero(  LRZE[num].ToString());

                    cw.JLR = PublicTool.IsNumElseToZero( JLR[num].ToString());
                    cw.JLROUT = PublicTool.IsNumElseToZero( JLROUT[num].ToString());
                    cw.JYHDCSDXJLJE = PublicTool.IsNumElseToZero( JYHDCSDXJLJE[num].ToString());
                    cw.XJJXJDJWJCJE = PublicTool.IsNumElseToZero( XJJXJDJWJCJE[num].ToString());
                    cw.ZZC = PublicTool.IsNumElseToZero( ZZC[num].ToString());

                    cw.LDZC = PublicTool.IsNumElseToZero( LDZC[num].ToString());
                    cw.ZFZ = PublicTool.IsNumElseToZero( ZFZ[num].ToString());
                    cw.LDFZ = PublicTool.IsNumElseToZero( LDFZ[num].ToString());
                    cw.GDQYBHSSGDQY = PublicTool.IsNumElseToZero( GDQYBHSSGDQY[num].ToString());
                    cw.JZCSYLJQ = decimal.Parse(PublicTool.IsNumElseToZero( JZCSYLJQ[num].ToString()));

                    if( _StockCwservice.Add(cw)==0){
                            
                        continue;
                    }


                }
            }
            MessageBox.Show("结束！");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<StockInfo> stocklist = _Stockservice.GetModelList("");
            foreach (StockInfo s in stocklist)
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem();
                item.URL = " http://quotes.money.163.com/service/zcfzb_" + s.stockcode + ".html";
                item.Encoding = Encoding.UTF8;
                item.Method = "GET";
                item.Timeout = 100000;
                item.ReadWriteTimeout = 30000;//写入Post数据超时时间，可选项默认为30000

                HttpResult result = http.GetHtml(item);

                string Result = result.Html.Replace("\r\n\t", "").Replace(" ", "");
                //string[] arrTemp = result.Html.Split('\r\n');
                string[] strlist = Result.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (strlist.Length == 72 || strlist.Length==1)
                {
                    continue;
                }
                string[] ReportDate=strlist[0].Substring(0, strlist[0].Length - 1).Split(',');
                string[] HBZJ=strlist[1].Substring(0, strlist[1].Length - 1).Split(',');
                string[] JSBFJ=strlist[2].Substring(0, strlist[2].Length - 1).Split(',');
                string[] CCZJ=strlist[3].Substring(0, strlist[3].Length - 1).Split(',');
                string[] JYXJRZC=strlist[4].Substring(0, strlist[4].Length - 1).Split(',');
                string[] YSJRZC=strlist[5].Substring(0, strlist[5].Length - 1).Split(',');
                string[] YSPJ=strlist[6].Substring(0, strlist[6].Length - 1).Split(',');
                string[] YSZK=strlist[7].Substring(0, strlist[7].Length - 1).Split(',');
                string[] YFKX=strlist[8].Substring(0, strlist[8].Length - 1).Split(',');
                string[] YSBF=strlist[9].Substring(0, strlist[9].Length - 1).Split(',');
                string[] YSFBZK=strlist[10].Substring(0, strlist[10].Length - 1).Split(',');
                string[] YSFBHTZBJ=strlist[11].Substring(0, strlist[11].Length - 1).Split(',');
                string[] YSLX=strlist[12].Substring(0, strlist[12].Length - 1).Split(',');
                string[] YSGL=strlist[13].Substring(0, strlist[13].Length - 1).Split(',');
                string[] QTYSK=strlist[14].Substring(0, strlist[14].Length - 1).Split(',');
                string[] YSCKTS=strlist[15].Substring(0, strlist[15].Length - 1).Split(',');
                string[] YSBTK=strlist[16].Substring(0, strlist[16].Length - 1).Split(',');
                string[] YSBZJ=strlist[17].Substring(0, strlist[17].Length - 1).Split(',');
                string[] NBYSK=strlist[18].Substring(0, strlist[18].Length - 1).Split(',');
                string[] MRFSJRZC=strlist[19].Substring(0, strlist[19].Length - 1).Split(',');
                string[] CH=strlist[20].Substring(0, strlist[20].Length - 1).Split(',');
                string[] DTFY=strlist[21].Substring(0, strlist[21].Length - 1).Split(',');
                string[] DCLLDZCSS=strlist[22].Substring(0, strlist[22].Length - 1).Split(',');
                string[] YNNDQDFLDZC=strlist[23].Substring(0, strlist[23].Length - 1).Split(',');
                string[] QTLDZC=strlist[24].Substring(0, strlist[24].Length - 1).Split(',');
                string[] LDZCHJ=strlist[25].Substring(0, strlist[25].Length - 1).Split(',');
                string[] FCDKJDK=strlist[26].Substring(0, strlist[26].Length - 1).Split(',');
                string[] KGCSJRZC=strlist[27].Substring(0, strlist[27].Length - 1).Split(',');
                string[] CYZDQTZ=strlist[28].Substring(0, strlist[28].Length - 1).Split(',');
                string[] CQYSK=strlist[29].Substring(0, strlist[29].Length - 1).Split(',');
                string[] CQGQTZ=strlist[30].Substring(0, strlist[30].Length - 1).Split(',');
                string[] QTCQTZ=strlist[31].Substring(0, strlist[31].Length - 1).Split(',');
                string[] TZXFDC=strlist[32].Substring(0, strlist[32].Length - 1).Split(',');
                string[] GDZCYZ=strlist[33].Substring(0, strlist[33].Length - 1).Split(',');
                string[] LJZJ=strlist[34].Substring(0, strlist[34].Length - 1).Split(',');
                string[] GDZCJZ=strlist[35].Substring(0, strlist[35].Length - 1).Split(',');
                string[] GDZCJZZB=strlist[36].Substring(0, strlist[36].Length - 1).Split(',');
                string[] GDZC=strlist[37].Substring(0, strlist[37].Length - 1).Split(',');
                string[] ZJGC=strlist[38].Substring(0, strlist[38].Length - 1).Split(',');
                string[] GCWZ=strlist[39].Substring(0, strlist[39].Length - 1).Split(',');
                string[] GDZCQL=strlist[40].Substring(0, strlist[40].Length - 1).Split(',');
                string[] SCXSWZC=strlist[41].Substring(0, strlist[41].Length - 1).Split(',');
                string[] GYXSWZC=strlist[42].Substring(0, strlist[42].Length - 1).Split(',');
                string[] QYZC=strlist[43].Substring(0, strlist[43].Length - 1).Split(',');
                string[] WXZC=strlist[44].Substring(0, strlist[44].Length - 1).Split(',');
                string[] KFZC=strlist[45].Substring(0, strlist[45].Length - 1).Split(',');
                string[] SY=strlist[46].Substring(0, strlist[46].Length - 1).Split(',');
                string[] CQDTFY=strlist[47].Substring(0, strlist[47].Length - 1).Split(',');
                string[] GQFZLTQ=strlist[48].Substring(0, strlist[48].Length - 1).Split(',');
                string[] DYSDSZC=strlist[49].Substring(0, strlist[49].Length - 1).Split(',');
                string[] QTFLDZC=strlist[50].Substring(0, strlist[50].Length - 1).Split(',');
                string[] FLDZCHJ=strlist[51].Substring(0, strlist[51].Length - 1).Split(',');
                string[] ZCZJ=strlist[52].Substring(0, strlist[52].Length - 1).Split(',');
                string[] DQJK=strlist[53].Substring(0, strlist[53].Length - 1).Split(',');
                string[] XZYYHJK=strlist[54].Substring(0, strlist[54].Length - 1).Split(',');
                string[] XSCKJTYCF=strlist[55].Substring(0, strlist[55].Length - 1).Split(',');
                string[] CRZJ=strlist[56].Substring(0, strlist[56].Length - 1).Split(',');
                string[] JYXJRFZ=strlist[57].Substring(0, strlist[57].Length - 1).Split(',');
                string[] YSJRFZ=strlist[58].Substring(0, strlist[58].Length - 1).Split(',');
                string[] YFPJ=strlist[59].Substring(0, strlist[59].Length - 1).Split(',');
                string[] YFZK=strlist[60].Substring(0, strlist[60].Length - 1).Split(',');
                string[] YuSZK=strlist[61].Substring(0, strlist[61].Length - 1).Split(',');
                string[] MCHGJRZCK=strlist[62].Substring(0, strlist[62].Length - 1).Split(',');
                string[] YFSXFJYJ=strlist[63].Substring(0, strlist[63].Length - 1).Split(',');
                string[] YFZGXC=strlist[64].Substring(0, strlist[64].Length - 1).Split(',');
                string[] YJSF=strlist[65].Substring(0, strlist[65].Length - 1).Split(',');
                string[] YFLX=strlist[66].Substring(0, strlist[66].Length - 1).Split(',');
                string[] YFGL=strlist[67].Substring(0, strlist[67].Length - 1).Split(',');
                string[] QTYJK=strlist[68].Substring(0, strlist[68].Length - 1).Split(',');
                string[] YFBZJ=strlist[69].Substring(0, strlist[69].Length - 1).Split(',');
                string[] NBYFK=strlist[70].Substring(0, strlist[70].Length - 1).Split(',');
                string[] QTYFK=strlist[71].Substring(0, strlist[71].Length - 1).Split(',');
                string[] YTFY=strlist[72].Substring(0, strlist[72].Length - 1).Split(',');
                string[] YJLDFZ=strlist[73].Substring(0, strlist[73].Length - 1).Split(',');
                string[] YFFBZK=strlist[74].Substring(0, strlist[74].Length - 1).Split(',');
                string[] BXHTZBJ=strlist[75].Substring(0, strlist[75].Length - 1).Split(',');
                string[] DLMMZQK=strlist[76].Substring(0, strlist[76].Length - 1).Split(',');
                string[] DLCXZQK=strlist[77].Substring(0, strlist[77].Length - 1).Split(',');
                string[] GJPZJS=strlist[78].Substring(0, strlist[78].Length - 1).Split(',');
                string[] GNPZJS=strlist[79].Substring(0, strlist[79].Length - 1).Split(',');
                string[] DYSY=strlist[80].Substring(0, strlist[80].Length - 1).Split(',');
                string[] YFDQZQ=strlist[81].Substring(0, strlist[81].Length - 1).Split(',');
                string[] YNDDQDFLDFZ=strlist[82].Substring(0, strlist[82].Length - 1).Split(',');
                string[] QTLDFZ=strlist[83].Substring(0, strlist[83].Length - 1).Split(',');
                string[] LDFZHJ=strlist[84].Substring(0, strlist[84].Length - 1).Split(',');
                string[] CQJQ=strlist[85].Substring(0, strlist[85].Length - 1).Split(',');
                string[] YFZQ=strlist[86].Substring(0, strlist[86].Length - 1).Split(',');
                string[] CQYFZQ=strlist[87].Substring(0, strlist[87].Length - 1).Split(',');
                string[] ZXYFK=strlist[88].Substring(0, strlist[88].Length - 1).Split(',');
                string[] YJFLDFZ=strlist[89].Substring(0, strlist[89].Length - 1).Split(',');
                string[] CQDYSY=strlist[90].Substring(0, strlist[90].Length - 1).Split(',');
                string[] DYSDSFZ=strlist[91].Substring(0, strlist[91].Length - 1).Split(',');
                string[] QTFLDFZ=strlist[92].Substring(0, strlist[92].Length - 1).Split(',');
                string[] FLDFZHJ=strlist[93].Substring(0, strlist[93].Length - 1).Split(',');
                string[] FZHJ=strlist[94].Substring(0, strlist[94].Length - 1).Split(',');
                string[] SSZB=strlist[95].Substring(0, strlist[95].Length - 1).Split(',');
                string[] ZBGJ=strlist[96].Substring(0, strlist[96].Length - 1).Split(',');
                string[] JKCG=strlist[97].Substring(0, strlist[97].Length - 1).Split(',');
                string[] ZXCB=strlist[98].Substring(0, strlist[98].Length - 1).Split(',');
                string[] YYGJ=strlist[99].Substring(0, strlist[99].Length - 1).Split(',');
                string[] YBFXZB=strlist[100].Substring(0, strlist[100].Length - 1).Split(',');
                string[] WQDDTZSS=strlist[101].Substring(0, strlist[101].Length - 1).Split(',');
                string[] WFPLR=strlist[102].Substring(0, strlist[102].Length - 1).Split(',');
                string[] NFPXJGL=strlist[103].Substring(0, strlist[103].Length - 1).Split(',');
                string[] WBBBZSCE=strlist[104].Substring(0, strlist[104].Length - 1).Split(',');
                string[] GSYMGSGDQYHJ=strlist[105].Substring(0, strlist[105].Length - 1).Split(',');
                string[] SSGDQY=strlist[106].Substring(0, strlist[106].Length - 1).Split(',');
                string[] SYZQY=strlist[107].Substring(0, strlist[107].Length - 1).Split(',');
                string strlist109 = strlist[108].Replace("\t", "");
                string[] FZHSYZQY=strlist109.Substring(0, strlist109.Length - 1).Split(',');


                for (int num = 1; num < ReportDate.Length; num++)
                {
                    int IsHave = _StockZCFZService.GetRecordCount("Code='" + s.stockcode + "' AND ReportDate=CONVERT(datetime,'" + ReportDate[num].ToString() + "',102)");
                    if (IsHave != 0)
                    {
                        continue;
                    }
                    StockZCFZInfo model = new StockZCFZInfo();
                    model.Code=s.stockcode;
                    model.ReportDate = Convert.ToDateTime(ReportDate[num].ToString());
                    model.HBZJ = PublicTool.IsNumElseToZero( HBZJ[num].ToString());
                    model.JSBFJ = PublicTool.IsNumElseToZero( JSBFJ[num].ToString());
                    model.CCZJ = PublicTool.IsNumElseToZero( CCZJ[num].ToString());
                    model.JYXJRZC = PublicTool.IsNumElseToZero( JYXJRZC[num].ToString());
                    model.YSJRZC = PublicTool.IsNumElseToZero( YSJRZC[num].ToString());
                    model.YSPJ = PublicTool.IsNumElseToZero( YSPJ[num].ToString());
                    model.YSZK = PublicTool.IsNumElseToZero( YSZK[num].ToString());
                    model.YFKX = PublicTool.IsNumElseToZero( YFKX[num].ToString());
                    model.YSBF = PublicTool.IsNumElseToZero( YSBF[num].ToString());
                    model.YSFBZK = PublicTool.IsNumElseToZero( YSFBZK[num].ToString());
                    model.YSFBHTZBJ = PublicTool.IsNumElseToZero( YSFBHTZBJ[num].ToString());
                    model.YSLX = PublicTool.IsNumElseToZero( YSLX[num].ToString());
                    model.YSGL = PublicTool.IsNumElseToZero( YSGL[num].ToString());
                    model.QTYSK = PublicTool.IsNumElseToZero( QTYSK[num].ToString());
                    model.YSCKTS = PublicTool.IsNumElseToZero( YSCKTS[num].ToString());
                    model.YSBTK = PublicTool.IsNumElseToZero( YSBTK[num].ToString());
                    model.YSBZJ = PublicTool.IsNumElseToZero( YSBZJ[num].ToString());
                    model.NBYSK = PublicTool.IsNumElseToZero( NBYSK[num].ToString());
                    model.MRFSJRZC = PublicTool.IsNumElseToZero( MRFSJRZC[num].ToString());
                    model.CH = PublicTool.IsNumElseToZero( CH[num].ToString());
                    model.DTFY = PublicTool.IsNumElseToZero( DTFY[num].ToString());
                    model.DCLLDZCSS = PublicTool.IsNumElseToZero( DCLLDZCSS[num].ToString());
                    model.YNNDQDFLDZC = PublicTool.IsNumElseToZero( YNNDQDFLDZC[num].ToString());
                    model.QTLDZC = PublicTool.IsNumElseToZero( QTLDZC[num].ToString());
                    model.LDZCHJ = PublicTool.IsNumElseToZero( LDZCHJ[num].ToString());
                    model.FCDKJDK = PublicTool.IsNumElseToZero( FCDKJDK[num].ToString());
                    model.KGCSJRZC = PublicTool.IsNumElseToZero( KGCSJRZC[num].ToString());
                    model.CYZDQTZ = PublicTool.IsNumElseToZero( CYZDQTZ[num].ToString());
                    model.CQYSK = PublicTool.IsNumElseToZero( CQYSK[num].ToString());
                    model.CQGQTZ = PublicTool.IsNumElseToZero( CQGQTZ[num].ToString());
                    model.QTCQTZ = PublicTool.IsNumElseToZero( QTCQTZ[num].ToString());
                    model.TZXFDC = PublicTool.IsNumElseToZero( TZXFDC[num].ToString());
                    model.GDZCYZ = PublicTool.IsNumElseToZero( GDZCYZ[num].ToString());
                    model.LJZJ = PublicTool.IsNumElseToZero( LJZJ[num].ToString());
                    model.GDZCJZ = PublicTool.IsNumElseToZero( GDZCJZ[num].ToString());
                    model.GDZCJZZB = PublicTool.IsNumElseToZero( GDZCJZZB[num].ToString());
                    model.GDZC = PublicTool.IsNumElseToZero( GDZC[num].ToString());
                    model.ZJGC = PublicTool.IsNumElseToZero( ZJGC[num].ToString());
                    model.GCWZ = PublicTool.IsNumElseToZero( GCWZ[num].ToString());
                    model.GDZCQL = PublicTool.IsNumElseToZero( GDZCQL[num].ToString());
                    model.SCXSWZC = PublicTool.IsNumElseToZero( SCXSWZC[num].ToString());
                    model.GYXSWZC = PublicTool.IsNumElseToZero( GYXSWZC[num].ToString());
                    model.QYZC = PublicTool.IsNumElseToZero( QYZC[num].ToString());
                    model.WXZC = PublicTool.IsNumElseToZero( WXZC[num].ToString());
                    model.KFZC = PublicTool.IsNumElseToZero( KFZC[num].ToString());
                    model.SY = PublicTool.IsNumElseToZero( SY[num].ToString());
                    model.CQDTFY = PublicTool.IsNumElseToZero( CQDTFY[num].ToString());
                    model.GQFZLTQ = PublicTool.IsNumElseToZero( GQFZLTQ[num].ToString());
                    model.DYSDSZC = PublicTool.IsNumElseToZero( DYSDSZC[num].ToString());
                    model.QTFLDZC = PublicTool.IsNumElseToZero( QTFLDZC[num].ToString());
                    model.FLDZCHJ = PublicTool.IsNumElseToZero( FLDZCHJ[num].ToString());
                    model.ZCZJ = PublicTool.IsNumElseToZero( ZCZJ[num].ToString());
                    model.DQJK = PublicTool.IsNumElseToZero( DQJK[num].ToString());
                    model.XZYYHJK = PublicTool.IsNumElseToZero( XZYYHJK[num].ToString());
                    model.XSCKJTYCF = PublicTool.IsNumElseToZero( XSCKJTYCF[num].ToString());
                    model.CRZJ = PublicTool.IsNumElseToZero( CRZJ[num].ToString());
                    model.JYXJRFZ = PublicTool.IsNumElseToZero( JYXJRFZ[num].ToString());
                    model.YSJRFZ = PublicTool.IsNumElseToZero( YSJRFZ[num].ToString());
                    model.YFPJ = PublicTool.IsNumElseToZero( YFPJ[num].ToString());
                    model.YFZK = PublicTool.IsNumElseToZero( YFZK[num].ToString());
                    model.YuSZK = PublicTool.IsNumElseToZero( YuSZK[num].ToString());
                    model.MCHGJRZCK = PublicTool.IsNumElseToZero( MCHGJRZCK[num].ToString());
                    model.YFSXFJYJ = PublicTool.IsNumElseToZero( YFSXFJYJ[num].ToString());
                    model.YFZGXC = PublicTool.IsNumElseToZero( YFZGXC[num].ToString());
                    model.YJSF = PublicTool.IsNumElseToZero( YJSF[num].ToString());
                    model.YFLX = PublicTool.IsNumElseToZero( YFLX[num].ToString());
                    model.YFGL = PublicTool.IsNumElseToZero( YFGL[num].ToString());
                    model.QTYJK = PublicTool.IsNumElseToZero( QTYJK[num].ToString());
                    model.YFBZJ = PublicTool.IsNumElseToZero( YFBZJ[num].ToString());
                    model.NBYFK = PublicTool.IsNumElseToZero( NBYFK[num].ToString());
                    model.QTYFK = PublicTool.IsNumElseToZero( QTYFK[num].ToString());
                    model.YTFY = PublicTool.IsNumElseToZero( YTFY[num].ToString());
                    model.YJLDFZ = PublicTool.IsNumElseToZero( YJLDFZ[num].ToString());
                    model.YFFBZK = PublicTool.IsNumElseToZero( YFFBZK[num].ToString());
                    model.BXHTZBJ = PublicTool.IsNumElseToZero( BXHTZBJ[num].ToString());
                    model.DLMMZQK = PublicTool.IsNumElseToZero( DLMMZQK[num].ToString());
                    model.DLCXZQK = PublicTool.IsNumElseToZero( DLCXZQK[num].ToString());
                    model.GJPZJS = PublicTool.IsNumElseToZero( GJPZJS[num].ToString());
                    model.GNPZJS = PublicTool.IsNumElseToZero( GNPZJS[num].ToString());
                    model.DYSY = PublicTool.IsNumElseToZero( DYSY[num].ToString());
                    model.YFDQZQ = PublicTool.IsNumElseToZero( YFDQZQ[num].ToString());
                    model.YNDDQDFLDFZ = PublicTool.IsNumElseToZero( YNDDQDFLDFZ[num].ToString());
                    model.QTLDFZ = PublicTool.IsNumElseToZero( QTLDFZ[num].ToString());
                    model.LDFZHJ = PublicTool.IsNumElseToZero( LDFZHJ[num].ToString());
                    model.CQJQ = PublicTool.IsNumElseToZero( CQJQ[num].ToString());
                    model.YFZQ = PublicTool.IsNumElseToZero( YFZQ[num].ToString());
                    model.CQYFZQ = PublicTool.IsNumElseToZero( CQYFZQ[num].ToString());
                    model.ZXYFK = PublicTool.IsNumElseToZero( ZXYFK[num].ToString());
                    model.YJFLDFZ = PublicTool.IsNumElseToZero( YJFLDFZ[num].ToString());
                    model.CQDYSY = PublicTool.IsNumElseToZero( CQDYSY[num].ToString());
                    model.DYSDSFZ = PublicTool.IsNumElseToZero( DYSDSFZ[num].ToString());
                    model.QTFLDFZ = PublicTool.IsNumElseToZero( QTFLDFZ[num].ToString());
                    model.FLDFZHJ = PublicTool.IsNumElseToZero( FLDFZHJ[num].ToString());
                    model.FZHJ = PublicTool.IsNumElseToZero( FZHJ[num].ToString());
                    model.SSZB = PublicTool.IsNumElseToZero( SSZB[num].ToString());
                    model.ZBGJ = PublicTool.IsNumElseToZero( ZBGJ[num].ToString());
                    model.JKCG = PublicTool.IsNumElseToZero( JKCG[num].ToString());
                    model.ZXCB = PublicTool.IsNumElseToZero( ZXCB[num].ToString());
                    model.YYGJ = PublicTool.IsNumElseToZero( YYGJ[num].ToString());
                    model.YBFXZB = PublicTool.IsNumElseToZero( YBFXZB[num].ToString());
                    model.WQDDTZSS = PublicTool.IsNumElseToZero( WQDDTZSS[num].ToString());
                    model.WFPLR = PublicTool.IsNumElseToZero( WFPLR[num].ToString());
                    model.NFPXJGL = PublicTool.IsNumElseToZero( NFPXJGL[num].ToString());
                    model.WBBBZSCE = PublicTool.IsNumElseToZero( WBBBZSCE[num].ToString());
                    model.GSYMGSGDQYHJ = PublicTool.IsNumElseToZero( GSYMGSGDQYHJ[num].ToString());
                    model.SSGDQY = PublicTool.IsNumElseToZero( SSGDQY[num].ToString());
                    model.SYZQY = PublicTool.IsNumElseToZero( SYZQY[num].ToString());
                    model.FZHSYZQY = PublicTool.IsNumElseToZero( FZHSYZQY[num].ToString());

                    if (_StockZCFZService.Add(model)==0 )
                    {

                        continue;
                    }


                }
            }
            MessageBox.Show("结束！");
            
        }

        

        
    }
}
