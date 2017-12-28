package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7204 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs7204.findAll", query="SELECT i FROM Ifs7204 i")
@Table(name="IFS7204")
public class Ifs7204 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String danui;
	private String emergency;
	private Double fkifs7203;
	private String fromStandard;
	private String hangmogCode;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String iraiKey;
	private double pkifs7204;
	private String recordGubun;
	private String resultCode;
	private String resultVal;
	private String sentaCode;
	private String specimenSer;
	private Date sysDate;
	private String sysId;
	private String toStandard;
	private Date updDate;
	private String updId;
	private String yobi1;

	public Ifs7204() {
	}


	public String getDanui() {
		return this.danui;
	}

	public void setDanui(String danui) {
		this.danui = danui;
	}


	public String getEmergency() {
		return this.emergency;
	}

	public void setEmergency(String emergency) {
		this.emergency = emergency;
	}


	public Double getFkifs7203() {
		return this.fkifs7203;
	}

	public void setFkifs7203(Double fkifs7203) {
		this.fkifs7203 = fkifs7203;
	}


	@Column(name="FROM_STANDARD")
	public String getFromStandard() {
		return this.fromStandard;
	}

	public void setFromStandard(String fromStandard) {
		this.fromStandard = fromStandard;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
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


	@Column(name="IRAI_KEY")
	public String getIraiKey() {
		return this.iraiKey;
	}

	public void setIraiKey(String iraiKey) {
		this.iraiKey = iraiKey;
	}


	public double getPkifs7204() {
		return this.pkifs7204;
	}

	public void setPkifs7204(double pkifs7204) {
		this.pkifs7204 = pkifs7204;
	}


	@Column(name="RECORD_GUBUN")
	public String getRecordGubun() {
		return this.recordGubun;
	}

	public void setRecordGubun(String recordGubun) {
		this.recordGubun = recordGubun;
	}


	@Column(name="RESULT_CODE")
	public String getResultCode() {
		return this.resultCode;
	}

	public void setResultCode(String resultCode) {
		this.resultCode = resultCode;
	}


	@Column(name="RESULT_VAL")
	public String getResultVal() {
		return this.resultVal;
	}

	public void setResultVal(String resultVal) {
		this.resultVal = resultVal;
	}


	@Column(name="SENTA_CODE")
	public String getSentaCode() {
		return this.sentaCode;
	}

	public void setSentaCode(String sentaCode) {
		this.sentaCode = sentaCode;
	}


	@Column(name="SPECIMEN_SER")
	public String getSpecimenSer() {
		return this.specimenSer;
	}

	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
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


	@Column(name="TO_STANDARD")
	public String getToStandard() {
		return this.toStandard;
	}

	public void setToStandard(String toStandard) {
		this.toStandard = toStandard;
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


	public String getYobi1() {
		return this.yobi1;
	}

	public void setYobi1(String yobi1) {
		this.yobi1 = yobi1;
	}

}