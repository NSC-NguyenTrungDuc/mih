package nta.med.data.model.ihis.invs;

import java.sql.Timestamp;

public class INV4001U00ExportCSVInfo {
	private String rowNum;
	private Timestamp churiDate;
	private String importTime;
	private String jaeryoCode;
	private String jaeryoName;
	private Timestamp startDate;
	private String lot;
	private Timestamp expiredDate;
	private Double ipgoQty;
	private String ipgoDanuiName;
	private String ipgoType;
	private String updId;
	private Double ipgoDanga;
	private Double qtyIpgoDanga;
	private String importCode;
	private String comment;
	public INV4001U00ExportCSVInfo(String rowNum, Timestamp churiDate, String importTime, String jaeryoCode,
			String jaeryoName, Timestamp startDate, String lot, Timestamp expiredDate, Double ipgoQty,
			String ipgoDanuiName, String ipgoType, String updId, Double ipgoDanga, Double qtyIpgoDanga,
			String importCode, String comment) {
		super();
		this.rowNum = rowNum;
		this.churiDate = churiDate;
		this.importTime = importTime;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.startDate = startDate;
		this.lot = lot;
		this.expiredDate = expiredDate;
		this.ipgoQty = ipgoQty;
		this.ipgoDanuiName = ipgoDanuiName;
		this.ipgoType = ipgoType;
		this.updId = updId;
		this.ipgoDanga = ipgoDanga;
		this.qtyIpgoDanga = qtyIpgoDanga;
		this.importCode = importCode;
		this.comment = comment;
	}
	public String getRowNum() {
		return rowNum;
	}
	public void setRowNum(String rowNum) {
		this.rowNum = rowNum;
	}
	public Timestamp getChuriDate() {
		return churiDate;
	}
	public void setChuriDate(Timestamp churiDate) {
		this.churiDate = churiDate;
	}
	public String getImportTime() {
		return importTime;
	}
	public void setImportTime(String importTime) {
		this.importTime = importTime;
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
	public Timestamp getStartDate() {
		return startDate;
	}
	public void setStartDate(Timestamp startDate) {
		this.startDate = startDate;
	}
	public String getLot() {
		return lot;
	}
	public void setLot(String lot) {
		this.lot = lot;
	}
	public Timestamp getExpiredDate() {
		return expiredDate;
	}
	public void setExpiredDate(Timestamp expiredDate) {
		this.expiredDate = expiredDate;
	}
	public Double getIpgoQty() {
		return ipgoQty;
	}
	public void setIpgoQty(Double ipgoQty) {
		this.ipgoQty = ipgoQty;
	}
	public String getIpgoDanuiName() {
		return ipgoDanuiName;
	}
	public void setIpgoDanuiName(String ipgoDanuiName) {
		this.ipgoDanuiName = ipgoDanuiName;
	}
	public String getIpgoType() {
		return ipgoType;
	}
	public void setIpgoType(String ipgoType) {
		this.ipgoType = ipgoType;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public Double getIpgoDanga() {
		return ipgoDanga;
	}
	public void setIpgoDanga(Double ipgoDanga) {
		this.ipgoDanga = ipgoDanga;
	}
	public Double getQtyIpgoDanga() {
		return qtyIpgoDanga;
	}
	public void setQtyIpgoDanga(Double qtyIpgoDanga) {
		this.qtyIpgoDanga = qtyIpgoDanga;
	}
	public String getImportCode() {
		return importCode;
	}
	public void setImportCode(String importCode) {
		this.importCode = importCode;
	}
	public String getComment() {
		return comment;
	}
	public void setComment(String comment) {
		this.comment = comment;
	}
	
}
