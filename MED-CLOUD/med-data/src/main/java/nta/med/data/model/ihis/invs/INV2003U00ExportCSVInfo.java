package nta.med.data.model.ihis.invs;

import java.util.Date;

public class INV2003U00ExportCSVInfo {
	private String rowNum;
	private Date churiDate;
	private String exportTime;
	private String jaeryoCode;
	private String jaeryoName;
	private Double chulgoQty;
	private String ipgoDanuiName;
	private String chulgoType;
	private String updId;
	private String exportCode;
	private String comment;

	public INV2003U00ExportCSVInfo(String rowNum, Date churiDate, String exportTime, String jaeryoCode,
			String jaeryoName, Double chulgoQty, String ipgoDanuiName, String chulgoType, String updId,
			String exportCode, String comment) {
		super();
		this.rowNum = rowNum;
		this.churiDate = churiDate;
		this.exportTime = exportTime;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.chulgoQty = chulgoQty;
		this.ipgoDanuiName = ipgoDanuiName;
		this.chulgoType = chulgoType;
		this.updId = updId;
		this.exportCode = exportCode;
		this.comment = comment;
	}

	public String getRowNum() {
		return rowNum;
	}

	public void setRowNum(String rowNum) {
		this.rowNum = rowNum;
	}

	public Date getChuriDate() {
		return churiDate;
	}

	public void setChuriDate(Date churiDate) {
		this.churiDate = churiDate;
	}

	public String getExportTime() {
		return exportTime;
	}

	public void setExportTime(String exportTime) {
		this.exportTime = exportTime;
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

	public Double getChulgoQty() {
		return chulgoQty;
	}

	public void setChulgoQty(Double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}

	public String getIpgoDanuiName() {
		return ipgoDanuiName;
	}

	public void setIpgoDanuiName(String ipgoDanuiName) {
		this.ipgoDanuiName = ipgoDanuiName;
	}

	public String getChulgoType() {
		return chulgoType;
	}

	public void setChulgoType(String chulgoType) {
		this.chulgoType = chulgoType;
	}

	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public String getExportCode() {
		return exportCode;
	}

	public void setExportCode(String exportCode) {
		this.exportCode = exportCode;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

}
