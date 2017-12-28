package nta.med.data.model.ihis.nuro;

import java.sql.Timestamp;

public class NuroOUT0101U02GridGongbiListInfo {
	private Timestamp startDate;
	private String bunho;
	private String budamjaBunho ;
	private String gongbiCode;
	private String sugubjaBunho ;
	private Timestamp endDate;
	private String remark;
	private Timestamp lastCheckDate;
	private String gongbiName;
	private String retrieveYn;
	private Timestamp oldStartDate;
	private String endYn;
	public NuroOUT0101U02GridGongbiListInfo(Timestamp startDate, String bunho,
			String budamjaBunho, String gongbiCode, String sugubjaBunho,
			Timestamp endDate, String remark, Timestamp lastCheckDate,
			String gongbiName, String retrieveYn, Timestamp oldStartDate,
			String endYn) {
		super();
		this.startDate = startDate;
		this.bunho = bunho;
		this.budamjaBunho = budamjaBunho;
		this.gongbiCode = gongbiCode;
		this.sugubjaBunho = sugubjaBunho;
		this.endDate = endDate;
		this.remark = remark;
		this.lastCheckDate = lastCheckDate;
		this.gongbiName = gongbiName;
		this.retrieveYn = retrieveYn;
		this.oldStartDate = oldStartDate;
		this.endYn = endYn;
	}
	public Timestamp getStartDate() {
		return startDate;
	}
	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getBudamjaBunho() {
		return budamjaBunho;
	}
	public void setBudamjaBunho(String budamjaBunho) {
		this.budamjaBunho = budamjaBunho;
	}
	public String getGongbiCode() {
		return gongbiCode;
	}
	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}
	public String getSugubjaBunho() {
		return sugubjaBunho;
	}
	public void setSugubjaBunho(String sugubjaBunho) {
		this.sugubjaBunho = sugubjaBunho;
	}
	public Timestamp getEndDate() {
		return endDate;
	}
	public void setEndDate(Timestamp endDate) {
		this.endDate = endDate;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public Timestamp getLastCheckDate() {
		return lastCheckDate;
	}
	public void setLastCheckDate(Timestamp lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}
	public String getGongbiName() {
		return gongbiName;
	}
	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}
	public String getRetrieveYn() {
		return retrieveYn;
	}
	public void setRetrieveYn(String retrieveYn) {
		this.retrieveYn = retrieveYn;
	}
	public Timestamp getOldStartDate() {
		return oldStartDate;
	}
	public void setOldStartDate(Timestamp oldStartDate) {
		this.oldStartDate = oldStartDate;
	}
	public String getEndYn() {
		return endYn;
	}
	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}
}
