package nta.med.data.model.ihis.inps;

public class INP2004Q01grdINP2004Info {

	private Double fkinp1001;
	private String bunho;
	private String suname;
	private String sex;
	private String age;
	private String birth;
	private String startDate;
	private String fromHoDong1;
	private String fromHoCode1;
	private String fromBedNo;
	private String toHoDong1;
	private String toHoCode1;
	private String toBedNo;
	private String ipwonDate;
	private String toiwonDate;

	public INP2004Q01grdINP2004Info(Double fkinp1001, String bunho, String suname, String sex, String age, String birth,
			String startDate, String fromHoDong1, String fromHoCode1, String fromBedNo, String toHoDong1,
			String toHoCode1, String toBedNo, String ipwonDate, String toiwonDate) {
		super();
		this.fkinp1001 = fkinp1001;
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
		this.age = age;
		this.birth = birth;
		this.startDate = startDate;
		this.fromHoDong1 = fromHoDong1;
		this.fromHoCode1 = fromHoCode1;
		this.fromBedNo = fromBedNo;
		this.toHoDong1 = toHoDong1;
		this.toHoCode1 = toHoCode1;
		this.toBedNo = toBedNo;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getAge() {
		return age;
	}

	public void setAge(String age) {
		this.age = age;
	}

	public String getBirth() {
		return birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}

	public String getStartDate() {
		return startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	public String getFromHoDong1() {
		return fromHoDong1;
	}

	public void setFromHoDong1(String fromHoDong1) {
		this.fromHoDong1 = fromHoDong1;
	}

	public String getFromHoCode1() {
		return fromHoCode1;
	}

	public void setFromHoCode1(String fromHoCode1) {
		this.fromHoCode1 = fromHoCode1;
	}

	public String getFromBedNo() {
		return fromBedNo;
	}

	public void setFromBedNo(String fromBedNo) {
		this.fromBedNo = fromBedNo;
	}

	public String getToHoDong1() {
		return toHoDong1;
	}

	public void setToHoDong1(String toHoDong1) {
		this.toHoDong1 = toHoDong1;
	}

	public String getToHoCode1() {
		return toHoCode1;
	}

	public void setToHoCode1(String toHoCode1) {
		this.toHoCode1 = toHoCode1;
	}

	public String getToBedNo() {
		return toBedNo;
	}

	public void setToBedNo(String toBedNo) {
		this.toBedNo = toBedNo;
	}

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(String toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

}
