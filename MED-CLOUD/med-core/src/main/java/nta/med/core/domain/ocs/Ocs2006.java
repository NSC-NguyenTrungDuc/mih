package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS2006 database table.
 * 
 */
@Entity
@Table(name = "OCS2006")
public class Ocs2006 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private Double bomSourceKey;
	private String bomYn;
	private String bunho;
	private String directCode;
	private String directDetail;
	private String directGubun;
	private Double dv;
	private String dvTime;
	private Double fkinp1001;
	private Double fkocs2005;
	private Double fkocs6016;
	private String hangmogCode;
	private String hospCode;
	private String inputGubun;
	private Double insulinFrom;
	private Double insulinTo;
	private String jusaCode;
	private String jusaSpdGubun;
	private Double nalsu;
	private String ordDanui;
	private Date orderDate;
	private Double pkSeq;
	private Double seq;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private String timeGubun;
	private Date updDate;
	private String updId;

	public Ocs2006() {
	}

	@Column(name = "BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	@Column(name = "BOM_SOURCE_KEY")
	public Double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}

	@Column(name = "BOM_YN")
	public String getBomYn() {
		return this.bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
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

	public Double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Double getFkocs2005() {
		return this.fkocs2005;
	}

	public void setFkocs2005(Double fkocs2005) {
		this.fkocs2005 = fkocs2005;
	}

	public Double getFkocs6016() {
		return this.fkocs6016;
	}

	public void setFkocs6016(Double fkocs6016) {
		this.fkocs6016 = fkocs6016;
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

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "ORDER_DATE")
	public Date getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(Date orderDate) {
		this.orderDate = orderDate;
	}

	@Column(name = "PK_SEQ")
	public Double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(Double pkSeq) {
		this.pkSeq = pkSeq;
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