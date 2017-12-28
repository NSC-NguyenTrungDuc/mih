package nta.med.data.model.ihis.system;

import java.util.Date;

public class LoadOcs0132Info {
	private String codeType;
    private String code;
    private String codeName;
    private Double valuePoint;
    private Double sortKey;
    private String groupKey;
    private String ment;
    private Date sysDate;
    private String updId;
    private Date updDate;
	public LoadOcs0132Info(String codeType, String code, String codeName,
			Double valuePoint, Double sortKey, String groupKey, String ment,
			Date sysDate, String updId, Date updDate) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.valuePoint = valuePoint;
		this.sortKey = sortKey;
		this.groupKey = groupKey;
		this.ment = ment;
		this.sysDate = sysDate;
		this.updId = updId;
		this.updDate = updDate;
	}
	public String getCodeType() {
		return codeType;
	}
	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public Double getValuePoint() {
		return valuePoint;
	}
	public void setValuePoint(Double valuePoint) {
		this.valuePoint = valuePoint;
	}
	public Double getSortKey() {
		return sortKey;
	}
	public void setSortKey(Double sortKey) {
		this.sortKey = sortKey;
	}
	public String getGroupKey() {
		return groupKey;
	}
	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}
	public String getMent() {
		return ment;
	}
	public void setMent(String ment) {
		this.ment = ment;
	}
	public Date getSysDate() {
		return sysDate;
	}
	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}
	public String getUpdId() {
		return updId;
	}
	public void setUpdId(String updId) {
		this.updId = updId;
	}
	public Date getUpdDate() {
		return updDate;
	}
	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}
}
