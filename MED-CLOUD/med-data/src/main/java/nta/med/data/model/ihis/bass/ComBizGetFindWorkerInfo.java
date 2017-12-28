package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class ComBizGetFindWorkerInfo implements Serializable {
	private String code;
	private String codeName;
	private String value;

	public ComBizGetFindWorkerInfo(String code, String codeName, String value) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.value = value;
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

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

}
