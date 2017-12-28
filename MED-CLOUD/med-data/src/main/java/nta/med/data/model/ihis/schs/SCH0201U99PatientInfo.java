package nta.med.data.model.ihis.schs;

public class SCH0201U99PatientInfo {
	private String suname;
	private String birth;
	private Double age;
	private String bunho;
    
	public SCH0201U99PatientInfo(String suname, String birth, Double age,
			String bunho) {
		super();
		this.suname = suname;
		this.birth = birth;
		this.age = age;
		this.bunho = bunho;
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

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	
}
