package nta.med.data.model.ihis.bass;

public class CreatePatientSurveyInfo {

	// private String bunho;
	// private String suname;
	// private String gwa;
	// private String gwaName;
	// private Date naewonDate;
	// private String jubsuTime;
	// private Double pkout1001;
	// private String pwd;
	//
	// public CreatePatientSurveyInfo(String bunho, String suname, String gwa,
	// String gwaName, Date naewonDate,
	// String jubsuTime, Double pkout1001, String pwd) {
	// super();
	// this.bunho = bunho;
	// this.suname = suname;
	// this.gwa = gwa;
	// this.gwaName = gwaName;
	// this.naewonDate = naewonDate;
	// this.jubsuTime = jubsuTime;
	// this.pkout1001 = pkout1001;
	// this.pwd = pwd;
	// }
	//
	// public String getBunho() {
	// return bunho;
	// }
	//
	// public void setBunho(String bunho) {
	// this.bunho = bunho;
	// }
	//
	// public String getSuname() {
	// return suname;
	// }
	//
	// public void setSuname(String suname) {
	// this.suname = suname;
	// }
	//
	// public String getGwa() {
	// return gwa;
	// }
	//
	// public void setGwa(String gwa) {
	// this.gwa = gwa;
	// }
	//
	// public String getGwaName() {
	// return gwaName;
	// }
	//
	// public void setGwaName(String gwaName) {
	// this.gwaName = gwaName;
	// }
	//
	// public Date getNaewonDate() {
	// return naewonDate;
	// }
	//
	// public void setNaewonDate(Date naewonDate) {
	// this.naewonDate = naewonDate;
	// }
	//
	// public String getJubsuTime() {
	// return jubsuTime;
	// }
	//
	// public void setJubsuTime(String jubsuTime) {
	// this.jubsuTime = jubsuTime;
	// }
	//
	// public Double getPkout1001() {
	// return pkout1001;
	// }
	//
	// public void setPkout1001(Double pkout1001) {
	// this.pkout1001 = pkout1001;
	// }
	//
	// public String getPwd() {
	// return pwd;
	// }
	//
	// public void setPwd(String pwd) {
	// this.pwd = pwd;
	// }

	private String bunho;
	private String suname;
	private String gwa;
	private String gwaName;
	private String naewonDate;
	private String jubsuTime;
	private String pkout1001;
	private String pwd;

	public CreatePatientSurveyInfo(String bunho, String suname, String gwa, String gwaName, String naewonDate,
			String jubsuTime, String pkout1001, String pwd) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.naewonDate = naewonDate;
		this.jubsuTime = jubsuTime;
		this.pkout1001 = pkout1001;
		this.pwd = pwd;
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

	public String getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getJubsuTime() {
		return jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}

	public String getPkout1001() {
		return pkout1001;
	}

	public void setPkout1001(String pkout1001) {
		this.pkout1001 = pkout1001;
	}

	public String getPwd() {
		return pwd;
	}

	public void setPwd(String pwd) {
		this.pwd = pwd;
	}

}
