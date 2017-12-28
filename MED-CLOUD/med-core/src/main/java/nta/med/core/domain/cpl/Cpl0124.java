package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0124 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0124.findAll", query="SELECT c FROM Cpl0124 c")
public class Cpl0124 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String jundalGubun;
	private String seqCode;
	private String seqName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String worklistForm;

	public Cpl0124() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="SEQ_CODE")
	public String getSeqCode() {
		return this.seqCode;
	}

	public void setSeqCode(String seqCode) {
		this.seqCode = seqCode;
	}


	@Column(name="SEQ_NAME")
	public String getSeqName() {
		return this.seqName;
	}

	public void setSeqName(String seqName) {
		this.seqName = seqName;
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


	@Column(name="WORKLIST_FORM")
	public String getWorklistForm() {
		return this.worklistForm;
	}

	public void setWorklistForm(String worklistForm) {
		this.worklistForm = worklistForm;
	}

}