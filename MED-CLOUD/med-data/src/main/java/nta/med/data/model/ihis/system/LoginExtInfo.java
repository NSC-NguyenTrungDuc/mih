package nta.med.data.model.ihis.system;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

/**
 * The persistent class for the ADM0000 database table.
 * 
 */
public class LoginExtInfo {

	private Long id;

	private BigDecimal activeFlg;

	private BigDecimal changePwdFlg;

	private Timestamp created;

	private BigDecimal firstLoginFlg;

	private String hospCode;

	private Date lastChangePwd;

	private String pwdHistory;

	private String sysId;

	private String updId;

	private Timestamp updated;

	private String userId;

	public LoginExtInfo(BigDecimal changePwdFlg, BigDecimal firstLoginFlg,
			Date lastChangePwd, String pwdHistory) {
		super();
		this.changePwdFlg = changePwdFlg;
		this.firstLoginFlg = firstLoginFlg;
		this.lastChangePwd = lastChangePwd;
		this.pwdHistory = pwdHistory;
	}

	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public BigDecimal getChangePwdFlg() {
		return this.changePwdFlg;
	}

	public void setChangePwdFlg(BigDecimal changePwdFlg) {
		this.changePwdFlg = changePwdFlg;
	}

	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}

	public BigDecimal getFirstLoginFlg() {
		return this.firstLoginFlg;
	}

	public void setFirstLoginFlg(BigDecimal firstLoginFlg) {
		this.firstLoginFlg = firstLoginFlg;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public Date getLastChangePwd() {
		return this.lastChangePwd;
	}

	public void setLastChangePwd(Date lastChangePwd) {
		this.lastChangePwd = lastChangePwd;
	}

	public String getPwdHistory() {
		return this.pwdHistory;
	}

	public void setPwdHistory(String pwdHistory) {
		this.pwdHistory = pwdHistory;
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

	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}