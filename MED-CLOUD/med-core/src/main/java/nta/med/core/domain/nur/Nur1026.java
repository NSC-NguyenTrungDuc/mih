package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR1026 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur1026.findAll", query="SELECT n FROM Nur1026 n")
public class Nur1026 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bulonYn;
	private double fknur1025;
	private Date girokDate;
	private String hospCode;
	private String jundojunrakYn;
	private double pknur1026;
	private String stopComments;
	private String stopMethod;
	private Date sysDate;
	private String sysId;
	private String tubeInsertYn;
	private Date updDate;
	private String updId;

	public Nur1026() {
	}


	@Column(name="BULON_YN")
	public String getBulonYn() {
		return this.bulonYn;
	}

	public void setBulonYn(String bulonYn) {
		this.bulonYn = bulonYn;
	}


	public double getFknur1025() {
		return this.fknur1025;
	}

	public void setFknur1025(double fknur1025) {
		this.fknur1025 = fknur1025;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="GIROK_DATE")
	public Date getGirokDate() {
		return this.girokDate;
	}

	public void setGirokDate(Date girokDate) {
		this.girokDate = girokDate;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNDOJUNRAK_YN")
	public String getJundojunrakYn() {
		return this.jundojunrakYn;
	}

	public void setJundojunrakYn(String jundojunrakYn) {
		this.jundojunrakYn = jundojunrakYn;
	}


	public double getPknur1026() {
		return this.pknur1026;
	}

	public void setPknur1026(double pknur1026) {
		this.pknur1026 = pknur1026;
	}


	@Column(name="STOP_COMMENTS")
	public String getStopComments() {
		return this.stopComments;
	}

	public void setStopComments(String stopComments) {
		this.stopComments = stopComments;
	}


	@Column(name="STOP_METHOD")
	public String getStopMethod() {
		return this.stopMethod;
	}

	public void setStopMethod(String stopMethod) {
		this.stopMethod = stopMethod;
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


	@Column(name="TUBE_INSERT_YN")
	public String getTubeInsertYn() {
		return this.tubeInsertYn;
	}

	public void setTubeInsertYn(String tubeInsertYn) {
		this.tubeInsertYn = tubeInsertYn;
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