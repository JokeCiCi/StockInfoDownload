using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
     public partial class StockZCFZInfo
        {
            public StockZCFZInfo()
            { }
            #region Model
            private int _id;
            private string _code;
            private DateTime? _reportdate;
            private string _hbzj;
            private string _jsbfj;
            private string _cczj;
            private string _jyxjrzc;
            private string _ysjrzc;
            private string _yspj;
            private string _yszk;
            private string _yfkx;
            private string _ysbf;
            private string _ysfbzk;
            private string _ysfbhtzbj;
            private string _yslx;
            private string _ysgl;
            private string _qtysk;
            private string _ysckts;
            private string _ysbtk;
            private string _ysbzj;
            private string _nbysk;
            private string _mrfsjrzc;
            private string _ch;
            private string _dtfy;
            private string _dclldzcss;
            private string _ynndqdfldzc;
            private string _qtldzc;
            private string _ldzchj;
            private string _fcdkjdk;
            private string _kgcsjrzc;
            private string _cyzdqtz;
            private string _cqysk;
            private string _cqgqtz;
            private string _qtcqtz;
            private string _tzxfdc;
            private string _gdzcyz;
            private string _ljzj;
            private string _gdzcjz;
            private string _gdzcjzzb;
            private string _gdzc;
            private string _zjgc;
            private string _gcwz;
            private string _gdzcql;
            private string _scxswzc;
            private string _gyxswzc;
            private string _qyzc;
            private string _wxzc;
            private string _kfzc;
            private string _sy;
            private string _cqdtfy;
            private string _gqfzltq;
            private string _dysdszc;
            private string _qtfldzc;
            private string _fldzchj;
            private string _zczj;
            private string _dqjk;
            private string _xzyyhjk;
            private string _xsckjtycf;
            private string _crzj;
            private string _jyxjrfz;
            private string _ysjrfz;
            private string _yfpj;
            private string _yfzk;
            private string _yuszk;
            private string _mchgjrzck;
            private string _yfsxfjyj;
            private string _yfzgxc;
            private string _yjsf;
            private string _yflx;
            private string _yfgl;
            private string _qtyjk;
            private string _yfbzj;
            private string _nbyfk;
            private string _qtyfk;
            private string _ytfy;
            private string _yjldfz;
            private string _yffbzk;
            private string _bxhtzbj;
            private string _dlmmzqk;
            private string _dlcxzqk;
            private string _gjpzjs;
            private string _gnpzjs;
            private string _dysy;
            private string _yfdqzq;
            private string _ynddqdfldfz;
            private string _qtldfz;
            private string _ldfzhj;
            private string _cqjq;
            private string _yfzq;
            private string _cqyfzq;
            private string _zxyfk;
            private string _yjfldfz;
            private string _cqdysy;
            private string _dysdsfz;
            private string _qtfldfz;
            private string _fldfzhj;
            private string _fzhj;
            private string _sszb;
            private string _zbgj;
            private string _jkcg;
            private string _zxcb;
            private string _yygj;
            private string _ybfxzb;
            private string _wqddtzss;
            private string _wfplr;
            private string _nfpxjgl;
            private string _wbbbzsce;
            private string _gsymgsgdqyhj;
            private string _ssgdqy;
            private string _syzqy;
            private string _fzhsyzqy;
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
                set { _reportdate = value; }
                get { return _reportdate; }
            }
            /// <summary>
            /// 货币资金(万元)
            /// </summary>
            public string HBZJ
            {
                set { _hbzj = value; }
                get { return _hbzj; }
            }
            /// <summary>
            /// 结算备付金(万元)
            /// </summary>
            public string JSBFJ
            {
                set { _jsbfj = value; }
                get { return _jsbfj; }
            }
            /// <summary>
            /// 拆出资金(万元)
            /// </summary>
            public string CCZJ
            {
                set { _cczj = value; }
                get { return _cczj; }
            }
            /// <summary>
            /// 交易性金融资产(万元)
            /// </summary>
            public string JYXJRZC
            {
                set { _jyxjrzc = value; }
                get { return _jyxjrzc; }
            }
            /// <summary>
            /// 衍生金融资产(万元)
            /// </summary>
            public string YSJRZC
            {
                set { _ysjrzc = value; }
                get { return _ysjrzc; }
            }
            /// <summary>
            /// 应收票据(万元)
            /// </summary>
            public string YSPJ
            {
                set { _yspj = value; }
                get { return _yspj; }
            }
            /// <summary>
            /// 应收账款(万元)
            /// </summary>
            public string YSZK
            {
                set { _yszk = value; }
                get { return _yszk; }
            }
            /// <summary>
            /// 预付款项(万元)
            /// </summary>
            public string YFKX
            {
                set { _yfkx = value; }
                get { return _yfkx; }
            }
            /// <summary>
            /// 应收保费(万元)
            /// </summary>
            public string YSBF
            {
                set { _ysbf = value; }
                get { return _ysbf; }
            }
            /// <summary>
            /// 应收分保账款(万元)
            /// </summary>
            public string YSFBZK
            {
                set { _ysfbzk = value; }
                get { return _ysfbzk; }
            }
            /// <summary>
            /// 应收分保合同准备金(万元)
            /// </summary>
            public string YSFBHTZBJ
            {
                set { _ysfbhtzbj = value; }
                get { return _ysfbhtzbj; }
            }
            /// <summary>
            /// 应收利息(万元)
            /// </summary>
            public string YSLX
            {
                set { _yslx = value; }
                get { return _yslx; }
            }
            /// <summary>
            /// 应收股利(万元)
            /// </summary>
            public string YSGL
            {
                set { _ysgl = value; }
                get { return _ysgl; }
            }
            /// <summary>
            /// 其他应收款(万元)
            /// </summary>
            public string QTYSK
            {
                set { _qtysk = value; }
                get { return _qtysk; }
            }
            /// <summary>
            /// 应收出口退税(万元)
            /// </summary>
            public string YSCKTS
            {
                set { _ysckts = value; }
                get { return _ysckts; }
            }
            /// <summary>
            /// 应收补贴款(万元)
            /// </summary>
            public string YSBTK
            {
                set { _ysbtk = value; }
                get { return _ysbtk; }
            }
            /// <summary>
            /// 应收保证金(万元)
            /// </summary>
            public string YSBZJ
            {
                set { _ysbzj = value; }
                get { return _ysbzj; }
            }
            /// <summary>
            /// 内部应收款(万元)
            /// </summary>
            public string NBYSK
            {
                set { _nbysk = value; }
                get { return _nbysk; }
            }
            /// <summary>
            /// 买入返售金融资产(万元)
            /// </summary>
            public string MRFSJRZC
            {
                set { _mrfsjrzc = value; }
                get { return _mrfsjrzc; }
            }
            /// <summary>
            /// 存货(万元)
            /// </summary>
            public string CH
            {
                set { _ch = value; }
                get { return _ch; }
            }
            /// <summary>
            /// 待摊费用(万元)
            /// </summary>
            public string DTFY
            {
                set { _dtfy = value; }
                get { return _dtfy; }
            }
            /// <summary>
            /// 待处理流动资产损益(万元)
            /// </summary>
            public string DCLLDZCSS
            {
                set { _dclldzcss = value; }
                get { return _dclldzcss; }
            }
            /// <summary>
            /// 一年内到期的非流动资产(万元)
            /// </summary>
            public string YNNDQDFLDZC
            {
                set { _ynndqdfldzc = value; }
                get { return _ynndqdfldzc; }
            }
            /// <summary>
            /// 其他流动资产(万元)
            /// </summary>
            public string QTLDZC
            {
                set { _qtldzc = value; }
                get { return _qtldzc; }
            }
            /// <summary>
            /// 流动资产合计(万元)
            /// </summary>
            public string LDZCHJ
            {
                set { _ldzchj = value; }
                get { return _ldzchj; }
            }
            /// <summary>
            /// 发放贷款及垫款(万元)
            /// </summary>
            public string FCDKJDK
            {
                set { _fcdkjdk = value; }
                get { return _fcdkjdk; }
            }
            /// <summary>
            /// 可供出售金融资产(万元)
            /// </summary>
            public string KGCSJRZC
            {
                set { _kgcsjrzc = value; }
                get { return _kgcsjrzc; }
            }
            /// <summary>
            /// 持有至到期投资(万元)
            /// </summary>
            public string CYZDQTZ
            {
                set { _cyzdqtz = value; }
                get { return _cyzdqtz; }
            }
            /// <summary>
            /// 长期应收款(万元)
            /// </summary>
            public string CQYSK
            {
                set { _cqysk = value; }
                get { return _cqysk; }
            }
            /// <summary>
            /// 长期股权投资(万元)
            /// </summary>
            public string CQGQTZ
            {
                set { _cqgqtz = value; }
                get { return _cqgqtz; }
            }
            /// <summary>
            /// 其他长期投资(万元)
            /// </summary>
            public string QTCQTZ
            {
                set { _qtcqtz = value; }
                get { return _qtcqtz; }
            }
            /// <summary>
            /// 投资性房地产(万元)
            /// </summary>
            public string TZXFDC
            {
                set { _tzxfdc = value; }
                get { return _tzxfdc; }
            }
            /// <summary>
            /// 固定资产原值(万元)
            /// </summary>
            public string GDZCYZ
            {
                set { _gdzcyz = value; }
                get { return _gdzcyz; }
            }
            /// <summary>
            /// 累计折旧(万元)
            /// </summary>
            public string LJZJ
            {
                set { _ljzj = value; }
                get { return _ljzj; }
            }
            /// <summary>
            /// 固定资产净值(万元)
            /// </summary>
            public string GDZCJZ
            {
                set { _gdzcjz = value; }
                get { return _gdzcjz; }
            }
            /// <summary>
            /// 固定资产减值准备(万元)
            /// </summary>
            public string GDZCJZZB
            {
                set { _gdzcjzzb = value; }
                get { return _gdzcjzzb; }
            }
            /// <summary>
            /// 固定资产(万元)
            /// </summary>
            public string GDZC
            {
                set { _gdzc = value; }
                get { return _gdzc; }
            }
            /// <summary>
            /// 在建工程(万元)
            /// </summary>
            public string ZJGC
            {
                set { _zjgc = value; }
                get { return _zjgc; }
            }
            /// <summary>
            /// 工程物资(万元)
            /// </summary>
            public string GCWZ
            {
                set { _gcwz = value; }
                get { return _gcwz; }
            }
            /// <summary>
            /// 固定资产清理(万元)
            /// </summary>
            public string GDZCQL
            {
                set { _gdzcql = value; }
                get { return _gdzcql; }
            }
            /// <summary>
            /// 生产性生物资产(万元)
            /// </summary>
            public string SCXSWZC
            {
                set { _scxswzc = value; }
                get { return _scxswzc; }
            }
            /// <summary>
            /// 公益性生物资产(万元)
            /// </summary>
            public string GYXSWZC
            {
                set { _gyxswzc = value; }
                get { return _gyxswzc; }
            }
            /// <summary>
            /// 油气资产(万元)
            /// </summary>
            public string QYZC
            {
                set { _qyzc = value; }
                get { return _qyzc; }
            }
            /// <summary>
            /// 无形资产(万元)
            /// </summary>
            public string WXZC
            {
                set { _wxzc = value; }
                get { return _wxzc; }
            }
            /// <summary>
            /// 开发支出(万元)
            /// </summary>
            public string KFZC
            {
                set { _kfzc = value; }
                get { return _kfzc; }
            }
            /// <summary>
            /// 商誉(万元)
            /// </summary>
            public string SY
            {
                set { _sy = value; }
                get { return _sy; }
            }
            /// <summary>
            /// 长期待摊费用(万元)
            /// </summary>
            public string CQDTFY
            {
                set { _cqdtfy = value; }
                get { return _cqdtfy; }
            }
            /// <summary>
            /// 股权分置流通权(万元)
            /// </summary>
            public string GQFZLTQ
            {
                set { _gqfzltq = value; }
                get { return _gqfzltq; }
            }
            /// <summary>
            /// 递延所得税资产(万元)
            /// </summary>
            public string DYSDSZC
            {
                set { _dysdszc = value; }
                get { return _dysdszc; }
            }
            /// <summary>
            /// 其他非流动资产(万元)
            /// </summary>
            public string QTFLDZC
            {
                set { _qtfldzc = value; }
                get { return _qtfldzc; }
            }
            /// <summary>
            /// 非流动资产合计(万元)
            /// </summary>
            public string FLDZCHJ
            {
                set { _fldzchj = value; }
                get { return _fldzchj; }
            }
            /// <summary>
            /// 资产总计(万元)
            /// </summary>
            public string ZCZJ
            {
                set { _zczj = value; }
                get { return _zczj; }
            }
            /// <summary>
            /// 短期借款(万元)
            /// </summary>
            public string DQJK
            {
                set { _dqjk = value; }
                get { return _dqjk; }
            }
            /// <summary>
            /// 向中央银行借款(万元)
            /// </summary>
            public string XZYYHJK
            {
                set { _xzyyhjk = value; }
                get { return _xzyyhjk; }
            }
            /// <summary>
            /// 吸收存款及同业存放(万元)
            /// </summary>
            public string XSCKJTYCF
            {
                set { _xsckjtycf = value; }
                get { return _xsckjtycf; }
            }
            /// <summary>
            /// 拆入资金(万元)
            /// </summary>
            public string CRZJ
            {
                set { _crzj = value; }
                get { return _crzj; }
            }
            /// <summary>
            /// 交易性金融负债(万元)
            /// </summary>
            public string JYXJRFZ
            {
                set { _jyxjrfz = value; }
                get { return _jyxjrfz; }
            }
            /// <summary>
            /// 衍生金融负债(万元)
            /// </summary>
            public string YSJRFZ
            {
                set { _ysjrfz = value; }
                get { return _ysjrfz; }
            }
            /// <summary>
            /// 应付票据(万元)
            /// </summary>
            public string YFPJ
            {
                set { _yfpj = value; }
                get { return _yfpj; }
            }
            /// <summary>
            /// 应付账款(万元)
            /// </summary>
            public string YFZK
            {
                set { _yfzk = value; }
                get { return _yfzk; }
            }
            /// <summary>
            /// 预收账款(万元)
            /// </summary>
            public string YuSZK
            {
                set { _yuszk = value; }
                get { return _yuszk; }
            }
            /// <summary>
            /// 卖出回购金融资产款(万元)
            /// </summary>
            public string MCHGJRZCK
            {
                set { _mchgjrzck = value; }
                get { return _mchgjrzck; }
            }
            /// <summary>
            /// 应付手续费及佣金(万元)
            /// </summary>
            public string YFSXFJYJ
            {
                set { _yfsxfjyj = value; }
                get { return _yfsxfjyj; }
            }
            /// <summary>
            /// 应付职工薪酬(万元)
            /// </summary>
            public string YFZGXC
            {
                set { _yfzgxc = value; }
                get { return _yfzgxc; }
            }
            /// <summary>
            /// 应交税费(万元)
            /// </summary>
            public string YJSF
            {
                set { _yjsf = value; }
                get { return _yjsf; }
            }
            /// <summary>
            /// 应付利息(万元)
            /// </summary>
            public string YFLX
            {
                set { _yflx = value; }
                get { return _yflx; }
            }
            /// <summary>
            /// 应付股利(万元)
            /// </summary>
            public string YFGL
            {
                set { _yfgl = value; }
                get { return _yfgl; }
            }
            /// <summary>
            /// 其他应交款(万元)
            /// </summary>
            public string QTYJK
            {
                set { _qtyjk = value; }
                get { return _qtyjk; }
            }
            /// <summary>
            /// 应付保证金(万元)
            /// </summary>
            public string YFBZJ
            {
                set { _yfbzj = value; }
                get { return _yfbzj; }
            }
            /// <summary>
            /// 内部应付款(万元)
            /// </summary>
            public string NBYFK
            {
                set { _nbyfk = value; }
                get { return _nbyfk; }
            }
            /// <summary>
            /// 其他应付款(万元)
            /// </summary>
            public string QTYFK
            {
                set { _qtyfk = value; }
                get { return _qtyfk; }
            }
            /// <summary>
            /// 预提费用(万元)
            /// </summary>
            public string YTFY
            {
                set { _ytfy = value; }
                get { return _ytfy; }
            }
            /// <summary>
            /// 预计流动负债(万元)
            /// </summary>
            public string YJLDFZ
            {
                set { _yjldfz = value; }
                get { return _yjldfz; }
            }
            /// <summary>
            /// 应付分保账款(万元)
            /// </summary>
            public string YFFBZK
            {
                set { _yffbzk = value; }
                get { return _yffbzk; }
            }
            /// <summary>
            /// 保险合同准备金(万元)
            /// </summary>
            public string BXHTZBJ
            {
                set { _bxhtzbj = value; }
                get { return _bxhtzbj; }
            }
            /// <summary>
            /// 代理买卖证券款(万元)
            /// </summary>
            public string DLMMZQK
            {
                set { _dlmmzqk = value; }
                get { return _dlmmzqk; }
            }
            /// <summary>
            /// 代理承销证券款(万元)
            /// </summary>
            public string DLCXZQK
            {
                set { _dlcxzqk = value; }
                get { return _dlcxzqk; }
            }
            /// <summary>
            /// 国际票证结算(万元)
            /// </summary>
            public string GJPZJS
            {
                set { _gjpzjs = value; }
                get { return _gjpzjs; }
            }
            /// <summary>
            /// 国内票证结算(万元)
            /// </summary>
            public string GNPZJS
            {
                set { _gnpzjs = value; }
                get { return _gnpzjs; }
            }
            /// <summary>
            /// 递延收益(万元)
            /// </summary>
            public string DYSY
            {
                set { _dysy = value; }
                get { return _dysy; }
            }
            /// <summary>
            /// 应付短期债券(万元)
            /// </summary>
            public string YFDQZQ
            {
                set { _yfdqzq = value; }
                get { return _yfdqzq; }
            }
            /// <summary>
            /// 一年内到期的非流动负债(万元)
            /// </summary>
            public string YNDDQDFLDFZ
            {
                set { _ynddqdfldfz = value; }
                get { return _ynddqdfldfz; }
            }
            /// <summary>
            /// 其他流动负债(万元)
            /// </summary>
            public string QTLDFZ
            {
                set { _qtldfz = value; }
                get { return _qtldfz; }
            }
            /// <summary>
            /// 流动负债合计(万元)
            /// </summary>
            public string LDFZHJ
            {
                set { _ldfzhj = value; }
                get { return _ldfzhj; }
            }
            /// <summary>
            /// 长期借款(万元)
            /// </summary>
            public string CQJQ
            {
                set { _cqjq = value; }
                get { return _cqjq; }
            }
            /// <summary>
            /// 应付债券(万元)
            /// </summary>
            public string YFZQ
            {
                set { _yfzq = value; }
                get { return _yfzq; }
            }
            /// <summary>
            /// 长期应付款(万元)
            /// </summary>
            public string CQYFZQ
            {
                set { _cqyfzq = value; }
                get { return _cqyfzq; }
            }
            /// <summary>
            /// 专项应付款(万元)
            /// </summary>
            public string ZXYFK
            {
                set { _zxyfk = value; }
                get { return _zxyfk; }
            }
            /// <summary>
            /// 预计非流动负债(万元)
            /// </summary>
            public string YJFLDFZ
            {
                set { _yjfldfz = value; }
                get { return _yjfldfz; }
            }
            /// <summary>
            /// 长期递延收益(万元)
            /// </summary>
            public string CQDYSY
            {
                set { _cqdysy = value; }
                get { return _cqdysy; }
            }
            /// <summary>
            /// 递延所得税负债(万元)
            /// </summary>
            public string DYSDSFZ
            {
                set { _dysdsfz = value; }
                get { return _dysdsfz; }
            }
            /// <summary>
            /// 其他非流动负债(万元)
            /// </summary>
            public string QTFLDFZ
            {
                set { _qtfldfz = value; }
                get { return _qtfldfz; }
            }
            /// <summary>
            /// 非流动负债合计(万元)
            /// </summary>
            public string FLDFZHJ
            {
                set { _fldfzhj = value; }
                get { return _fldfzhj; }
            }
            /// <summary>
            /// 负债合计(万元)
            /// </summary>
            public string FZHJ
            {
                set { _fzhj = value; }
                get { return _fzhj; }
            }
            /// <summary>
            /// 实收资本(或股本)(万元)
            /// </summary>
            public string SSZB
            {
                set { _sszb = value; }
                get { return _sszb; }
            }
            /// <summary>
            /// 资本公积(万元)
            /// </summary>
            public string ZBGJ
            {
                set { _zbgj = value; }
                get { return _zbgj; }
            }
            /// <summary>
            /// 减:库存股(万元)
            /// </summary>
            public string JKCG
            {
                set { _jkcg = value; }
                get { return _jkcg; }
            }
            /// <summary>
            /// 专项储备(万元)
            /// </summary>
            public string ZXCB
            {
                set { _zxcb = value; }
                get { return _zxcb; }
            }
            /// <summary>
            /// 盈余公积(万元)
            /// </summary>
            public string YYGJ
            {
                set { _yygj = value; }
                get { return _yygj; }
            }
            /// <summary>
            /// 一般风险准备(万元)
            /// </summary>
            public string YBFXZB
            {
                set { _ybfxzb = value; }
                get { return _ybfxzb; }
            }
            /// <summary>
            /// 未确定的投资损失(万元)
            /// </summary>
            public string WQDDTZSS
            {
                set { _wqddtzss = value; }
                get { return _wqddtzss; }
            }
            /// <summary>
            /// 未分配利润(万元)
            /// </summary>
            public string WFPLR
            {
                set { _wfplr = value; }
                get { return _wfplr; }
            }
            /// <summary>
            /// 拟分配现金股利(万元)
            /// </summary>
            public string NFPXJGL
            {
                set { _nfpxjgl = value; }
                get { return _nfpxjgl; }
            }
            /// <summary>
            /// 外币报表折算差额(万元)
            /// </summary>
            public string WBBBZSCE
            {
                set { _wbbbzsce = value; }
                get { return _wbbbzsce; }
            }
            /// <summary>
            /// 归属于母公司股东权益合计(万元)
            /// </summary>
            public string GSYMGSGDQYHJ
            {
                set { _gsymgsgdqyhj = value; }
                get { return _gsymgsgdqyhj; }
            }
            /// <summary>
            /// 少数股东权益(万元)
            /// </summary>
            public string SSGDQY
            {
                set { _ssgdqy = value; }
                get { return _ssgdqy; }
            }
            /// <summary>
            /// 所有者权益(或股东权益)合计(万元)
            /// </summary>
            public string SYZQY
            {
                set { _syzqy = value; }
                get { return _syzqy; }
            }
            /// <summary>
            /// 负债和所有者权益(或股东权益)总计(万元)
            /// </summary>
            public string FZHSYZQY
            {
                set { _fzhsyzqy = value; }
                get { return _fzhsyzqy; }
            }
            #endregion Model
        }
    
}
