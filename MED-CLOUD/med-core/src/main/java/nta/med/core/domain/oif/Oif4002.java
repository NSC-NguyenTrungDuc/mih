package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF4002 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif4002.findAll", query="SELECT o FROM Oif4002 o")
public class Oif4002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String admCode;
	private String admCodeName;
	private String admMemo;
	private String bundNum;
	private String classCode;
	private String classCodeName;
	private String classCodeTd;
	private double fkoif1101;
	private double fkoif4001;
	private String hospCode;
	private String memo;
	private double pkoif4002;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Oif4002() {
	}


	@Column(name="ADM_CODE")
	public String getAdmCode() {
		return this.admCode;
	}

	public void setAdmCode(String admCode) {
		this.admCode = admCode;
	}


	@Column(name="ADM_CODE_NAME")
	public String getAdmCodeName() {
		return this.admCodeName;
	}

	public void setAdmCodeName(String admCodeName) {
		this.admCodeName = admCodeName;
	}


	@Column(name="ADM_MEMO")
	public String getAdmMemo() {
		return this.admMemo;
	}

	public void setAdmMemo(String admMemo) {
		this.admMemo = admMemo;
	}


	@Column(name="BUND_NUM")
	public String getBundNum() {
		return this.bundNum;
	}

	public void setBundNum(String bundNum) {
		this.bundNum = bundNum;
	}


	@Column(name="CLASS_CODE")
	public String getClassCode() {
		return this.classCode;
	}

	public void setClassCode(String classCode) {
		this.classCode = classCode;
	}


	@Column(name="CLASS_CODE_NAME")
	public String getClassCodeName() {
		return this.classCodeName;
	}

	public void setClassCodeName(String classCodeName) {
		this.classCodeName = classCodeName;
	}


	@Column(name="CLASS_CODE_TD")
	public String getClassCodeTd() {
		return this.classCodeTd;
	}

	public void setClassCodeTd(String classCodeTd) {
		this.classCodeTd = classCodeTd;
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


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMemo() {
		return this.memo;
	}

	public void setMemo(String memo) {
		this.memo = memo;
	}


	public double getPkoif4002() {
		return this.pkoif4002;
	}

	public void setPkoif4002(double pkoif4002) {
		this.pkoif4002 = pkoif4002;
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