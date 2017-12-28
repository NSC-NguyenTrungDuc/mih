package nta.med.data.model.ihis.ocso;

import java.util.Date;

public class OCS1003R00LayOUT1001Info {
	private String reserYn                  ;
	private String bunho                    ;
	private String suname                   ;
	private String suname2                  ;
	private String birth                    ;
	private String sexAge                  ;
	private String doctor                   ;
	private String doctoName              ;
	private String gwa                      ;
	private String gwaName                 ;
	private String chojae                   ;
	private String chojaeName              ;
	private String naewonDate              ;
	private String inputGubun              ;
	private String orderEndYn             ;
	public OCS1003R00LayOUT1001Info(String reserYn, String bunho,
			String suname, String suname2, String birth, String sexAge,
			String doctor, String doctoName, String gwa, String gwaName,
			String chojae, String chojaeName, String naewonDate,
			String inputGubun, String orderEndYn) {
		super();
		this.reserYn = reserYn;
		this.bunho = bunho;
		this.suname = suname;
		this.suname2 = suname2;
		this.birth = birth;
		this.sexAge = sexAge;
		this.doctor = doctor;
		this.doctoName = doctoName;
		this.gwa = gwa;
		this.gwaName = gwaName;
		this.chojae = chojae;
		this.chojaeName = chojaeName;
		this.naewonDate = naewonDate;
		this.inputGubun = inputGubun;
		this.orderEndYn = orderEndYn;
	}
	public String getReserYn() {
		return reserYn;
	}
	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
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
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getSexAge() {
		return sexAge;
	}
	public void setSexAge(String sexAge) {
		this.sexAge = sexAge;
	}
	public String getDoctor() {
		return doctor;
	}
	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}
	public String getDoctoName() {
		return doctoName;
	}
	public void setDoctoName(String doctoName) {
		this.doctoName = doctoName;
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
	public String getChojae() {
		return chojae;
	}
	public void setChojae(String chojae) {
		this.chojae = chojae;
	}
	public String getChojaeName() {
		return chojaeName;
	}
	public void setChojaeName(String chojaeName) {
		this.chojaeName = chojaeName;
	}
	public String getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getInputGubun() {
		return inputGubun;
	}
	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}
	public String getOrderEndYn() {
		return orderEndYn;
	}
	public void setOrderEndYn(String orderEndYn) {
		this.orderEndYn = orderEndYn;
	}
	
}
