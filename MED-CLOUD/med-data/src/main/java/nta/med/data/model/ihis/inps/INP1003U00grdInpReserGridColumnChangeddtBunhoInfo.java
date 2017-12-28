package nta.med.data.model.ihis.inps;

/**
 * @author vnc.tuyen
 */
public class INP1003U00grdInpReserGridColumnChangeddtBunhoInfo {
	private String suname;
    private String tel;
    private String deleteYn;
    
	public INP1003U00grdInpReserGridColumnChangeddtBunhoInfo(String suname, String tel, String deleteYn) {
		super();
		this.suname = suname;
		this.tel = tel;
		this.deleteYn = deleteYn;
	}
	
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getTel() {
		return tel;
	}
	public void setTel(String tel) {
		this.tel = tel;
	}
	public String getDeleteYn() {
		return deleteYn;
	}
	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}
    
}
