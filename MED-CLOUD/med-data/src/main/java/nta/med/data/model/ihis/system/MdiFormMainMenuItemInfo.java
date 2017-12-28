package nta.med.data.model.ihis.system;

public class MdiFormMainMenuItemInfo {
	private String pgmSysId;
    private String pgmId;
	public MdiFormMainMenuItemInfo(String pgmSysId, String pgmId) {
		super();
		this.pgmSysId = pgmSysId;
		this.pgmId = pgmId;
	}
	public String getPgmSysId() {
		return pgmSysId;
	}
	public void setPgmSysId(String pgmSysId) {
		this.pgmSysId = pgmSysId;
	}
	public String getPgmId() {
		return pgmId;
	}
	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}
}
