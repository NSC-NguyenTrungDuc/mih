package nta.med.core.domain.cht;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the CHT0110 database table.
 * 
 */
@Entity
@NamedQuery(name = "Cht0110.findAll", query = "SELECT c FROM Cht0110 c")
@Table(name = "CHT0110")
public class Cht0110 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bulyongYn;
	private Date endDate;
	private String hospCode;
	private String junyeomBunryu;
	private String junyeomKind;
	private String samangSangGroup;
	private String sangCode;
	private String sangName;
	private String sangNameHan;
	private String sangNameInx;
	private String sangNameSelf;
	private Date startDate;
	private String sugaSangCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String modifyFlg;

	public Cht0110() {
	}

	@Column(name = "BULYONG_YN")
	public String getBulyongYn() {
		return this.bulyongYn;
	}

	public void setBulyongYn(String bulyongYn) {
		this.bulyongYn = bulyongYn;
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

	@Column(name = "JUNYEOM_BUNRYU")
	public String getJunyeomBunryu() {
		return this.junyeomBunryu;
	}

	public void setJunyeomBunryu(String junyeomBunryu) {
		this.junyeomBunryu = junyeomBunryu;
	}

	@Column(name = "JUNYEOM_KIND")
	public String getJunyeomKind() {
		return this.junyeomKind;
	}

	public void setJunyeomKind(String junyeomKind) {
		this.junyeomKind = junyeomKind;
	}

	@Column(name = "SAMANG_SANG_GROUP")
	public String getSamangSangGroup() {
		return this.samangSangGroup;
	}

	public void setSamangSangGroup(String samangSangGroup) {
		this.samangSangGroup = samangSangGroup;
	}

	@Column(name = "SANG_CODE")
	public String getSangCode() {
		return this.sangCode;
	}

	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}

	@Column(name = "SANG_NAME")
	public String getSangName() {
		return this.sangName;
	}

	public void setSangName(String sangName) {
		this.sangName = sangName;
	}

	@Column(name = "SANG_NAME_HAN")
	public String getSangNameHan() {
		return this.sangNameHan;
	}

	public void setSangNameHan(String sangNameHan) {
		this.sangNameHan = sangNameHan;
	}

	@Column(name = "SANG_NAME_INX")
	public String getSangNameInx() {
		return this.sangNameInx;
	}

	public void setSangNameInx(String sangNameInx) {
		this.sangNameInx = sangNameInx;
	}

	@Column(name = "SANG_NAME_SELF")
	public String getSangNameSelf() {
		return this.sangNameSelf;
	}

	public void setSangNameSelf(String sangNameSelf) {
		this.sangNameSelf = sangNameSelf;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	@Column(name = "SUGA_SANG_CODE")
	public String getSugaSangCode() {
		return this.sugaSangCode;
	}

	public void setSugaSangCode(String sugaSangCode) {
		this.sugaSangCode = sugaSangCode;
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