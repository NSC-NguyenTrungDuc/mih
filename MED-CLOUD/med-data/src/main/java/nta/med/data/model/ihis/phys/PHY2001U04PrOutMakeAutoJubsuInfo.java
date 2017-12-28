package nta.med.data.model.ihis.phys;

public class PHY2001U04PrOutMakeAutoJubsuInfo {
	private Double ioNewPkout1001;
	private String ioErr ;
	
	public PHY2001U04PrOutMakeAutoJubsuInfo(){
		
	}
	public PHY2001U04PrOutMakeAutoJubsuInfo(Double ioNewPkout1001, String ioErr) {
		super();
		this.ioNewPkout1001 = ioNewPkout1001;
		this.ioErr = ioErr;
	}
	public Double getIoNewPkout1001() {
		return ioNewPkout1001;
	}
	public void setIoNewPkout1001(Double ioNewPkout1001) {
		this.ioNewPkout1001 = ioNewPkout1001;
	}
	public String getIoErr() {
		return ioErr;
	}
	public void setIoErr(String ioErr) {
		this.ioErr = ioErr;
	}
}
