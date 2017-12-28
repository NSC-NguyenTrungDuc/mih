package nta.med.data.model.ihis.nuro;

public class NuroOUT1001U01LoadOUT0105Info {
	private String gongbiCode;
    private Double priority;
    
	public NuroOUT1001U01LoadOUT0105Info(String gongbiCode, Double priority) {
		super();
		this.gongbiCode = gongbiCode;
		this.priority = priority;
	}
	public String getGongbiCode() {
		return gongbiCode;
	}
	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}
	public Double getPriority() {
		return priority;
	}
	public void setPriority(Double priority) {
		this.priority = priority;
	}
    
	
}
