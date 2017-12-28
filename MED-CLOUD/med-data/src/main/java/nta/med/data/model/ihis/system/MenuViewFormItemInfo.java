package nta.med.data.model.ihis.system;

public class MenuViewFormItemInfo {
	private String menuTp;
    private Double menuLevel;
    private String trId;
    private String menuTitle;
    private String pgmId;
    private String pgmOpenTp;
    private String menuParam;
	public MenuViewFormItemInfo(String menuTp, Double menuLevel, String trId,
			String menuTitle, String pgmId, String pgmOpenTp, String menuParam) {
		super();
		this.menuTp = menuTp;
		this.menuLevel = menuLevel;
		this.trId = trId;
		this.menuTitle = menuTitle;
		this.pgmId = pgmId;
		this.pgmOpenTp = pgmOpenTp;
		this.menuParam = menuParam;
	}
	public String getMenuTp() {
		return menuTp;
	}
	public void setMenuTp(String menuTp) {
		this.menuTp = menuTp;
	}
	public Double getMenuLevel() {
		return menuLevel;
	}
	public void setMenuLevel(Double menuLevel) {
		this.menuLevel = menuLevel;
	}
	public String getTrId() {
		return trId;
	}
	public void setTrId(String trId) {
		this.trId = trId;
	}
	public String getMenuTitle() {
		return menuTitle;
	}
	public void setMenuTitle(String menuTitle) {
		this.menuTitle = menuTitle;
	}
	public String getPgmId() {
		return pgmId;
	}
	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}
	public String getPgmOpenTp() {
		return pgmOpenTp;
	}
	public void setPgmOpenTp(String pgmOpenTp) {
		this.pgmOpenTp = pgmOpenTp;
	}
	public String getMenuParam() {
		return menuParam;
	}
	public void setMenuParam(String menuParam) {
		this.menuParam = menuParam;
	}
}
