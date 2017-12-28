package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS0101 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs0101.findAll", query="SELECT i FROM Ifs0101 i")
public class Ifs0101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String addressCnt;
	private String birth;
	private String bunho;
	private String gubunCnt;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private double pkifs0101;
	private String procGubun;
	private String procGubunSub;
	private String remark;
	private String sex;
	private String suname11;
	private String suname12;
	private String suname13;
	private String suname21;
	private String suname22;
	private String suname23;
	private String suname31;
	private String suname32;
	private String suname33;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Ifs0101() {
	}


	@Column(name="ADDRESS_CNT")
	public String getAddressCnt() {
		return this.addressCnt;
	}

	public void setAddressCnt(String addressCnt) {
		this.addressCnt = addressCnt;
	}


	public String getBirth() {
		return this.birth;
	}

	public void setBirth(String birth) {
		this.birth = birth;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="GUBUN_CNT")
	public String getGubunCnt() {
		return this.gubunCnt;
	}

	public void setGubunCnt(String gubunCnt) {
		this.gubunCnt = gubunCnt;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	public double getPkifs0101() {
		return this.pkifs0101;
	}

	public void setPkifs0101(double pkifs0101) {
		this.pkifs0101 = pkifs0101;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	@Column(name="PROC_GUBUN_SUB")
	public String getProcGubunSub() {
		return this.procGubunSub;
	}

	public void setProcGubunSub(String procGubunSub) {
		this.procGubunSub = procGubunSub;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}


	public String getSuname11() {
		return this.suname11;
	}

	public void setSuname11(String suname11) {
		this.suname11 = suname11;
	}


	public String getSuname12() {
		return this.suname12;
	}

	public void setSuname12(String suname12) {
		this.suname12 = suname12;
	}


	public String getSuname13() {
		return this.suname13;
	}

	public void setSuname13(String suname13) {
		this.suname13 = suname13;
	}


	public String getSuname21() {
		return this.suname21;
	}

	public void setSuname21(String suname21) {
		this.suname21 = suname21;
	}


	public String getSuname22() {
		return this.suname22;
	}

	public void setSuname22(String suname22) {
		this.suname22 = suname22;
	}


	public String getSuname23() {
		return this.suname23;
	}

	public void setSuname23(String suname23) {
		this.suname23 = suname23;
	}


	public String getSuname31() {
		return this.suname31;
	}

	public void setSuname31(String suname31) {
		this.suname31 = suname31;
	}


	public String getSuname32() {
		return this.suname32;
	}

	public void setSuname32(String suname32) {
		this.suname32 = suname32;
	}


	public String getSuname33() {
		return this.suname33;
	}

	public void setSuname33(String suname33) {
		this.suname33 = suname33;
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