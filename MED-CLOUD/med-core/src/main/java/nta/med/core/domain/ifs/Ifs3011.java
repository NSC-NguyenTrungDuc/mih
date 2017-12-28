package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS3011 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs3011.findAll", query="SELECT i FROM Ifs3011 i")
public class Ifs3011 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bedNo;
	private String bunho;
	private String dataDate;
	private String dataGubun;
	private String dataKey;
	private String dataTime;
	private String doctor;
	private double fkinp1001;
	private String gwa;
	private String hoCode;
	private String hoDong;
	private String hoGubun;
	private String hospCode;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifHospCode;
	private String ifTime;
	private double inp2004TransCnt;
	private double pkifs3011;
	private String procDate;
	private String procGubun;
	private String procGubun2;
	private String procTime;
	private String remark;
	private Date sysDate;
	private String sysId;
	private String timeGubun;
	private String toiwonGubun;
	private Date updDate;
	private String updId;

	public Ifs3011() {
	}


	@Column(name="BED_NO")
	public String getBedNo() {
		return this.bedNo;
	}

	public void setBedNo(String bedNo) {
		this.bedNo = bedNo;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="DATA_DATE")
	public String getDataDate() {
		return this.dataDate;
	}

	public void setDataDate(String dataDate) {
		this.dataDate = dataDate;
	}


	@Column(name="DATA_GUBUN")
	public String getDataGubun() {
		return this.dataGubun;
	}

	public void setDataGubun(String dataGubun) {
		this.dataGubun = dataGubun;
	}


	@Column(name="DATA_KEY")
	public String getDataKey() {
		return this.dataKey;
	}

	public void setDataKey(String dataKey) {
		this.dataKey = dataKey;
	}


	@Column(name="DATA_TIME")
	public String getDataTime() {
		return this.dataTime;
	}

	public void setDataTime(String dataTime) {
		this.dataTime = dataTime;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HO_GUBUN")
	public String getHoGubun() {
		return this.hoGubun;
	}

	public void setHoGubun(String hoGubun) {
		this.hoGubun = hoGubun;
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


	@Column(name="IF_HOSP_CODE")
	public String getIfHospCode() {
		return this.ifHospCode;
	}

	public void setIfHospCode(String ifHospCode) {
		this.ifHospCode = ifHospCode;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="INP2004_TRANS_CNT")
	public double getInp2004TransCnt() {
		return this.inp2004TransCnt;
	}

	public void setInp2004TransCnt(double inp2004TransCnt) {
		this.inp2004TransCnt = inp2004TransCnt;
	}


	public double getPkifs3011() {
		return this.pkifs3011;
	}

	public void setPkifs3011(double pkifs3011) {
		this.pkifs3011 = pkifs3011;
	}


	@Column(name="PROC_DATE")
	public String getProcDate() {
		return this.procDate;
	}

	public void setProcDate(String procDate) {
		this.procDate = procDate;
	}


	@Column(name="PROC_GUBUN")
	public String getProcGubun() {
		return this.procGubun;
	}

	public void setProcGubun(String procGubun) {
		this.procGubun = procGubun;
	}


	@Column(name="PROC_GUBUN2")
	public String getProcGubun2() {
		return this.procGubun2;
	}

	public void setProcGubun2(String procGubun2) {
		this.procGubun2 = procGubun2;
	}


	@Column(name="PROC_TIME")
	public String getProcTime() {
		return this.procTime;
	}

	public void setProcTime(String procTime) {
		this.procTime = procTime;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
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


	@Column(name="TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
	}


	@Column(name="TOIWON_GUBUN")
	public String getToiwonGubun() {
		return this.toiwonGubun;
	}

	public void setToiwonGubun(String toiwonGubun) {
		this.toiwonGubun = toiwonGubun;
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