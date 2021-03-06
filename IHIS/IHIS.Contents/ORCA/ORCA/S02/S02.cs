using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Orca;
using IHIS.CloudConnector.Contracts.Models.Orca;
using IHIS.CloudConnector.Contracts.Results.Orca;
using IHIS.Framework;
using IHIS.Utils;

namespace IHIS.ORCA
{
    [ToolboxItem(false)]
    public partial class S02 : XScreen
    {
        private readonly List<XComboItem> comboItems = new List<XComboItem>();
        private ShunouResult shunouResult;

        public S02()
        {
            InitializeComponent();
            gridIncomeInformation.ExecuteQuery = GetIncomeInfoData;
        }


        private void S02_Load(object sender, EventArgs e)
        {
            txtPerformMonth.Text = JapaneseDateTime.ConvertToJapanYearShortString(DateTime.Now);
        }

        private IList<object[]> GetIncomeInfoData(BindVarCollection varList)
        {
            IList<object[]> result = new List<object[]>();
            if (CloudService.Instance.Connect())
            {
                ShunouArgs args = new ShunouArgs();
                args.PatientId = int.Parse(txtPartientId.Text).ToString();
                //args.PerformMonth = txtPerformMonth.Text;
                args.PerformMonth = "2014-12";
                shunouResult = CloudService.Instance.Submit<ShunouResult, ShunouArgs>(args);

                //shunouResult = new ShunouResult();
                //PatientInformation pi = new PatientInformation();
                //pi.PatientId = "2";
                //pi.Sex = "1";
                //pi.WholeName = "Tuan";
                //pi.WholeNameInKana = "Tuan";
                //pi.BirthDate = "2014-12-22";
                //shunouResult.PatientInfo = pi;
                //shunouResult.IncomeInformation.Add(new IncomeInformation("dsf","fdsfs","fdsfsd","fsdfsd",
                //    "fdsfsdf","fdsfsdf","fdsfdsfsd","43434","222222","dsfsdf"));

                if (shunouResult != null)
                {
                    txtName.Text = shunouResult.PatientInfo.WholeName;
                    txtKanaName.Text = shunouResult.PatientInfo.WholeNameInKana;
                    txtSex.Text = shunouResult.PatientInfo.Sex;
                    txtDOB.Text = shunouResult.PatientInfo.BirthDate;

                    int i = 1;
                    comboItems.Clear();
                    foreach (IncomeInformation ic in shunouResult.IncomeInformation)
                    {
                        comboItems.Add(new XComboItem(ic.DepartmentCode, string.Format("{0} {1}",
                            ic.DepartmentCode,
                            ic.DepartmentName)));

                        int reqAmount = Int32.Parse(ic.RequestedAmount);
                        int paidAmount = Int32.Parse(ic.PaidAmount);
                        int unpaidAmount = reqAmount - paidAmount;

                        object[] item =
                        {
                            i++,
                            ic.InvoiceNumber,
                            ic.DepartmentName,
                            ic.Insuarance,
                            ic.PercentOfPayment,
                            ic.OrderDate,
                            ic.DateOfExamination,
                            reqAmount.ToString("N", CultureInfo.CreateSpecificCulture("en-US")),
                            paidAmount.ToString("N", CultureInfo.CreateSpecificCulture("en-US")),
                            unpaidAmount == 0
                                ? string.Empty
                                : unpaidAmount.ToString("N", CultureInfo.CreateSpecificCulture("en-US")),
                            ic.Status
                        };
                        result.Add(item);
                    }

                    cbxDept.ComboItems.AddRange(comboItems.ToArray());
                }
            }
            else
            {
                MessageBox.Show("Can't connect to cloud.");
            }
            return result;
        }

        private void txtPartientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPartientId.Text.Length < 5)
                {
                    txtPartientId.Text = txtPartientId.Text.PadLeft(5, '0');
                }

                //MessageBox.Show(int.Parse(txtPartientId.Text).ToString());
                gridIncomeInformation.QueryLayout(true);
                gridIncomeInformation.DisplayData(true);
            }
        }

        private void txtPartientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
              
        private void txtPerformMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Regex regex = new Regex(@"\A[H,S,T,M]\d{1,2}\.\d{1,2}");
                Match match = regex.Match(txtPerformMonth.Text);
                if (!(match.Success && match.Value == txtPerformMonth.Text))
                {
                    XMessageBox.Show("Invalid perform month format");
                }
            }
        }
    }
}