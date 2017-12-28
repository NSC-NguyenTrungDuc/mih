package nta.med.data.model.ihis.bass;

public class BAS0250Q00grdHOBEDInfo {

	private String hoDong;
	private String hoCode;
	private String hoTotalBed;
	private String hoGrade;
	private String hoStatus;
	
	public BAS0250Q00grdHOBEDInfo(String hoDong, String hoCode, String hoTotalBed, String hoGrade, String hoStatus) {
		super();
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.hoTotalBed = hoTotalBed;
		this.hoGrade = hoGrade;
		this.hoStatus = hoStatus;
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

	public String getHoTotalBed() {
		return hoTotalBed;
	}

	public void setHoTotalBed(String hoTotalBed) {
		this.hoTotalBed = hoTotalBed;
	}

	public String getHoGrade() {
		return hoGrade;
	}

	public void setHoGrade(String hoGrade) {
		this.hoGrade = hoGrade;
	}

	public String getHoStatus() {
		return hoStatus;
	}

	public void setHoStatus(String hoStatus) {
		this.hoStatus = hoStatus;
	}
	
}
