package nta.med.data.model.ihis.inps;

public class INP1001U01LoadIpwonTypeListInfo {

	private Double pkinp1001;
	private String ipwonType;
	private String codeName;
	private String japanDate;
	private String contKey;

	public INP1001U01LoadIpwonTypeListInfo(Double pkinp1001, String ipwonType, String codeName, String japanDate,
			String contKey) {
		super();
		this.pkinp1001 = pkinp1001;
		this.ipwonType = ipwonType;
		this.codeName = codeName;
		this.japanDate = japanDate;
		this.contKey = contKey;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getIpwonType() {
		return ipwonType;
	}

	public void setIpwonType(String ipwonType) {
		this.ipwonType = ipwonType;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getJapanDate() {
		return japanDate;
	}

	public void setJapanDate(String japanDate) {
		this.japanDate = japanDate;
	}

	public String getContKey() {
		return contKey;
	}

	public void setContKey(String contKey) {
		this.contKey = contKey;
	}

}
