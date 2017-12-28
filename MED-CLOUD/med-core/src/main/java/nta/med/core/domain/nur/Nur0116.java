package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR0116 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur0116.findAll", query="SELECT n FROM Nur0116 n")
public class Nur0116 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double endBun;
	private Date endDate;
	private String hangmogCode;
	private String hospCode;
	private String jisiOrderGubun;
	private String nurGrCode;
	private String nurMdCode;
	private double startBun;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0116() {
	}


	@Column(name="END_BUN")
	public double getEndBun() {
		return this.endBun;
	}

	public void setEndBun(double endBun) {
		this.endBun = endBun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JISI_ORDER_GUBUN")
	public String getJisiOrderGubun() {
		return this.jisiOrderGubun;
	}

	public void setJisiOrderGubun(String jisiOrderGubun) {
		this.jisiOrderGubun = jisiOrderGubun;
	}


	@Column(name="NUR_GR_CODE")
	public String getNurGrCode() {
		return this.nurGrCode;
	}

	public void setNurGrCode(String nurGrCode) {
		this.nurGrCode = nurGrCode;
	}


	@Column(name="NUR_MD_CODE")
	public String getNurMdCode() {
		return this.nurMdCode;
	}

	public void setNurMdCode(String nurMdCode) {
		this.nurMdCode = nurMdCode;
	}


	@Column(name="START_BUN")
	public double getStartBun() {
		return this.startBun;
	}

	public void setStartBun(double startBun) {
		this.startBun = startBun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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