package nta.med.data.model.ihis.system;

public class OBGetJundaTable1Info {
	private String jundalTableOut          ;
	private String jundalPartOut           ;
	private String movePart                 ;
	private String jundalTableInp          ;
	private String jundalPartInp           ;
	public OBGetJundaTable1Info(String jundalTableOut, String jundalPartOut,
			String movePart, String jundalTableInp, String jundalPartInp) {
		super();
		this.jundalTableOut = jundalTableOut;
		this.jundalPartOut = jundalPartOut;
		this.movePart = movePart;
		this.jundalTableInp = jundalTableInp;
		this.jundalPartInp = jundalPartInp;
	}
	public String getJundalTableOut() {
		return jundalTableOut;
	}
	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}
	public String getJundalPartOut() {
		return jundalPartOut;
	}
	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}
	public String getMovePart() {
		return movePart;
	}
	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}
	public String getJundalTableInp() {
		return jundalTableInp;
	}
	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}
	public String getJundalPartInp() {
		return jundalPartInp;
	}
	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}
	

}
