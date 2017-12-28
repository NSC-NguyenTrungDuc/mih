package nta.med.core.domain.phr;

import java.math.BigDecimal;
import java.math.BigInteger;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import org.hibernate.annotations.Parameter;
import org.hibernate.annotations.Type;
import org.hibernate.annotations.TypeDef;
import org.jasypt.hibernate4.type.EncryptedStringType;

/**
 * The persistent class for the PHR_ACCOUNT database table.
 * 
 */
//@TypeDef(name = "encryptedString", typeClass = EncryptedStringType.class, parameters = {
//		@Parameter(name = "encryptorRegisteredName", value = "hibernateStringEncryptor") })
@Entity
@Table(name = "PHR_ACCOUNT")
public class PhrAccount extends PhrBaseEntity {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID", unique = true, nullable = false)
	private Long id;

	@Column(name = "BABY_BACKGROUND_URL")
	private String babyBackgroundUrl;

	private String email;
//
//	@Type(type = "encryptedString")
	private String password;

	@Column(name = "STANDARD_BACKGROUND_URL")
	private String standardBackgroundUrl;

	private BigDecimal status;

	@Column(name = "SYS_ID")
	private String sysId;

	@Column(name = "UPD_ID")
	private String updId;

	@Column(name = "TYPE")
	private int type;
	
	@Column(name = "LOGIN_TYPE")
	private BigDecimal loginType;
	
	@Column(name = "FACEBOOK_ID")
	private BigInteger facebookId;
	
	public String getBabyBackgroundUrl() {
		return this.babyBackgroundUrl;
	}

	public void setBabyBackgroundUrl(String babyBackgroundUrl) {
		this.babyBackgroundUrl = babyBackgroundUrl;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

//	@Type(type = "encryptedString")
	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getStandardBackgroundUrl() {
		return this.standardBackgroundUrl;
	}

	public void setStandardBackgroundUrl(String standardBackgroundUrl) {
		this.standardBackgroundUrl = standardBackgroundUrl;
	}

	public BigDecimal getStatus() {
		return this.status;
	}

	public void setStatus(BigDecimal status) {
		this.status = status;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}
	
	public BigDecimal getLoginType() {
		return loginType;
	}

	public void setLoginType(BigDecimal loginType) {
		this.loginType = loginType;
	}

	public BigInteger getFacebookId() {
		return facebookId;
	}

	public void setFacebookId(BigInteger facebookId) {
		this.facebookId = facebookId;
	}
}