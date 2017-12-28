package nta.med.core.domain.adm;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;


/**
 * The persistent class for the ADMS_MENU database table.
 * 
 */
@Entity
@Table(name="ADMS_MENU")
public class AdmsMenu implements Serializable {
	private static final long serialVersionUID = 1L;
	private Long admsMenuId;
	private Integer activeFlg;
	private Date created;
	private String hospCode;
	private Integer selectFlg;
	private String sysId;
	private String systemId;
	private String trId;
	private String updId;
	private Date updated;

	public AdmsMenu() {
	}


	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ADMS_MENU_ID")
	public Long getAdmsMenuId() {
		return this.admsMenuId;
	}

	public void setAdmsMenuId(Long admsMenuId) {
		this.admsMenuId = admsMenuId;
	}


	@Column(name="ACTIVE_FLG")
	public Integer getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}


	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="SELECT_FLG")
	public Integer getSelectFlg() {
		return this.selectFlg;
	}

	public void setSelectFlg(Integer selectFlg) {
		this.selectFlg = selectFlg;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="SYSTEM_ID")
	public String getSystemId() {
		return this.systemId;
	}

	public void setSystemId(String systemId) {
		this.systemId = systemId;
	}


	@Column(name="TR_ID")
	public String getTrId() {
		return this.trId;
	}

	public void setTrId(String trId) {
		this.trId = trId;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

}