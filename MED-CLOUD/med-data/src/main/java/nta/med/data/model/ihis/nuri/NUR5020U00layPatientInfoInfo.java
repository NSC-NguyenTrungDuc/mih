package nta.med.data.model.ihis.nuri;

public class NUR5020U00layPatientInfoInfo {

	private String hoDong;
	private String suname;
	private Integer age;
	private String sex;
	private String sang;
	private String gwa;

	public NUR5020U00layPatientInfoInfo(String hoDong, String suname, Integer age, String sex, String sang,
			String gwa) {
		super();
		this.hoDong = hoDong;
		this.suname = suname;
		this.age = age;
		this.sex = sex;
		this.sang = sang;
		this.gwa = gwa;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public Integer getAge() {
		return age;
	}

	public void setAge(Integer age) {
		this.age = age;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getSang() {
		return sang;
	}

	public void setSang(String sang) {
		this.sang = sang;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

}
