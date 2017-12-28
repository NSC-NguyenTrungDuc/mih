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
 * The persistent class for the ADMS_GROUP database table.
 * 
 */
@Entity
@Table(name="ADMS_GROUP")
public class AdmsGroup implements Serializable {
	private static final long serialVersionUID = 1L;
	private Long admsGroupId;
	private Integer activeFlg;
	private Timestamp created;
	private String grpId;
	private Integer grpSeq;
	private String hospCode;
	private Integer selectFlg;
	private String sysId;
	private String updId;
	private Timestamp updated;

	public AdmsGroup() {
	}


	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ADMS_GROUP_ID")
	public Long getAdmsGroupId() {
		return this.admsGroupId;
	}

	public void setAdmsGroupId(Long admsGroupId) {
		this.admsGroupId = admsGroupId;
	}


	@Column(name="ACTIVE_FLG")
	public Integer getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
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


	@Column(name="GRP_SEQ")
	public Integer getGrpSeq() {
		return this.grpSeq;
	}

	public void setGrpSeq(Integer grpSeq) {
		this.grpSeq = grpSeq;
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