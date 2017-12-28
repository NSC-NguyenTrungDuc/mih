package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS6016 database table.
 * 
 */
@Entity
@Table(name = "OCS6016")
public class Ocs6016 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private String bomSourceKey;
	private String bomYn;
	private String cpCode;
	private String cpPathCode;
	private String directCode;
	private String directDetail;
	private String directGubun;
	private Double dv;
	private String dvTime;
	private Double fkOcs2006seq;
	private Double fkocs6010;
	private Double fkocs6015;
	private String hangmogCode;
	private String hospCode;
	private String inputGubun;
	private Double insulinFrom;
	private Double insulinTo;
	private Double jaewonil;
	private String jusaCode;
	private String jusaSpdGubun;
	private Double nalsu;
	private String ordDanui;
	private Double pkSeq;
	private Double pkocs6016;
	private Double seq;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private String timeGubun;
	private Date updDate;
	private String updId;

	public Ocs6016() {
	}

	@Column(name = "BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	@Column(name = "BOM_SOURCE_KEY")
	public String getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(String bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}

	@Column(name = "BOM_YN")
	public String getBomYn() {
		return this.bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	@Column(name = "CP_CODE")
	public String getCpCode() {
		return this.cpCode;
	}

	public void setCpCode(String cpCode) {
		this.cpCode = cpCode;
	}

	@Column(name = "CP_PATH_CODE")
	public String getCpPathCode() {
		return this.cpPathCode;
	}

	public void setCpPathCode(String cpPathCode) {
		this.cpPathCode = cpPathCode;
	}

	@Column(name = "DIRECT_CODE")
	public String getDirectCode() {
		return this.directCode;
	}

	public void setDirectCode(String directCode) {
		this.directCode = directCode;
	}

	@Column(name = "DIRECT_DETAIL")
	public String getDirectDetail() {
		return this.directDetail;
	}

	public void setDirectDetail(String directDetail) {
		this.directDetail = directDetail;
	}

	@Column(name = "DIRECT_GUBUN")
	public String getDirectGubun() {
		return this.directGubun;
	}

	public void setDirectGubun(String directGubun) {
		this.directGubun = directGubun;
	}

	public Double getDv() {
		return this.dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	@Column(name = "DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	@Column(name = "FK_OCS2006SEQ")
	public Double getFkOcs2006seq() {
		return this.fkOcs2006seq;
	}

	public void setFkOcs2006seq(Double fkOcs2006seq) {
		this.fkOcs2006seq = fkOcs2006seq;
	}

	public Double getFkocs6010() {
		return this.fkocs6010;
	}

	public void setFkocs6010(Double fkocs6010) {
		this.fkocs6010 = fkocs6010;
	}

	public Double getFkocs6015() {
		return this.fkocs6015;
	}

	public void setFkocs6015(Double fkocs6015) {
		this.fkocs6015 = fkocs6015;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "INPUT_GUBUN")
	public String getInputGubun() {
		return this.inputGubun;
	}

	public void setInputGubun(String inputGubun) {
		this.inputGubun = inputGubun;
	}

	@Column(name = "INSULIN_FROM")
	public Double getInsulinFrom() {
		return this.insulinFrom;
	}

	public void setInsulinFrom(Double insulinFrom) {
		this.insulinFrom = insulinFrom;
	}

	@Column(name = "INSULIN_TO")
	public Double getInsulinTo() {
		return this.insulinTo;
	}

	public void setInsulinTo(Double insulinTo) {
		this.insulinTo = insulinTo;
	}

	public Double getJaewonil() {
		return this.jaewonil;
	}

	public void setJaewonil(Double jaewonil) {
		this.jaewonil = jaewonil;
	}

	@Column(name = "JUSA_CODE")
	public String getJusaCode() {
		return this.jusaCode;
	}

	public void setJusaCode(String jusaCode) {
		this.jusaCode = jusaCode;
	}

	@Column(name = "JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}

	public Double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}

	@Column(name = "ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	@Column(name = "PK_SEQ")
	public Double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
	}

	public Double getPkocs6016() {
		return this.pkocs6016;
	}

	public void setPkocs6016(Double pkocs6016) {
		this.pkocs6016 = pkocs6016;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
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

	@Column(name = "TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
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