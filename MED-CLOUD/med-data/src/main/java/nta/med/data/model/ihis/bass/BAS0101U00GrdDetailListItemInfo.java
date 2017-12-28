package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class BAS0101U00GrdDetailListItemInfo implements Serializable {
	private String codeType;
	private String code;
	private String codeName;
	private String groupKey;
	private String remark;
	private String sortKey;
	private String rowState;

	public BAS0101U00GrdDetailListItemInfo(String codeType, String code,
			String codeName, String groupKey, String remark, String sortKey,
			String rowState) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.codeName = codeName;
		this.groupKey = groupKey;
		this.remark = remark;
		this.sortKey = sortKey;
		this.rowState = rowState;
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

	public String getRowState() {
		return rowState;
	}

	public void setRowState(String rowState) {
		this.rowState = rowState;
	}

}
