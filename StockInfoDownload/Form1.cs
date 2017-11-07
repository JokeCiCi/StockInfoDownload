using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockInfoDownload.AppCode;

namespace StockInfoDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           StringBuilder Result = new StringBuilder(1024 * 1024);
           StringBuilder ErrInfo = new StringBuilder(256);
           bool bool1 = TdxApi.OpenTdx(ErrInfo);

           int ConnectionID = TdxApi.TdxHq_Multi_Connect("222.73.49.4", 7709, Result, ErrInfo);
           bool1 = TdxApi.TdxHq_Multi_GetCompanyInfoCategory( ConnectionID, 0, "000001", Result,  ErrInfo);
           Console.WriteLine(bool1 ? Result.ToString() : ErrInfo.ToString());
           int length = 10000;
           bool1 = TdxApi.TdxHq_Multi_GetCompanyInfoContent(ConnectionID, 0, "000001", "000001.txt", 0, 12665, Result, ErrInfo); 
           Console.WriteLine(bool1 ? Result.ToString() : ErrInfo.ToString());
        }
        
    }
}
