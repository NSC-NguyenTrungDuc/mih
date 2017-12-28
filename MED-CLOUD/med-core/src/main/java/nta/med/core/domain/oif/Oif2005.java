package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF2005 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif2005.findAll", query="SELECT o FROM Oif2005 o")
public class Oif2005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String area;
	private String city;
	private String country;
	private String extension;
	private double fkoif1001;
	private double fkoif2001;
	private String gubunCode;
	private String hospCode;
	private String memo;
	private String num;
	private double pkSeq;
	private Date sysDate;
	private String sysId;
	private String telCode;
	private Date updDate;
	private String updId;

	public Oif2005() {
	}


	public String getArea() {
		return this.area;
	}

	public void setArea(String area) {
		this.area = area;
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


	public String getExtension() {
		return this.extension;
	}

	public void setExtension(String extension) {
		this.extension = extension;
	}


	public double getFkoif1001() {
		return this.fkoif1001;
	}

	public void setFkoif1001(double fkoif1001) {
		this.fkoif1001 = fkoif1001;
	}


	public double getFkoif2001() {
		return this.fkoif2001;
	}

	public void setFkoif2001(double fkoif2001) {
		this.fkoif2001 = fkoif2001;
	}


	@Column(name="GUBUN_CODE")
	public String getGubunCode() {
		return this.gubunCode;
	}

	public void setGubunCode(String gubunCode) {
		this.gubunCode = gubunCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getMemo() {
		return this.memo;
	}

	public void setMemo(String memo) {
		this.memo = memo;
	}


	public String getNum() {
		return this.num;
	}

	public void setNum(String num) {
		this.num = num;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
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


	@Column(name="TEL_CODE")
	public String getTelCode() {
		return this.telCode;
	}

	public void setTelCode(String telCode) {
		this.telCode = telCode;
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