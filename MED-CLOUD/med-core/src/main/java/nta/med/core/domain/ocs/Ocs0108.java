package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0108 database table.
 * 
 */
@Entity
// @NamedQuery(name="Ocs0108.findAll", query="SELECT o FROM Ocs0108 o")
@Table(name = "OCS0108")
public class Ocs0108 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double changeQty1;
	private Double changeQty2;
	private String hangmogCode;
	private Date hangmogStartDate;
	private String hospCode;
	private String ordDanui;
	private Double seq;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String modifyFlg;

	public Ocs0108() {
	}

	@Column(name = "CHANGE_QTY1")
	public Double getChangeQty1() {
		return this.changeQty1;
	}

	public void setChangeQty1(Double changeQty1) {
		this.changeQty1 = changeQty1;
	}

	@Column(name = "CHANGE_QTY2")
	public Double getChangeQty2() {
		return this.changeQty2;
	}

	public void setChangeQty2(Double changeQty2) {
		this.changeQty2 = changeQty2;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "HANGMOG_START_DATE")
	public Date getHangmogStartDate() {
		return this.hangmogStartDate;
	}

	public void setHangmogStartDate(Date hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
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

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}