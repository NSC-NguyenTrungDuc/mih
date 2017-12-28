package nta.med.core.domain.inp;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INP1010 database table.
 * 
 */
@Entity
@NamedQuery(name="Inp1010.findAll", query="SELECT i FROM Inp1010 i")
public class Inp1010 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date fromCancelDate;
	private Date fromChtIpwonDate;
	private Date fromChtToiwonDate;
	private String fromDrgNo;
	private String fromDrgYn;
	private Date fromGaToiwonDate;
	private Date fromIpwonDate;
	private Date fromToiwonDate;
	private Date fromToiwonResDate;
	private String hospCode;
	private String iudGubun;
	private double pkinp1001;
	private double pkinp1010;
	private Date sysDate;
	private String sysId;
	private Date toCancelDate;
	private Date toChtIpwonDate;
	private Date toChtToiwonDate;
	private String toDrgNo;
	private String toDrgYn;
	private Date toGaToiwonDate;
	private Date toIpwonDate;
	private Date toToiwonDate;
	private Date toToiwonResDate;
	private Date updDate;
	private String updId;

	public Inp1010() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_CANCEL_DATE")
	public Date getFromCancelDate() {
		return this.fromCancelDate;
	}

	public void setFromCancelDate(Date fromCancelDate) {
		this.fromCancelDate = fromCancelDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_CHT_IPWON_DATE")
	public Date getFromChtIpwonDate() {
		return this.fromChtIpwonDate;
	}

	public void setFromChtIpwonDate(Date fromChtIpwonDate) {
		this.fromChtIpwonDate = fromChtIpwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_CHT_TOIWON_DATE")
	public Date getFromChtToiwonDate() {
		return this.fromChtToiwonDate;
	}

	public void setFromChtToiwonDate(Date fromChtToiwonDate) {
		this.fromChtToiwonDate = fromChtToiwonDate;
	}


	@Column(name="FROM_DRG_NO")
	public String getFromDrgNo() {
		return this.fromDrgNo;
	}

	public void setFromDrgNo(String fromDrgNo) {
		this.fromDrgNo = fromDrgNo;
	}


	@Column(name="FROM_DRG_YN")
	public String getFromDrgYn() {
		return this.fromDrgYn;
	}

	public void setFromDrgYn(String fromDrgYn) {
		this.fromDrgYn = fromDrgYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_GA_TOIWON_DATE")
	public Date getFromGaToiwonDate() {
		return this.fromGaToiwonDate;
	}

	public void setFromGaToiwonDate(Date fromGaToiwonDate) {
		this.fromGaToiwonDate = fromGaToiwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_IPWON_DATE")
	public Date getFromIpwonDate() {
		return this.fromIpwonDate;
	}

	public void setFromIpwonDate(Date fromIpwonDate) {
		this.fromIpwonDate = fromIpwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_TOIWON_DATE")
	public Date getFromToiwonDate() {
		return this.fromToiwonDate;
	}

	public void setFromToiwonDate(Date fromToiwonDate) {
		this.fromToiwonDate = fromToiwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="FROM_TOIWON_RES_DATE")
	public Date getFromToiwonResDate() {
		return this.fromToiwonResDate;
	}

	public void setFromToiwonResDate(Date fromToiwonResDate) {
		this.fromToiwonResDate = fromToiwonResDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IUD_GUBUN")
	public String getIudGubun() {
		return this.iudGubun;
	}

	public void setIudGubun(String iudGubun) {
		this.iudGubun = iudGubun;
	}


	public double getPkinp1001() {
		return this.pkinp1001;
	}

	public void setPkinp1001(double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}


	public double getPkinp1010() {
		return this.pkinp1010;
	}

	public void setPkinp1010(double pkinp1010) {
		this.pkinp1010 = pkinp1010;
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
	@Column(name="TO_CANCEL_DATE")
	public Date getToCancelDate() {
		return this.toCancelDate;
	}

	public void setToCancelDate(Date toCancelDate) {
		this.toCancelDate = toCancelDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TO_CHT_IPWON_DATE")
	public Date getToChtIpwonDate() {
		return this.toChtIpwonDate;
	}

	public void setToChtIpwonDate(Date toChtIpwonDate) {
		this.toChtIpwonDate = toChtIpwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TO_CHT_TOIWON_DATE")
	public Date getToChtToiwonDate() {
		return this.toChtToiwonDate;
	}

	public void setToChtToiwonDate(Date toChtToiwonDate) {
		this.toChtToiwonDate = toChtToiwonDate;
	}


	@Column(name="TO_DRG_NO")
	public String getToDrgNo() {
		return this.toDrgNo;
	}

	public void setToDrgNo(String toDrgNo) {
		this.toDrgNo = toDrgNo;
	}


	@Column(name="TO_DRG_YN")
	public String getToDrgYn() {
		return this.toDrgYn;
	}

	public void setToDrgYn(String toDrgYn) {
		this.toDrgYn = toDrgYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TO_GA_TOIWON_DATE")
	public Date getToGaToiwonDate() {
		return this.toGaToiwonDate;
	}

	public void setToGaToiwonDate(Date toGaToiwonDate) {
		this.toGaToiwonDate = toGaToiwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TO_IPWON_DATE")
	public Date getToIpwonDate() {
		return this.toIpwonDate;
	}

	public void setToIpwonDate(Date toIpwonDate) {
		this.toIpwonDate = toIpwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TO_TOIWON_DATE")
	public Date getToToiwonDate() {
		return this.toToiwonDate;
	}

	public void setToToiwonDate(Date toToiwonDate) {
		this.toToiwonDate = toToiwonDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="TO_TOIWON_RES_DATE")
	public Date getToToiwonResDate() {
		return this.toToiwonResDate;
	}

	public void setToToiwonResDate(Date toToiwonResDate) {
		this.toToiwonResDate = toToiwonResDate;
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