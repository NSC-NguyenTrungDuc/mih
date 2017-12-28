package nta.med.data.model.ihis.inps;

public class INP1003U01fbxInp1003Info {
	
	private String output1;
	private String output2;
	private String output3;
	
	public INP1003U01fbxInp1003Info(String output1, String output2, String output3){
		this.output1 = output1;
		this.output2 = output2;
		this.output3 = output3;
	}

	public String getOutput1() {
		return output1;
	}

	public void setOutput1(String output1) {
		this.output1 = output1;
	}

	public String getOutput2() {
		return output2;
	}

	public void setOutput2(String output2) {
		this.output2 = output2;
	}

	public String getOutput3() {
		return output3;
	}

	public void setOutput3(String output3) {
		this.output3 = output3;
	}
	
	
}
