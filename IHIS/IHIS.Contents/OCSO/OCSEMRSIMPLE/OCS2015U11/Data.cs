using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using EmrDocker;
using EmrDocker.Glossary;
using EmrDocker.Models;
using EmrDockerS;

namespace ERMUserControl
{
    public class Combobox
    {
        public string DisplayId;
        public int Value;
        public Combobox(string displayId, int value)
        {
            DisplayId = displayId;
            Value = value;
        }
    }

    public class GridWraper
    {
        public string TagCode;
        public string TagName;
        public string Content;
        public GridWraper(string tagCode, string tagName, string content)
        {
            TagCode = tagCode;
            TagName = tagName;
            Content = content;
        }
    }

    //public enum TypeEnum
    //{
    //    Tag,
    //    Image,
    //    Pdf,
    //    Order,
    //    Header
    //}

    public class DataCreator
    {
        //not used
        public static DataTable CreateTemplateData()
        {
            DataTable dt = new DataTable("Test");
            dt.Columns.Add("TagCode", typeof(string));
            dt.Columns.Add("TagName", typeof(int));
            dt.Rows.Add("All Template", -1);
            dt.Rows.Add("Template 0", 0);
            dt.Rows.Add("Template 1", 1);
            dt.Rows.Add("Template 2", 2);
            dt.Rows.Add("Template 3", 3);
            dt.Rows.Add("Template 4", 4);
            dt.Rows.Add("Template 5", 5);

            return dt;
        }

        //not used
        public static Dictionary<string, string> DicConvertTag()
        {
            Dictionary<string, string> lstDicConvertTag = new Dictionary<string, string>();
            lstDicConvertTag.Add("S", "S");
            lstDicConvertTag.Add("AN", "既往歴");
            lstDicConvertTag.Add("FH", "家族歴");
            lstDicConvertTag.Add("LH", "生活歴");
            lstDicConvertTag.Add("O", "O");
            lstDicConvertTag.Add("A", "A");
            lstDicConvertTag.Add("MI", "#a");
            lstDicConvertTag.Add("MA", "#1");
            lstDicConvertTag.Add("P", "P");
            lstDicConvertTag.Add("Tx", "治療プラン");
            lstDicConvertTag.Add("Dx", "診断プラン");
            lstDicConvertTag.Add("Ex", "教育プラン");

            return lstDicConvertTag;
        }

        //not used
        public static Dictionary<string, string> NonDicConvertTag()
        {
            Dictionary<string, string> lstDicConvertTag = new Dictionary<string, string>();
            lstDicConvertTag.Add("S", "S");
            lstDicConvertTag.Add("既往歴", "AN");
            lstDicConvertTag.Add("家族歴", "FH");
            lstDicConvertTag.Add("生活歴", "LH");
            lstDicConvertTag.Add("O", "O");
            lstDicConvertTag.Add("A", "A");
            lstDicConvertTag.Add("#a", "MI");
            lstDicConvertTag.Add("#1", "MA");
            lstDicConvertTag.Add("P", "P");
            lstDicConvertTag.Add("治療プラン", "Tx");
            lstDicConvertTag.Add("診断プラン", "Dx");
            lstDicConvertTag.Add("教育プラン", "Ex");

            return lstDicConvertTag;
        }

        //hash code list Tag
        public static DataTable CboTagData()
        {
            DataTable dt = new DataTable("Test");
            dt.Columns.Add("TagCode", typeof(string));
            dt.Columns.Add("TagName", typeof(string));
            dt.Rows.Add("S", "S");
            dt.Rows.Add("AN", "既往歴");
            dt.Rows.Add("FH", "家族歴");
            dt.Rows.Add("LH", "生活歴");
            dt.Rows.Add("O", "O");
            dt.Rows.Add("A", "A");
            dt.Rows.Add("MI", "#a");
            dt.Rows.Add("MA", "#1");
            dt.Rows.Add("P", "P");
            dt.Rows.Add("Tx", "治療プラン");
            dt.Rows.Add("Dx", "診断プラン");
            dt.Rows.Add("Ex", "教育プラン");

            return dt;
        }

        public static DataTable CreateDisplayTagData()
        {
            DataTable dtDi = new DataTable("TestdtDi");
            dtDi.Columns.Add("DisplayId", typeof(string));
            dtDi.Columns.Add("Value", typeof(int));
            
            dtDi.Rows.Add(Resources.Text_tag_code_1, 0);
            dtDi.Rows.Add(Resources.Text_tag_code_2, 1);
            dtDi.Rows.Add(Resources.Text_tag_code_3, 2);

            return dtDi;
        }

        //not used
        //public static DataColumn KeyField;
        public static DataTable CreateDataGridEditor(int rowCount, string strDate, bool cleanContent)
        {
            DataTable tbl = new DataTable();
            //KeyField = tbl.Columns.Add("ID", typeof(string));
            //KeyField.ReadOnly = true;
            //KeyField.AutoIncrement = true;
            tbl.Columns.Add("TagCode", typeof(string));
            tbl.Columns.Add("TagName", typeof(string));
            tbl.Columns.Add("Content", typeof(object));
            tbl.Columns.Add("Type", typeof(TypeEnum));
            tbl.Columns.Add("CreateDate", typeof(string));
            tbl.Columns.Add("DirLocation", typeof(string));

            //for (int i = 0; i < rowCount; i++)
            //    tbl.Rows.Add(new object[] { null, String.Format("TagCode {0}", i), String.Format("TagName {0}", i), DateTime.Now.AddDays(i) });

            tbl.Rows.Add("S", "S", Image.FromFile(@"C:\5.jpg"), TypeEnum.Image, "2015/08/13", "");
            tbl.Rows.Add("AN", "既往歴", cleanContent ? "" : "なし。3か月前の検診での胸部Xp正常と言われている", TypeEnum.Tag, "2015/08/13", "");
            tbl.Rows.Add("FH", "家族歴", cleanContent ? "" : "叔父が肺癌，祖父が大腸癌。父が高血圧・心不全", TypeEnum.Tag, "2015/08/11", "");
            tbl.Rows.Add("LH", "生活歴", cleanContent ? "" : "機会飲酒。喫煙20本／日×34年。パートでレジ打ち業務。56歳の夫", TypeEnum.Tag, "2015/08/11", "");
            tbl.Rows.Add("O", "O", cleanContent ? "" : "重篤感なく，すっと歩いて入室し会話内容も明確だが，不安げで思", TypeEnum.Tag, "2015/08/12", "");
            tbl.Rows.Add("A", "A", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/12", "");
            tbl.Rows.Add("MI", "#a", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            tbl.Rows.Add("MA", "#1", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            tbl.Rows.Add("P", "P", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            tbl.Rows.Add("Tx", "治療プラン", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/09", "");
            tbl.Rows.Add("Dx", "診断プラン", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/09", "");
            tbl.Rows.Add("Tx", "治療プラン", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/08", "");
            tbl.Rows.Add("Ex", "教育プラン", cleanContent ? "" : "診断とその根拠について丁寧に説明し，喫煙の影響や，経過次第で肺", TypeEnum.Tag, "2015/08/08", "");
            tbl.Rows.Add("Dx", "教育プラン", cleanContent ? "" : "診断とその根拠について丁寧に説明し，喫煙の影響や，経過次第で肺", TypeEnum.Tag, DateTime.Now.ToString("yyyy/MM/dd"), "");
            return tbl;
        }

        public static DataTable CreateDataGrid(int rowCount, string strDate, bool cleanContent, string orderType)
        {
            int i = 0, j = 0;
            DataTable dtTag = new DataTable();
            //dtTag.Columns.Add("Oder", typeof(int));
            DataColumn dcmpk = dtTag.Columns.Add("Oder", typeof(int));
            dtTag.Columns.Add("TagCode", typeof(string));
            dtTag.Columns.Add("TagName", typeof(string));
            dtTag.Columns.Add("Content", typeof(object));
            dtTag.Columns.Add("Type", typeof(TypeEnum)); //(TypeEnum: string, Image, pdf)
            dtTag.Columns.Add("CreateDate", typeof(string));
            dtTag.Columns.Add("DirLocation", typeof(string));
            dtTag.PrimaryKey = new DataColumn[] { dcmpk };

            //for (int i = 0; i < rowCount; i++)
            //    tbl.Rows.Add(new object[] { null, String.Format("TagCode {0}", i), String.Format("TagName {0}", i), DateTime.Now.AddDays(i) });

            dtTag.Rows.Add(++i, "S", "S", Image.FromFile(@"C:\5.jpg"), TypeEnum.Image, "2015/08/13", "");
            //dtTag.Rows.Add(++i, "S", "S", Image.FromFile(@"C:\Test.pdf"), TypeEnum.Pdf, "2015/08/13", "");
            dtTag.Rows.Add(++i, "AN", "既往歴", cleanContent ? "" : "なし。3か月前の検診での胸部Xp正常と言われている", TypeEnum.Tag, "2015/08/13", "");
            dtTag.Rows.Add(++i, "FH", "家族歴", cleanContent ? "" : "叔父が肺癌，祖父が大腸癌。父が高血圧・心不全", TypeEnum.Tag, "2015/08/11", "");
            dtTag.Rows.Add(++i, "LH", "生活歴", cleanContent ? "" : "機会飲酒。喫煙20本／日×34年。パートでレジ打ち業務。56歳の夫", TypeEnum.Tag, "2015/08/11", "");
            dtTag.Rows.Add(++i, "O", "O", cleanContent ? "" : "重篤感なく，すっと歩いて入室し会話内容も明確だが，不安げで思", TypeEnum.Tag, "2015/08/12", "");
            dtTag.Rows.Add(++i, "A", "A", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/12", "");
            dtTag.Rows.Add(++i, "MI", "#a", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "ToSuKe 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "MA", "#1", cleanContent ? "" : "Nakamira 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "P", "P", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/10", "");
            dtTag.Rows.Add(++i, "A", "A", cleanContent ? "" : "Nakamura 咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/12", "");
            dtTag.Rows.Add(++i, "Tx", "治療プラン", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/09", "");
            dtTag.Rows.Add(++i, "Dx", "診断プラン", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/09", "");
            dtTag.Rows.Add(++i, "Tx", "治療プラン", cleanContent ? "" : "咳がしつこい気がするので，レントゲンを撮ってほしい。先月亡くなった叔父の肺癌の初期症状と似ている", TypeEnum.Tag, "2015/08/08", "");
            dtTag.Rows.Add(++i, "Ex", "教育プラン", cleanContent ? "" : "診断とその根拠について丁寧に説明し，喫煙の影響や，経過次第で肺", TypeEnum.Tag, "2015/08/08", "");
            dtTag.Rows.Add(++i, "Dx", "教育プラン", cleanContent ? "" : "診断とその根拠について丁寧に説明し，喫煙の影響や，経過次第で肺", TypeEnum.Tag, DateTime.Now.ToString("yyyy/MM/dd"), "");

            //add row Order If(dtOrder.Count > 0)
            dtTag.Rows.Add(++i, "Order", "", "", TypeEnum.Order, DateTime.Now.ToString("yyyy/MM/dd"), "");

            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("BtnDo", typeof(object));
            dtOrder.Columns.Add("OrderCurrent", typeof(int));
            DataColumn dcdfk = dtOrder.Columns.Add("ParrentTagCurrent", typeof(int));
            dtOrder.Columns.Add("OderType", typeof(int));
            dtOrder.Columns.Add("OrderId", typeof(string));
            dtOrder.Columns.Add("Contents", typeof(object));
            dtOrder.Columns.Add("OrderGubun", typeof(string));
            dtOrder.Columns.Add("Bunho", typeof(string));
            dtOrder.Columns.Add("Doctor", typeof(string));
            dtOrder.Columns.Add("Gwa", typeof(string));
            dtOrder.Columns.Add("NaewonDate", typeof(string));
            dtOrder.Columns.Add("NaewonKey", typeof(string));
            dtOrder.Columns.Add("InputTab", typeof(string));
            if (string.IsNullOrEmpty(orderType))
            {
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00001", "Contrent test 001", "0B", "000000831", "01K01OCS", "01", "2015/08/21", "661.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00002", "Contrent test 002", "0C", "000000832", "01K01OCS", "01", "2015/08/22", "662.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00003", "Contrent test 003", "0D", "000000833", "01K01OCS", "01", "2015/08/23", "663.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00004", "Contrent test 004", "0E", "000000834", "01K01OCS", "01", "2015/08/24", "664.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00005", "Contrent test 005", "0F", "000000835", "01K01OCS", "01", "2015/08/25", "665.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00006", "Contrent test 006", "0G", "000000836", "01K01OCS", "01", "2015/08/26", "666.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00007", "Contrent test 007", "0H", "000000837", "01K01OCS", "01", "2015/08/27", "667.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00008", "Contrent test 008", "0O", "000000838", "01K01OCS", "01", "2015/08/28", "668.0", "2");
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00008", "Contrent test 009", "0O", "000000839", "01K01OCS", "01", "2015/08/27", "661.0", "2");
            }
            else
            {
                dtOrder.Rows.Add("Do...", ++j, i, 0, "Order00001", "Contrent test 001", orderType);
            }

            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { dtTag, dtOrder });
            ds.Relations.Add("CustomerOrders", dcmpk, dcdfk);

            return dtTag;
        }

        //not used
        //public static DataColumn KeyField;
        public static DataTable CreateDataGrid1(int rowCount, string strDate, bool cleanContent)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("TagCode", typeof(string));
            tbl.Columns.Add("TagName", typeof(string));
            tbl.Columns.Add("Content", typeof(object));
            tbl.Columns.Add("Type", typeof(int));
            tbl.Columns.Add("CreateDate", typeof(string));
            //for (int i = 0; i < rowCount; i++)
            //    tbl.Rows.Add(new object[] { null, String.Format("TagCode {0}", i), String.Format("TagName {0}", i), DateTime.Now.AddDays(i) });

            tbl.Rows.Add("S", "S", Image.FromFile(@"C:\5.jpg"), 1, "2015/08/13");

            return tbl;
        }

        //not used
        //public static DataColumn KeyField;
        public static DataTable CreateDataOrderGrid(int rowCount, string strDate, bool cleanContent)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("BtnDo", typeof(object));
            tbl.Columns.Add("Status", typeof(string));
            tbl.Columns.Add("Department", typeof(string));
            tbl.Columns.Add("OrderName", typeof(string));
            tbl.Columns.Add("Decription", typeof(string));
            tbl.Columns.Add("bunho", typeof(string));
            tbl.Columns.Add("doctor", typeof(string));
            tbl.Columns.Add("gwa", typeof(string));
            tbl.Columns.Add("naewon_date", typeof(string));
            tbl.Columns.Add("naewon_key", typeof(string));
            //for (int i = 0; i < rowCount; i++)
            //    tbl.Rows.Add(new object[] { null, String.Format("TagCode {0}", i), String.Format("TagName {0}", i), DateTime.Now.AddDays(i) });

            //tbl.Rows.Add("S", "S", Image.FromFile(@"C:\5.jpg"), 1, "2015/08/13");
            tbl.Rows.Add("Do...", "通常", "内服薬", "ソラナックス０．４ｍｇ錠", "1錠*3", "000000839", "01K01OCS", "01", "2015/08/27", "661.0");
            tbl.Rows.Add("Do...", "通常", "検体検査", "クレアチニン [血清]", "1無*1", "000000840", "01K01OCS", "01", "2015/08/27", "661.0");
            tbl.Rows.Add("Do...", "通常", "検体検査", "尿素窒素(BUN) [血清]", "1無*1", "000000841", "01K01OCS", "01", "2015/08/27", "661.0");
            tbl.Rows.Add("Do...", "通常", "検体検査", "アクチオス点滴静注用２５０ｍｇ", "1瓶*1", "000000842", "01K01OCS", "01", "2015/08/27", "661.0");
            tbl.Rows.Add("Do...", "通常", "検体検査", "γ－ＧＴＰ [血清]", "1無*1", "000000838", "01K01OCS", "01", "2015/08/27", "661.0");

            return tbl;
        }
    }
}
