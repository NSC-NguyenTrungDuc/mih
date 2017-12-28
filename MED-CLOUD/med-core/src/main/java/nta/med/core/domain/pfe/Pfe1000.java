package nta.med.core.domain.pfe;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the PFE1000 database table.
 * 
 */
@Entity
//@NamedQuery(name="Pfe1000.findAll", query="SELECT p FROM Pfe1000 p")
@Table(name= "PFE1000")
public class Pfe1000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String a1;
	private String a2;
	private String a3;
	private String a4;
	private String a5;
	private String a6;
	private String a7;
	private String a8;
	private String a9;
	private String bunho;
	private String c1;
	private String c2;
	private String c3;
	private String c4;
	private String c5;
	private String c6;
	private String c7;
	private String c8;
	private String c9;
	private Double fkocs;
	private String hangmogCode;
	private String hospCode;
	private Double pkpfe1000;
	private String residentYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Pfe1000() {
	}


	public String getA1() {
		return this.a1;
	}

	public void setA1(String a1) {
		this.a1 = a1;
	}


	public String getA2() {
		return this.a2;
	}

	public void setA2(String a2) {
		this.a2 = a2;
	}


	public String getA3() {
		return this.a3;
	}

	public void setA3(String a3) {
		this.a3 = a3;
	}


	public String getA4() {
		return this.a4;
	}

	public void setA4(String a4) {
		this.a4 = a4;
	}


	public String getA5() {
		return this.a5;
	}

	public void setA5(String a5) {
		this.a5 = a5;
	}


	public String getA6() {
		return this.a6;
	}

	public void setA6(String a6) {
		this.a6 = a6;
	}


	public String getA7() {
		return this.a7;
	}

	public void setA7(String a7) {
		this.a7 = a7;
	}


	public String getA8() {
		return this.a8;
	}

	public void setA8(String a8) {
		this.a8 = a8;
	}


	public String getA9() {
		return this.a9;
	}

	public void setA9(String a9) {
		this.a9 = a9;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getC1() {
		return this.c1;
	}

	public void setC1(String c1) {
		this.c1 = c1;
	}


	public String getC2() {
		return this.c2;
	}

	public void setC2(String c2) {
		this.c2 = c2;
	}


	public String getC3() {
		return this.c3;
	}

	public void setC3(String c3) {
		this.c3 = c3;
	}


	public String getC4() {
		return this.c4;
	}

	public void setC4(String c4) {
		this.c4 = c4;
	}


	public String getC5() {
		return this.c5;
	}

	public void setC5(String c5) {
		this.c5 = c5;
	}


	public String getC6() {
		return this.c6;
	}

	public void setC6(String c6) {
		this.c6 = c6;
	}


	public String getC7() {
		return this.c7;
	}

	public void setC7(String c7) {
		this.c7 = c7;
	}


	public String getC8() {
		return this.c8;
	}

	public void setC8(String c8) {
		this.c8 = c8;
	}


	public String getC9() {
		return this.c9;
	}

	public void setC9(String c9) {
		this.c9 = c9;
	}


	public Double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(Double fkocs) {
		this.fkocs = fkocs;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public Double getPkpfe1000() {
		return this.pkpfe1000;
	}

	public void setPkpfe1000(Double pkpfe1000) {
		this.pkpfe1000 = pkpfe1000;
	}


	@Column(name="RESIDENT_YN")
	public String getResidentYn() {
		return this.residentYn;
	}

	public void setResidentYn(String residentYn) {
		this.residentYn = residentYn;
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