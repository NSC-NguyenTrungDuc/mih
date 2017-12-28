package nta.med.core.domain.inp;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the INP5001 database table.
 * 
 */
@Entity
@Table(name = "INP5001")
public class Inp5001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String chargeYn;
	private String hospCode;
	private String inwonMagamYn;
	private Date magamDate;
	private String nutJoMagamYn;
	private String nutJuMagamYn;
	private String nutSeokMagamYn;
	private String suikMagamYn;
	private String suipMagamYn;
	private Date sysDate;
	private String sysId;
	private String tongyeMagamYn;
	private Date updDate;
	private String updId;

	public Inp5001() {
	}

	@Column(name = "CHARGE_YN")
	public String getChargeYn() {
		return this.chargeYn;
	}

	public void setChargeYn(String chargeYn) {
		this.chargeYn = chargeYn;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INWON_MAGAM_YN")
	public String getInwonMagamYn() {
		return this.inwonMagamYn;
	}

	public void setInwonMagamYn(String inwonMagamYn) {
		this.inwonMagamYn = inwonMagamYn;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}

	@Column(name = "NUT_JO_MAGAM_YN")
	public String getNutJoMagamYn() {
		return this.nutJoMagamYn;
	}

	public void setNutJoMagamYn(String nutJoMagamYn) {
		this.nutJoMagamYn = nutJoMagamYn;
	}

	@Column(name = "NUT_JU_MAGAM_YN")
	public String getNutJuMagamYn() {
		return this.nutJuMagamYn;
	}

	public void setNutJuMagamYn(String nutJuMagamYn) {
		this.nutJuMagamYn = nutJuMagamYn;
	}

	@Column(name = "NUT_SEOK_MAGAM_YN")
	public String getNutSeokMagamYn() {
		return this.nutSeokMagamYn;
	}

	public void setNutSeokMagamYn(String nutSeokMagamYn) {
		this.nutSeokMagamYn = nutSeokMagamYn;
	}

	@Column(name = "SUIK_MAGAM_YN")
	public String getSuikMagamYn() {
		return this.suikMagamYn;
	}

	public void setSuikMagamYn(String suikMagamYn) {
		this.suikMagamYn = suikMagamYn;
	}

	@Column(name = "SUIP_MAGAM_YN")
	public String getSuipMagamYn() {
		return this.suipMagamYn;
	}

	public void setSuipMagamYn(String suipMagamYn) {
		this.suipMagamYn = suipMagamYn;
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

	@Column(name = "TONGYE_MAGAM_YN")
	public String getTongyeMagamYn() {
		return this.tongyeMagamYn;
	}

	public void setTongyeMagamYn(String tongyeMagamYn) {
		this.tongyeMagamYn = tongyeMagamYn;
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