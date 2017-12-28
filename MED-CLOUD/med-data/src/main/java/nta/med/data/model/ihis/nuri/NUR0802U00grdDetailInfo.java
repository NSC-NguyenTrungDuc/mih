package nta.med.data.model.ihis.nuri;

public class NUR0802U00grdDetailInfo {
	private String needType;
	private String needGubun;
	private String codeName;
	private String needAsmtCode;
	private String needAsmtName;
	private String makeHFileYn;

	public NUR0802U00grdDetailInfo(String needType, String needGubun, String codeName, String needAsmtCode,
			String needAsmtName, String makeHFileYn) {
		super();
		this.needType = needType;
		this.needGubun = needGubun;
		this.codeName = codeName;
		this.needAsmtCode = needAsmtCode;
		this.needAsmtName = needAsmtName;
		this.makeHFileYn = makeHFileYn;
	}

	public String getNeedType() {
		return needType;
	}

	public void setNeedType(String needType) {
		this.needType = needType;
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

	public String getMakeHFileYn() {
		return makeHFileYn;
	}

	public void setMakeHFileYn(String makeHFileYn) {
		this.makeHFileYn = makeHFileYn;
	}

}
