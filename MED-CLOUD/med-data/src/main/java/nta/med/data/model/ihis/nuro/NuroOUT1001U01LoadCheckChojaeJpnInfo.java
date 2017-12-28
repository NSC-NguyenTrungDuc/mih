package nta.med.data.model.ihis.nuro;

public class NuroOUT1001U01LoadCheckChojaeJpnInfo {
    private String chojae;         
    private String chtChojae;      
    private String gajubsuGubun;  
    private String err;
    
	public NuroOUT1001U01LoadCheckChojaeJpnInfo(String chojae,
			String chtChojae, String gajubsuGubun, String err) {
		super();
		this.chojae = chojae;
		this.chtChojae = chtChojae;
		this.gajubsuGubun = gajubsuGubun;
		this.err = err;
	}
	public String getChojae() {
		return chojae;
	}
	public void setChojae(String chojae) {
		this.chojae = chojae;
	}
	public String getChtChojae() {
		return chtChojae;
	}
	public void setChtChojae(String chtChojae) {
		this.chtChojae = chtChojae;
	}
	public String getGajubsuGubun() {
		return gajubsuGubun;
	}
	public void setGajubsuGubun(String gajubsuGubun) {
		this.gajubsuGubun = gajubsuGubun;
	}
	public String getErr() {
		return err;
	}
	public void setErr(String err) {
		this.err = err;
	}
    
    
}
