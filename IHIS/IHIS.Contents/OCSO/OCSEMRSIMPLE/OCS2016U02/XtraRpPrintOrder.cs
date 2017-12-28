using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace IHIS.OCSO
{
    public partial class XtraRpPrintOrder : DevExpress.XtraReports.UI.XtraReport
    {
        #region DetailReportBand     
        private DetailReportBand drg;
        private DetailReportBand inj;      
        private DetailReportBand cpl;    
        private DetailReportBand phy;       
        private DetailReportBand pfe;      
        private DetailReportBand phi;     
        private DetailReportBand xrt;        
        private DetailReportBand tst;   
        private DetailReportBand opr;      
        private DetailReportBand other;      
        #endregion

        #region Property

        public DetailReportBand Drg
        {
            get { return drg; }
            set { drg = value; }
        }

        public DetailReportBand Inj
        {
            get { return inj; }
            set { inj = value; }
        }

        public DetailReportBand Cpl
        {
            get { return cpl; }
            set { cpl = value; }
        }

        public DetailReportBand Phy
        {
            get { return phy; }
            set { phy = value; }
        }

        public DetailReportBand Pfe
        {
            get { return pfe; }
            set { pfe = value; }
        }

        public DetailReportBand Phi
        {
            get { return phi; }
            set { phi = value; }
        }

        public DetailReportBand Xrt
        {
            get { return xrt; }
            set { xrt = value; }
        }

        public DetailReportBand Tst
        {
            get { return tst; }
            set { tst = value; }
        }

        public DetailReportBand Opr
        {
            get { return opr; }
            set { opr = value; }
        }

        public DetailReportBand Other
        {
            get { return other; }
            set { other = value; }
        }
        #endregion

        public XtraRpPrintOrder()
        {
            InitializeComponent();
            this.Drg = this.DtRpDrg;
            this.Inj = this.DtRpInj;
            this.Cpl = this.DtRpCpl;
            this.Phy = this.DtRpPhy;
            this.Pfe = this.DtRpPfe;
            this.Phi = this.DtRpPhi;
            this.Xrt = this.DtRpXrt;
            this.Tst = this.DtRpTst;
            this.Opr = this.DtRpOpr;
            this.Other = this.DtRpOther;
        }

    }
}
