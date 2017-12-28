package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0241 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0241.findAll", query="SELECT b FROM Bas0241 b")
public class Bas0241 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunCode;
	private String donbogYn;
	private String homeCareYn;
	private String imsiDrugYn;
	private String ioGubun;
	private String nuCode;
	private String nuGubun;
	private Date nuYmd;
	private String orderGubun;
	private String sgCode;
	private String susuryoGubun;
	private Date sysDate;
	private String sysId;
	private String taxYn;
	private Date updDate;
	private String updId;
	private String wonyoiOrderYn;

	public Bas0241() {
	}


	@Column(name="BUN_CODE")
	public String getBunCode() {
		return this.bunCode;
	}

	public void setBunCode(String bunCode) {
		this.bunCode = bunCode;
	}


	@Column(name="DONBOG_YN")
	public String getDonbogYn() {
		return this.donbogYn;
	}

	public void setDonbogYn(String donbogYn) {
		this.donbogYn = donbogYn;
	}


	@Column(name="HOME_CARE_YN")
	public String getHomeCareYn() {
		return this.homeCareYn;
	}

	public void setHomeCareYn(String homeCareYn) {
		this.homeCareYn = homeCareYn;
	}


	@Column(name="IMSI_DRUG_YN")
	public String getImsiDrugYn() {
		return this.imsiDrugYn;
	}

	public void setImsiDrugYn(String imsiDrugYn) {
		this.imsiDrugYn = imsiDrugYn;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}


	@Column(name="NU_CODE")
	public String getNuCode() {
		return this.nuCode;
	}

	public void setNuCode(String nuCode) {
		this.nuCode = nuCode;
	}


	@Column(name="NU_GUBUN")
	public String getNuGubun() {
		return this.nuGubun;
	}

	public void setNuGubun(String nuGubun) {
		this.nuGubun = nuGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NU_YMD")
	public Date getNuYmd() {
		return this.nuYmd;
	}

	public void setNuYmd(Date nuYmd) {
		this.nuYmd = nuYmd;
	}


	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SUSURYO_GUBUN")
	public String getSusuryoGubun() {
		return this.susuryoGubun;
	}

	public void setSusuryoGubun(String susuryoGubun) {
		this.susuryoGubun = susuryoGubun;
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


	@Column(name="TAX_YN")
	public String getTaxYn() {
		return this.taxYn;
	}

	public void setTaxYn(String taxYn) {
		this.taxYn = taxYn;
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


	@Column(name="WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}

}