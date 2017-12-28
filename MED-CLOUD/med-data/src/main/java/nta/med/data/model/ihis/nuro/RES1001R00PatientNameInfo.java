package nta.med.data.model.ihis.nuro;

public class RES1001R00PatientNameInfo {
	private String suname;
	private String birth;
	private Double age;
	public RES1001R00PatientNameInfo(String suname, String birth, Double age) {
		super();
		this.suname = suname;
		this.birth = birth;
		this.age = age;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public Double getAge() {
		return age;
	}
	public void setAge(Double age) {
		this.age = age;
	}
	
}
