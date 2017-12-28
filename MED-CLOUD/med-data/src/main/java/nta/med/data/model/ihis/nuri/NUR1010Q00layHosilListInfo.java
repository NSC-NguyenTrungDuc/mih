package nta.med.data.model.ihis.nuri;

public class NUR1010Q00layHosilListInfo {
	private String hoCode;
	private String hoStatus;
	private String hoBedCount;
	private String hoSex;
	private String hoCodeName;
	private String doubleHoYn;
	private String hoSort;
	
	public NUR1010Q00layHosilListInfo(String hoCode, String hoStatus, String hoBedCount, String hoSex,
			String hoCodeName, String doubleHoYn, String hoSort) {
		super();
		this.hoCode = hoCode;
		this.hoStatus = hoStatus;
		this.hoBedCount = hoBedCount;
		this.hoSex = hoSex;
		this.hoCodeName = hoCodeName;
		this.doubleHoYn = doubleHoYn;
		this.hoSort = hoSort;
	}

	public String getHoCode() {
		return hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	public String getHoStatus() {
		return hoStatus;
	}

	public void setHoStatus(String hoStatus) {
		this.hoStatus = hoStatus;
	}

	public String getHoBedCount() {
		return hoBedCount;
	}

	public void setHoBedCount(String hoBedCount) {
		this.hoBedCount = hoBedCount;
	}

	public String getHoSex() {
		return hoSex;
	}

	public void setHoSex(String hoSex) {
		this.hoSex = hoSex;
	}

	public String getHoCodeName() {
		return hoCodeName;
	}

	public void setHoCodeName(String hoCodeName) {
		this.hoCodeName = hoCodeName;
	}

	public String getDoubleHoYn() {
		return doubleHoYn;
	}

	public void setDoubleHoYn(String doubleHoYn) {
		this.doubleHoYn = doubleHoYn;
	}

	public String getHoSort() {
		return hoSort;
	}

	public void setHoSort(String hoSort) {
		this.hoSort = hoSort;
	}
	
}
