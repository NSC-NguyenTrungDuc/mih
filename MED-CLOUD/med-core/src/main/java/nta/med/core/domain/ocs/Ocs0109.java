package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS0109 database table.
 * 
 */
@Entity
@NamedQuery(name = "Ocs0109.findAll", query = "SELECT o FROM Ocs0109 o")
public class Ocs0109 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bigo;
	private String genericCode;
	private String genericCodeOrg;
	private String genericName;
	private String genericNameInx;
	private String hospCode;
	private String kikaku;
	private String kusuriGubun;
	private String lowPrice;
	private String seibunName;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String modifyFlg;

	public Ocs0109() {
	}

	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}

	@Column(name = "GENERIC_CODE")
	public String getGenericCode() {
		return this.genericCode;
	}

	public void setGenericCode(String genericCode) {
		this.genericCode = genericCode;
	}

	@Column(name = "GENERIC_CODE_ORG")
	public String getGenericCodeOrg() {
		return this.genericCodeOrg;
	}

	public void setGenericCodeOrg(String genericCodeOrg) {
		this.genericCodeOrg = genericCodeOrg;
	}

	@Column(name = "GENERIC_NAME")
	public String getGenericName() {
		return this.genericName;
	}

	public void setGenericName(String genericName) {
		this.genericName = genericName;
	}

	@Column(name = "GENERIC_NAME_INX")
	public String getGenericNameInx() {
		return this.genericNameInx;
	}

	public void setGenericNameInx(String genericNameInx) {
		this.genericNameInx = genericNameInx;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getKikaku() {
		return this.kikaku;
	}

	public void setKikaku(String kikaku) {
		this.kikaku = kikaku;
	}

	@Column(name = "KUSURI_GUBUN")
	public String getKusuriGubun() {
		return this.kusuriGubun;
	}

	public void setKusuriGubun(String kusuriGubun) {
		this.kusuriGubun = kusuriGubun;
	}

	@Column(name = "LOW_PRICE")
	public String getLowPrice() {
		return this.lowPrice;
	}

	public void setLowPrice(String lowPrice) {
		this.lowPrice = lowPrice;
	}

	@Column(name = "SEIBUN_NAME")
	public String getSeibunName() {
		return this.seibunName;
	}

	public void setSeibunName(String seibunName) {
		this.seibunName = seibunName;
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

	@Column(name = "MODIFY_FLG")
	public String getModifyFlg() {
		return modifyFlg;
	}

	public void setModifyFlg(String modifyFlg) {
		this.modifyFlg = modifyFlg;
	}
}