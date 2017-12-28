package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NuroORDERTRANSUpdateOCS1003SelectToInsert {
	private Date actingDate;
	private String bunho;
	private String gubun;
	private String gwa;
	private String doctor;
	private String chojae;
	private Double seq;
	public NuroORDERTRANSUpdateOCS1003SelectToInsert(Date actingDate,
			String bunho, String gubun, String gwa, String doctor,
			String chojae, Double seq) {
		super();
		this.actingDate = actingDate;
		this.bunho = bunho;
		this.gubun = gubun;
		this.gwa = gwa;
		this.doctor = doctor;
		this.chojae = chojae;
		this.seq = seq;
	}
	public Date getActingDate() {
		return actingDate;
	}
	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
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
	public String getChojae() {
		return chojae;
	}
	public void setChojae(String chojae) {
		this.chojae = chojae;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	
}
