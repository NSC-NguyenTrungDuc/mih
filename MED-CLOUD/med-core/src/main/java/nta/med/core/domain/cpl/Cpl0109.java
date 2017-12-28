package nta.med.core.domain.cpl;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the CPL0109 database table.
 * 
 */
@Entity
@Table(name = "CPL0109")
public class Cpl0109 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String code;
	private String codeName;
	private String codeNameRe;
	private String codeNameRe2;
	private String codeType;
	private String codeValue;
	private String hospCode;
	private Date sysDate;
	private String sysId;
	private String systemGubun;
	private Date updDate;
	private String updId;
	private String language;
	private String modifyFlg;

	public Cpl0109() {
	}

	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	@Column(name = "CODE_NAME")
	public String getCodeName() {
		return this.codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	@Column(name = "CODE_NAME_RE")
	public String getCodeNameRe() {
		return this.codeNameRe;
	}

	public void setCodeNameRe(String codeNameRe) {
		this.codeNameRe = codeNameRe;
	}

	@Column(name = "CODE_NAME_RE2")
	public String getCodeNameRe2() {
		return this.codeNameRe2;
	}

	public void setCodeNameRe2(String codeNameRe2) {
		this.codeNameRe2 = codeNameRe2;
	}

	@Column(name = "CODE_TYPE")
	public String getCodeType() {
		return this.codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}

	@Column(name = "CODE_VALUE")
	public String getCodeValue() {
		return this.codeValue;
	}

	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "SYSTEM_GUBUN")
	public String getSystemGubun() {
		return this.systemGubun;
	}

	public void setSystemGubun(String systemGubun) {
		this.systemGubun = systemGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	@Column(name = "LANGUAGE")
	public String getLanguage() {
		return this.language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}