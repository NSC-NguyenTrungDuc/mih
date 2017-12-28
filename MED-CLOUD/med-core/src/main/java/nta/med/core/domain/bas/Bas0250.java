package nta.med.core.domain.bas;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the BAS0250 database table.
 * 
 */
@Entity
//@NamedQuery(name="Bas0250.findAll", query="SELECT b FROM Bas0250 b")
@Table(name="BAS0250")
public class Bas0250 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String DoubleHoYn;
	private Date endDate;
	private String hoCode;
	private String hoCodeName;
	private String hoDong;
	private String hoGrade;
	private String hoGubun;
	private String hoMainGwa;
	private String hoSex;
	private Double hoSexFemail;
	private Double hoSexMail;
	private Double hoSort;
	private String hoSpecialYn;
	private String hoStatus;
	private Double hoTotalBed;
	private Double hoUsedBed;
	private String hospCode;
	private String incuYn;
	private Double reportTotalBed;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private String team;
	private Date updDate;
	private String updId;

	public Bas0250() {
	}


	@Column(name="Double_HO_YN")
	public String getDoubleHoYn() {
		return this.DoubleHoYn;
	}

	public void setDoubleHoYn(String DoubleHoYn) {
		this.DoubleHoYn = DoubleHoYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_CODE_NAME")
	public String getHoCodeName() {
		return this.hoCodeName;
	}

	public void setHoCodeName(String hoCodeName) {
		this.hoCodeName = hoCodeName;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HO_GRADE")
	public String getHoGrade() {
		return this.hoGrade;
	}

	public void setHoGrade(String hoGrade) {
		this.hoGrade = hoGrade;
	}


	@Column(name="HO_GUBUN")
	public String getHoGubun() {
		return this.hoGubun;
	}

	public void setHoGubun(String hoGubun) {
		this.hoGubun = hoGubun;
	}


	@Column(name="HO_MAIN_GWA")
	public String getHoMainGwa() {
		return this.hoMainGwa;
	}

	public void setHoMainGwa(String hoMainGwa) {
		this.hoMainGwa = hoMainGwa;
	}


	@Column(name="HO_SEX")
	public String getHoSex() {
		return this.hoSex;
	}

	public void setHoSex(String hoSex) {
		this.hoSex = hoSex;
	}


	@Column(name="HO_SEX_FEMAIL")
	public Double getHoSexFemail() {
		return this.hoSexFemail;
	}

	public void setHoSexFemail(Double hoSexFemail) {
		this.hoSexFemail = hoSexFemail;
	}


	@Column(name="HO_SEX_MAIL")
	public Double getHoSexMail() {
		return this.hoSexMail;
	}

	public void setHoSexMail(Double hoSexMail) {
		this.hoSexMail = hoSexMail;
	}


	@Column(name="HO_SORT")
	public Double getHoSort() {
		return this.hoSort;
	}

	public void setHoSort(Double hoSort) {
		this.hoSort = hoSort;
	}


	@Column(name="HO_SPECIAL_YN")
	public String getHoSpecialYn() {
		return this.hoSpecialYn;
	}

	public void setHoSpecialYn(String hoSpecialYn) {
		this.hoSpecialYn = hoSpecialYn;
	}


	@Column(name="HO_STATUS")
	public String getHoStatus() {
		return this.hoStatus;
	}

	public void setHoStatus(String hoStatus) {
		this.hoStatus = hoStatus;
	}


	@Column(name="HO_TOTAL_BED")
	public Double getHoTotalBed() {
		return this.hoTotalBed;
	}

	public void setHoTotalBed(Double hoTotalBed) {
		this.hoTotalBed = hoTotalBed;
	}


	@Column(name="HO_USED_BED")
	public Double getHoUsedBed() {
		return this.hoUsedBed;
	}

	public void setHoUsedBed(Double hoUsedBed) {
		this.hoUsedBed = hoUsedBed;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="INCU_YN")
	public String getIncuYn() {
		return this.incuYn;
	}

	public void setIncuYn(String incuYn) {
		this.incuYn = incuYn;
	}


	@Column(name="REPORT_TOTAL_BED")
	public Double getReportTotalBed() {
		return this.reportTotalBed;
	}

	public void setReportTotalBed(Double reportTotalBed) {
		this.reportTotalBed = reportTotalBed;
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


	public String getTeam() {
		return this.team;
	}

	public void setTeam(String team) {
		this.team = team;
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