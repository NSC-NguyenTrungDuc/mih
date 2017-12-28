package nta.med.data.model.ihis.ocso;

public class OCSACTGrdPaListInfo {
	private String inOutGubun;
	private String bunho;
	private String suname;
	private String suname2;
	private String gwa;
	private String gwaName;
	private String doctor;
	private String doctorName;
	private String jundalTable;
	private String reserYn;
	private String emergency;
	private String trial;

	public OCSACTGrdPaListInfo(String inOutGubun, String bunho, String suname,
			String suname2, String gwa, String gwaName, String doctor,
			String doctorName, String jundalTable, String reserYn,
			String emergency, String trial) {
		super();
		this.inOutGubun = inOutGubun;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.jundalTable = jundalTable;
		this.reserYn = reserYn;
		this.emergency = emergency;
		this.trial = trial;
	}

	public String getInOutGubun() {
		return inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
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

	public String getSuname2() {
		return suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
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

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getJundalTable() {
		return jundalTable;
	}

	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}

	public String getReserYn() {
		return reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}

	public String getEmergency() {
		return emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}

	public String getTrial() {
		return trial;
	}

	public void setTrial(String trial) {
		this.trial = trial;
	}

}