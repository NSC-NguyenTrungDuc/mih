package nta.med.data.model.ihis.bass;

public class BAS0250Q00layBedStatusInfo {

	private String hoDong;
	private String hoCode;
	private String bedNo;
	private String bedStatus;
	private String codeName;
	private String fromBedDate;
	
	public BAS0250Q00layBedStatusInfo(String hoDong, String hoCode, String bedNo, String bedStatus, String codeName,
			String fromBedDate) {
		super();
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.bedNo = bedNo;
		this.bedStatus = bedStatus;
		this.codeName = codeName;
		this.fromBedDate = fromBedDate;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	public String getBedNo() {
		return bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}

	public String getBedStatus() {
		return bedStatus;
	}

	public void setBedStatus(String bedStatus) {
		this.bedStatus = bedStatus;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getFromBedDate() {
		return fromBedDate;
	}

	public void setFromBedDate(String fromBedDate) {
		this.fromBedDate = fromBedDate;
	}
	
}
