package nta.med.core.domain.adm;

import java.io.Serializable;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;


/**
 * The persistent class for the ADMS_GROUP_SYSTEM database table.
 * 
 */
@Entity
@Table(name="ADMS_GROUP_SYSTEM")
public class AdmsGroupSystem implements Serializable {
	private static final long serialVersionUID = 1L;
	private Long admsGroupSystemId;
	private Integer activeFlg;
	private Long admsGroupId;
	private Timestamp created;
	private String grpId;
	private String hospCode;
	private Integer selectFlg;
	private String sysId;
	private String systemId;
	private Integer systemSeq;
	private String updId;
	private Timestamp updated;

	public AdmsGroupSystem() {
	}


	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ADMS_GROUP_SYSTEM_ID")
	public Long getAdmsGroupSystemId() {
		return this.admsGroupSystemId;
	}

	public void setAdmsGroupSystemId(Long admsGroupSystemId) {
		this.admsGroupSystemId = admsGroupSystemId;
	}


	@Column(name="ACTIVE_FLG")
	public Integer getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}


	@Column(name="ADMS_GROUP_ID")
	public Long getAdmsGroupId() {
		return this.admsGroupId;
	}

	public void setAdmsGroupId(Long admsGroupId) {
		this.admsGroupId = admsGroupId;
	}


	public Timestamp getCreated() {
		return this.created;
	}

	public void setCreated(Timestamp created) {
		this.created = created;
	}


	@Column(name="GRP_ID")
	public String getGrpId() {
		return this.grpId;
	}

	public void setGrpId(String grpId) {
		this.grpId = grpId;
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


	@Column(name="SYSTEM_SEQ")
	public Integer getSystemSeq() {
		return this.systemSeq;
	}

	public void setSystemSeq(Integer systemSeq) {
		this.systemSeq = systemSeq;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	public Timestamp getUpdated() {
		return this.updated;
	}

	public void setUpdated(Timestamp updated) {
		this.updated = updated;
	}

}