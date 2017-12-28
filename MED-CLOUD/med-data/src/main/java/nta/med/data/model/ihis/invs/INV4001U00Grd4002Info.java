package nta.med.data.model.ihis.invs;

import java.util.Date;

public class INV4001U00Grd4002Info {
	private Double pkinv4002    ;
	private Double fkinv4001    ;
	private String jaeryoCode  ;
	private String jaeryoName  ;
	private Double ipgoQty     ;
	private String ipgoDanui   ;
	private Double ipgoDanga   ;
	private String remark       ;
	private Double sumDanga    ;
	private Date startDate     ;
	private String lot;
	private Date endDate;
	private String rowState    ;
	public INV4001U00Grd4002Info(Double pkinv4002, Double fkinv4001, String jaeryoCode, String jaeryoName,
			Double ipgoQty, String ipgoDanui, Double ipgoDanga, String remark, Double sumDanga, Date startDate,
			String lot, Date endDate) {
		super();
		this.pkinv4002 = pkinv4002;
		this.fkinv4001 = fkinv4001;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.ipgoQty = ipgoQty;
		this.ipgoDanui = ipgoDanui;
		this.ipgoDanga = ipgoDanga;
		this.remark = remark;
		this.sumDanga = sumDanga;
		this.startDate = startDate;
		this.lot = lot;
		this.endDate = endDate;
	}
	public Double getPkinv4002() {
		return pkinv4002;
	}
	public void setPkinv4002(Double pkinv4002) {
		this.pkinv4002 = pkinv4002;
	}
	public Double getFkinv4001() {
		return fkinv4001;
	}
	public void setFkinv4001(Double fkinv4001) {
		this.fkinv4001 = fkinv4001;
	}
	public String getJaeryoCode() {
		return jaeryoCode;
	}
	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}
	public String getJaeryoName() {
		return jaeryoName;
	}
	public void setJaeryoName(String jaeryoName) {
		this.jaeryoName = jaeryoName;
	}
	public Double getIpgoQty() {
		return ipgoQty;
	}
	public void setIpgoQty(Double ipgoQty) {
		this.ipgoQty = ipgoQty;
	}
	public String getIpgoDanui() {
		return ipgoDanui;
	}
	public void setIpgoDanui(String ipgoDanui) {
		this.ipgoDanui = ipgoDanui;
	}
	public Double getIpgoDanga() {
		return ipgoDanga;
	}
	public void setIpgoDanga(Double ipgoDanga) {
		this.ipgoDanga = ipgoDanga;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public Double getSumDanga() {
		return sumDanga;
	}
	public void setSumDanga(Double sumDanga) {
		this.sumDanga = sumDanga;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public String getLot() {
		return lot;
	}
	public void setLot(String lot) {
		this.lot = lot;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getRowState() {
		return rowState;
	}
	public void setRowState(String rowState) {
		this.rowState = rowState;
	}
	
}
