package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF4003 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif4003.findAll", query="SELECT o FROM Oif4003 o")
public class Oif4003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actCode;
	private String actCodeName;
	private String actCodeTd;
	private String actMemo;
	private String aliasCode;
	private String duration;
	private Date eventEnd;
	private String eventName;
	private Date eventStart;
	private double fkoif1101;
	private double fkoif4001;
	private double fkoif4002;
	private String hospCode;
	private String numCode;
	private double numSu;
	private String numUnit;
	private double pkSeq;
	private String subCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif4003() {
	}


	@Column(name="ACT_CODE")
	public String getActCode() {
		return this.actCode;
	}

	public void setActCode(String actCode) {
		this.actCode = actCode;
	}


	@Column(name="ACT_CODE_NAME")
	public String getActCodeName() {
		return this.actCodeName;
	}

	public void setActCodeName(String actCodeName) {
		this.actCodeName = actCodeName;
	}


	@Column(name="ACT_CODE_TD")
	public String getActCodeTd() {
		return this.actCodeTd;
	}

	public void setActCodeTd(String actCodeTd) {
		this.actCodeTd = actCodeTd;
	}


	@Column(name="ACT_MEMO")
	public String getActMemo() {
		return this.actMemo;
	}

	public void setActMemo(String actMemo) {
		this.actMemo = actMemo;
	}


	@Column(name="ALIAS_CODE")
	public String getAliasCode() {
		return this.aliasCode;
	}

	public void setAliasCode(String aliasCode) {
		this.aliasCode = aliasCode;
	}


	public String getDuration() {
		return this.duration;
	}

	public void setDuration(String duration) {
		this.duration = duration;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="EVENT_END")
	public Date getEventEnd() {
		return this.eventEnd;
	}

	public void setEventEnd(Date eventEnd) {
		this.eventEnd = eventEnd;
	}


	@Column(name="EVENT_NAME")
	public String getEventName() {
		return this.eventName;
	}

	public void setEventName(String eventName) {
		this.eventName = eventName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="EVENT_START")
	public Date getEventStart() {
		return this.eventStart;
	}

	public void setEventStart(Date eventStart) {
		this.eventStart = eventStart;
	}


	public double getFkoif1101() {
		return this.fkoif1101;
	}

	public void setFkoif1101(double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}


	public double getFkoif4001() {
		return this.fkoif4001;
	}

	public void setFkoif4001(double fkoif4001) {
		this.fkoif4001 = fkoif4001;
	}


	public double getFkoif4002() {
		return this.fkoif4002;
	}

	public void setFkoif4002(double fkoif4002) {
		this.fkoif4002 = fkoif4002;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NUM_CODE")
	public String getNumCode() {
		return this.numCode;
	}

	public void setNumCode(String numCode) {
		this.numCode = numCode;
	}


	@Column(name="NUM_SU")
	public double getNumSu() {
		return this.numSu;
	}

	public void setNumSu(double numSu) {
		this.numSu = numSu;
	}


	@Column(name="NUM_UNIT")
	public String getNumUnit() {
		return this.numUnit;
	}

	public void setNumUnit(String numUnit) {
		this.numUnit = numUnit;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	@Column(name="SUB_CODE")
	public String getSubCode() {
		return this.subCode;
	}

	public void setSubCode(String subCode) {
		this.subCode = subCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}