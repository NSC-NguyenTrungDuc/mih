package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class ORDERTRANSGrdSiksaInfo {
	private Double fkinp1001      ;
	private Double pkocs2015      ;
	private String bunho          ;
	private String inputGubun    ;
	private String directGubun   ;
	private String nurGrName    ;
	private String directCode    ;
	private String nurMdName    ;
	private String directCont1   ;
	private String nurSoName    ;
	private String orderDate     ;
	private Date drtFromDate  ;
	private Date drtToDate    ;
	private Date actDate       ;
	private Double pkSeq        ;
	private String actingYn      ;
	private String selectYn      ;
	private String sendYn        ;
	public ORDERTRANSGrdSiksaInfo(Double fkinp1001, Double pkocs2015,
			String bunho, String inputGubun, String directGubun,
			String nurGrName, String directCode, String nurMdName,
			String directCont1, String nurSoName, String orderDate,
			Date drtFromDate, Date drtToDate, Date actDate, Double pkSeq,
			String actingYn, String selectYn, String sendYn) {
		super();
		this.fkinp1001 = fkinp1001;
		this.pkocs2015 = pkocs2015;
		this.bunho = bunho;
		this.inputGubun = inputGubun;
		this.directGubun = directGubun;
		this.nurGrName = nurGrName;
		this.directCode = directCode;
		this.nurMdName = nurMdName;
		this.directCont1 = directCont1;
		this.nurSoName = nurSoName;
		this.orderDate = orderDate;
		this.drtFromDate = drtFromDate;
		this.drtToDate = drtToDate;
		this.actDate = actDate;
		this.pkSeq = pkSeq;
		this.actingYn = actingYn;
		this.selectYn = selectYn;
		this.sendYn = sendYn;
	}
	public Double getFkinp1001() {
		return fkinp1001;
	}
	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}
	public Double getPkocs2015() {
		return pkocs2015;
	}
	public void setPkocs2015(Double pkocs2015) {
		this.pkocs2015 = pkocs2015;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getInputGubun() {
		return inputGubun;
	}
	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}
	public String getDirectGubun() {
		return directGubun;
	}
	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}
	public String getNurGrName() {
		return nurGrName;
	}
	public void setNurGrName(String nurGrName) {
		this.nurGrName = nurGrName;
	}
	public String getDirectCode() {
		return directCode;
	}
	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}
	public String getNurMdName() {
		return nurMdName;
	}
	public void setNurMdName(String nurMdName) {
		this.nurMdName = nurMdName;
	}
	public String getDirectCont1() {
		return directCont1;
	}
	public void setDirectCont1(String directCont1) {
		this.directCont1 = directCont1;
	}
	public String getNurSoName() {
		return nurSoName;
	}
	public void setNurSoName(String nurSoName) {
		this.nurSoName = nurSoName;
	}
	public String getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}
	public Date getDrtFromDate() {
		return drtFromDate;
	}
	public void setDrtFromDate(Date drtFromDate) {
		this.drtFromDate = drtFromDate;
	}
	public Date getDrtToDate() {
		return drtToDate;
	}
	public void setDrtToDate(Date drtToDate) {
		this.drtToDate = drtToDate;
	}
	public Date getActDate() {
		return actDate;
	}
	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}
	public Double getPkSeq() {
		return pkSeq;
	}
	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}
	public String getActingYn() {
		return actingYn;
	}
	public void setActingYn(String actingYn) {
		this.actingYn = actingYn;
	}
	public String getSelectYn() {
		return selectYn;
	}
	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}
	public String getSendYn() {
		return sendYn;
	}
	public void setSendYn(String sendYn) {
		this.sendYn = sendYn;
	}
}
