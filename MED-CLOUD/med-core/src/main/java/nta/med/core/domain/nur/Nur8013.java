package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR8013 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur8013.findAll", query="SELECT n FROM Nur8013 n")
public class Nur8013 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private String firstGubun;
	private Date fromDate;
	private String grCode;
	private String grCodeText;
	private String hospCode;
	private double nurPoint;
	private String nurPointText;
	private String smCode;
	private String smCodeText;
	private String speTonggyeCd;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur8013() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="FIRST_GUBUN")
	public String getFirstGubun() {
		return this.firstGubun;
	}

	public void setFirstGubun(String firstGubun) {
		this.firstGubun = firstGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_DATE")
	public Date getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Date fromDate) {
		this.fromDate = fromDate;
	}


	@Column(name="GR_CODE")
	public String getGrCode() {
		return this.grCode;
	}

	public void setGrCode(String grCode) {
		this.grCode = grCode;
	}


	@Column(name="GR_CODE_TEXT")
	public String getGrCodeText() {
		return this.grCodeText;
	}

	public void setGrCodeText(String grCodeText) {
		this.grCodeText = grCodeText;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NUR_POINT")
	public double getNurPoint() {
		return this.nurPoint;
	}

	public void setNurPoint(double nurPoint) {
		this.nurPoint = nurPoint;
	}


	@Column(name="NUR_POINT_TEXT")
	public String getNurPointText() {
		return this.nurPointText;
	}

	public void setNurPointText(String nurPointText) {
		this.nurPointText = nurPointText;
	}


	@Column(name="SM_CODE")
	public String getSmCode() {
		return this.smCode;
	}

	public void setSmCode(String smCode) {
		this.smCode = smCode;
	}


	@Column(name="SM_CODE_TEXT")
	public String getSmCodeText() {
		return this.smCodeText;
	}

	public void setSmCodeText(String smCodeText) {
		this.smCodeText = smCodeText;
	}


	@Column(name="SPE_TONGGYE_CD")
	public String getSpeTonggyeCd() {
		return this.speTonggyeCd;
	}

	public void setSpeTonggyeCd(String speTonggyeCd) {
		this.speTonggyeCd = speTonggyeCd;
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