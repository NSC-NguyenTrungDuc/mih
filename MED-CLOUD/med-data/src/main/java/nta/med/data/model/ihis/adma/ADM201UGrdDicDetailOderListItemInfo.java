package nta.med.data.model.ihis.adma;

public class ADM201UGrdDicDetailOderListItemInfo {
	private String colId;
	private String code;
	private String codeNm;
	
	public ADM201UGrdDicDetailOderListItemInfo(String colId, String code,
			String codeNm) {
		super();
		this.colId = colId;
		this.code = code;
		this.codeNm = codeNm;
	}
	public String getColId() {
		return colId;
	}
	public void setColId(String colId) {
		this.colId = colId;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getCodeNm() {
		return codeNm;
	}
	public void setCodeNm(String codeNm) {
		this.codeNm = codeNm;
	}
	
}
