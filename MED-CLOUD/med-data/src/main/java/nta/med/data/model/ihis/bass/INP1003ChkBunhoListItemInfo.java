package nta.med.data.model.ihis.bass;

public class INP1003ChkBunhoListItemInfo {
	private String deleteYn;
	private String jubsuBreak;
	private String codeName;
	
	public INP1003ChkBunhoListItemInfo(String deleteYn, String jubsuBreak,
			String codeName) {
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
