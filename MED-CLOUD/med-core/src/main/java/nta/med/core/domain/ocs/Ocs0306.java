package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0306 database table.
 * 
 */
@Entity
@Table(name="OCS0306")
public class Ocs0306 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private double bomSourceKey;
	private String bomYn;
	private String directCode;
	private String directDetail;
	private String directGubun;
	private double dv;
	private String dvTime;
	private String hangmogCode;
	private String hospCode;
	private double insulinFrom;
	private double insulinTo;
	private String jusaCode;
	private String jusaSpdGubun;
	private String memb;
	private String membGubun;
	private double nalsu;
	private String ordDanui;
	private double pkSeq;
	private double seq;
	private double suryang;
	private Date   sysDate;
	private String sysId;
	private String timeGubun;
	private Date   updDate;
	private String updId;
	private String yaksokDirectCode;

	public Ocs0306() {
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}


	@Column(name="BOM_SOURCE_KEY")
	public double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}


	@Column(name="BOM_YN")
	public String getBomYn() {
		return this.bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}


	@Column(name="DIRECT_CODE")
	public String getDirectCode() {
		return this.directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}


	@Column(name="DIRECT_DETAIL")
	public String getDirectDetail() {
		return this.directDetail;
	}

	public void setDirectDetail(String directDetail) {
		this.directDetail = directDetail;
	}


	@Column(name="DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}


	public double getDv() {
		return this.dv;
	}

	public void setDv(double dv) {
		this.dv = dv;
	}


	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
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


	@Column(name="INSULIN_FROM")
	public double getInsulinFrom() {
		return this.insulinFrom;
	}

	public void setInsulinFrom(double insulinFrom) {
		this.insulinFrom = insulinFrom;
	}


	@Column(name="INSULIN_TO")
	public double getInsulinTo() {
		return this.insulinTo;
	}

	public void setInsulinTo(double insulinTo) {
		this.insulinTo = insulinTo;
	}


	@Column(name="JUSA_CODE")
	public String getJusaCode() {
		return this.jusaCode;
	}

	public void setJusaCode(String jusaCode) {
		this.jusaCode = jusaCode;
	}


	@Column(name="JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}


	public String getMemb() {
		return this.memb;
	}

	public void setMemb(String memb) {
		this.memb = memb;
	}


	@Column(name="MEMB_GUBUN")
	public String getMembGubun() {
		return this.membGubun;
	}

	public void setMembGubun(String membGubun) {
		this.membGubun = membGubun;
	}


	public double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(double nalsu) {
		this.nalsu = nalsu;
	}


	@Column(name="ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
	}


	public double getSeq() {
		return this.seq;
	}

	public void setSeq(double seq) {
		this.seq = seq;
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


	@Column(name="TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
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


	@Column(name="YAKSOK_DIRECT_CODE")
	public String getYaksokDirectCode() {
		return this.yaksokDirectCode;
	}

	public void setYaksokDirectCode(String yaksokDirectCode) {
		this.yaksokDirectCode = yaksokDirectCode;
	}

}