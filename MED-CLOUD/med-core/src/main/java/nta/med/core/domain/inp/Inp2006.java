package nta.med.core.domain.inp;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the INP2006 database table.
 * 
 */
@Entity
@NamedQuery(name="Inp2006.findAll", query="SELECT i FROM Inp2006 i")
public class Inp2006 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String doctor;
	private double fkinp1001;
	private String fkinp1002;
	private String gubun;
	private String gwa;
	private String hoCode1;
	private String hoCode2;
	private String hoGrade1;
	private String hoGrade2;
	private String hoStatus1;
	private String hoStatus2;
	private String hospCode;
	private String incu;
	private Date orderDate;
	private String specialYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Inp2006() {
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getFkinp1002() {
		return this.fkinp1002;
	}

	public void setFkinp1002(String fkinp1002) {
		this.fkinp1002 = fkinp1002;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HO_CODE1")
	public String getHoCode1() {
		return this.hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}


	@Column(name="HO_CODE2")
	public String getHoCode2() {
		return this.hoCode2;
	}

	public void setHoCode2(String hoCode2) {
		this.hoCode2 = hoCode2;
	}


	@Column(name="HO_GRADE1")
	public String getHoGrade1() {
		return this.hoGrade1;
	}

	public void setHoGrade1(String hoGrade1) {
		this.hoGrade1 = hoGrade1;
	}


	@Column(name="HO_GRADE2")
	public String getHoGrade2() {
		return this.hoGrade2;
	}

	public void setHoGrade2(String hoGrade2) {
		this.hoGrade2 = hoGrade2;
	}


	@Column(name="HO_STATUS1")
	public String getHoStatus1() {
		return this.hoStatus1;
	}

	public void setHoStatus1(String hoStatus1) {
		this.hoStatus1 = hoStatus1;
	}


	@Column(name="HO_STATUS2")
	public String getHoStatus2() {
		return this.hoStatus2;
	}

	public void setHoStatus2(String hoStatus2) {
		this.hoStatus2 = hoStatus2;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getIncu() {
		return this.incu;
	}

	public void setIncu(String incu) {
		this.incu = incu;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	@Column(name="SPECIAL_YN")
	public String getSpecialYn() {
		return this.specialYn;
	}

	public void setSpecialYn(String specialYn) {
		this.specialYn = specialYn;
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