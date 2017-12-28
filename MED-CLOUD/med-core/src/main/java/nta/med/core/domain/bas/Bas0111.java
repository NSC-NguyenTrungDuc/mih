package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0111 database table.
 * 
 */
@Entity
//@NamedQuery(name="Bas0111.findAll", query="SELECT b FROM Bas0111 b")
@Table(name="BAS0111")
public class Bas0111 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String address;
	private String address1;
	private String gaein;
	private String gaeinName;
	private String hospCode;
	private String johap;
	private String johapGubun;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String useYn;
	private String zipCode1;
	private String zipCode2;

	public Bas0111() {
	}


	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}


	public String getAddress1() {
		return this.address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
	}


	public String getGaein() {
		return this.gaein;
	}

	public void setGaein(String gaein) {
		this.gaein = gaein;
	}


	@Column(name="GAEIN_NAME")
	public String getGaeinName() {
		return this.gaeinName;
	}

	public void setGaeinName(String gaeinName) {
		this.gaeinName = gaeinName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getJohap() {
		return this.johap;
	}

	public void setJohap(String johap) {
		this.johap = johap;
	}


	@Column(name="JOHAP_GUBUN")
	public String getJohapGubun() {
		return this.johapGubun;
	}

	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
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


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}


	@Column(name="ZIP_CODE1")
	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}


	@Column(name="ZIP_CODE2")
	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

}