package nta.med.data.model.ihis.nuri;

public class NUR1091Q00layDownListInfo {

	private String codeType;
	private String codeTypeName;
	private Double maxScore;
	private String code;
	private String codeName;
	private Double score;

	public NUR1091Q00layDownListInfo(String codeType, String codeTypeName, Double maxScore, String code,
			String codeName, Double score) {
		super();
		this.codeType = codeType;
		this.codeTypeName = codeTypeName;
		this.maxScore = maxScore;
		this.code = code;
		this.codeName = codeName;
		this.score = score;
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

	public Double getMaxScore() {
		return maxScore;
	}

	public void setMaxScore(Double maxScore) {
		this.maxScore = maxScore;
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

	public Double getScore() {
		return score;
	}

	public void setScore(Double score) {
		this.score = score;
	}

}
