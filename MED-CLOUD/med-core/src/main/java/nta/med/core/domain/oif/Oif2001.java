package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF2001 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif2001.findAll", query="SELECT o FROM Oif2001 o")
public class Oif2001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String clientGroup;
	private String clientNum;
	private String cmId;
	private String depId;
	private String docUid;
	private Date endDate;
	private String endFlag;
	private String errMsg;
	private String familyCode;
	private double fkoif1001;
	private String hospCode;
	private double inratio;
	private String insurCode;
	private String insurName;
	private String insurNum;
	private String insuredId;
	private String insuredName;
	private String license;
	private double outratio;
	private double pkoif2001;
	private Date sendDate;
	private Date startDate;
	private String suname1;
	private String suname2;
	private String suname3;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String workId;
	private String workName;

	public Oif2001() {
	}


	@Column(name="CLIENT_GROUP")
	public String getClientGroup() {
		return this.clientGroup;
	}

	public void setClientGroup(String clientGroup) {
		this.clientGroup = clientGroup;
	}


	@Column(name="CLIENT_NUM")
	public String getClientNum() {
		return this.clientNum;
	}

	public void setClientNum(String clientNum) {
		this.clientNum = clientNum;
	}


	@Column(name="CM_ID")
	public String getCmId() {
		return this.cmId;
	}

	public void setCmId(String cmId) {
		this.cmId = cmId;
	}


	@Column(name="DEP_ID")
	public String getDepId() {
		return this.depId;
	}

	public void setDepId(String depId) {
		this.depId = depId;
	}


	@Column(name="DOC_UID")
	public String getDocUid() {
		return this.docUid;
	}

	public void setDocUid(String docUid) {
		this.docUid = docUid;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	@Column(name="END_FLAG")
	public String getEndFlag() {
		return this.endFlag;
	}

	public void setEndFlag(String endFlag) {
		this.endFlag = endFlag;
	}


	@Column(name="ERR_MSG")
	public String getErrMsg() {
		return this.errMsg;
	}

	public void setErrMsg(String errMsg) {
		this.errMsg = errMsg;
	}


	@Column(name="FAMILY_CODE")
	public String getFamilyCode() {
		return this.familyCode;
	}

	public void setFamilyCode(String familyCode) {
		this.familyCode = familyCode;
	}


	public double getFkoif1001() {
		return this.fkoif1001;
	}

	public void setFkoif1001(double fkoif1001) {
		this.fkoif1001 = fkoif1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getInratio() {
		return this.inratio;
	}

	public void setInratio(double inratio) {
		this.inratio = inratio;
	}


	@Column(name="INSUR_CODE")
	public String getInsurCode() {
		return this.insurCode;
	}

	public void setInsurCode(String insurCode) {
		this.insurCode = insurCode;
	}


	@Column(name="INSUR_NAME")
	public String getInsurName() {
		return this.insurName;
	}

	public void setInsurName(String insurName) {
		this.insurName = insurName;
	}


	@Column(name="INSUR_NUM")
	public String getInsurNum() {
		return this.insurNum;
	}

	public void setInsurNum(String insurNum) {
		this.insurNum = insurNum;
	}


	@Column(name="INSURED_ID")
	public String getInsuredId() {
		return this.insuredId;
	}

	public void setInsuredId(String insuredId) {
		this.insuredId = insuredId;
	}


	@Column(name="INSURED_NAME")
	public String getInsuredName() {
		return this.insuredName;
	}

	public void setInsuredName(String insuredName) {
		this.insuredName = insuredName;
	}


	public String getLicense() {
		return this.license;
	}

	public void setLicense(String license) {
		this.license = license;
	}


	public double getOutratio() {
		return this.outratio;
	}

	public void setOutratio(double outratio) {
		this.outratio = outratio;
	}


	public double getPkoif2001() {
		return this.pkoif2001;
	}

	public void setPkoif2001(double pkoif2001) {
		this.pkoif2001 = pkoif2001;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SEND_DATE")
	public Date getSendDate() {
		return this.sendDate;
	}

	public void setSendDate(Date sendDate) {
		this.sendDate = sendDate;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}


	public String getSuname1() {
		return this.suname1;
	}

	public void setSuname1(String suname1) {
		this.suname1 = suname1;
	}


	public String getSuname2() {
		return this.suname2;
	}

	public void setSuname2(String suname2) {
		this.suname2 = suname2;
	}


	public String getSuname3() {
		return this.suname3;
	}

	public void setSuname3(String suname3) {
		this.suname3 = suname3;
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


	@Column(name="WORK_ID")
	public String getWorkId() {
		return this.workId;
	}

	public void setWorkId(String workId) {
		this.workId = workId;
	}


	@Column(name="WORK_NAME")
	public String getWorkName() {
		return this.workName;
	}

	public void setWorkName(String workName) {
		this.workName = workName;
	}

}