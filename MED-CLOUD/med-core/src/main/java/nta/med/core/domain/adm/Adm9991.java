package nta.med.core.domain.adm;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the ADM9991 database table.
 * 
 */
@Entity
@Table(name="ADM9991")
public class Adm9991 extends BaseEntity implements AdmInterface {
	private static final long serialVersionUID = 1L;
	private String a1;
	private String a10;
	private String a11;
	private String a12;
	private String a13;
	private String a14;
	private String a15;
	private String a16;
	private String a17;
	private String a18;
	private String a19;
	private String a2;
	private String a3;
	private String a4;
	private String a5;
	private String a6;
	private String a7;
	private String a8;
	private String a9;
	private String grouping;
	private Date sysDate;
	private String sysId;
	private String useYn;

	public Adm9991() {
	}


	public String getA1() {
		return this.a1;
	}

	public void setA1(String a1) {
		this.a1 = a1;
	}


	public String getA10() {
		return this.a10;
	}

	public void setA10(String a10) {
		this.a10 = a10;
	}


	public String getA11() {
		return this.a11;
	}

	public void setA11(String a11) {
		this.a11 = a11;
	}


	public String getA12() {
		return this.a12;
	}

	public void setA12(String a12) {
		this.a12 = a12;
	}


	public String getA13() {
		return this.a13;
	}

	public void setA13(String a13) {
		this.a13 = a13;
	}


	public String getA14() {
		return this.a14;
	}

	public void setA14(String a14) {
		this.a14 = a14;
	}


	public String getA15() {
		return this.a15;
	}

	public void setA15(String a15) {
		this.a15 = a15;
	}


	public String getA16() {
		return this.a16;
	}

	public void setA16(String a16) {
		this.a16 = a16;
	}


	public String getA17() {
		return this.a17;
	}

	public void setA17(String a17) {
		this.a17 = a17;
	}


	public String getA18() {
		return this.a18;
	}

	public void setA18(String a18) {
		this.a18 = a18;
	}


	public String getA19() {
		return this.a19;
	}

	public void setA19(String a19) {
		this.a19 = a19;
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


	public String getGrouping() {
		return this.grouping;
	}

	public void setGrouping(String grouping) {
		this.grouping = grouping;
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


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}

}