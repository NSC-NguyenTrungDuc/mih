package nta.med.core.domain.nur;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the NUR0812 database table.
 * 
 */
@Entity
@Table(name = "NUR0812")
public class Nur0812 extends BaseEntity {
	private static final long serialVersionUID = 1L;

	private String hospCode;
	private String needAsmtCode;
	private String needGubun;
	private String needHType;
	private String payloadNo;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0812() {
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "NEED_ASMT_CODE")
	public String getNeedAsmtCode() {
		return this.needAsmtCode;
	}

	public void setNeedAsmtCode(String needAsmtCode) {
		this.needAsmtCode = needAsmtCode;
	}

	@Column(name = "NEED_GUBUN")
	public String getNeedGubun() {
		return this.needGubun;
	}

	public void setNeedGubun(String needGubun) {
		this.needGubun = needGubun;
	}

	@Column(name = "NEED_H_TYPE")
	public String getNeedHType() {
		return this.needHType;
	}

	public void setNeedHType(String needHType) {
		this.needHType = needHType;
	}

	@Column(name = "PAYLOAD_NO")
	public String getPayloadNo() {
		return this.payloadNo;
	}

	public void setPayloadNo(String payloadNo) {
		this.payloadNo = payloadNo;
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

}