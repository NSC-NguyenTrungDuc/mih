package nta.med.data.model.ihis.drgs;

import java.sql.Timestamp;

public class DrgsDRG5100P01NebokLabelListItemInfo {
	private String bunho;
	private String gwaName;
	private String doctorName;
	private String suname;
	private String suname2;
	private Integer age;
	private String sex;
	private Timestamp birth;
	private Double drgBunho;
	private String rpBunho;
	private String reserDate;
	private String jusaGubun;
	private String jusaSpdGubun;
	private Double suryang;
	private String ordDanui;
	private String dvTime;
	private Double dv;
	private String bogyongCode;
	private Double subulSuryang;
	private String subulDanui;
	private String jaeryoName;
	private Double nalsuCnt;
	
	public DrgsDRG5100P01NebokLabelListItemInfo(String bunho, String gwaName,
			String doctorName, String suname, String suname2, Integer age,
			String sex, Timestamp birth, Double drgBunho, String rpBunho,
			String reserDate, String jusaGubun, String jusaSpdGubun,
			Double suryang, String ordDanui, String dvTime, Double dv,
			String bogyongCode, Double subulSuryang, String subulDanui,
			String jaeryoName, Double nalsuCnt) {
		this.bunho = bunho;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.suname = suname;
		this.suname2 = suname2;
		this.age = age;
		this.sex = sex;
		this.birth = birth;
		this.drgBunho = drgBunho;
		this.rpBunho = rpBunho;
		this.reserDate = reserDate;
		this.jusaGubun = jusaGubun;
		this.jusaSpdGubun = jusaSpdGubun;
		this.suryang = suryang;
		this.ordDanui = ordDanui;
		this.dvTime = dvTime;
		this.dv = dv;
		this.bogyongCode = bogyongCode;
		this.subulSuryang = subulSuryang;
		this.subulDanui = subulDanui;
		this.jaeryoName = jaeryoName;
		this.nalsuCnt = nalsuCnt;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
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

	public Integer getAge() {
		return age;
	}

	public void setAge(Integer age) {
		this.age = age;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public Timestamp getBirth() {
		return birth;
	}

	public void setBirth(Timestamp birth) {
		this.birth = birth;
	}

	public Double getDrgBunho() {
		return drgBunho;
	}

	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}

	public String getRpBunho() {
		return rpBunho;
	}

	public void setRpBunho(String rpBunho) {
		this.rpBunho = rpBunho;
	}

	public String getReserDate() {
		return reserDate;
	}

	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}

	public String getJusaGubun() {
		return jusaGubun;
	}

	public void setJusaGubun(String jusaGubun) {
		this.jusaGubun = jusaGubun;
	}

	public String getJusaSpdGubun() {
		return jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
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

	public String getDvTime() {
		return dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	public Double getDv() {
		return dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	public String getBogyongCode() {
		return bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	public Double getSubulSuryang() {
		return subulSuryang;
	}

	public void setSubulSuryang(Double subulSuryang) {
		this.subulSuryang = subulSuryang;
	}

	public String getSubulDanui() {
		return subulDanui;
	}

	public void setSubulDanui(String subulDanui) {
		this.subulDanui = subulDanui;
	}

	public String getJaeryoName() {
		return jaeryoName;
	}

	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}

	public Double getNalsuCnt() {
		return nalsuCnt;
	}

	public void setNalsuCnt(Double nalsuCnt) {
		this.nalsuCnt = nalsuCnt;
	}
}
