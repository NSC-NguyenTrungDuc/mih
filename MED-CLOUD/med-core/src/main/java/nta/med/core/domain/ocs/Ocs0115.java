package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0115 database table.
 * 
 */
@Entity
// @NamedQuery(name="Ocs0115.findAll", query="SELECT o FROM Ocs0115 o")
@Table(name = "OCS0115")
public class Ocs0115 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date endDate;
	private String hangmogCode;
	private Date hangmogStartDate;
	private String hospCode;
	private String inputGwa;
	private String inputPart;
	private String jundalPartInp;
	private String jundalPartOut;
	private String jundalTableInp;
	private String jundalTableOut;
	private String movePart;
	private Date startDate;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	//private String modifyFlg;

	public Ocs0115() {
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "END_DATE")
	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
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

	@Column(name = "INPUT_GWA")
	public String getInputGwa() {
		return this.inputGwa;
	}

	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}

	@Column(name = "INPUT_PART")
	public String getInputPart() {
		return this.inputPart;
	}

	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
	}

	@Column(name = "JUNDAL_PART_INP")
	public String getJundalPartInp() {
		return this.jundalPartInp;
	}

	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}

	@Column(name = "JUNDAL_PART_OUT")
	public String getJundalPartOut() {
		return this.jundalPartOut;
	}

	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}

	@Column(name = "JUNDAL_TABLE_INP")
	public String getJundalTableInp() {
		return this.jundalTableInp;
	}

	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}

	@Column(name = "JUNDAL_TABLE_OUT")
	public String getJundalTableOut() {
		return this.jundalTableOut;
	}

	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}

	@Column(name = "MOVE_PART")
	public String getMovePart() {
		return this.movePart;
	}

	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "START_DATE")
	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
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

	/*@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}*/
}