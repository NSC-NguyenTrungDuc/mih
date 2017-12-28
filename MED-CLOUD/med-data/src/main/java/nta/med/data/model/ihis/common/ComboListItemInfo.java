
package nta.med.data.model.ihis.common;

import java.io.Serializable;

public class ComboListItemInfo implements Serializable {
    private String code;
    private String codeName;
    
	public ComboListItemInfo(String code, String codeName) {
		super();
		this.code = code;
		this.codeName = codeName;
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
}
