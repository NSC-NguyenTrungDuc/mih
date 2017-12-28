package nta.med.data.model.ihis.ocsa;

public class OcsaOCS0503U00ValidationCheckInfo {
	private String naewon ;
	private String orderYn ;
	public OcsaOCS0503U00ValidationCheckInfo(String naewon,String orderYn){
		super();
		this.naewon=naewon;
		this.orderYn=orderYn;
	}
	public String getNaewon() {
		return naewon;
	}
	public void setNaewon(String naewon) {
		this.naewon = naewon;
	}
	public String getOrderYn() {
		return orderYn;
	}
	public void setOrderYn(String orderYn) {
		this.orderYn = orderYn;
	}
	
	
}
