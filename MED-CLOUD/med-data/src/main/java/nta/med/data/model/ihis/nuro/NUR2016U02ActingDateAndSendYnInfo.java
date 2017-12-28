package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NUR2016U02ActingDateAndSendYnInfo {
	private String bunho;
	private Date actingDate;
	private String ifDataSendYn;
	private String gwa;
	private String doctor;
	private Date naewonDate;

	public NUR2016U02ActingDateAndSendYnInfo(String bunho, Date actingDate, String ifDataSendYn, String gwa,
			String doctor, Date naewonDate) {
		super();
		this.bunho = bunho;
		this.actingDate = actingDate;
		this.ifDataSendYn = ifDataSendYn;
		this.gwa = gwa;
		this.doctor = doctor;
		this.naewonDate = naewonDate;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Date getActingDate() {
		return actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}

	public String getIfDataSendYn() {
		return ifDataSendYn;
	}

	public void setIfDataSendYn(String ifDataSendYn) {
		this.ifDataSendYn = ifDataSendYn;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public Date getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}

	
}
