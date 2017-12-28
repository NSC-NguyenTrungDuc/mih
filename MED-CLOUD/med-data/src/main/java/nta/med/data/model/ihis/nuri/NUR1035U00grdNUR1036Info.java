package nta.med.data.model.ihis.nuri;

public class NUR1035U00grdNUR1036Info {
	private Double fknur1035;
	private String checkDate;
	private String checkTime;
	private String dangerAct;
	private String changedSkin;
	private String edema;
	private String numbness;
	private String scratch;
	private String tubeTrouble;
	private String petechia;
	private String inputId;
	private String inputName;
	private String remark;
	private String dataRowState;
	public NUR1035U00grdNUR1036Info(Double fknur1035, String checkDate, String checkTime, String dangerAct,
			String changedSkin, String edema, String numbness, String scratch, String tubeTrouble, String petechia,
			String inputId, String inputName, String remark, String dataRowState) {
		super();
		this.fknur1035 = fknur1035;
		this.checkDate = checkDate;
		this.checkTime = checkTime;
		this.dangerAct = dangerAct;
		this.changedSkin = changedSkin;
		this.edema = edema;
		this.numbness = numbness;
		this.scratch = scratch;
		this.tubeTrouble = tubeTrouble;
		this.petechia = petechia;
		this.inputId = inputId;
		this.inputName = inputName;
		this.remark = remark;
		this.dataRowState = dataRowState;
	}
	public Double getFknur1035() {
		return fknur1035;
	}
	public void setFknur1035(Double fknur1035) {
		this.fknur1035 = fknur1035;
	}
	public String getCheckDate() {
		return checkDate;
	}
	public void setCheckDate(String checkDate) {
		this.checkDate = checkDate;
	}
	public String getCheckTime() {
		return checkTime;
	}
	public void setCheckTime(String checkTime) {
		this.checkTime = checkTime;
	}
	public String getDangerAct() {
		return dangerAct;
	}
	public void setDangerAct(String dangerAct) {
		this.dangerAct = dangerAct;
	}
	public String getChangedSkin() {
		return changedSkin;
	}
	public void setChangedSkin(String changedSkin) {
		this.changedSkin = changedSkin;
	}
	public String getEdema() {
		return edema;
	}
	public void setEdema(String edema) {
		this.edema = edema;
	}
	public String getNumbness() {
		return numbness;
	}
	public void setNumbness(String numbness) {
		this.numbness = numbness;
	}
	public String getScratch() {
		return scratch;
	}
	public void setScratch(String scratch) {
		this.scratch = scratch;
	}
	public String getTubeTrouble() {
		return tubeTrouble;
	}
	public void setTubeTrouble(String tubeTrouble) {
		this.tubeTrouble = tubeTrouble;
	}
	public String getPetechia() {
		return petechia;
	}
	public void setPetechia(String petechia) {
		this.petechia = petechia;
	}
	public String getInputId() {
		return inputId;
	}
	public void setInputId(String inputId) {
		this.inputId = inputId;
	}
	public String getInputName() {
		return inputName;
	}
	public void setInputName(String inputName) {
		this.inputName = inputName;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getDataRowState() {
		return dataRowState;
	}
	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
}
