package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR0301 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur0301.findAll", query="SELECT n FROM Nur0301 n")
public class Nur0301 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String commonRoomYn;
	private Date endDate;
	private String gwa;
	private String gwaRoom;
	private String gwaRoomColor;
	private double gwaRoomInwon;
	private String gwaRoomName;
	private String hospCode;
	private String ipAddress;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vald;

	public Nur0301() {
	}


	@Column(name="COMMON_ROOM_YN")
	public String getCommonRoomYn() {
		return this.commonRoomYn;
	}

	public void setCommonRoomYn(String commonRoomYn) {
		this.commonRoomYn = commonRoomYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_ROOM")
	public String getGwaRoom() {
		return this.gwaRoom;
	}

	public void setGwaRoom(String gwaRoom) {
		this.gwaRoom = gwaRoom;
	}


	@Column(name="GWA_ROOM_COLOR")
	public String getGwaRoomColor() {
		return this.gwaRoomColor;
	}

	public void setGwaRoomColor(String gwaRoomColor) {
		this.gwaRoomColor = gwaRoomColor;
	}


	@Column(name="GWA_ROOM_INWON")
	public double getGwaRoomInwon() {
		return this.gwaRoomInwon;
	}

	public void setGwaRoomInwon(double gwaRoomInwon) {
		this.gwaRoomInwon = gwaRoomInwon;
	}


	@Column(name="GWA_ROOM_NAME")
	public String getGwaRoomName() {
		return this.gwaRoomName;
	}

	public void setGwaRoomName(String gwaRoomName) {
		this.gwaRoomName = gwaRoomName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IP_ADDRESS")
	public String getIpAddress() {
		return this.ipAddress;
	}

	public void setIpAddress(String ipAddress) {
		this.ipAddress = ipAddress;
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


	public String getVald() {
		return this.vald;
	}

	public void setVald(String vald) {
		this.vald = vald;
	}

}