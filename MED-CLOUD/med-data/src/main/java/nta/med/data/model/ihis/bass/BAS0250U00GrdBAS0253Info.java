package nta.med.data.model.ihis.bass;

public class BAS0250U00GrdBAS0253Info {

	private String hoCode;
	private String bedNo;
	private String fromBedDate;
	private String toBedDate;
	private String bedStatus;
	private String bedNoTel;
	private String hoDong;

	public BAS0250U00GrdBAS0253Info(String hoCode, String bedNo, String fromBedDate, String toBedDate, String bedStatus,
			String bedNoTel, String hoDong) {
		super();
		this.hoCode = hoCode;
		this.bedNo = bedNo;
		this.fromBedDate = fromBedDate;
		this.toBedDate = toBedDate;
		this.bedStatus = bedStatus;
		this.bedNoTel = bedNoTel;
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

	public String getFromBedDate() {
		return fromBedDate;
	}

	public void setFromBedDate(String fromBedDate) {
		this.fromBedDate = fromBedDate;
	}

	public String getToBedDate() {
		return toBedDate;
	}

	public void setToBedDate(String toBedDate) {
		this.toBedDate = toBedDate;
	}

	public String getBedStatus() {
		return bedStatus;
	}

	public void setBedStatus(String bedStatus) {
		this.bedStatus = bedStatus;
	}

	public String getBedNoTel() {
		return bedNoTel;
	}

	public void setBedNoTel(String bedNoTel) {
		this.bedNoTel = bedNoTel;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

}
