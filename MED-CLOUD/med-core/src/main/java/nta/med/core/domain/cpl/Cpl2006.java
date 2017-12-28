package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL2006 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl2006.findAll", query="SELECT c FROM Cpl2006 c")
public class Cpl2006 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String brace1;
	private String brace10;
	private String brace11;
	private String brace12;
	private String brace2;
	private String brace3;
	private String brace4;
	private String brace5;
	private String brace6;
	private String brace7;
	private String brace8;
	private String brace9;
	private String calHangmogCode;
	private String hangmogCode1;
	private String hangmogCode2;
	private String hangmogCode3;
	private String hangmogCode4;
	private String hangmogCode5;
	private String hangmogCode6;
	private String hospCode;
	private String numYn1;
	private String numYn2;
	private String numYn3;
	private String numYn4;
	private String numYn5;
	private String numYn6;
	private String operation1;
	private String operation2;
	private String operation3;
	private String operation4;
	private String operation5;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl2006() {
	}


	public String getBrace1() {
		return this.brace1;
	}

	public void setBrace1(String brace1) {
		this.brace1 = brace1;
	}


	public String getBrace10() {
		return this.brace10;
	}

	public void setBrace10(String brace10) {
		this.brace10 = brace10;
	}


	public String getBrace11() {
		return this.brace11;
	}

	public void setBrace11(String brace11) {
		this.brace11 = brace11;
	}


	public String getBrace12() {
		return this.brace12;
	}

	public void setBrace12(String brace12) {
		this.brace12 = brace12;
	}


	public String getBrace2() {
		return this.brace2;
	}

	public void setBrace2(String brace2) {
		this.brace2 = brace2;
	}


	public String getBrace3() {
		return this.brace3;
	}

	public void setBrace3(String brace3) {
		this.brace3 = brace3;
	}


	public String getBrace4() {
		return this.brace4;
	}

	public void setBrace4(String brace4) {
		this.brace4 = brace4;
	}


	public String getBrace5() {
		return this.brace5;
	}

	public void setBrace5(String brace5) {
		this.brace5 = brace5;
	}


	public String getBrace6() {
		return this.brace6;
	}

	public void setBrace6(String brace6) {
		this.brace6 = brace6;
	}


	public String getBrace7() {
		return this.brace7;
	}

	public void setBrace7(String brace7) {
		this.brace7 = brace7;
	}


	public String getBrace8() {
		return this.brace8;
	}

	public void setBrace8(String brace8) {
		this.brace8 = brace8;
	}


	public String getBrace9() {
		return this.brace9;
	}

	public void setBrace9(String brace9) {
		this.brace9 = brace9;
	}


	@Column(name="CAL_HANGMOG_CODE")
	public String getCalHangmogCode() {
		return this.calHangmogCode;
	}

	public void setCalHangmogCode(String calHangmogCode) {
		this.calHangmogCode = calHangmogCode;
	}


	@Column(name="HANGMOG_CODE1")
	public String getHangmogCode1() {
		return this.hangmogCode1;
	}

	public void setHangmogCode1(String hangmogCode1) {
		this.hangmogCode1 = hangmogCode1;
	}


	@Column(name="HANGMOG_CODE2")
	public String getHangmogCode2() {
		return this.hangmogCode2;
	}

	public void setHangmogCode2(String hangmogCode2) {
		this.hangmogCode2 = hangmogCode2;
	}


	@Column(name="HANGMOG_CODE3")
	public String getHangmogCode3() {
		return this.hangmogCode3;
	}

	public void setHangmogCode3(String hangmogCode3) {
		this.hangmogCode3 = hangmogCode3;
	}


	@Column(name="HANGMOG_CODE4")
	public String getHangmogCode4() {
		return this.hangmogCode4;
	}

	public void setHangmogCode4(String hangmogCode4) {
		this.hangmogCode4 = hangmogCode4;
	}


	@Column(name="HANGMOG_CODE5")
	public String getHangmogCode5() {
		return this.hangmogCode5;
	}

	public void setHangmogCode5(String hangmogCode5) {
		this.hangmogCode5 = hangmogCode5;
	}


	@Column(name="HANGMOG_CODE6")
	public String getHangmogCode6() {
		return this.hangmogCode6;
	}

	public void setHangmogCode6(String hangmogCode6) {
		this.hangmogCode6 = hangmogCode6;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NUM_YN1")
	public String getNumYn1() {
		return this.numYn1;
	}

	public void setNumYn1(String numYn1) {
		this.numYn1 = numYn1;
	}


	@Column(name="NUM_YN2")
	public String getNumYn2() {
		return this.numYn2;
	}

	public void setNumYn2(String numYn2) {
		this.numYn2 = numYn2;
	}


	@Column(name="NUM_YN3")
	public String getNumYn3() {
		return this.numYn3;
	}

	public void setNumYn3(String numYn3) {
		this.numYn3 = numYn3;
	}


	@Column(name="NUM_YN4")
	public String getNumYn4() {
		return this.numYn4;
	}

	public void setNumYn4(String numYn4) {
		this.numYn4 = numYn4;
	}


	@Column(name="NUM_YN5")
	public String getNumYn5() {
		return this.numYn5;
	}

	public void setNumYn5(String numYn5) {
		this.numYn5 = numYn5;
	}


	@Column(name="NUM_YN6")
	public String getNumYn6() {
		return this.numYn6;
	}

	public void setNumYn6(String numYn6) {
		this.numYn6 = numYn6;
	}


	public String getOperation1() {
		return this.operation1;
	}

	public void setOperation1(String operation1) {
		this.operation1 = operation1;
	}


	public String getOperation2() {
		return this.operation2;
	}

	public void setOperation2(String operation2) {
		this.operation2 = operation2;
	}


	public String getOperation3() {
		return this.operation3;
	}

	public void setOperation3(String operation3) {
		this.operation3 = operation3;
	}


	public String getOperation4() {
		return this.operation4;
	}

	public void setOperation4(String operation4) {
		this.operation4 = operation4;
	}


	public String getOperation5() {
		return this.operation5;
	}

	public void setOperation5(String operation5) {
		this.operation5 = operation5;
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