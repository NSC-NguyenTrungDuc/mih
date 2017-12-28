package nta.med.core.domain.cht;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the CHT0115 database table.
 * 
 */
@Entity
@Table(name = "CHT0115")
public class Cht0115 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private String hospCode;
	private double sort;
	private Date startDate;
	private String susikChangeCode;
	private String susikCode;
	private Date susikCrDate;
	private String susikDetailGubun;
	private Date susikDisableDate;
	private String susikGubun;
	private String susikGwanriNo;
	private String susikName;
	private String susikNameGana;
	private Date susikUpdDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String modifyFlg;

	public Cht0115() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public double getSort() {
		return this.sort;
	}

	public void setSort(double sort) {
		this.sort = sort;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	@Column(name = "SUSIK_CHANGE_CODE")
	public String getSusikChangeCode() {
		return this.susikChangeCode;
	}

	public void setSusikChangeCode(String susikChangeCode) {
		this.susikChangeCode = susikChangeCode;
	}

	@Column(name = "SUSIK_CODE")
	public String getSusikCode() {
		return this.susikCode;
	}

	public void setSusikCode(String susikCode) {
		this.susikCode = susikCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SUSIK_CR_DATE")
	public Date getSusikCrDate() {
		return this.susikCrDate;
	}

	public void setSusikCrDate(Date susikCrDate) {
		this.susikCrDate = susikCrDate;
	}

	@Column(name = "SUSIK_DETAIL_GUBUN")
	public String getSusikDetailGubun() {
		return this.susikDetailGubun;
	}

	public void setSusikDetailGubun(String susikDetailGubun) {
		this.susikDetailGubun = susikDetailGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SUSIK_DISABLE_DATE")
	public Date getSusikDisableDate() {
		return this.susikDisableDate;
	}

	public void setSusikDisableDate(Date susikDisableDate) {
		this.susikDisableDate = susikDisableDate;
	}

	@Column(name = "SUSIK_GUBUN")
	public String getSusikGubun() {
		return this.susikGubun;
	}

	public void setSusikGubun(String susikGubun) {
		this.susikGubun = susikGubun;
	}

	@Column(name = "SUSIK_GWANRI_NO")
	public String getSusikGwanriNo() {
		return this.susikGwanriNo;
	}

	public void setSusikGwanriNo(String susikGwanriNo) {
		this.susikGwanriNo = susikGwanriNo;
	}

	@Column(name = "SUSIK_NAME")
	public String getSusikName() {
		return this.susikName;
	}

	public void setSusikName(String susikName) {
		this.susikName = susikName;
	}

	@Column(name = "SUSIK_NAME_GANA")
	public String getSusikNameGana() {
		return this.susikNameGana;
	}

	public void setSusikNameGana(String susikNameGana) {
		this.susikNameGana = susikNameGana;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SUSIK_UPD_DATE")
	public Date getSusikUpdDate() {
		return this.susikUpdDate;
	}

	public void setSusikUpdDate(Date susikUpdDate) {
		this.susikUpdDate = susikUpdDate;
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

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
	
}