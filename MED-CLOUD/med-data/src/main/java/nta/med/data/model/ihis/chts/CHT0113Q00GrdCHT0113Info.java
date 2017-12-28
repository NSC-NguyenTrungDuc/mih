package nta.med.data.model.ihis.chts;

import java.io.Serializable;
import java.util.Date;

public class CHT0113Q00GrdCHT0113Info implements Serializable {
	   private String disabilityCode;
	   private String disabilityName;
	   private String disabilityKanaName;
	   private Date startDate;
	   private Date endDate;
	   private String deleteYn;
	   private Double pkcht0113;
	   private String n;
	public CHT0113Q00GrdCHT0113Info(String disabilityCode,
			String disabilityName, String disabilityKanaName, Date startDate,
			Date endDate, String deleteYn, Double pkcht0113, String n) {
		super();
		this.disabilityCode = disabilityCode;
		this.disabilityName = disabilityName;
		this.disabilityKanaName = disabilityKanaName;
		this.startDate = startDate;
		this.endDate = endDate;
		this.deleteYn = deleteYn;
		this.pkcht0113 = pkcht0113;
		this.n = n;
	}
	public String getDisabilityCode() {
		return disabilityCode;
	}
	public void setDisabilityCode(String disabilityCode) {
		this.disabilityCode = disabilityCode;
	}
	public String getDisabilityName() {
		return disabilityName;
	}
	public void setDisabilityName(String disabilityName) {
		this.disabilityName = disabilityName;
	}
	public String getDisabilityKanaName() {
		return disabilityKanaName;
	}
	public void setDisabilityKanaName(String disabilityKanaName) {
		this.disabilityKanaName = disabilityKanaName;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getDeleteYn() {
		return deleteYn;
	}
	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}
	public Double getPkcht0113() {
		return pkcht0113;
	}
	public void setPkcht0113(Double pkcht0113) {
		this.pkcht0113 = pkcht0113;
	}
	public String getN() {
		return n;
	}
	public void setN(String n) {
		this.n = n;
	}
	   
}
