package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0317 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0317.findAll", query="SELECT b FROM Bas0317 b")
public class Bas0317 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private String hangmogCode;
	private String hospCode;
	private String sgCode;
	private String sgCodeIlban;
	private String sgCodeNoin;
	private String sgCode1;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Bas0317() {
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


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SG_CODE_ILBAN")
	public String getSgCodeIlban() {
		return this.sgCodeIlban;
	}

	public void setSgCodeIlban(String sgCodeIlban) {
		this.sgCodeIlban = sgCodeIlban;
	}


	@Column(name="SG_CODE_NOIN")
	public String getSgCodeNoin() {
		return this.sgCodeNoin;
	}

	public void setSgCodeNoin(String sgCodeNoin) {
		this.sgCodeNoin = sgCodeNoin;
	}


	@Column(name="SG_CODE1")
	public String getSgCode1() {
		return this.sgCode1;
	}

	public void setSgCode1(String sgCode1) {
		this.sgCode1 = sgCode1;
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