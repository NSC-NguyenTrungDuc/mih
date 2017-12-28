package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1003 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1003.findAll", query="SELECT n FROM Nur1003 n")
public class Nur1003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actingCheckYn;
	private String bunho;
	private String comments;
	private double dataSort;
	private String doctor;
	private double fkout1001;
	private String gwa;
	private String hospCode;
	private double jubsuNo;
	private Date naewonDate;
	private String naewonType;
	private double pknur1003;
	private double printSeq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1003() {
	}


	@Column(name="ACTING_CHECK_YN")
	public String getActingCheckYn() {
		return this.actingCheckYn;
	}

	public void setActingCheckYn(String actingCheckYn) {
		this.actingCheckYn = actingCheckYn;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="DATA_SORT")
	public double getDataSort() {
		return this.dataSort;
	}

	public void setDataSort(double dataSort) {
		this.dataSort = dataSort;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkout1001() {
		return this.fkout1001;
	}

	public void setFkout1001(double fkout1001) {
		this.fkout1001 = fkout1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUBSU_NO")
	public double getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(double jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}


	@Column(name="NAEWON_TYPE")
	public String getNaewonType() {
		return this.naewonType;
	}

	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}


	public double getPknur1003() {
		return this.pknur1003;
	}

	public void setPknur1003(double pknur1003) {
		this.pknur1003 = pknur1003;
	}


	@Column(name="PRINT_SEQ")
	public double getPrintSeq() {
		return this.printSeq;
	}

	public void setPrintSeq(double printSeq) {
		this.printSeq = printSeq;
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