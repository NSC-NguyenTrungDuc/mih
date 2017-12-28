package nta.med.data.model.ihis.phys;

import java.io.Serializable;

public class PHY2001U04CboJubsuGubunInfo implements Serializable {
	private String code        ;
	private String codeName   ;
	private String sortKey    ;
	public PHY2001U04CboJubsuGubunInfo(String code, String codeName,
			String sortKey) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.sortKey = sortKey;
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
	public String getSortKey() {
		return sortKey;
	}
	public void setSortKey(String sortKey) {
		this.sortKey = sortKey;
	}
	

}
