package nta.med.data.model.ihis.ocsi;

import java.util.Date;

public class OCS6010U10PopupTAgrdOCS2015Info {
	private Double pkocs2015 ;
    private String bunho ;
    private Double fkinp1001 ;
    private Date orderDate ;
    private String inputGubun ;
    private Double pkSeq ;
    private Double seq ;
    private Date actDate ;
    private String actId ;
    private String actResultCode ;
    private String actResultText ;
    private String inputId ;
    private String inputGwa ;
    private String inputDoctor ;
    private String dataRowStage ;
	public OCS6010U10PopupTAgrdOCS2015Info(Double pkocs2015, String bunho, Double fkinp1001, Date orderDate,
			String inputGubun, Double pkSeq, Double seq, Date actDate, String actId, String actResultCode,
			String actResultText, String inputId, String inputGwa, String inputDoctor, String dataRowStage) {
		super();
		this.pkocs2015 = pkocs2015;
		this.bunho = bunho;
		this.fkinp1001 = fkinp1001;
		this.orderDate = orderDate;
		this.inputGubun = inputGubun;
		this.pkSeq = pkSeq;
		this.seq = seq;
		this.actDate = actDate;
		this.actId = actId;
		this.actResultCode = actResultCode;
		this.actResultText = actResultText;
		this.inputId = inputId;
		this.inputGwa = inputGwa;
		this.inputDoctor = inputDoctor;
		this.dataRowStage = dataRowStage;
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
	public String getActResultCode() {
		return actResultCode;
	}
	public void setActResultCode(String actResultCode) {
		this.actResultCode = actResultCode;
	}
	public String getActResultText() {
		return actResultText;
	}
	public void setActResultText(String actResultText) {
		this.actResultText = actResultText;
	}
	public String getInputId() {
		return inputId;
	}
	public void setInputId(String inputId) {
		this.inputId = inputId;
	}
	public String getInputGwa() {
		return inputGwa;
	}
	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}
	public String getInputDoctor() {
		return inputDoctor;
	}
	public void setInputDoctor(String inputDoctor) {
		this.inputDoctor = inputDoctor;
	}
	public String getDataRowStage() {
		return dataRowStage;
	}
	public void setDataRowStage(String dataRowStage) {
		this.dataRowStage = dataRowStage;
	}
    
}
