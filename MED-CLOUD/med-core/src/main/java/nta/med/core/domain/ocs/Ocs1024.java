package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS1024 database table.
 * 
 */
@Entity
@Table(name="OCS1024")
public class Ocs1024 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bogyongCode;
	private String bunho;
	private Double currentSuryang;
	private String drgComment;
	private Double dv;
	private String dvTime;
	private String fkinp1001;
	private String generalDispYn;
	private String gwa;
	private String hangmogCode;
	private String hospCode;
	private String inputTab;
	private String inputUserId;
	private String jusa;
	private String jusaSpdGubun;
	private Double nalsu;
	private String ordDanui;
	private String orderDate;
	private String orderGubun;
	private Double pkocs1024;
	private Double seq;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private Double totalSuryang;
	private Date updDate;
	private String updId;
	private String usedupYn;

	public Ocs1024() {
	}


	@Column(name="BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	@Column(name="BUNHO")
	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Column(name="CURRENT_SURYANG")
	public Double getCurrentSuryang() {
		return this.currentSuryang;
	}

	public void setCurrentSuryang(Double currentSuryang) {
		this.currentSuryang = currentSuryang;
	}

	@Column(name="DRG_COMMENT")
	public String getDrgComment() {
		return this.drgComment;
	}

	public void setDrgComment(String drgComment) {
		this.drgComment = drgComment;
	}

	@Column(name="DV")
	public Double getDv() {
		return this.dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	@Column(name="DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	@Column(name="FKINP1001")
	public String getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(String fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	@Column(name="GENERAL_DISP_YN")
	public String getGeneralDispYn() {
		return this.generalDispYn;
	}

	public void setGeneralDispYn(String generalDispYn) {
		this.generalDispYn = generalDispYn;
	}
	
	@Column(name="GWA")
	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
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

	@Column(name="INPUT_TAB")
	public String getInputTab() {
		return this.inputTab;
	}

	public void setInputTab(String inputTab) {
		this.inputTab = inputTab;
	}

	@Column(name="INPUT_USER_ID")
	public String getInputUserId() {
		return this.inputUserId;
	}

	public void setInputUserId(String inputUserId) {
		this.inputUserId = inputUserId;
	}

	@Column(name="JUSA")
	public String getJusa() {
		return this.jusa;
	}

	public void setJusa(String jusa) {
		this.jusa = jusa;
	}

	@Column(name="JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}

	@Column(name="NALSU")
	public Double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}

	@Column(name="ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	@Column(name="ORDER_DATE")
	public String getOrderDate() {
		return this.orderDate;
	}

	public void setOrderDate(String orderDate) {
		this.orderDate = orderDate;
	}

	@Column(name="ORDER_GUBUN")
	public String getOrderGubun() {
		return this.orderGubun;
	}

	public void setOrderGubun(String orderGubun) {
		this.orderGubun = orderGubun;
	}

	@Column(name="PKOCS1024")
	public Double getPkocs1024() {
		return this.pkocs1024;
	}

	public void setPkocs1024(Double pkocs1024) {
		this.pkocs1024 = pkocs1024;
	}

	@Column(name="SEQ")
	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	@Column(name="SURYANG")
	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
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

	@Column(name="TOTAL_SURYANG")
	public Double getTotalSuryang() {
		return this.totalSuryang;
	}

	public void setTotalSuryang(Double totalSuryang) {
		this.totalSuryang = totalSuryang;
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

	@Column(name="USEDUP_YN")
	public String getUsedupYn() {
		return this.usedupYn;
	}

	public void setUsedupYn(String usedupYn) {
		this.usedupYn = usedupYn;
	}

}