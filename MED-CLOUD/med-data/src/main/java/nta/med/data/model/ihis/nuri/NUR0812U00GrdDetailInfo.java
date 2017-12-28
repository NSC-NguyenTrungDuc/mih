package nta.med.data.model.ihis.nuri;

public class NUR0812U00GrdDetailInfo {

	private String needHType;
	private String needGubun;
	private String codeName;
	private String needAsmtCode;
	private String needAsmtName;
	private String payloadNo;

	public NUR0812U00GrdDetailInfo(String needHType, String needGubun, String codeName, String needAsmtCode,
			String needAsmtName, String payloadNo) {
		super();
		this.needHType = needHType;
		this.needGubun = needGubun;
		this.codeName = codeName;
		this.needAsmtCode = needAsmtCode;
		this.needAsmtName = needAsmtName;
		this.payloadNo = payloadNo;
	}

	public String getNeedHType() {
		return needHType;
	}

	public void setNeedHType(String needHType) {
		this.needHType = needHType;
	}

	public String getNeedGubun() {
		return needGubun;
	}

	public void setNeedGubun(String needGubun) {
		this.needGubun = needGubun;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getNeedAsmtCode() {
		return needAsmtCode;
	}

	public void setNeedAsmtCode(String needAsmtCode) {
		this.needAsmtCode = needAsmtCode;
	}

	public String getNeedAsmtName() {
		return needAsmtName;
	}

	public void setNeedAsmtName(String needAsmtName) {
		this.needAsmtName = needAsmtName;
	}

	public String getPayloadNo() {
		return payloadNo;
	}

	public void setPayloadNo(String payloadNo) {
		this.payloadNo = payloadNo;
	}

}
