package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC4002 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc4002.findAll", query="SELECT d FROM Doc4002 d")
public class Doc4002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String code1;
	private String code2;
	private String code3;
	private String code4;
	private String code5;
	private String code6;
	private String code7;
	private String code8;
	private String code9;
	private String cont1;
	private String cont2;
	private String cont3;
	private String cont4;
	private String cont5;
	private String cont6;
	private String cont7;
	private String cont8;
	private String cont9;
	private double fkdoc4001;
	private String hospCode;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc4002() {
	}


	public String getCode1() {
		return this.code1;
	}

	public void setCode1(String code1) {
		this.code1 = code1;
	}


	public String getCode2() {
		return this.code2;
	}

	public void setCode2(String code2) {
		this.code2 = code2;
	}


	public String getCode3() {
		return this.code3;
	}

	public void setCode3(String code3) {
		this.code3 = code3;
	}


	public String getCode4() {
		return this.code4;
	}

	public void setCode4(String code4) {
		this.code4 = code4;
	}


	public String getCode5() {
		return this.code5;
	}

	public void setCode5(String code5) {
		this.code5 = code5;
	}


	public String getCode6() {
		return this.code6;
	}

	public void setCode6(String code6) {
		this.code6 = code6;
	}


	public String getCode7() {
		return this.code7;
	}

	public void setCode7(String code7) {
		this.code7 = code7;
	}


	public String getCode8() {
		return this.code8;
	}

	public void setCode8(String code8) {
		this.code8 = code8;
	}


	public String getCode9() {
		return this.code9;
	}

	public void setCode9(String code9) {
		this.code9 = code9;
	}


	public String getCont1() {
		return this.cont1;
	}

	public void setCont1(String cont1) {
		this.cont1 = cont1;
	}


	public String getCont2() {
		return this.cont2;
	}

	public void setCont2(String cont2) {
		this.cont2 = cont2;
	}


	public String getCont3() {
		return this.cont3;
	}

	public void setCont3(String cont3) {
		this.cont3 = cont3;
	}


	public String getCont4() {
		return this.cont4;
	}

	public void setCont4(String cont4) {
		this.cont4 = cont4;
	}


	public String getCont5() {
		return this.cont5;
	}

	public void setCont5(String cont5) {
		this.cont5 = cont5;
	}


	public String getCont6() {
		return this.cont6;
	}

	public void setCont6(String cont6) {
		this.cont6 = cont6;
	}


	public String getCont7() {
		return this.cont7;
	}

	public void setCont7(String cont7) {
		this.cont7 = cont7;
	}


	public String getCont8() {
		return this.cont8;
	}

	public void setCont8(String cont8) {
		this.cont8 = cont8;
	}


	public String getCont9() {
		return this.cont9;
	}

	public void setCont9(String cont9) {
		this.cont9 = cont9;
	}


	public double getFkdoc4001() {
		return this.fkdoc4001;
	}

	public void setFkdoc4001(double fkdoc4001) {
		this.fkdoc4001 = fkdoc4001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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