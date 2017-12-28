package nta.med.data.model.ihis.inps;

import java.util.Date;

public class INP3003U00grdINP2002Info {
	private String juSangYn      ;
	private String sangCode       ;
	private String sangName       ;
	private Date sangStartDate ;
	private Date sangEndDate   ;
	private String sangEndSayu   ;
	public INP3003U00grdINP2002Info(String juSangYn, String sangCode, String sangName, Date sangStartDate,
			Date sangEndDate, String sangEndSayu) {
		super();
		this.juSangYn = juSangYn;
		this.sangCode = sangCode;
		this.sangName = sangName;
		this.sangStartDate = sangStartDate;
		this.sangEndDate = sangEndDate;
		this.sangEndSayu = sangEndSayu;
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
	public String getSangName() {
		return sangName;
	}
	public void setSangName(String sangName) {
		this.sangName = sangName;
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
	
}
