package nta.med.core.glossary;

public enum ExportPatientHeader {
	ENGLISH("en") {

		@Override
		public String createdDate() {
			return "Created Date";
		}

		@Override
		public String createdAdmin() {
			return "Created Admin";
		}

		@Override
		public String updatedDate() {
			return "Updated Date";
		}

		@Override
		public String updatedAdmin() {
			return "Updated Admin";
		}

		@Override
		public String hospitalCode() {
			return "Hospital Code";
		}

		@Override
		public String patientCode() {
			return "Patient ID";
		}

		@Override
		public String suname() {
			return "Name";
		}

		@Override
		public String suname2() {
			return "Suname2";
		}

		@Override
		public String sex() {
			return "Sex";
		}

		@Override
		public String birthday() {
			return "Birthday";
		}
		
		@Override
		public String postalCode() {
			return "PostalCode";
		}
		
		@Override
		public String address1() {
			return "Address";
		}

		@Override
		public String address2() {
			return "Address2";
		}

		@Override
		public String phoneNumber() {
			return "Phone1";
		}

		@Override
		public String phoneNumber2() {
			return "Phone2";
		}

		@Override
		public String phoneNumber3() {
			return "Phone3";
		}

		@Override
		public String phoneType1() {
			return "Phone1 Type";
		}

		@Override
		public String phoneType2() {
			return "Phone2 Type";
		}

		@Override
		public String phoneType3() {
			return "Phone3 Type";
		}

		@Override
		public String insuranceType() {
			return "Insurance Type";
		}

		@Override
		public String interuptedReception() {
			return "Interupted Reception";
		}

		@Override
		public String interuptedReceptionReason() {
			return "Interupted Reception Reason";
		}

		@Override
		public String delete() {
			return "Delete";
		}

		@Override
		public String patientNode() {
			return "Patient Note";
		}

		@Override
		public String emailAddress() {
			return "Email Address";
		}

		@Override
		public String paceMakerYn() {
			return "paceMakerYn";
		}

		@Override
		public String selfPaceMaker() {
			return "selfPaceMaker";
		}

		@Override
		public String password() {
			return "Password";
		}

		@Override
		public String patientType() {
			return "Patient Type";
		}
		
    }, VIETNAMESE("vi") {

    	@Override
		public String createdDate() {
			return "Ngày tạo";
		}

		@Override
		public String createdAdmin() {
			return "Người tạo";
		}

		@Override
		public String updatedDate() {
			return "Ngày sửa";
		}

		@Override
		public String updatedAdmin() {
			return "Người sửa";
		}

		@Override
		public String hospitalCode() {
			return "Mã bệnh viện";
		}

		@Override
		public String patientCode() {
			return "Mã bệnh nhân";
		}

		@Override
		public String suname() {
			return "Tên";
		}

		@Override
		public String suname2() {
			return "suname2";
		}

		@Override
		public String sex() {
			return "Giới tính";
		}

		@Override
		public String birthday() {
			return "Ngày sinh";
		}
		
		@Override
		public String postalCode() {
			return "postalCode";
		}
		
		@Override
		public String address1() {
			return "Địa chỉ";
		}

		@Override
		public String address2() {
			return "address2";
		}

		@Override
		public String phoneNumber() {
			return "Số điện thoại 1";
		}

		@Override
		public String phoneNumber2() {
			return "Số điện thoại 2";
		}

		@Override
		public String phoneNumber3() {
			return "Số điện thoại 3";
		}

		@Override
		public String phoneType1() {
			return "Loại số điện thoại 1";
		}

		@Override
		public String phoneType2() {
			return "Loại số điện thoại 2";
		}

		@Override
		public String phoneType3() {
			return "Loại số điện thoại 3";
		}

		@Override
		public String insuranceType() {
			return "Loại bảo hiểm";
		}

		@Override
		public String interuptedReception() {
			return "Dừng tiếp nhận";
		}

		@Override
		public String interuptedReceptionReason() {
			return "Lý do dừng tiếp nhận";
		}

		@Override
		public String delete() {
			return "Xóa";
		}

		@Override
		public String patientNode() {
			return "Ghi chú";
		}

		@Override
		public String emailAddress() {
			return "Email";
		}

		@Override
		public String paceMakerYn() {
			return "paceMakerYn";
		}

		@Override
		public String selfPaceMaker() {
			return "selfPaceMaker";
		}

		@Override
		public String password() {
			return "Mật khẩu";
		}

		@Override
		public String patientType() {
			return "Loại bệnh nhân";
		}
    	
    }, JAPANESE("ja") {

		@Override
		public String createdDate() {
			return "生成日時";
		}

		@Override
		public String createdAdmin() {
			return "生成者 ID";
		}

		@Override
		public String updatedDate() {
			return "更新日時";
		}

		@Override
		public String updatedAdmin() {
			return "更新者 ID";
		}

		@Override
		public String hospitalCode() {
			return "病院コード";
		}

		@Override
		public String patientCode() {
			return "患者番号";
		}

		@Override
		public String suname() {
			return "患者氏名(漢字)";
		}

		@Override
		public String suname2() {
			return "患者氏名(カナ)";
		}

		@Override
		public String sex() {
			return "性別";
		}

		@Override
		public String birthday() {
			return "生年月日";
		}
		
		@Override
		public String postalCode() {
			return "郵便番号";
		}
		
		@Override
		public String address1() {
			return "住所1";
		}

		@Override
		public String address2() {
			return "住所2";
		}

		@Override
		public String phoneNumber() {
			return "電話番号";
		}

		@Override
		public String phoneNumber2() {
			return "電話番号1";
		}

		@Override
		public String phoneNumber3() {
			return "携帯電話";
		}

		@Override
		public String phoneType1() {
			return "電話区分";
		}

		@Override
		public String phoneType2() {
			return "電話区分2";
		}

		@Override
		public String phoneType3() {
			return "電話区分3";
		}

		@Override
		public String insuranceType() {
			return "患者保険種別区分";
		}

		@Override
		public String interuptedReception() {
			return "受付中断可否";
		}

		@Override
		public String interuptedReceptionReason() {
			return "受付中断事由";
		}

		@Override
		public String delete() {
			return "削除可能可否";
		}

		@Override
		public String patientNode() {
			return "適用";
		}

		@Override
		public String emailAddress() {
			return "メール";
		}

		@Override
		public String paceMakerYn() {
			return "ペースメーカー（有・無）";
		}

		@Override
		public String selfPaceMaker() {
			return "当病院ペースメーカー着用有無";
		}

		@Override
		public String password() {
			return "パスワード";
		}

		@Override
		public String patientType() {
			return "患者種類";
		}
        
    };

    private String value;

    ExportPatientHeader(String value) {
        this.value = value;
    }
    
    public abstract String createdDate();
    public abstract String createdAdmin();
    public abstract String updatedDate();
    public abstract String updatedAdmin();
    public abstract String hospitalCode();
    public abstract String patientCode();
    public abstract String suname();
    public abstract String suname2();
    public abstract String sex();
    public abstract String birthday();
    public abstract String postalCode();
    public abstract String address1();
    public abstract String address2();
    public abstract String phoneNumber();
    public abstract String phoneNumber2();
    public abstract String phoneNumber3();
    public abstract String phoneType1();
    public abstract String phoneType2();
    public abstract String phoneType3(); 
    public abstract String insuranceType();
    public abstract String interuptedReception();
    public abstract String interuptedReceptionReason();
    public abstract String delete();
    public abstract String patientNode();
    public abstract String emailAddress();
    public abstract String paceMakerYn();
    public abstract String selfPaceMaker();
    public abstract String password();
    public abstract String patientType();
    

    @Override
    public String toString(){
		return value;
	}

    public static ExportPatientHeader newInstance(String val){
        switch (val.toLowerCase()){
            case "en": return ENGLISH;
            case "vi": return VIETNAMESE;
            case "ja": return JAPANESE;
            default: return JAPANESE;
        }
    }
}
