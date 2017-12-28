package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class BAS0001U00grdDetailItemInfo implements Serializable {
	private String codeType ;
	private String code;
	private String codeName;
	private String groupKey ;
	private String remark ;
	private String sortKey ;
	public BAS0001U00grdDetailItemInfo(String codeType, String code,
			String codeName, String groupKey, String remark, String sortKey) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.groupKey = groupKey;
		this.remark = remark;
		this.sortKey = sortKey;
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
	public String getGroupKey() {
		return groupKey;
	}
	public void setGroupKey(String groupKey) {
		this.groupKey = groupKey;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getSortKey() {
		return sortKey;
	}
	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	} 
	

}