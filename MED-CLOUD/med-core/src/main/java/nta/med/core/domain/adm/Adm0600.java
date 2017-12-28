package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0600 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0600.findAll", query="SELECT a FROM Adm0600 a")
public class Adm0600 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String ipAddr;
	private String msgId;
	private String msgRegArg;
	private String msgType;
	private String pgmId;
	private Date regiTime;
	private String sysId;

	public Adm0600() {
	}


	@Column(name="IP_ADDR")
	public String getIpAddr() {
		return this.ipAddr;
	}

	public void setIpAddr(String ipAddr) {
		this.ipAddr = ipAddr;
	}


	@Column(name="MSG_ID")
	public String getMsgId() {
		return this.msgId;
	}

	public void setMsgId(String msgId) {
		this.msgId = msgId;
	}


	@Column(name="MSG_REG_ARG")
	public String getMsgRegArg() {
		return this.msgRegArg;
	}

	public void setMsgRegArg(String msgRegArg) {
		this.msgRegArg = msgRegArg;
	}


	@Column(name="MSG_TYPE")
	public String getMsgType() {
		return this.msgType;
	}

	public void setMsgType(String msgType) {
		this.msgType = msgType;
	}


	@Column(name="PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="REGI_TIME")
	public Date getRegiTime() {
		return this.regiTime;
	}

	public void setRegiTime(Date regiTime) {
		this.regiTime = regiTime;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

}