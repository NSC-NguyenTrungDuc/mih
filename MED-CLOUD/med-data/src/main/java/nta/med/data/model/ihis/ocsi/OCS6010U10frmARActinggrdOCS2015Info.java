package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10frmARActinggrdOCS2015Info {

	private String bunho;
	private Double fkinp1001;
	private Date orderDate;
	private String inputGubun;
	private String inputId;
	private Double pkSeq;
	private Double seq;
	private Double pkocs2015;
	private Date actDate;
	private String actId;
	private Double dv;
	private Double changeQty;
	private Double fio2;
	private Double suryang;
	private String startTime;
	private Date endDate;
	private String endTime;
	private String userNm;
	private String inputGwa;
	private String inputDocto;

	public OCS6010U10frmARActinggrdOCS2015Info(String bunho, Double fkinp1001, Date orderDate, String inputGubun,
			String inputId, Double pkSeq, Double seq, Double pkocs2015, Date actDate, String actId, Double dv,
			Double changeQty, Double fio2, Double suryang, String startTime, Date endDate, String endTime,
			String userNm, String inputGwa, String inputDocto) {
		super();
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.orderDate = orderDate;
		this.inputGubun = inputGubun;
		this.inputId = inputId;
		this.pkSeq = pkSeq;
		this.seq = seq;
		this.pkocs2015 = pkocs2015;
		this.actDate = actDate;
		this.actId = actId;
		this.dv = dv;
		this.changeQty = changeQty;
		this.fio2 = fio2;
		this.suryang = suryang;
		this.startTime = startTime;
		this.endDate = endDate;
		this.endTime = endTime;
		this.userNm = userNm;
		this.inputGwa = inputGwa;
		this.inputDocto = inputDocto;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getOrderDate() {
		return orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	public String getInputGubun() {
		return inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	public String getInputId() {
		return inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	public Double getPkSeq() {
		return pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public Double getPkocs2015() {
		return pkocs2015;
	}

	public void setPkocs2015(Double pkocs2015) {
		this.pkocs2015 = pkocs2015;
	}

	public Date getActDate() {
		return actDate;
	}

	public void setActDate(Date actDate) {
		this.actDate = actDate;
	}

	public String getActId() {
		return actId;
	}

	public void setActId(String actId) {
		this.actId = actId;
	}

	public Double getDv() {
		return dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	public Double getChangeQty() {
		return changeQty;
	}

	public void setChangeQty(Double changeQty) {
		this.changeQty = changeQty;
	}

	public Double getFio2() {
		return fio2;
	}

	public void setFio2(Double fio2) {
		this.fio2 = fio2;
	}

	public Double getSuryang() {
		return suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	public String getStartTime() {
		return startTime;
	}

	public void setStartTime(String startTime) {
		this.startTime = startTime;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getEndTime() {
		return endTime;
	}

	public void setEndTime(String endTime) {
		this.endTime = endTime;
	}

	public String getUserNm() {
		return userNm;
	}

	public void setUserNm(String userNm) {
		this.userNm = userNm;
	}

	public String getInputGwa() {
		return inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}

	public String getInputDocto() {
		return inputDocto;
	}

	public void setInputDocto(String inputDocto) {
		this.inputDocto = inputDocto;
	}

}
