package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF1002 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif1002.findAll", query="SELECT o FROM Oif1002 o")
public class Oif1002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String addrCode;
	private String addrFull;
	private String city;
	private String country;
	private double fkoif1001;
	private String homeNum;
	private String hospCode;
	private double pkSeq;
	private String prefecture;
	private Date sysDate;
	private String sysId;
	private String town;
	private Date updDate;
	private String updId;
	private String zip;

	public Oif1002() {
	}


	@Column(name="ADDR_CODE")
	public String getAddrCode() {
		return this.addrCode;
	}

	public void setAddrCode(String addrCode) {
		this.addrCode = addrCode;
	}


	@Column(name="ADDR_FULL")
	public String getAddrFull() {
		return this.addrFull;
	}

	public void setAddrFull(String addrFull) {
		this.addrFull = addrFull;
	}


	public String getCity() {
		return this.city;
	}

	public void setCity(String city) {
		this.city = city;
	}


	public String getCountry() {
		return this.country;
	}

	public void setCountry(String country) {
		this.country = country;
	}


	public double getFkoif1001() {
		return this.fkoif1001;
	}

	public void setFkoif1001(double fkoif1001) {
		this.fkoif1001 = fkoif1001;
	}


	@Column(name="HOME_NUM")
	public String getHomeNum() {
		return this.homeNum;
	}

	public void setHomeNum(String homeNum) {
		this.homeNum = homeNum;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	public String getPrefecture() {
		return this.prefecture;
	}

	public void setPrefecture(String prefecture) {
		this.prefecture = prefecture;
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


	public String getTown() {
		return this.town;
	}

	public void setTown(String town) {
		this.town = town;
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


	public String getZip() {
		return this.zip;
	}

	public void setZip(String zip) {
		this.zip = zip;
	}

}