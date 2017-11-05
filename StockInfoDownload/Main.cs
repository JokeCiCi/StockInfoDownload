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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder Result = new StringBuilder(1024 * 1024);
            StringBuilder ErrInfo = new StringBuilder(256);

            bool bool1 = TdxApi.OpenTdx(ErrInfo);
            if (bool1)
            {
                BackGroundForm form = new BackGroundForm();
                form.Show();
            }

        }
    }
}
