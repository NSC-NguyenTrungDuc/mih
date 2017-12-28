package nta.med.core.domain.drg;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DRG3012 database table.
 * 
 */
@Entity
@NamedQuery(name="Drg3012.findAll", query="SELECT d FROM Drg3012 d")
public class Drg3012 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private double bannabSuryang;
	private double bdJanyoSuryang;
	private String chulgoBuseo;
	private Date chulgoDate;
	private double chulgoQty;
	private double chulgoSeq;
	private String chulgoType;
	private double dJanyoSuryang;
	private double dSuryang;
	private String hoDong;
	private double hoDongSuryang;
	private String hospCode;
	private String jaeryoCode;
	private double janyoSuryang;
	private Date magamDate;
	private double michulgoSuryang;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Drg3012() {
	}


	@Column(name="BANNAB_SURYANG")
	public double getBannabSuryang() {
		return this.bannabSuryang;
	}

	public void setBannabSuryang(double bannabSuryang) {
		this.bannabSuryang = bannabSuryang;
	}


	@Column(name="BD_JANYO_SURYANG")
	public double getBdJanyoSuryang() {
		return this.bdJanyoSuryang;
	}

	public void setBdJanyoSuryang(double bdJanyoSuryang) {
		this.bdJanyoSuryang = bdJanyoSuryang;
	}


	@Column(name="CHULGO_BUSEO")
	public String getChulgoBuseo() {
		return this.chulgoBuseo;
	}

	public void setChulgoBuseo(String chulgoBuseo) {
		this.chulgoBuseo = chulgoBuseo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="CHULGO_DATE")
	public Date getChulgoDate() {
		return this.chulgoDate;
	}

	public void setChulgoDate(Date chulgoDate) {
		this.chulgoDate = chulgoDate;
	}


	@Column(name="CHULGO_QTY")
	public double getChulgoQty() {
		return this.chulgoQty;
	}

	public void setChulgoQty(double chulgoQty) {
		this.chulgoQty = chulgoQty;
	}


	@Column(name="CHULGO_SEQ")
	public double getChulgoSeq() {
		return this.chulgoSeq;
	}

	public void setChulgoSeq(double chulgoSeq) {
		this.chulgoSeq = chulgoSeq;
	}


	@Column(name="CHULGO_TYPE")
	public String getChulgoType() {
		return this.chulgoType;
	}

	public void setChulgoType(String chulgoType) {
		this.chulgoType = chulgoType;
	}


	@Column(name="D_JANYO_SURYANG")
	public double getDJanyoSuryang() {
		return this.dJanyoSuryang;
	}

	public void setDJanyoSuryang(double dJanyoSuryang) {
		this.dJanyoSuryang = dJanyoSuryang;
	}


	@Column(name="D_SURYANG")
	public double getDSuryang() {
		return this.dSuryang;
	}

	public void setDSuryang(double dSuryang) {
		this.dSuryang = dSuryang;
	}


	@Column(name="HO_DONG")
	public String getHoDong() {
		return this.hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}


	@Column(name="HO_DONG_SURYANG")
	public double getHoDongSuryang() {
		return this.hoDongSuryang;
	}

	public void setHoDongSuryang(double hoDongSuryang) {
		this.hoDongSuryang = hoDongSuryang;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JAERYO_CODE")
	public String getJaeryoCode() {
		return this.jaeryoCode;
	}

	public void setJaeryoCode(String jaeryoCode) {
		this.jaeryoCode = jaeryoCode;
	}


	@Column(name="JANYO_SURYANG")
	public double getJanyoSuryang() {
		return this.janyoSuryang;
	}

	public void setJanyoSuryang(double janyoSuryang) {
		this.janyoSuryang = janyoSuryang;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="MAGAM_DATE")
	public Date getMagamDate() {
		return this.magamDate;
	}

	public void setMagamDate(Date magamDate) {
		this.magamDate = magamDate;
	}


	@Column(name="MICHULGO_SURYANG")
	public double getMichulgoSuryang() {
		return this.michulgoSuryang;
	}

	public void setMichulgoSuryang(double michulgoSuryang) {
		this.michulgoSuryang = michulgoSuryang;
	}


	public double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(double suryang) {
		this.suryang = suryang;
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