package nta.phr.model;

/**
 * @author HoanPC
 *
 */
public class PhrUserChildInfoModel {
	
	private Long id;
	private Long account_id;
	private String fullname;
	private String fullname_kana;
	private String birth_day;
	private String sex;
	private String locale;

	public PhrUserChildInfoModel() {}

	public PhrUserChildInfoModel(Long id, Long account_id, String fullname, String fullname_kana, String birth_day,
			String sex, String locale) {
		super();
		this.id = id;
		this.account_id = account_id;
		this.fullname = fullname;
		this.fullname_kana = fullname_kana;
		this.birth_day = birth_day;
		this.sex = sex;
		this.locale = locale;
	}

	@Override
	public String toString() {
		return "PhrUserChildInfoModel [id=" + id + ", account_id=" + account_id + ", fullname=" + fullname 
				+ ", fullname_kana=" + fullname_kana + ", birth_day=" + birth_day + ", sex=" + sex + ", locale=" + locale + "]";
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Long getAccount_id() {
		return account_id;
	}

	public void setAccount_id(Long account_id) {
		this.account_id = account_id;
	}

	public String getFullname() {
		return fullname;
	}

	public void setFullname(String fullname) {
		this.fullname = fullname;
	}

	public String getFullname_kana() {
		return fullname_kana;
	}

	public void setFullname_kana(String fullname_kana) {
		this.fullname_kana = fullname_kana;
	}

	public String getBirth_day() {
		return birth_day;
	}

	public void setBirth_day(String birth_day) {
		this.birth_day = birth_day;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getLocale() {
		return locale;
	}

	public void setLocale(String locale) {
		this.locale = locale;
	}
	
}
