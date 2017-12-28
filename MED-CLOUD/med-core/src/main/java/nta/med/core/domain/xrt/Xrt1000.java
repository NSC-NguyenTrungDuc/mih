package nta.med.core.domain.xrt;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the XRT1000 database table.
 * 
 */
@Entity
@NamedQuery(name="Xrt1000.findAll", query="SELECT x FROM Xrt1000 x")
public class Xrt1000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private String cdFilmGubun;
	private double fkocs;
	private double fkxrt0201;
	private String hangmogCode;
	private String hospCode;
	private String inOutGubun;
	private String jindanComment;
	private String jindanName;
	private Date orderDate;
	private double pkxrt1000;
	private double preFkocs;
	private String preInOutGubun;
	private Date requestDate;
	private String requestDoctor;
	private double suryang;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Xrt1000() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CD_FILM_GUBUN")
	public String getCdFilmGubun() {
		return this.cdFilmGubun;
	}

	public void setCdFilmGubun(String cdFilmGubun) {
		this.cdFilmGubun = cdFilmGubun;
	}


	public double getFkocs() {
		return this.fkocs;
	}

	public void setFkocs(double fkocs) {
		this.fkocs = fkocs;
	}


	public double getFkxrt0201() {
		return this.fkxrt0201;
	}

	public void setFkxrt0201(double fkxrt0201) {
		this.fkxrt0201 = fkxrt0201;
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


	@Column(name="IN_OUT_GUBUN")
	public String getInOutGubun() {
		return this.inOutGubun;
	}

	public void setInOutGubun(String inOutGubun) {
		this.inOutGubun = inOutGubun;
	}


	@Column(name="JINDAN_COMMENT")
	public String getJindanComment() {
		return this.jindanComment;
	}

	public void setJindanComment(String jindanComment) {
		this.jindanComment = jindanComment;
	}


	@Column(name="JINDAN_NAME")
	public String getJindanName() {
		return this.jindanName;
	}

	public void setJindanName(String jindanName) {
		this.jindanName = jindanName;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}


	public double getPkxrt1000() {
		return this.pkxrt1000;
	}

	public void setPkxrt1000(double pkxrt1000) {
		this.pkxrt1000 = pkxrt1000;
	}


	@Column(name="PRE_FKOCS")
	public double getPreFkocs() {
		return this.preFkocs;
	}

	public void setPreFkocs(double preFkocs) {
		this.preFkocs = preFkocs;
	}


	@Column(name="PRE_IN_OUT_GUBUN")
	public String getPreInOutGubun() {
		return this.preInOutGubun;
	}

	public void setPreInOutGubun(String preInOutGubun) {
		this.preInOutGubun = preInOutGubun;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="REQUEST_DATE")
	public Date getRequestDate() {
		return this.requestDate;
	}

	public void setRequestDate(Date requestDate) {
		this.requestDate = requestDate;
	}


	@Column(name="REQUEST_DOCTOR")
	public String getRequestDoctor() {
		return this.requestDoctor;
	}

	public void setRequestDoctor(String requestDoctor) {
		this.requestDoctor = requestDoctor;
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