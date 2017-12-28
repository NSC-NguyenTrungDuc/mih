package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1030 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1030.findAll", query="SELECT n FROM Nur1030 n")
public class Nur1030 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private Date endDate;
	private String hospCode;
	private String nurComment;
	private String nurData01;
	private String nurData02;
	private String nurData03;
	private String nurData04;
	private String nurData05;
	private String nurData06;
	private String nurData07;
	private String nurData08;
	private String nurData09;
	private String nurData10;
	private String nurData11;
	private String nurData12;
	private String nurData13;
	private String nurData14;
	private String nurData15;
	private String nurGrGubun;
	private String nurMdGubun;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur1030() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="NUR_COMMENT")
	public String getNurComment() {
		return this.nurComment;
	}

	public void setNurComment(String nurComment) {
		this.nurComment = nurComment;
	}


	@Column(name="NUR_DATA01")
	public String getNurData01() {
		return this.nurData01;
	}

	public void setNurData01(String nurData01) {
		this.nurData01 = nurData01;
	}


	@Column(name="NUR_DATA02")
	public String getNurData02() {
		return this.nurData02;
	}

	public void setNurData02(String nurData02) {
		this.nurData02 = nurData02;
	}


	@Column(name="NUR_DATA03")
	public String getNurData03() {
		return this.nurData03;
	}

	public void setNurData03(String nurData03) {
		this.nurData03 = nurData03;
	}


	@Column(name="NUR_DATA04")
	public String getNurData04() {
		return this.nurData04;
	}

	public void setNurData04(String nurData04) {
		this.nurData04 = nurData04;
	}


	@Column(name="NUR_DATA05")
	public String getNurData05() {
		return this.nurData05;
	}

	public void setNurData05(String nurData05) {
		this.nurData05 = nurData05;
	}


	@Column(name="NUR_DATA06")
	public String getNurData06() {
		return this.nurData06;
	}

	public void setNurData06(String nurData06) {
		this.nurData06 = nurData06;
	}


	@Column(name="NUR_DATA07")
	public String getNurData07() {
		return this.nurData07;
	}

	public void setNurData07(String nurData07) {
		this.nurData07 = nurData07;
	}


	@Column(name="NUR_DATA08")
	public String getNurData08() {
		return this.nurData08;
	}

	public void setNurData08(String nurData08) {
		this.nurData08 = nurData08;
	}


	@Column(name="NUR_DATA09")
	public String getNurData09() {
		return this.nurData09;
	}

	public void setNurData09(String nurData09) {
		this.nurData09 = nurData09;
	}


	@Column(name="NUR_DATA10")
	public String getNurData10() {
		return this.nurData10;
	}

	public void setNurData10(String nurData10) {
		this.nurData10 = nurData10;
	}


	@Column(name="NUR_DATA11")
	public String getNurData11() {
		return this.nurData11;
	}

	public void setNurData11(String nurData11) {
		this.nurData11 = nurData11;
	}


	@Column(name="NUR_DATA12")
	public String getNurData12() {
		return this.nurData12;
	}

	public void setNurData12(String nurData12) {
		this.nurData12 = nurData12;
	}


	@Column(name="NUR_DATA13")
	public String getNurData13() {
		return this.nurData13;
	}

	public void setNurData13(String nurData13) {
		this.nurData13 = nurData13;
	}


	@Column(name="NUR_DATA14")
	public String getNurData14() {
		return this.nurData14;
	}

	public void setNurData14(String nurData14) {
		this.nurData14 = nurData14;
	}


	@Column(name="NUR_DATA15")
	public String getNurData15() {
		return this.nurData15;
	}

	public void setNurData15(String nurData15) {
		this.nurData15 = nurData15;
	}


	@Column(name="NUR_GR_GUBUN")
	public String getNurGrGubun() {
		return this.nurGrGubun;
	}

	public void setNurGrGubun(String nurGrGubun) {
		this.nurGrGubun = nurGrGubun;
	}


	@Column(name="NUR_MD_GUBUN")
	public String getNurMdGubun() {
		return this.nurMdGubun;
	}

	public void setNurMdGubun(String nurMdGubun) {
		this.nurMdGubun = nurMdGubun;
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