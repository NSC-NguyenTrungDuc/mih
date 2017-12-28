package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG9992 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg9992.findAll", query="SELECT d FROM Drg9992 d")
public class Drg9992 extends BaseEntity {
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
	private String a20;
	private String a21;
	private String a22;
	private String a23;
	private String a24;
	private String a25;
	private String a26;
	private String a27;
	private String a28;
	private String a29;
	private String a3;
	private String a30;
	private String a31;
	private String a32;
	private String a33;
	private String a34;
	private String a4;
	private String a5;
	private String a6;
	private String a7;
	private String a8;
	private String a9;
	private Date confirmDate;
	private String confirmId;
	private String grouping;
	private Date inputDate;
	private String useYn;

	public Drg9992() {
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


	public String getA20() {
		return this.a20;
	}

	public void setA20(String a20) {
		this.a20 = a20;
	}


	public String getA21() {
		return this.a21;
	}

	public void setA21(String a21) {
		this.a21 = a21;
	}


	public String getA22() {
		return this.a22;
	}

	public void setA22(String a22) {
		this.a22 = a22;
	}


	public String getA23() {
		return this.a23;
	}

	public void setA23(String a23) {
		this.a23 = a23;
	}


	public String getA24() {
		return this.a24;
	}

	public void setA24(String a24) {
		this.a24 = a24;
	}


	public String getA25() {
		return this.a25;
	}

	public void setA25(String a25) {
		this.a25 = a25;
	}


	public String getA26() {
		return this.a26;
	}

	public void setA26(String a26) {
		this.a26 = a26;
	}


	public String getA27() {
		return this.a27;
	}

	public void setA27(String a27) {
		this.a27 = a27;
	}


	public String getA28() {
		return this.a28;
	}

	public void setA28(String a28) {
		this.a28 = a28;
	}


	public String getA29() {
		return this.a29;
	}

	public void setA29(String a29) {
		this.a29 = a29;
	}


	public String getA3() {
		return this.a3;
	}

	public void setA3(String a3) {
		this.a3 = a3;
	}


	public String getA30() {
		return this.a30;
	}

	public void setA30(String a30) {
		this.a30 = a30;
	}


	public String getA31() {
		return this.a31;
	}

	public void setA31(String a31) {
		this.a31 = a31;
	}


	public String getA32() {
		return this.a32;
	}

	public void setA32(String a32) {
		this.a32 = a32;
	}


	public String getA33() {
		return this.a33;
	}

	public void setA33(String a33) {
		this.a33 = a33;
	}


	public String getA34() {
		return this.a34;
	}

	public void setA34(String a34) {
		this.a34 = a34;
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


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CONFIRM_DATE")
	public Date getConfirmDate() {
		return this.confirmDate;
	}

	public void setConfirmDate(Date confirmDate) {
		this.confirmDate = confirmDate;
	}


	@Column(name="CONFIRM_ID")
	public String getConfirmId() {
		return this.confirmId;
	}

	public void setConfirmId(String confirmId) {
		this.confirmId = confirmId;
	}


	public String getGrouping() {
		return this.grouping;
	}

	public void setGrouping(String grouping) {
		this.grouping = grouping;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="INPUT_DATE")
	public Date getInputDate() {
		return this.inputDate;
	}

	public void setInputDate(Date inputDate) {
		this.inputDate = inputDate;
	}


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}

}