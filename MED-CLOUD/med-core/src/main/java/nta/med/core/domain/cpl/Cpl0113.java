package nta.med.core.domain.cpl;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the CPL0113 database table.
 * 
 */
@Entity
@NamedQuery(name="Cpl0113.findAll", query="SELECT c FROM Cpl0113 c")
public class Cpl0113 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date addDate;
	private String buyAmt;
	private Date buyDate;
	private String buyType;
	private String cCompanyCode;
	private String gyukyuk;
	private String hospCode;
	private String jangbiCode;
	private String jangbiName;
	private String jangbiNameRe;
	private String jundalGubun;
	private String mCompanyCode;
	private Date makeDate;
	private String manageNo;
	private String manyYn;
	private String sCompanyCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Cpl0113() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ADD_DATE")
	public Date getAddDate() {
		return this.addDate;
	}

	public void setAddDate(Date addDate) {
		this.addDate = addDate;
	}


	@Column(name="BUY_AMT")
	public String getBuyAmt() {
		return this.buyAmt;
	}

	public void setBuyAmt(String buyAmt) {
		this.buyAmt = buyAmt;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BUY_DATE")
	public Date getBuyDate() {
		return this.buyDate;
	}

	public void setBuyDate(Date buyDate) {
		this.buyDate = buyDate;
	}


	@Column(name="BUY_TYPE")
	public String getBuyType() {
		return this.buyType;
	}

	public void setBuyType(String buyType) {
		this.buyType = buyType;
	}


	@Column(name="C_COMPANY_CODE")
	public String getCCompanyCode() {
		return this.cCompanyCode;
	}

	public void setCCompanyCode(String cCompanyCode) {
		this.cCompanyCode = cCompanyCode;
	}


	public String getGyukyuk() {
		return this.gyukyuk;
	}

	public void setGyukyuk(String gyukyuk) {
		this.gyukyuk = gyukyuk;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JANGBI_CODE")
	public String getJangbiCode() {
		return this.jangbiCode;
	}

	public void setJangbiCode(String jangbiCode) {
		this.jangbiCode = jangbiCode;
	}


	@Column(name="JANGBI_NAME")
	public String getJangbiName() {
		return this.jangbiName;
	}

	public void setJangbiName(String jangbiName) {
		this.jangbiName = jangbiName;
	}


	@Column(name="JANGBI_NAME_RE")
	public String getJangbiNameRe() {
		return this.jangbiNameRe;
	}

	public void setJangbiNameRe(String jangbiNameRe) {
		this.jangbiNameRe = jangbiNameRe;
	}


	@Column(name="JUNDAL_GUBUN")
	public String getJundalGubun() {
		return this.jundalGubun;
	}

	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}


	@Column(name="M_COMPANY_CODE")
	public String getMCompanyCode() {
		return this.mCompanyCode;
	}

	public void setMCompanyCode(String mCompanyCode) {
		this.mCompanyCode = mCompanyCode;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAKE_DATE")
	public Date getMakeDate() {
		return this.makeDate;
	}

	public void setMakeDate(Date makeDate) {
		this.makeDate = makeDate;
	}


	@Column(name="MANAGE_NO")
	public String getManageNo() {
		return this.manageNo;
	}

	public void setManageNo(String manageNo) {
		this.manageNo = manageNo;
	}


	@Column(name="MANY_YN")
	public String getManyYn() {
		return this.manyYn;
	}

	public void setManyYn(String manyYn) {
		this.manyYn = manyYn;
	}


	@Column(name="S_COMPANY_CODE")
	public String getSCompanyCode() {
		return this.sCompanyCode;
	}

	public void setSCompanyCode(String sCompanyCode) {
		this.sCompanyCode = sCompanyCode;
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