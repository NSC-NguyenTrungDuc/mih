package nta.med.data.model.ihis.ocso;

import java.util.Date;

public class OCS1003R00LayOCS1001Info {
	private String juSangYn          ;
	private String sangCode           ;
	private Double ser                 ;
	private String disSangName      ;
	private Date sangStartDate     ;
	private Date sangEndDate       ;
	private String sangEndSayu       ;
	private String sangName           ;
	private String preModifierName   ;
	private String postModifierName  ;
	private String endYn              ;
	public OCS1003R00LayOCS1001Info(String juSangYn, String sangCode,
			Double ser, String disSangName, Date sangStartDate,
			Date sangEndDate, String sangEndSayu, String sangName,
			String preModifierName, String postModifierName, String endYn) {
		super();
		this.juSangYn = juSangYn;
		this.sangCode = sangCode;
		this.ser = ser;
		this.disSangName = disSangName;
		this.sangStartDate = sangStartDate;
		this.sangEndDate = sangEndDate;
		this.sangEndSayu = sangEndSayu;
		this.sangName = sangName;
		this.preModifierName = preModifierName;
		this.postModifierName = postModifierName;
		this.endYn = endYn;
	}
	public String getJuSangYn() {
		return juSangYn;
	}
	public void setJuSangYn(String juSangYn) {
		this.juSangYn = juSangYn;
	}
	public String getSangCode() {
		return sangCode;
	}
	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}
	public Double getSer() {
		return ser;
	}
	public void setSer(Double ser) {
		this.ser = ser;
	}
	public String getDisSangName() {
		return disSangName;
	}
	public void setDisSangName(String disSangName) {
		this.disSangName = disSangName;
	}
	public Date getSangStartDate() {
		return sangStartDate;
	}
	public void setSangStartDate(Date sangStartDate) {
		this.sangStartDate = sangStartDate;
	}
	public Date getSangEndDate() {
		return sangEndDate;
	}
	public void setSangEndDate(Date sangEndDate) {
		this.sangEndDate = sangEndDate;
	}
	public String getSangEndSayu() {
		return sangEndSayu;
	}
	public void setSangEndSayu(String sangEndSayu) {
		this.sangEndSayu = sangEndSayu;
	}
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
	}
	public String getPreModifierName() {
		return preModifierName;
	}
	public void setPreModifierName(String preModifierName) {
		this.preModifierName = preModifierName;
	}
	public String getPostModifierName() {
		return postModifierName;
	}
	public void setPostModifierName(String postModifierName) {
		this.postModifierName = postModifierName;
	}
	public String getEndYn() {
		return endYn;
	}
	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}
	

}
