package nta.med.data.model.ihis.schs;

import java.io.Serializable;

public class ComboGumsaListItemInfo implements Serializable {
	private String code;
	private String codeName;
	private Double seq;

	public ComboGumsaListItemInfo(String code, String codeName, Double seq) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.seq = seq;
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

	public Double getSeq() {
		return seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

}
