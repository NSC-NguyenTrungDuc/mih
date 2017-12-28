package nta.med.data.model.ihis.invs;

import nta.med.data.model.ihis.system.ExportCsvInterface;

public class INV4001U00ExportInfo implements ExportCsvInterface{
	private String churiDate;
	private String ipgoType;
	private String updId;
	private String jaeryoCode;
	private String jaeryoName;
	private String startDate;
	private String lot;
	private String expiredDate;
	private String ipgoQty;
	private String ipgoDanuiName;
	private String ipgoDanga;
	
	public INV4001U00ExportInfo(String churiDate, String ipgoType, String updId, String jaeryoCode, String jaeryoName,
			String startDate, String lot, String expiredDate, String ipgoQty, String ipgoDanuiName, String ipgoDanga) {
		super();
		this.churiDate = churiDate;
		this.ipgoType = ipgoType;
		this.updId = updId;
		this.jaeryoCode = jaeryoCode;
		this.jaeryoName = jaeryoName;
		this.startDate = startDate;
		this.lot = lot;
		this.expiredDate = expiredDate;
		this.ipgoQty = ipgoQty;
		this.ipgoDanuiName = ipgoDanuiName;
		this.ipgoDanga = ipgoDanga;
	}

	
	public String getChuriDate() {
		return churiDate;
	}


	public void setChuriDate(String churiDate) {
		this.churiDate = churiDate;
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


	public String getStartDate() {
		return startDate;
	}


	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}


	public String getLot() {
		return lot;
	}


	public void setLot(String lot) {
		this.lot = lot;
	}


	public String getExpiredDate() {
		return expiredDate;
	}


	public void setExpiredDate(String expiredDate) {
		this.expiredDate = expiredDate;
	}


	public String getIpgoQty() {
		return ipgoQty;
	}


	public void setIpgoQty(String ipgoQty) {
		this.ipgoQty = ipgoQty;
	}


	public String getIpgoDanuiName() {
		return ipgoDanuiName;
	}


	public void setIpgoDanuiName(String ipgoDanuiName) {
		this.ipgoDanuiName = ipgoDanuiName;
	}


	public String getIpgoDanga() {
		return ipgoDanga;
	}


	public void setIpgoDanga(String ipgoDanga) {
		this.ipgoDanga = ipgoDanga;
	}


	@Override
	public String[] convertItemToArray() {
		return (new String[]{churiDate, ipgoType, updId, jaeryoCode, jaeryoName,
				startDate, lot, expiredDate, ipgoQty, ipgoDanuiName, ipgoDanga});
	}
	
//	@Override
//	public String[] convertItemToArray() {
//		return (new String[]{DateUtil.toString(churiDate, DateUtil.PATTERN_HHMM), ipgoType, updId, jaeryoCode, jaeryoName,
//				DateUtil.toString(startDate, DateUtil.PATTERN_HHMM), String.valueOf(lot),
//				DateUtil.toString(expiredDate, DateUtil.PATTERN_HHMM), String.valueOf(ipgoQty), ipgoDanuiName, String.valueOf(ipgoDanga)});
}
