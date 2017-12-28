package nta.med.data.model.ihis.inps;

public class INP1003U00SaveLayoutChkBunhoInfo {
	private String deleteYn;
	private String jubsuBreak;
	private String codeName;
	public INP1003U00SaveLayoutChkBunhoInfo(String deleteYn, String jubsuBreak, String codeName) {
		super();
		this.deleteYn = deleteYn;
		this.jubsuBreak = jubsuBreak;
		this.codeName = codeName;
	}
	public String getDeleteYn() {
		return deleteYn;
	}
	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}
	public String getJubsuBreak() {
		return jubsuBreak;
	}
	public void setJubsuBreak(String jubsuBreak) {
		this.jubsuBreak = jubsuBreak;
	}
	public String getCodeName() {
		return codeName;
	}
	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}
	
}
