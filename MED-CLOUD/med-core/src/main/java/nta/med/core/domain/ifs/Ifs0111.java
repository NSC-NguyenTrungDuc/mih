package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS0111 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs0111.findAll", query="SELECT i FROM Ifs0111 i")
public class Ifs0111 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bonGubun;
	private String bunho;
	private String continueGubun;
	private double fkifs0101;
	private String gaein;
	private String giho;
	private String gubun;
	private String gubunEndDate;
	private String gubunGubun;
	private String gubunName;
	private String gubunName2;
	private String gubunRateIn;
	private String gubunRateOut;
	private String gubunStartDate;
	private String handoCodeIn;
	private String handoGubunIn;
	private String handoGubunOut;
	private String hangoCodeOut;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String jeosodeukFlag;
	private String johap;
	private String remark1;
	private String remark2;
	private String remark3;
	private double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String wiimjibulFlag;

	public Ifs0111() {
	}


	@Column(name="BON_GUBUN")
	public String getBonGubun() {
		return this.bonGubun;
	}

	public void setBonGubun(String bonGubun) {
		this.bonGubun = bonGubun;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CONTINUE_GUBUN")
	public String getContinueGubun() {
		return this.continueGubun;
	}

	public void setContinueGubun(String continueGubun) {
		this.continueGubun = continueGubun;
	}


	public double getFkifs0101() {
		return this.fkifs0101;
	}

	public void setFkifs0101(double fkifs0101) {
		this.fkifs0101 = fkifs0101;
	}


	public String getGaein() {
		return this.gaein;
	}

	public void setGaein(String gaein) {
		this.gaein = gaein;
	}


	public String getGiho() {
		return this.giho;
	}

	public void setGiho(String giho) {
		this.giho = giho;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="GUBUN_END_DATE")
	public String getGubunEndDate() {
		return this.gubunEndDate;
	}

	public void setGubunEndDate(String gubunEndDate) {
		this.gubunEndDate = gubunEndDate;
	}


	@Column(name="GUBUN_GUBUN")
	public String getGubunGubun() {
		return this.gubunGubun;
	}

	public void setGubunGubun(String gubunGubun) {
		this.gubunGubun = gubunGubun;
	}


	@Column(name="GUBUN_NAME")
	public String getGubunName() {
		return this.gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}


	@Column(name="GUBUN_NAME2")
	public String getGubunName2() {
		return this.gubunName2;
	}

	public void setGubunName2(String gubunName2) {
		this.gubunName2 = gubunName2;
	}


	@Column(name="GUBUN_RATE_IN")
	public String getGubunRateIn() {
		return this.gubunRateIn;
	}

	public void setGubunRateIn(String gubunRateIn) {
		this.gubunRateIn = gubunRateIn;
	}


	@Column(name="GUBUN_RATE_OUT")
	public String getGubunRateOut() {
		return this.gubunRateOut;
	}

	public void setGubunRateOut(String gubunRateOut) {
		this.gubunRateOut = gubunRateOut;
	}


	@Column(name="GUBUN_START_DATE")
	public String getGubunStartDate() {
		return this.gubunStartDate;
	}

	public void setGubunStartDate(String gubunStartDate) {
		this.gubunStartDate = gubunStartDate;
	}


	@Column(name="HANDO_CODE_IN")
	public String getHandoCodeIn() {
		return this.handoCodeIn;
	}

	public void setHandoCodeIn(String handoCodeIn) {
		this.handoCodeIn = handoCodeIn;
	}


	@Column(name="HANDO_GUBUN_IN")
	public String getHandoGubunIn() {
		return this.handoGubunIn;
	}

	public void setHandoGubunIn(String handoGubunIn) {
		this.handoGubunIn = handoGubunIn;
	}


	@Column(name="HANDO_GUBUN_OUT")
	public String getHandoGubunOut() {
		return this.handoGubunOut;
	}

	public void setHandoGubunOut(String handoGubunOut) {
		this.handoGubunOut = handoGubunOut;
	}


	@Column(name="HANGO_CODE_OUT")
	public String getHangoCodeOut() {
		return this.hangoCodeOut;
	}

	public void setHangoCodeOut(String hangoCodeOut) {
		this.hangoCodeOut = hangoCodeOut;
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


	@Column(name="JEOSODEUK_FLAG")
	public String getJeosodeukFlag() {
		return this.jeosodeukFlag;
	}

	public void setJeosodeukFlag(String jeosodeukFlag) {
		this.jeosodeukFlag = jeosodeukFlag;
	}


	public String getJohap() {
		return this.johap;
	}

	public void setJohap(String johap) {
		this.johap = johap;
	}


	public String getRemark1() {
		return this.remark1;
	}

	public void setRemark1(String remark1) {
		this.remark1 = remark1;
	}


	public String getRemark2() {
		return this.remark2;
	}

	public void setRemark2(String remark2) {
		this.remark2 = remark2;
	}


	public String getRemark3() {
		return this.remark3;
	}

	public void setRemark3(String remark3) {
		this.remark3 = remark3;
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


	@Column(name="WIIMJIBUL_FLAG")
	public String getWiimjibulFlag() {
		return this.wiimjibulFlag;
	}

	public void setWiimjibulFlag(String wiimjibulFlag) {
		this.wiimjibulFlag = wiimjibulFlag;
	}

}