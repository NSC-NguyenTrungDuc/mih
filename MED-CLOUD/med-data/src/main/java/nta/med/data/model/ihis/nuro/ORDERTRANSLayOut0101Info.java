package nta.med.data.model.ihis.nuro;

public class ORDERTRANSLayOut0101Info {
	private String suname       ;
	private String suname2      ;
	private String birth        ;
	private String tel          ;
	private String sex          ;
	private Integer age          ;
	private String ifValidYn    ;
	public ORDERTRANSLayOut0101Info(String suname, String suname2,
			String birth, String tel, String sex, Integer age, String ifValidYn) {
		super();
		this.suname = suname;
		this.suname2 = suname2;
		this.birth = birth;
		this.tel = tel;
		this.sex = sex;
		this.age = age;
		this.ifValidYn = ifValidYn;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getSuname2() {
		return suname2;
	}
	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
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
	public String getIfValidYn() {
		return ifValidYn;
	}
	public void setIfValidYn(String ifValidYn) {
		this.ifValidYn = ifValidYn;
	}
	
}
