package nta.med.data.model.ihis.system;

import java.math.BigDecimal;

public class DrugKinkiDiseaseInfo implements DrugKinkiInterface  {
	private String kinkiId ;
	private String diseaseName ;
	private String indexTerm ;
	private String standardDiseaseName ;
	private String diseaseCode ;
	private String icd10 ;
	private BigDecimal decisionFlg ;
	private String comment ;
	public DrugKinkiDiseaseInfo(String kinkiId, String diseaseName,
			String indexTerm, String standardDiseaseName, String diseaseCode,
			String icd10, BigDecimal decisionFlg, String comment) {
		super();
		this.kinkiId = kinkiId;
		this.diseaseName = diseaseName;
		this.indexTerm = indexTerm;
		this.standardDiseaseName = standardDiseaseName;
		this.diseaseCode = diseaseCode;
		this.icd10 = icd10;
		this.decisionFlg = decisionFlg;
		this.comment = comment;
	}
	public String getKinkiId() {
		return kinkiId;
	}
	public void setKinkiId(String kinkiId) {
		this.kinkiId = kinkiId;
	}
	public String getDiseaseName() {
		return diseaseName;
	}
	public void setDiseaseName(String diseaseName) {
		this.diseaseName = diseaseName;
	}
	public String getIndexTerm() {
		return indexTerm;
	}
	public void setIndexTerm(String indexTerm) {
		this.indexTerm = indexTerm;
	}
	public String getStandardDiseaseName() {
		return standardDiseaseName;
	}
	public void setStandardDiseaseName(String standardDiseaseName) {
		this.standardDiseaseName = standardDiseaseName;
	}
	public String getDiseaseCode() {
		return diseaseCode;
	}
	public void setDiseaseCode(String diseaseCode) {
		this.diseaseCode = diseaseCode;
	}
	public String getIcd10() {
		return icd10;
	}
	public void setIcd10(String icd10) {
		this.icd10 = icd10;
	}
	public BigDecimal getDecisionFlg() {
		return decisionFlg;
	}
	public void setDecisionFlg(BigDecimal decisionFlg) {
		this.decisionFlg = decisionFlg;
	}
	public String getComment() {
		return comment;
	}
	public void setComment(String comment) {
		this.comment = comment;
	}

	
	public String convertToRowCsv() {
		StringBuilder rowCsv = new StringBuilder();
		rowCsv.append(kinkiId);
		rowCsv.append(",");
		rowCsv.append(diseaseName);
		rowCsv.append(",");
		rowCsv.append(indexTerm);
		rowCsv.append(",");
		rowCsv.append(standardDiseaseName);
		rowCsv.append(",");
		rowCsv.append(diseaseCode);
		rowCsv.append(",");
		rowCsv.append(icd10);
		rowCsv.append(",");
		rowCsv.append(decisionFlg);
		rowCsv.append(",");
		rowCsv.append(comment);
		return rowCsv.toString();
	}

	@Override
	public String[] convertItemToArray() {
		return (new String[]{kinkiId, diseaseName, indexTerm, standardDiseaseName, diseaseCode, icd10, String.valueOf(decisionFlg), comment});
	}
}
