package nta.med.data.model.ihis.nuri;

public class NUR0801U00GrdMasterInfo {

	private String hoDong;
	private String buseoName;
	private String needType;
	private String codeName;
	private String makeHFileYn;

	public NUR0801U00GrdMasterInfo(String hoDong, String buseoName, String needType, String codeName,
			String makeHFileYn) {
		super();
		this.hoDong = hoDong;
		this.buseoName = buseoName;
		this.needType = needType;
		this.codeName = codeName;
		this.makeHFileYn = makeHFileYn;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getBuseoName() {
		return buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}

	public String getNeedType() {
		return needType;
	}

	public void setNeedType(String needType) {
		this.needType = needType;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getMakeHFileYn() {
		return makeHFileYn;
	}

	public void setMakeHFileYn(String makeHFileYn) {
		this.makeHFileYn = makeHFileYn;
	}

}
