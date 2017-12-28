package nta.med.data.model.ihis.inps;

/**
 * @author vnc.tuyen
 */
public class INP1003U00grdCSC0108Info {
	
	private String code;
	private String codeName;
	private String n;

	public INP1003U00grdCSC0108Info(String code, String codeName, String n) {
		super();
		this.code = code;
		this.codeName = codeName;
		this.n = n;
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
	public String getN() {
		return n;
	}
	public void setN(String n) {
		this.n = n;
	}
	
}
