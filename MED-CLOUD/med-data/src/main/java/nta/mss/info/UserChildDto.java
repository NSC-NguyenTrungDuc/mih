package nta.mss.info;

import java.math.BigDecimal;
import java.math.BigInteger;

/**
 * @author HoanPC
 *
 */
public class UserChildDto {
	
	private BigInteger id;
	private Integer accountId;
	private String fullname;
	private String fullnameKana;
	private String birthday;
	private String sex;
	private String locale;
	private BigDecimal babyFlg;
	private String phone;
	
	public UserChildDto(BigInteger id, Integer accountId, String fullname, String fullnameKana, String birthday,
			String sex, String locale, BigDecimal babyFlg, String phone) {
		super();
		this.id = id;
		this.accountId = accountId;
		this.fullname = fullname;
		this.fullnameKana = fullnameKana;
		this.birthday = birthday;
		this.sex = sex;
		this.locale = locale;
		this.babyFlg = babyFlg;
		this.phone = phone;
	}

	public BigInteger getId() {
		return id;
	}

	public void setId(BigInteger id) {
		this.id = id;
	}

	public Integer getAccountId() {
		return accountId;
	}

	public void setAccountId(Integer accountId) {
		this.accountId = accountId;
	}

	public String getFullname() {
		return fullname;
	}

	public void setFullname(String fullname) {
		this.fullname = fullname;
	}

	public String getFullnameKana() {
		return fullnameKana;
	}

	public void setFullnameKana(String fullnameKana) {
		this.fullnameKana = fullnameKana;
	}

	public String getBirthday() {
		return birthday;
	}

	public void setBirthday(String birthday) {
		this.birthday = birthday;
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

	public BigDecimal getBabyFlg() {
		return babyFlg;
	}

	public void setBabyFlg(BigDecimal babyFlg) {
		this.babyFlg = babyFlg;
	}
	
	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	@Override
	public String toString() {
		return "UserChildDto [id=" + id + ", accountId=" + accountId + ", fullname="
				+ fullname + ", fullnameKana=" + fullnameKana + ", birthday=" + birthday + ", sex=" + sex
				+ ", locale=" + locale + ", babyFlg=" + babyFlg + ", phone=" + phone + "]";
	}
	
}
