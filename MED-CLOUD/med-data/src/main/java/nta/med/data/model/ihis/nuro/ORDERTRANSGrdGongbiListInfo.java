package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORDERTRANSGrdGongbiListInfo {
	private String gongbiCode     ;
	private String gongbiName     ;
	private Date lastCheckDate ;
	private String budamjaBunho   ;
	private String sugubjaBunho   ;
	private String selectYn       ;
	private String priority        ;
	private String ifValidYn     ;
	public ORDERTRANSGrdGongbiListInfo(String gongbiCode, String gongbiName,
			Date lastCheckDate, String budamjaBunho, String sugubjaBunho,
			String selectYn, String priority, String ifValidYn) {
		super();
		this.gongbiCode = gongbiCode;
		this.gongbiName = gongbiName;
		this.lastCheckDate = lastCheckDate;
		this.budamjaBunho = budamjaBunho;
		this.sugubjaBunho = sugubjaBunho;
		this.selectYn = selectYn;
		this.priority = priority;
		this.ifValidYn = ifValidYn;
	}
	public String getGongbiCode() {
		return gongbiCode;
	}
	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}
	public String getGongbiName() {
		return gongbiName;
	}
	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}
	public Date getLastCheckDate() {
		return lastCheckDate;
	}
	public void setLastCheckDate(Date lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}
	public String getBudamjaBunho() {
		return budamjaBunho;
	}
	public void setBudamjaBunho(String budamjaBunho) {
		this.budamjaBunho = budamjaBunho;
	}
	public String getSugubjaBunho() {
		return sugubjaBunho;
	}
	public void setSugubjaBunho(String sugubjaBunho) {
		this.sugubjaBunho = sugubjaBunho;
	}
	public String getSelectYn() {
		return selectYn;
	}
	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}
	public String getPriority() {
		return priority;
	}
	public void setPriority(String priority) {
		this.priority = priority;
	}
	public String getIfValidYn() {
		return ifValidYn;
	}
	public void setIfValidYn(String ifValidYn) {
		this.ifValidYn = ifValidYn;
	}
	
}
