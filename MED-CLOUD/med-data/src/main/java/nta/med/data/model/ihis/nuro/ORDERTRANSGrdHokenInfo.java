package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORDERTRANSGrdHokenInfo {
	private String gubun        ;
	private String gubunName   ;
	private Date startDate   ;
	private Date endDate     ;
	private String johap        ;
	private String selectYn    ;
	public ORDERTRANSGrdHokenInfo(String gubun, String gubunName,
			Date startDate, Date endDate, String johap, String selectYn) {
		super();
		this.gubun = gubun;
		this.gubunName = gubunName;
		this.startDate = startDate;
		this.endDate = endDate;
		this.johap = johap;
		this.selectYn = selectYn;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getGubunName() {
		return gubunName;
	}
	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
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
	public String getJohap() {
		return johap;
	}
	public void setJohap(String johap) {
		this.johap = johap;
	}
	public String getSelectYn() {
		return selectYn;
	}
	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}
	
}
