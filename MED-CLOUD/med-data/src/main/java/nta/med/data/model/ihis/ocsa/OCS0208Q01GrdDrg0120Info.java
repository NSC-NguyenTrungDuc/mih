package nta.med.data.model.ihis.ocsa;

public class OCS0208Q01GrdDrg0120Info {
	private String bogyongCode ;
	private String bogyongName ;
	private String blockGubun ;
	private String bogyongGubun ;
	public OCS0208Q01GrdDrg0120Info(String bogyongCode, String bogyongName,
			String blockGubun, String bogyongGubun) {
		super();
		this.bogyongCode = bogyongCode;
		this.bogyongName = bogyongName;
		this.blockGubun = blockGubun;
		this.bogyongGubun = bogyongGubun;
	}
	public String getBogyongCode() {
		return bogyongCode;
	}
	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}
	public String getBogyongName() {
		return bogyongName;
	}
	public void setBogyongName(String bogyongName) {
		this.bogyongName = bogyongName;
	}
	public String getBlockGubun() {
		return blockGubun;
	}
	public void setBlockGubun(String blockGubun) {
		this.blockGubun = blockGubun;
	}
	public String getBogyongGubun() {
		return bogyongGubun;
	}
	public void setBogyongGubun(String bogyongGubun) {
		this.bogyongGubun = bogyongGubun;
	}
}
