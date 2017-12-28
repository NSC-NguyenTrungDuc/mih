package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT0101U00GrdDcodeInfo implements Serializable {

	private String codeType;
	private String code;
	private String code2;
	private String codeName;
	private String codeName2;
	private Double seq;
	private String codeValue;
	private String charSeq;
	public XRT0101U00GrdDcodeInfo(String codeType, String code,
			String code2, String codeName, String codeName2, Double seq,
			String codeValue, String charSeq) {
		super();
		this.codeType = codeType;
		this.code = code;
		this.code2 = code2;
		this.codeName = codeName;
		this.codeName2 = codeName2;
		this.seq = seq;
		this.codeValue = codeValue;
		this.charSeq = charSeq;
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
	public String getCode2() {
		return code2;
	}
	public void setCode2(String code2) {
		this.code2 = code2;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	public String getCodeName2() {
		return codeName2;
	}
	public void setCodeName2(String codeName2) {
		this.codeName2 = codeName2;
	}
	public Double getSeq() {
		return seq;
	}
	public void setSeq(Double seq) {
		this.seq = seq;
	}
	public String getCodeValue() {
		return codeValue;
	}
	public void setCodeValue(String codeValue) {
		this.codeValue = codeValue;
	}
	public String getCharSeq() {
		return charSeq;
	}
	public void setCharSeq(String charSeq) {
		this.charSeq = charSeq;
	}

	
}
