package nta.med.data.model.ihis.cpls;

public class CPL0000Q00SelectOUT0101ListItemInfo {
	private String bunho;
    private String suname;
    private String birth;
    private String sex;
    private Integer age;
	public CPL0000Q00SelectOUT0101ListItemInfo(String bunho, String suname,
			String birth, String sex, Integer age) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.birth = birth;
		this.sex = sex;
		this.age = age;
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
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public Integer getAge() {
		return age;
	}
	public void setAge(Integer age) {
		this.age = age;
	}
}
