using System;
using System.Collections.Generic;
using System.Text;
using IHIS.ORCA;
using System.Globalization;

namespace TestORCA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create mml header
            HeaderInfo header = new HeaderInfo();
            // Create mml detail
            DetailInfo detail = new DetailInfo();
            detail.HiModuleItem = new HealthInsuranceModuleItem();
            detail.RdModuleItem = new List<RegisteredDiagnosisModuleItem>();
            detail.ClaimModuleItem = new ClaimModuleItem();

            // Set header info
            {
                header.CreateDate = DateTime.Now;
                header.Version = "2.3";
                header.FacilityId = "1234567";
                header.HospName = "K01";
                header.FacilityCode = "JPN000000000000";
                header.HospAddress = "病院";
                header.HospZipCode = "113-0021";
                header.CreatorText = "doctor";
                header.Bunho = "000000005";
            }

            // Create HealthInsurance module
            {
                detail.HiModuleItem.CountryType = "JPN";
                detail.HiModuleItem.InsuranceCode = "00";
                detail.HiModuleItem.InsuranceNumber = "020016";
                detail.HiModuleItem.StartDate = DateTime.Parse("2015-10-08");
                detail.HiModuleItem.EndDate = DateTime.Parse("9999-12-31");

                // PublicHeathInsuranceItem
                detail.HiModuleItem.PublicHeathInsuranceItem = new PublicHeathInsuranceItemInfo();
                detail.HiModuleItem.PublicHeathInsuranceItem.PriorityNumber = 1;
                detail.HiModuleItem.PublicHeathInsuranceItem.ProviderName = "病院	病院	病院";
                detail.HiModuleItem.PublicHeathInsuranceItem.StartDate = DateTime.Parse("2015-11-05");
                detail.HiModuleItem.PublicHeathInsuranceItem.EndDate = DateTime.Parse("2016-11-05");
            }

            // Create RegisterDiagnosisModule
            {
                RegisteredDiagnosisModuleItem rdModuleItem = new RegisteredDiagnosisModuleItem();
                rdModuleItem.DiagnosisCode = "4920006";
                rdModuleItem.DiagnosisSystem = "Diagnosis";
                rdModuleItem.DiagnosisStartDate = DateTime.ParseExact("2015-07-05", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                rdModuleItem.DiagnosisEndDate = DateTime.ParseExact("9999-12-31", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                rdModuleItem.MmlTableId = "MML0012";
                rdModuleItem.DiagnosisCategory = "mainDiagnosis";

                //rdModuleItem = new RegisteredDiagnosisModuleItem();
                //rdModuleItem.DiagnosisCode = "";
                //rdModuleItem.DiagnosisSystem = "";
                //rdModuleItem.DiagnosisStartDate = DateTime.Now;
                //rdModuleItem.DiagnosisEndDate = DateTime.Now;
                //rdModuleItem.MmlTableId = "";

                detail.RdModuleItem.Add(rdModuleItem);
            }

            // Create Claim module
            {
                detail.ClaimModuleItem.DoctorId = "11000";
                detail.ClaimModuleItem.PerformTime = DateTime.Now;
                //detail.ClaimModuleItem.RegistTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                detail.ClaimModuleItem.GwaName = "内科";
                detail.ClaimModuleItem.BundleListItem = new List<BundleItemInfo>();
                {
                    BundleItemInfo biItem = new BundleItemInfo();
                    biItem.ClassCode = "800";
                    biItem.BundleNumber = 1;
                    //biItem.HangmogCode = "612140702";
                    biItem.HangmogCode = "621261101";

                    //BundleItemInfo biItem = new BundleItemInfo();
                    //biItem.ClassCode = "800";
                    //biItem.BundleNumber = 1;
                    //biItem.HangmogCode = "";

                    detail.ClaimModuleItem.BundleListItem.Add(biItem);
                }
            }

            OrdersInfo ordersInfo = new OrdersInfo(header, detail);
            ORCAServices os = new ORCAServices(ordersInfo);

            // Save mml
            if (os.SaveMmlOrders(@"D://claim1.xml"))
            {
                os.SendTCP(@"C:\Users\AnhNV\Desktop\new.xml", "10.1.20.161", 8210);
                //os.SendTCP(@"C:\Users\AnhNV\Desktop\template.xml", "10.1.20.161", 8210);
                //os.SendTCP(@"D://claim.xml", "10.1.20.161", 8210);
                Console.WriteLine("Done!");
                //Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed!");
                //Console.ReadKey();
            }
        }
    }
}