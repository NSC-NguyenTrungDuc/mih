package nta.med.core.domain.drg;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the DRG3041 database table.
 * 
 */
@Entity
@Table(name = "DRG3041")
public class Drg3041 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date actingDate;
	private String actingId;
	private String actingTime;
	private String autoYn;
	private String bannabYn;
	private String bunho;
	private String chulgoAllYn;
	private Date chulgoDate;
	private String chulgoId;
	private String chulgoTime;
	private Double drgBunho;
	private String hoCode;
	private String hoDong;
	private String hospCode;
	private Date ipgoDate;
	private String ipgoId;
	private String ipgoTime;
	private Date jubsuDate;
	private Date mixDate;
	private String mixId;
	private String mixTime;
	private Double seq;
	private String serialV;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg3041() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ACTING_DATE")
	public Date getActingDate() {
		return this.actingDate;
	}

	public void setActingDate(Date actingDate) {
		this.actingDate = actingDate;
	}

	@Column(name = "ACTING_ID")
	public String getActingId() {
		return this.actingId;
	}

	public void setActingId(String actingId) {
		this.actingId = actingId;
	}

	@Column(name = "ACTING_TIME")
	public String getActingTime() {
		return this.actingTime;
	}

	public void setActingTime(String actingTime) {
		this.actingTime = actingTime;
	}

	@Column(name = "AUTO_YN")
	public String getAutoYn() {
		return this.autoYn;
	}

	public void setAutoYn(String autoYn) {
		this.autoYn = autoYn;
	}

	@Column(name = "BANNAB_YN")
	public String getBannabYn() {
		return this.bannabYn;
	}

	public void setBannabYn(String bannabYn) {
		this.bannabYn = bannabYn;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name = "CHULGO_ALL_YN")
	public String getChulgoAllYn() {
		return this.chulgoAllYn;
	}

	public void setChulgoAllYn(String chulgoAllYn) {
		this.chulgoAllYn = chulgoAllYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "CHULGO_DATE")
	public Date getChulgoDate() {
		return this.chulgoDate;
	}

	public void setChulgoDate(Date chulgoDate) {
		this.chulgoDate = chulgoDate;
	}

	@Column(name = "CHULGO_ID")
	public String getChulgoId() {
		return this.chulgoId;
	}

	public void setChulgoId(String chulgoId) {
		this.chulgoId = chulgoId;
	}

	@Column(name = "CHULGO_TIME")
	public String getChulgoTime() {
		return this.chulgoTime;
	}

	public void setChulgoTime(String chulgoTime) {
		this.chulgoTime = chulgoTime;
	}

	@Column(name = "DRG_BUNHO")
	public Double getDrgBunho() {
		return this.drgBunho;
	}

	public void setDrgBunho(Double drgBunho) {
		this.drgBunho = drgBunho;
	}

	@Column(name = "HO_CODE")
	public String getHoCode() {
		return this.hoCode;
	}

	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}

	@Column(name = "HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "IPGO_DATE")
	public Date getIpgoDate() {
		return this.ipgoDate;
	}

	public void setIpgoDate(Date ipgoDate) {
		this.ipgoDate = ipgoDate;
	}

	@Column(name = "IPGO_ID")
	public String getIpgoId() {
		return this.ipgoId;
	}

	public void setIpgoId(String ipgoId) {
		this.ipgoId = ipgoId;
	}

	@Column(name = "IPGO_TIME")
	public String getIpgoTime() {
		return this.ipgoTime;
	}

	public void setIpgoTime(String ipgoTime) {
		this.ipgoTime = ipgoTime;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "JUBSU_DATE")
	public Date getJubsuDate() {
		return this.jubsuDate;
	}

	public void setJubsuDate(Date jubsuDate) {
		this.jubsuDate = jubsuDate;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "MIX_DATE")
	public Date getMixDate() {
		return this.mixDate;
	}

	public void setMixDate(Date mixDate) {
		this.mixDate = mixDate;
	}

	@Column(name = "MIX_ID")
	public String getMixId() {
		return this.mixId;
	}

	public void setMixId(String mixId) {
		this.mixId = mixId;
	}

	@Column(name = "MIX_TIME")
	public String getMixTime() {
		return this.mixTime;
	}

	public void setMixTime(String mixTime) {
		this.mixTime = mixTime;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	@Column(name = "SERIAL_V")
	public String getSerialV() {
		return this.serialV;
	}

	public void setSerialV(String serialV) {
		this.serialV = serialV;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}