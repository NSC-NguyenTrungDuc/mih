package nta.med.data.model.ihis.nuro;

import java.io.Serializable;

public class NuroOUT1101Q01PrintNameInfo implements Serializable{
	private String codeName;
    private String sortKey;
	public NuroOUT1101Q01PrintNameInfo(String codeName, String sortKey) {
		super();
		this.codeName = codeName;
		this.sortKey = sortKey;
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
