package nta.med.data.model.ihis.nuri;

public class NUR5020U00grdWatchListInfo {

	private String nurWrdt;
	private String gubun;
	private String gubunName;
	private String gwa;
	private String gwaName;
	private String hoDong;
	private String hoCode;
	private String bunho;
	private String suname;
	private String age;
	private String sex;
	private String sang;
	private String state1;
	private String state2;
	private String state3;
	private String dataRowState;
	
	public NUR5020U00grdWatchListInfo(String nurWrdt, String gubun, String gubunName, String gwa, String gwaName,
			String hoDong, String hoCode, String bunho, String suname, String age, String sex, String sang,
			String state1, String state2, String state3, String dataRowState) {
		super();
		this.nurWrdt = nurWrdt;
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.bunho = bunho;
		this.suname = suname;
		this.age = age;
		this.sex = sex;
		this.sang = sang;
		this.state1 = state1;
		this.state2 = state2;
		this.state3 = state3;
		this.dataRowState = dataRowState;
	}

	public String getNurWrdt() {
		return nurWrdt;
	}

	public void setNurWrdt(String nurWrdt) {
		this.nurWrdt = nurWrdt;
	}

	public String getGubun() {
		return gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getAge() {
		return age;
	}

	public void setAge(String age) {
		this.age = age;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getSang() {
		return sang;
	}

	public void setSang(String sang) {
		this.sang = sang;
	}

	public String getState1() {
		return state1;
	}

	public void setState1(String state1) {
		this.state1 = state1;
	}

	public String getState2() {
		return state2;
	}

	public void setState2(String state2) {
		this.state2 = state2;
	}

	public String getState3() {
		return state3;
	}

	public void setState3(String state3) {
		this.state3 = state3;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
}
