package nta.phr.model;

public class PhrAccountInfoModel {
	
	private Long id;
	private String email;
	private String name;
	private String name_kana;
	private String sex;
	private String birthday;

	public PhrAccountInfoModel() {}

	public PhrAccountInfoModel(Long id, String email, String name, String name_kana, String sex, String birthday) {
		super();
		this.id = id;
		this.email = email;
		this.name = name;
		this.name_kana = name_kana;
		this.sex = sex;
		this.birthday = birthday;
	}

	@Override
	public String toString() {
		return "PhrLoginModel [id=" + id + ", email=" + email + ", name=" + name + ", name_kana=" + name_kana + ", sex=" + sex + ", birthday=" + birthday +"]";
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getName_kana() {
		return name_kana;
	}

	public void setName_kana(String name_kana) {
		this.name_kana = name_kana;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
	}
	
}
