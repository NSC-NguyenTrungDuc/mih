package nta.med.core.domain.bas;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the BAS0100 database table.
 * 
 */
@Entity
@NamedQuery(name="Bas0100.findAll", query="SELECT b FROM Bas0100 b")
public class Bas0100 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String comments;
	private Date endDate;
	private String gubun;
	private String hospCode;
	private String jinryoGubun1;
	private String jinryoGubun2;
	private String jinryoGubun3;
	private String jukyongGubun;
	private String sgCodeInp;
	private String sgCodeOut;
	private String siseolCode;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String useYn;

	public Bas0100() {
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JINRYO_GUBUN1")
	public String getJinryoGubun1() {
		return this.jinryoGubun1;
	}

	public void setJinryoGubun1(String jinryoGubun1) {
		this.jinryoGubun1 = jinryoGubun1;
	}


	@Column(name="JINRYO_GUBUN2")
	public String getJinryoGubun2() {
		return this.jinryoGubun2;
	}

	public void setJinryoGubun2(String jinryoGubun2) {
		this.jinryoGubun2 = jinryoGubun2;
	}


	@Column(name="JINRYO_GUBUN3")
	public String getJinryoGubun3() {
		return this.jinryoGubun3;
	}

	public void setJinryoGubun3(String jinryoGubun3) {
		this.jinryoGubun3 = jinryoGubun3;
	}


	@Column(name="JUKYONG_GUBUN")
	public String getJukyongGubun() {
		return this.jukyongGubun;
	}

	public void setJukyongGubun(String jukyongGubun) {
		this.jukyongGubun = jukyongGubun;
	}


	@Column(name="SG_CODE_INP")
	public String getSgCodeInp() {
		return this.sgCodeInp;
	}

	public void setSgCodeInp(String sgCodeInp) {
		this.sgCodeInp = sgCodeInp;
	}


	@Column(name="SG_CODE_OUT")
	public String getSgCodeOut() {
		return this.sgCodeOut;
	}

	public void setSgCodeOut(String sgCodeOut) {
		this.sgCodeOut = sgCodeOut;
	}


	@Column(name="SISEOL_CODE")
	public String getSiseolCode() {
		return this.siseolCode;
	}

	public void setSiseolCode(String siseolCode) {
		this.siseolCode = siseolCode;
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


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}

}