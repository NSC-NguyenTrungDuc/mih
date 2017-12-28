package nta.med.core.domain.ocs;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0303 database table.
 * 
 */
@Entity
@Table(name="OCS0307")
public class Ocs0307 extends BaseEntity{
	private static final long serialVersionUID = 1L;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String memb;
	private String yaksokCode;
	private String sangCode;
	private String hospCode;
	private Double fkocs0307Seq;
	private BigDecimal activeFlg;
	
	public Ocs0307() {
	}
	
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}
	
	@Column(name="SYS_ID")
	public String getSysId() {
		return sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}
	
	@Column(name="UPD_ID")
	public String getUpdId() {
		return updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}
	
	@Column(name="MEMB")
	public String getMemb() {
		return memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}
	
	@Column(name="YAKSOK_CODE")
	public String getYaksokCode() {
		return yaksokCode;
	}

	public void setYaksokCode(String yaksokCode) {
		this.yaksokCode = yaksokCode;
	}
	
	@Column(name="SANG_CODE")
	public String getSangCode() {
		return sangCode;
	}

	public void setSangCode(String sangCode) {
		this.sangCode = sangCode;
	}

	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name="FKOCS0300_SEQ")
	public Double getFkocs0307Seq() {
		return fkocs0307Seq;
	}

	public void setFkocs0307Seq(Double fkocs0307Seq) {
		this.fkocs0307Seq = fkocs0307Seq;
	}
	
	@Column(name="ACTIVE_FLG")
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}
	
	
}
