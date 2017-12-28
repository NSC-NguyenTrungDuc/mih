package nta.med.core.domain.out;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OUT5001 database table.
 * 
 */
@Entity
@NamedQuery(name="Out5001.findAll", query="SELECT o FROM Out5001 o")
public class Out5001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String changgu;
	private double diffAmt;
	private String hospCode;
	private String inwonMagamYn;
	private Date magamDate;
	private double seqWrite;
	private String suipMagamYn;
	private Date sysDate;
	private String sysId;
	private String totalMagamYn;
	private Date updDate;
	private String updId;

	public Out5001() {
	}


	public String getChanggu() {
		return this.changgu;
	}

	public void setChanggu(String changgu) {
		this.changgu = changgu;
	}


	@Column(name="DIFF_AMT")
	public double getDiffAmt() {
		return this.diffAmt;
	}

	public void setDiffAmt(double diffAmt) {
		this.diffAmt = diffAmt;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INWON_MAGAM_YN")
	public String getInwonMagamYn() {
		return this.inwonMagamYn;
	}

	public void setInwonMagamYn(String inwonMagamYn) {
		this.inwonMagamYn = inwonMagamYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}


	@Column(name="SEQ_WRITE")
	public double getSeqWrite() {
		return this.seqWrite;
	}

	public void setSeqWrite(double seqWrite) {
		this.seqWrite = seqWrite;
	}


	@Column(name="SUIP_MAGAM_YN")
	public String getSuipMagamYn() {
		return this.suipMagamYn;
	}

	public void setSuipMagamYn(String suipMagamYn) {
		this.suipMagamYn = suipMagamYn;
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


	@Column(name="TOTAL_MAGAM_YN")
	public String getTotalMagamYn() {
		return this.totalMagamYn;
	}

	public void setTotalMagamYn(String totalMagamYn) {
		this.totalMagamYn = totalMagamYn;
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