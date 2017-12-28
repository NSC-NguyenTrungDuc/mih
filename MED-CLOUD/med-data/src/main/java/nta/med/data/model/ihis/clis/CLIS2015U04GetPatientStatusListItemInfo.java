/**
 * 
 */
package nta.med.data.model.ihis.clis;

import java.util.Date;

public class CLIS2015U04GetPatientStatusListItemInfo {
	private Integer patientStatusId;
	private String description;
	private Date updated;
	private Date updateDate;
	private String codeName;
	private Integer sortNo;
	private String sysId;
	private String code;
	private Integer protocolPatientId;
	
	public CLIS2015U04GetPatientStatusListItemInfo(Integer patientStatusId,
			String description, Date updated, Date updateDate, String codeName, Integer sortNo,
			String sysId, String code, Integer protocolPatientId) {
		super();
		this.patientStatusId = patientStatusId;
		this.description = description;
		this.updated = updated;
		this.updateDate = updateDate;
		this.codeName = codeName;
		this.sortNo = sortNo;
		this.sysId = sysId;
		this.code = code;
		this.protocolPatientId = protocolPatientId;
	}
	public Integer getPatientStatusId() {
		return patientStatusId;
	}
	public void setPatientStatusId(Integer patientStatusId) {
		this.patientStatusId = patientStatusId;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public Date getUpdated() {
		return updated;
	}
	public void setUpdated(Date updated) {
		this.updated = updated;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public Integer getSortNo() {
		return sortNo;
	}
	public void setSortNo(Integer sortNo) {
		this.sortNo = sortNo;
	}
	public String getSysId() {
		return sysId;
	}
	public void setSysId(String sysId) {
		this.sysId = sysId;
	}
	public Date getUpdateDate() {
		return updateDate;
	}
	public void setUpdateDate(Date updateDate) {
		this.updateDate = updateDate;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public Integer getProtocolPatientId() {
		return protocolPatientId;
	}
	public void setProtocolPatientId(Integer protocolPatientId) {
		this.protocolPatientId = protocolPatientId;
	}
}
