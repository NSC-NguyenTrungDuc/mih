using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {

    public class MmlTableManager {
        private MmlTable _mml0001;
        private MmlTable _mml0002;
        private MmlTable _mml0003;
        private MmlTable _mml0004;
        private MmlTable _mml0005;
        private MmlTable _mml0006;
        private MmlTable _mml0007;
        private MmlTable _mml0008;
        private MmlTable _mml0009;
        private MmlTable _mml0010;
        private MmlTable _mml0011;
        private MmlTable _mml0012;
        private MmlTable _mml0013;
        private MmlTable _mml0014;
        private MmlTable _mml0015;
        private MmlTable _mml0016;
        private MmlTable _mml0017;
        private MmlTable _mml0018;
        private MmlTable _mml0019;
        private MmlTable _mml0020;
        private MmlTable _mml021;
        private MmlTable _mml0022;
        private MmlTable _mml0023;
        private MmlTable _mml0024;
        private MmlTable _mml0025;
        private MmlTable _mml0026;
        private MmlTable _mml0027;
        private MmlTable _mml0028;
        private MmlTable _mml0029;
        private MmlTable _mml0030;
        private MmlTable _mml0031;
        private MmlTable _mml0032;
        private MmlTable _mml0033;
        private MmlTable _mml0034;
        private MmlTable _mml0035;
        private MmlTable _mml0036;
        private MmlTable _claim001;
        private MmlTable _claim002;
        private MmlTable _claim003;
        private MmlTable _claim004;
        private MmlTable _claim005;
        private MmlTable _claim006;
        private MmlTable _claim007;
        private MmlTable _claim008;
        private MmlTable _claim009;

        /// <summary>
        /// チェックディジット方式
        /// </summary>
        public MmlTable Mml0001
        {
            get { return _mml0001; }
            set { _mml0001 = value; }
        }

        /// <summary>
        /// 住所区分
        /// </summary>
        public MmlTable Mml0002
        {
            get { return _mml0002; }
            set { _mml0002 = value; }
        }

        /// <summary>
        /// 電話番号区分
        /// </summary>
        public MmlTable Mml0003
        {
            get { return _mml0003; }
            set { _mml0003 = value; }
        }

        /// <summary>
        /// 抽出基準
        /// </summary>
        public MmlTable Mml0004
        {
            get { return _mml0004; }
            set { _mml0004 = value; }
        }

        /// <summary>
        /// 記載内容モジュールの種別
        /// </summary>
        public MmlTable Mml0005
        {
            get { return _mml0005; }
            set { _mml0005 = value; }
        }

        /// <summary>
        /// アクセス権者
        /// </summary>
        public MmlTable Mml0006
        {
            get { return _mml0006; }
            set { _mml0006 = value; }
        }

        /// <summary>
        /// 文書詳細種別
        /// </summary>
        public MmlTable Mml0007
        {
            get { return _mml0007; }
            set { _mml0007 = value; }
        }

        /// <summary>
        /// 関連文書との関係
        /// </summary>
        public MmlTable Mml0008
        {
            get { return _mml0008; }
            set { _mml0008 = value; }
        }

        /// <summary>
        /// その他のID種別
        /// </summary>
        public MmlTable Mml0009
        {
            get { return _mml0009; }
            set { _mml0009 = value; }
        }

        /// <summary>
        /// 性別
        /// </summary>
        public MmlTable Mml0010
        {
            get { return _mml0010; }
            set { _mml0010 = value; }
        }

        /// <summary>
        /// 婚姻状態
        /// </summary>
        public MmlTable Mml0011
        {
            get { return _mml0011; }
            set { _mml0011 = value; }
        }

        /// <summary>
        /// Diagnosis category 1
        /// 主病名区分
        /// </summary>
        public MmlTable Mml0012
        {
            get { return _mml0012; }
            set { _mml0012 = value; }
        }

        /// <summary>
        /// Diagnosis category 2
        /// 診断・医事区分
        /// </summary>
        public MmlTable Mml0013
        {
            get { return _mml0013; }
            set { _mml0013 = value; }
        }

        /// <summary>
        /// Diagnosis category 3
        /// 診断分類
        /// </summary>
        public MmlTable Mml0014
        {
            get { return _mml0014; }
            set { _mml0014 = value; }
        }

        /// <summary>
        /// Diagnosis category 4
        /// 疑い・確定区分
        /// </summary>
        public MmlTable Mml0015
        {
            get { return _mml0015; }
            set { _mml0015 = value; }
        }

        /// <summary>
        /// 病名転帰
        /// </summary>
        public MmlTable Mml0016
        {
            get { return _mml0016; }
            set { _mml0016 = value; }
        }

        /// <summary>
        /// アレルギー反応程度
        /// </summary>
        public MmlTable Mml0017
        {
            get { return _mml0017; }
            set { _mml0017 = value; }
        }

        /// <summary>
        /// ABO式血液型
        /// </summary>
        public MmlTable Mml0018
        {
            get { return _mml0018; }
            set { _mml0018 = value; }
        }

        /// <summary>
        /// Rho(D)式血液型
        /// </summary>
        public MmlTable Mml0019
        {
            get { return _mml0019; }
            set { _mml0019 = value; }
        }

        /// <summary>
        /// 続柄
        /// </summary>
        public MmlTable Mml0020
        {
            get { return _mml0020; }
            set { _mml0020 = value; }
        }

        /// <summary>
        /// 手術区分
        /// </summary>
        public MmlTable Mml021
        {
            get { return _mml021; }
            set { _mml021 = value; }
        }

        /// <summary>
        /// 手術スタッフ区分
        /// </summary>
        public MmlTable Mml0022
        {
            get { return _mml0022; }
            set { _mml0022 = value; }
        }

        /// <summary>
        /// 麻酔医区分
        /// </summary>
        public MmlTable Mml0023
        {
            get { return _mml0023; }
            set { _mml0023 = value; }
        }

        /// <summary>
        /// ID区分
        /// </summary>
        public MmlTable Mml0024
        {
            get { return _mml0024; }
            set { _mml0024 = value; }
        }

        /// <summary>
        /// 表記コード
        /// </summary>
        public MmlTable Mml0025
        {
            get { return _mml0025; }
            set { _mml0025 = value; }
        }

        /// <summary>
        /// 記録者分類および医療資格コード
        /// </summary>
        public MmlTable Mml0026
        {
            get { return _mml0026; }
            set { _mml0026 = value; }
        }

        /// <summary>
        /// 施設ID区分
        /// </summary>
        public MmlTable Mml0027
        {
            get { return _mml0027; }
            set { _mml0027 = value; }
        }

        /// <summary>
        /// 医科診療科コード
        /// </summary>
        public MmlTable Mml0028
        {
            get { return _mml0028; }
            set { _mml0028 = value; }
        }

        /// <summary>
        /// 医科歯科区分
        /// </summary>
        public MmlTable Mml0029
        {
            get { return _mml0029; }
            set { _mml0029 = value; }
        }

        /// <summary>
        /// 歯科診療科コード
        /// </summary>
        public MmlTable Mml0030
        {
            get { return _mml0030; }
            set { _mml0030 = value; }
        }

        /// <summary>
        /// 保険種別
        /// </summary>
        public MmlTable Mml0031
        {
            get { return _mml0031; }
            set { _mml0031 = value; }
        }

        /// <summary>
        /// 負担方法コード
        /// </summary>
        public MmlTable Mml0032
        {
            get { return _mml0032; }
            set { _mml0032 = value; }
        }

        /// <summary>
        /// Medical Role
        /// </summary>
        public MmlTable Mml0033
        {
            get { return _mml0033; }
            set { _mml0033 = value; }
        }

        /// <summary>
        /// アクセス許可区分
        /// </summary>
        public MmlTable Mml0034
        {
            get { return _mml0034; }
            set { _mml0034 = value; }
        }

        /// <summary>
        /// 施設アクセス権定義
        /// </summary>
        public MmlTable Mml0035
        {
            get { return _mml0035; }
            set { _mml0035 = value; }
        }

        /// <summary>
        /// 個人アクセス権定義
        /// </summary>
        public MmlTable Mml0036
        {
            get { return _mml0036; }
            set { _mml0036 = value; }
        }

        /// <summary>
        /// 時間外区分
        /// </summary>
        public MmlTable Claim001
        {
            get { return _claim001; }
            set { _claim001 = value; }
        }

        /// <summary>
        /// 診療行為区分コード
        /// </summary>
        public MmlTable Claim002
        {
            get { return _claim002; }
            set { _claim002 = value; }
        }

        /// <summary>
        /// 診療種別区分
        /// </summary>
        public MmlTable Claim003
        {
            get { return _claim003; }
            set { _claim003 = value; }
        }

        /// <summary>
        /// 数量コード
        /// </summary>
        public MmlTable Claim004
        {
            get { return _claim004; }
            set { _claim004 = value; }
        }

        /// <summary>
        /// フイルムサイズコード
        /// </summary>
        public MmlTable Claim005
        {
            get { return _claim005; }
            set { _claim005 = value; }
        }

        /// <summary>
        /// 用法コード
        /// </summary>
        public MmlTable Claim006
        {
            get { return _claim006; }
            set { _claim006 = value; }
        }

        /// <summary>
        /// レセ電算診療行為区分コード
        /// </summary>
        public MmlTable Claim007
        {
            get { return _claim007; }
            set { _claim007 = value; }
        }

        /// <summary>
        /// 状態
        /// </summary>
        public MmlTable Claim008
        {
            get { return _claim008; }
            set { _claim008 = value; }
        }

        /// <summary>
        /// 予約
        /// </summary>
        public MmlTable Claim009
        {
            get { return _claim009; }
            set { _claim009 = value; }
        }

        public MmlTableManager() {
            Claim001 = new MmlTable();
        }
    }

    public class MmlTable {
        private string _tableId;
        private string _comment;
        private List<MmlTableItem> _itemList;

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public List<MmlTableItem> ItemList
        {
            get { return _itemList; }
            set { _itemList = value; }
        }

        public MmlTable() {
            this.ItemList = new List<MmlTableItem>();
        }

        public string GetDescription(string val) {
            foreach (MmlTableItem item in ItemList)
            {
                if (item.Value == val) return item.Description;
            }
            return string.Empty;
        }

    }

    public class MmlTableItem {
        private string _description;
        private string _comment;
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public MmlTableItem() {

        }
    }
}
