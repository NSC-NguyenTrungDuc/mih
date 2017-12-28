package nta.med.data.model.ihis.bass;

public class BAS0250Q00layJaewonListInfo {

	private String hoDong1;
	private String hoCode1;
	private String bedNo;
	private String suname;
	private String ipwonDate;
	private String toiwonResDate;
	private String toiwonResYn;
	private String sex;
	private String ipwonType;
	private String ipwonTypeName;
	
	public BAS0250Q00layJaewonListInfo(String hoDong1, String hoCode1, String bedNo, String suname, String ipwonDate,
			String toiwonResDate, String toiwonResYn, String sex, String ipwonType, String ipwonTypeName) {
		super();
		this.hoDong1 = hoDong1;
		this.hoCode1 = hoCode1;
		this.bedNo = bedNo;
		this.suname = suname;
		this.ipwonDate = ipwonDate;
		this.toiwonResDate = toiwonResDate;
		this.toiwonResYn = toiwonResYn;
		this.sex = sex;
		this.ipwonType = ipwonType;
		this.ipwonTypeName = ipwonTypeName;
	}

	public String getHoDong1() {
		return hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
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

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getToiwonResDate() {
		return toiwonResDate;
	}

	public void setToiwonResDate(String toiwonResDate) {
		this.toiwonResDate = toiwonResDate;
	}

	public String getToiwonResYn() {
		return toiwonResYn;
	}

	public void setToiwonResYn(String toiwonResYn) {
		this.toiwonResYn = toiwonResYn;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getIpwonType() {
		return ipwonType;
	}

	public void setIpwonType(String ipwonType) {
		this.ipwonType = ipwonType;
	}

	public String getIpwonTypeName() {
		return ipwonTypeName;
	}

	public void setIpwonTypeName(String ipwonTypeName) {
		this.ipwonTypeName = ipwonTypeName;
	}
	
}
