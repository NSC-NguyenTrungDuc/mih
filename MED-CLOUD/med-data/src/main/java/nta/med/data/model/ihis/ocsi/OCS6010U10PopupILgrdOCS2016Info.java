package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10PopupILgrdOCS2016Info {

	private Date actDate;
	private String actTime;
	private Double bloodSugar;
	private Double fkocs2016;
	private Double suryang;
	private String ordDanui;
	private String userNm;
	private String kubun;

	public OCS6010U10PopupILgrdOCS2016Info(Date actDate, String actTime, Double bloodSugar, Double fkocs2016,
			Double suryang, String ordDanui, String userNm, String kubun) {
		super();
		this.actDate = actDate;
		this.actTime = actTime;
		this.bloodSugar = bloodSugar;
		this.fkocs2016 = fkocs2016;
		this.suryang = suryang;
		this.ordDanui = ordDanui;
		this.userNm = userNm;
		this.kubun = kubun;
	}

	public Date getActDate() {
		return actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}

	public String getActTime() {
		return actTime;
	}

	public void setActTime(String actTime) {
		this.actTime = actTime;
	}

	public Double getBloodSugar() {
		return bloodSugar;
	}

	public void setBloodSugar(Double bloodSugar) {
		this.bloodSugar = bloodSugar;
	}

	public Double getFkocs2016() {
		return fkocs2016;
	}

	public void setFkocs2016(Double fkocs2016) {
		this.fkocs2016 = fkocs2016;
	}

	public Double getSuryang() {
		return suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	public String getOrdDanui() {
		return ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public String getUserNm() {
		return userNm;
	}

	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}

	public String getKubun() {
		return kubun;
	}

	public void setKubun(String kubun) {
		this.kubun = kubun;
	}

}
