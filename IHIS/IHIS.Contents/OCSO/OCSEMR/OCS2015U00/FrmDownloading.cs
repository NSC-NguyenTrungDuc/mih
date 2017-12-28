using System.Drawing;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
    public partial class FrmDownloading : Form
    {
        public FrmDownloading()
        {
            InitializeComponent();
            SetBackgroundImage();
        }

        private void SetBackgroundImage()
        {
            //한국어,일본어 모드에 따라 배경 이미지 설정
            try
            {
                string resName = "";

                switch (NetInfo.Language)
                {
                    case IHIS.Framework.LangMode.En:
                        resName = "IHIS.Images.DownloadingFormJr_EN.gif";
                        break;
                    case IHIS.Framework.LangMode.Jr:
                        resName = "IHIS.Images.DownloadingFormJr.gif";
                        break;
                    case IHIS.Framework.LangMode.Vi:
                        resName = "IHIS.Images.DownloadingFormJr_VN.gif";
                        break;
                    default:
                        resName = "IHIS.Images.DownloadingFormJr.gif";
                        break;
                }

                System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
                this.BackgroundImage = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(resName));
            }
            catch { }
        }
    }
}
