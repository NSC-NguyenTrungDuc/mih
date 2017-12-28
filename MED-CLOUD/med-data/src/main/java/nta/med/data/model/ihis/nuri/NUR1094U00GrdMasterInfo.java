package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1094U00GrdMasterInfo {

	private Double pknur1094;
	private Double fkinp1001;
	private Date createDate;
	private String inputId;
	private String inputIdName;
	private Double sumScore;
	private String levelScore;
	private String levelScoreName;
	private String remark;

	public NUR1094U00GrdMasterInfo(Double pknur1094, Double fkinp1001, Date createDate, String inputId,
			String inputIdName, Double sumScore, String levelScore, String levelScoreName, String remark) {
		super();
		this.pknur1094 = pknur1094;
		this.fkinp1001 = fkinp1001;
		this.createDate = createDate;
		this.inputId = inputId;
		this.inputIdName = inputIdName;
		this.sumScore = sumScore;
		this.levelScore = levelScore;
		this.levelScoreName = levelScoreName;
		this.remark = remark;
	}

	public Double getPknur1094() {
		return pknur1094;
	}

	public void setPknur1094(Double pknur1094) {
		this.pknur1094 = pknur1094;
	}

	public Double getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getCreateDate() {
		return createDate;
	}

	public void setCreateDate(Date createDate) {
		this.createDate = createDate;
	}

	public String getInputId() {
		return inputId;
	}

	public void setInputId(String inputId) {
		this.inputId = inputId;
	}

	public String getInputIdName() {
		return inputIdName;
	}

	public void setInputIdName(String inputIdName) {
		this.inputIdName = inputIdName;
	}

	public Double getSumScore() {
		return sumScore;
	}

	public void setSumScore(Double sumScore) {
		this.sumScore = sumScore;
	}

	public String getLevelScore() {
		return levelScore;
	}

	public void setLevelScore(String levelScore) {
		this.levelScore = levelScore;
	}

	public String getLevelScoreName() {
		return levelScoreName;
	}

	public void setLevelScoreName(String levelScoreName) {
		this.levelScoreName = levelScoreName;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

}
