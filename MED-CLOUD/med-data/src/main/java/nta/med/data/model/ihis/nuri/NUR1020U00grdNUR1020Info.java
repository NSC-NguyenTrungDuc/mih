package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1020U00grdNUR1020Info {

	private String bunho;
	private Double fkinp1001;
	private Date ymd;
	private String vspatnGubun;
	private String vspatnTime;
	private Double prGubun1;
	private Double prGubun2;
	private Double prGubun3;
	private Double prGubun4;
	private Double prGubun5;
	private Double prGubun6;
	private Double prGubun7;
	private Double prGubun8;

	public NUR1020U00grdNUR1020Info(String bunho, Double fkinp1001, Date ymd, String vspatnGubun, String vspatnTime,
			Double prGubun1, Double prGubun2, Double prGubun3, Double prGubun4, Double prGubun5, Double prGubun6,
			Double prGubun7, Double prGubun8) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.ymd = ymd;
		this.vspatnGubun = vspatnGubun;
		this.vspatnTime = vspatnTime;
		this.prGubun1 = prGubun1;
		this.prGubun2 = prGubun2;
		this.prGubun3 = prGubun3;
		this.prGubun4 = prGubun4;
		this.prGubun5 = prGubun5;
		this.prGubun6 = prGubun6;
		this.prGubun7 = prGubun7;
		this.prGubun8 = prGubun8;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getYmd() {
		return ymd;
	}

	public void setYmd(Date ymd) {
		this.ymd = ymd;
	}

	public String getVspatnGubun() {
		return vspatnGubun;
	}

	public void setVspatnGubun(String vspatnGubun) {
		this.vspatnGubun = vspatnGubun;
	}

	public String getVspatnTime() {
		return vspatnTime;
	}

	public void setVspatnTime(String vspatnTime) {
		this.vspatnTime = vspatnTime;
	}

	public Double getPrGubun1() {
		return prGubun1;
	}

	public void setPrGubun1(Double prGubun1) {
		this.prGubun1 = prGubun1;
	}

	public Double getPrGubun2() {
		return prGubun2;
	}

	public void setPrGubun2(Double prGubun2) {
		this.prGubun2 = prGubun2;
	}

	public Double getPrGubun3() {
		return prGubun3;
	}

	public void setPrGubun3(Double prGubun3) {
		this.prGubun3 = prGubun3;
	}

	public Double getPrGubun4() {
		return prGubun4;
	}

	public void setPrGubun4(Double prGubun4) {
		this.prGubun4 = prGubun4;
	}

	public Double getPrGubun5() {
		return prGubun5;
	}

	public void setPrGubun5(Double prGubun5) {
		this.prGubun5 = prGubun5;
	}

	public Double getPrGubun6() {
		return prGubun6;
	}

	public void setPrGubun6(Double prGubun6) {
		this.prGubun6 = prGubun6;
	}

	public Double getPrGubun7() {
		return prGubun7;
	}

	public void setPrGubun7(Double prGubun7) {
		this.prGubun7 = prGubun7;
	}

	public Double getPrGubun8() {
		return prGubun8;
	}

	public void setPrGubun8(Double prGubun8) {
		this.prGubun8 = prGubun8;
	}

}
