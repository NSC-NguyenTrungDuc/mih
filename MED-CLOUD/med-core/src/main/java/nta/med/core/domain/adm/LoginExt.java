package nta.med.core.domain.adm;

import java.io.Serializable;
import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;


/**
 * The persistent class for the LOGIN_EXT database table.
 * 
 */
@Entity
@Table(name="LOGIN_EXT")
@NamedQuery(name="LoginExt.findAll", query="SELECT l FROM LoginExt l")
public class LoginExt implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private String id;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	@Column(name="CHANGE_PWD_FLG")
	private BigDecimal changePwdFlg;

	private Date created;

	@Column(name="FIRST_LOGIN_FLG")
	private BigDecimal firstLoginFlg;

	@Column(name="HOSP_CODE")
	private String hospCode;

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="LAST_CHANGE_PWD")
	private Date lastChangePwd;

	@Column(name="PWD_HISTORY")
	private String pwdHistory;

	@Column(name="SYS_ID")
	private String sysId;

	@Column(name="UPD_ID")
	private String updId;

	private Date updated;

	@Column(name="USER_ID")
	private String userId;

	public LoginExt() {
	}

	public String getId() {
		return this.id;
	}

	public void setId(String id) {
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

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
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

	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}