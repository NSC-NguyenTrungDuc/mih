package nta.med.data.model.ihis.bass;

public class BAS0250Q00layReserBedInfo {

	private String hoDong;
	private String hoCode;
	private String bedNo;
	private String suname;
	private String reserDate;
	
	public BAS0250Q00layReserBedInfo(String hoDong, String hoCode, String bedNo, String suname, String reserDate) {
		super();
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.bedNo = bedNo;
		this.suname = suname;
		this.reserDate = reserDate;
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

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getReserDate() {
		return reserDate;
	}

	public void setReserDate(String reserDate) {
		this.reserDate = reserDate;
	}
	
}
