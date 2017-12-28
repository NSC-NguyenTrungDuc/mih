package nta.med.core.domain.adm;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the ADM3300 database table.
 * 
 */
@Entity
@Table(name="ADM3300")
public class Adm3300 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bPrintName;
	private String bPrintName2;
	private String crMemb;
	private Date crTime;
	private String crTrm;
	private String deptCode;
	private String gumsaMsgYn;
	private String gwaRoom;
	private String hospCode;
	private String ipAddr;
	private String serverIp;
	private String sysId;
	private String trmId;
	private String upMemb;
	private Date upTime;
	private String upTrm;
	private String useYn;
	private String userId;

	public Adm3300() {
	}


	@Column(name="B_PRINT_NAME")
	public String getBPrintName() {
		return this.bPrintName;
	}

	public void setBPrintName(String bPrintName) {
		this.bPrintName = bPrintName;
	}


	@Column(name="B_PRINT_NAME2")
	public String getBPrintName2() {
		return this.bPrintName2;
	}

	public void setBPrintName2(String bPrintName2) {
		this.bPrintName2 = bPrintName2;
	}


	@Column(name="CR_MEMB")
	public String getCrMemb() {
		return this.crMemb;
	}

	public void setCrMemb(String crMemb) {
		this.crMemb = crMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CR_TIME")
	public Date getCrTime() {
		return this.crTime;
	}

	public void setCrTime(Date crTime) {
		this.crTime = crTime;
	}


	@Column(name="CR_TRM")
	public String getCrTrm() {
		return this.crTrm;
	}

	public void setCrTrm(String crTrm) {
		this.crTrm = crTrm;
	}


	@Column(name="DEPT_CODE")
	public String getDeptCode() {
		return this.deptCode;
	}

	public void setDeptCode(String deptCode) {
		this.deptCode = deptCode;
	}


	@Column(name="GUMSA_MSG_YN")
	public String getGumsaMsgYn() {
		return this.gumsaMsgYn;
	}

	public void setGumsaMsgYn(String gumsaMsgYn) {
		this.gumsaMsgYn = gumsaMsgYn;
	}


	@Column(name="GWA_ROOM")
	public String getGwaRoom() {
		return this.gwaRoom;
	}

	public void setGwaRoom(String gwaRoom) {
		this.gwaRoom = gwaRoom;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IP_ADDR")
	public String getIpAddr() {
		return this.ipAddr;
	}

	public void setIpAddr(String ipAddr) {
		this.ipAddr = ipAddr;
	}


	@Column(name="SERVER_IP")
	public String getServerIp() {
		return this.serverIp;
	}

	public void setServerIp(String serverIp) {
		this.serverIp = serverIp;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="TRM_ID")
	public String getTrmId() {
		return this.trmId;
	}

	public void setTrmId(String trmId) {
		this.trmId = trmId;
	}


	@Column(name="UP_MEMB")
	public String getUpMemb() {
		return this.upMemb;
	}

	public void setUpMemb(String upMemb) {
		this.upMemb = upMemb;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UP_TIME")
	public Date getUpTime() {
		return this.upTime;
	}

	public void setUpTime(Date upTime) {
		this.upTime = upTime;
	}


	@Column(name="UP_TRM")
	public String getUpTrm() {
		return this.upTrm;
	}

	public void setUpTrm(String upTrm) {
		this.upTrm = upTrm;
	}


	@Column(name="USE_YN")
	public String getUseYn() {
		return this.useYn;
	}

	public void setUseYn(String useYn) {
		this.useYn = useYn;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}