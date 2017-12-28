package nta.med.data.model.ihis.nuri;

public class NUR1010Q00layBedListInfo {
	private String hoDong;
	private String hoCode;
	private String bedNo;
	private String team;
	
	public NUR1010Q00layBedListInfo(String hoDong, String hoCode, String bedNo, String team) {
		super();
		this.hoDong = hoDong;
		this.hoCode = hoCode;
		this.bedNo = bedNo;
		this.team = team;
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

	public String getTeam() {
		return team;
	}

	public void setTeam(String team) {
		this.team = team;
	}
	
}
