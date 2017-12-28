package nta.med.data.model.ihis.nuri;

public class NUR0101U00grdMasterInfo {
	private String codeType;
	private String codeTypeName;
	private String dataRowState;
	
	public NUR0101U00grdMasterInfo(String codeType, String codeTypeName, String dataRowState){
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.dataRowState = dataRowState;
	}

	public String getCodeType() {
		return codeType;
	}

	public void setCodeType(String codeType) {
		this.codeType = codeType;
	}

	public String getCodeTypeName() {
		return codeTypeName;
	}

	public void setCodeTypeName(String codeTypeName) {
		this.codeTypeName = codeTypeName;
	}

	public String getDataRowState() {
		return dataRowState;
	}

	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}

}
