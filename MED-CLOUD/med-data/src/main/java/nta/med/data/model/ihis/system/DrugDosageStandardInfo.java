package nta.med.data.model.ihis.system;

public class DrugDosageStandardInfo implements DrugKinkiInterface {
	private String drugId ;
	private String branchNumber ;
	private String dosageBranchNumber ;
	private String a44 ;
	private String a45 ;
	private String a46 ;
	private String a47 ;
	private String a48 ;
	private String a49 ;
	private String a50 ;
	private String a51 ;
	private String a52 ;
	private String a53 ;
	private String a54 ;
	private String a55 ;
	private String a56 ;
	private String a57 ;
	private String a58 ;
	private String a59 ;
	private String a60 ;
	private String a61 ;
	private String a62 ;
	private String a63 ;
	private String a64 ;
	private String a65 ;
	private String a66 ;
	private String a67 ;
	private String a68 ;
	private String a69 ;
	private String a70 ;
	private String a71 ;
	private String a72 ;
	@Override
	public String toString() {
		return drugId + "," + branchNumber + "," + dosageBranchNumber + ","
				+ a44 + "," + a45 + "," + a46 + "," + a47 + "," + a48
				+ "," + a49 + "," + a50 + "," + a51 + "," + a52 + ","
				+ a53 + "," + a54 + "," + a55 + "," + a56 + "," + a57
				+ "," + a58 + "," + a59 + "," + a60 + "," + a61 + ","
				+ a62 + "," + a63 + "," + a64 + "," + a65 + "," + a66
				+ "," + a67 + "," + a68 + "," + a69 + "," + a70 + ","
				+ a71 + "," + a72;
	}
	
	public String convertToRowCsv() {
		StringBuilder rowCsv = new StringBuilder();
		
		rowCsv.append(drugId); 
		rowCsv.append(",");
		rowCsv.append(branchNumber); 
		rowCsv.append(",");
		rowCsv.append(dosageBranchNumber);
		rowCsv.append(",");
		rowCsv.append(a44);
		rowCsv.append(","); 
		rowCsv.append(a45);
		rowCsv.append(","); 
		rowCsv.append(a46);
		rowCsv.append(","); 
		rowCsv.append(a47);
		rowCsv.append(","); 
		rowCsv.append(a48);
		rowCsv.append(",");
		rowCsv.append(a49);
		rowCsv.append(","); 
		rowCsv.append(a50);
		rowCsv.append(","); 
		rowCsv.append(a51);
		rowCsv.append(","); 
		rowCsv.append(a52);
		rowCsv.append(",");
		rowCsv.append(a53);
		rowCsv.append(","); 
		rowCsv.append(a54);
		rowCsv.append(","); 
		rowCsv.append(a55);
		rowCsv.append(","); 
		rowCsv.append(a56);
		rowCsv.append(","); 
		rowCsv.append(a57);
		rowCsv.append(",");
		rowCsv.append(a58);
		rowCsv.append(","); 
		rowCsv.append(a59);
		rowCsv.append(","); 
		rowCsv.append(a60);
		rowCsv.append(","); 
		rowCsv.append(a61);
		rowCsv.append(",");
		rowCsv.append(a62);
		rowCsv.append(","); 
		rowCsv.append(a63);
		rowCsv.append(","); 
		rowCsv.append(a64);
		rowCsv.append(","); 
		rowCsv.append(a65);
		rowCsv.append(","); 
		rowCsv.append(a66);
		rowCsv.append(",");
		rowCsv.append(a67);
		rowCsv.append(","); 
		rowCsv.append(a68);
		rowCsv.append(","); 
		rowCsv.append(a69);
		rowCsv.append(","); 
		rowCsv.append(a70);
		rowCsv.append(",");
		rowCsv.append(a71);
		rowCsv.append(","); 
		rowCsv.append(a72);
		
		return rowCsv.toString();
	}

	@Override
	public String[] convertItemToArray() {


		return (new String[]{drugId, branchNumber, dosageBranchNumber, a44, a45, a46, a47, a48, a49, a50, a51, a52, a53, a54, a55,
				a56, a57, a58, a58, a59, a60, a61, a62 ,a63, a69, a65, a66, a67, a68, a69, a70, a71, a72 });
	}

	public DrugDosageStandardInfo(String drugId, String branchNumber,
			String dosageBranchNumber, String a44, String a45, String a46,
			String a47, String a48, String a49, String a50, String a51,
			String a52, String a53, String a54, String a55, String a56,
			String a57, String a58, String a59, String a60, String a61,
			String a62, String a63, String a64, String a65, String a66,
			String a67, String a68, String a69, String a70, String a71,
			String a72) {
		super();
		this.drugId = drugId;
		this.branchNumber = branchNumber;
		this.dosageBranchNumber = dosageBranchNumber;
		this.a44 = a44;
		this.a45 = a45;
		this.a46 = a46;
		this.a47 = a47;
		this.a48 = a48;
		this.a49 = a49;
		this.a50 = a50;
		this.a51 = a51;
		this.a52 = a52;
		this.a53 = a53;
		this.a54 = a54;
		this.a55 = a55;
		this.a56 = a56;
		this.a57 = a57;
		this.a58 = a58;
		this.a59 = a59;
		this.a60 = a60;
		this.a61 = a61;
		this.a62 = a62;
		this.a63 = a63;
		this.a64 = a64;
		this.a65 = a65;
		this.a66 = a66;
		this.a67 = a67;
		this.a68 = a68;
		this.a69 = a69;
		this.a70 = a70;
		this.a71 = a71;
		this.a72 = a72;
	}
	public String getDrugId() {
		return drugId;
	}
	public void setDrugId(String drugId) {
		this.drugId = drugId;
	}
	public String getBranchNumber() {
		return branchNumber;
	}
	public void setBranchNumber(String branchNumber) {
		this.branchNumber = branchNumber;
	}
	public String getDosageBranchNumber() {
		return dosageBranchNumber;
	}
	public void setDosageBranchNumber(String dosageBranchNumber) {
		this.dosageBranchNumber = dosageBranchNumber;
	}
	public String getA44() {
		return a44;
	}
	public void setA44(String a44) {
		this.a44 = a44;
	}
	public String getA45() {
		return a45;
	}
	public void setA45(String a45) {
		this.a45 = a45;
	}
	public String getA46() {
		return a46;
	}
	public void setA46(String a46) {
		this.a46 = a46;
	}
	public String getA47() {
		return a47;
	}
	public void setA47(String a47) {
		this.a47 = a47;
	}
	public String getA48() {
		return a48;
	}
	public void setA48(String a48) {
		this.a48 = a48;
	}
	public String getA49() {
		return a49;
	}
	public void setA49(String a49) {
		this.a49 = a49;
	}
	public String getA50() {
		return a50;
	}
	public void setA50(String a50) {
		this.a50 = a50;
	}
	public String getA51() {
		return a51;
	}
	public void setA51(String a51) {
		this.a51 = a51;
	}
	public String getA52() {
		return a52;
	}
	public void setA52(String a52) {
		this.a52 = a52;
	}
	public String getA53() {
		return a53;
	}
	public void setA53(String a53) {
		this.a53 = a53;
	}
	public String getA54() {
		return a54;
	}
	public void setA54(String a54) {
		this.a54 = a54;
	}
	public String getA55() {
		return a55;
	}
	public void setA55(String a55) {
		this.a55 = a55;
	}
	public String getA56() {
		return a56;
	}
	public void setA56(String a56) {
		this.a56 = a56;
	}
	public String getA57() {
		return a57;
	}
	public void setA57(String a57) {
		this.a57 = a57;
	}
	public String getA58() {
		return a58;
	}
	public void setA58(String a58) {
		this.a58 = a58;
	}
	public String getA59() {
		return a59;
	}
	public void setA59(String a59) {
		this.a59 = a59;
	}
	public String getA60() {
		return a60;
	}
	public void setA60(String a60) {
		this.a60 = a60;
	}
	public String getA61() {
		return a61;
	}
	public void setA61(String a61) {
		this.a61 = a61;
	}
	public String getA62() {
		return a62;
	}
	public void setA62(String a62) {
		this.a62 = a62;
	}
	public String getA63() {
		return a63;
	}
	public void setA63(String a63) {
		this.a63 = a63;
	}
	public String getA64() {
		return a64;
	}
	public void setA64(String a64) {
		this.a64 = a64;
	}
	public String getA65() {
		return a65;
	}
	public void setA65(String a65) {
		this.a65 = a65;
	}
	public String getA66() {
		return a66;
	}
	public void setA66(String a66) {
		this.a66 = a66;
	}
	public String getA67() {
		return a67;
	}
	public void setA67(String a67) {
		this.a67 = a67;
	}
	public String getA68() {
		return a68;
	}
	public void setA68(String a68) {
		this.a68 = a68;
	}
	public String getA69() {
		return a69;
	}
	public void setA69(String a69) {
		this.a69 = a69;
	}
	public String getA70() {
		return a70;
	}
	public void setA70(String a70) {
		this.a70 = a70;
	}
	public String getA71() {
		return a71;
	}
	public void setA71(String a71) {
		this.a71 = a71;
	}
	public String getA72() {
		return a72;
	}
	public void setA72(String a72) {
		this.a72 = a72;
	}

}
