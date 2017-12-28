package nta.med.data.model.ihis.system;

import java.util.Date;

public class DrugCheckingInfo implements DrugKinkiInterface  {

	private String drugId;

	private String branchNumber;

	private String a3;

	private String a4;

	private String a5;

	private String a6;

	private String a7;

	private String a8;

	private String a9;

	private String yjCode;

	private String a11;

	private String a12;

	private String a13;

	private String a14;

	private String a15;

	private String a16;

	private String a17;

	private String a18;

	private int a19;

	private String a20;

	private int a21;

	private int a22;

	private String a23;

	private String a24;

	private Date a25;

	private Date a26;

	private Date a27;

	private Date a28;
	
	
	
	public DrugCheckingInfo() {
		super();
	}

	public DrugCheckingInfo(String drugId, String branchNumber, String a3, String a4, String a5, String a6, String a7,
			String a8, String a9, String yjCode, String a11, String a12, String a13, String a14, String a15, String a16,
			String a17, String a18, int a19, String a20, int a21, int a22, String a23, String a24, Date a25, Date a26,
			Date a27, Date a28) {
		super();
		this.drugId = drugId;
		this.branchNumber = branchNumber;
		this.a3 = a3;
		this.a4 = a4;
		this.a5 = a5;
		this.a6 = a6;
		this.a7 = a7;
		this.a8 = a8;
		this.a9 = a9;
		this.yjCode = yjCode;
		this.a11 = a11;
		this.a12 = a12;
		this.a13 = a13;
		this.a14 = a14;
		this.a15 = a15;
		this.a16 = a16;
		this.a17 = a17;
		this.a18 = a18;
		this.a19 = a19;
		this.a20 = a20;
		this.a21 = a21;
		this.a22 = a22;
		this.a23 = a23;
		this.a24 = a24;
		this.a25 = a25;
		this.a26 = a26;
		this.a27 = a27;
		this.a28 = a28;
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

	public String getA3() {
		return a3;
	}

	public void setA3(String a3) {
		this.a3 = a3;
	}

	public String getA4() {
		return a4;
	}

	public void setA4(String a4) {
		this.a4 = a4;
	}

	public String getA5() {
		return a5;
	}

	public void setA5(String a5) {
		this.a5 = a5;
	}

	public String getA6() {
		return a6;
	}

	public void setA6(String a6) {
		this.a6 = a6;
	}

	public String getA7() {
		return a7;
	}

	public void setA7(String a7) {
		this.a7 = a7;
	}

	public String getA8() {
		return a8;
	}

	public void setA8(String a8) {
		this.a8 = a8;
	}

	public String getA9() {
		return a9;
	}

	public void setA9(String a9) {
		this.a9 = a9;
	}

	public String getYjCode() {
		return yjCode;
	}

	public void setYjCode(String yjCode) {
		this.yjCode = yjCode;
	}

	public String getA11() {
		return a11;
	}

	public void setA11(String a11) {
		this.a11 = a11;
	}

	public String getA12() {
		return a12;
	}

	public void setA12(String a12) {
		this.a12 = a12;
	}

	public String getA13() {
		return a13;
	}

	public void setA13(String a13) {
		this.a13 = a13;
	}

	public String getA14() {
		return a14;
	}

	public void setA14(String a14) {
		this.a14 = a14;
	}

	public String getA15() {
		return a15;
	}

	public void setA15(String a15) {
		this.a15 = a15;
	}

	public String getA16() {
		return a16;
	}

	public void setA16(String a16) {
		this.a16 = a16;
	}

	public String getA17() {
		return a17;
	}

	public void setA17(String a17) {
		this.a17 = a17;
	}

	public String getA18() {
		return a18;
	}

	public void setA18(String a18) {
		this.a18 = a18;
	}

	public int getA19() {
		return a19;
	}

	public void setA19(int a19) {
		this.a19 = a19;
	}

	public String getA20() {
		return a20;
	}

	public void setA20(String a20) {
		this.a20 = a20;
	}

	public int getA21() {
		return a21;
	}

	public void setA21(int a21) {
		this.a21 = a21;
	}

	public int getA22() {
		return a22;
	}

	public void setA22(int a22) {
		this.a22 = a22;
	}

	public String getA23() {
		return a23;
	}

	public void setA23(String a23) {
		this.a23 = a23;
	}

	public String getA24() {
		return a24;
	}

	public void setA24(String a24) {
		this.a24 = a24;
	}

	public Date getA25() {
		return a25;
	}

	public void setA25(Date a25) {
		this.a25 = a25;
	}

	public Date getA26() {
		return a26;
	}

	public void setA26(Date a26) {
		this.a26 = a26;
	}

	public Date getA27() {
		return a27;
	}

	public void setA27(Date a27) {
		this.a27 = a27;
	}

	public Date getA28() {
		return a28;
	}

	public void setA28(Date a28) {
		this.a28 = a28;
	}
	
	public String convertToRowCsv() {
		
		StringBuilder rowCsv = new StringBuilder();
		rowCsv.append(drugId);
		rowCsv.append(",");
		rowCsv.append(branchNumber);
		rowCsv.append(",");
		rowCsv.append(a3);
		rowCsv.append(",");
		rowCsv.append(a4);
		rowCsv.append(",");
		rowCsv.append(a5);
		rowCsv.append(",");
		rowCsv.append(a6);
		rowCsv.append(",");
		rowCsv.append(a7);
		rowCsv.append(",");
		rowCsv.append(a8);
		rowCsv.append(",");
		rowCsv.append(a9);
		rowCsv.append(",");
		rowCsv.append(yjCode);
		rowCsv.append(",");
		rowCsv.append(a11);
		rowCsv.append(",");
		rowCsv.append(a12);
		rowCsv.append(",");
		rowCsv.append(a13);
		rowCsv.append(",");
		rowCsv.append(a14);
		rowCsv.append(",");
		rowCsv.append(a15);
		rowCsv.append(",");
		rowCsv.append(a16);
		rowCsv.append(",");
		rowCsv.append(a17);
		rowCsv.append(",");
		rowCsv.append(a18);
		rowCsv.append(",");
		rowCsv.append(a19);
		rowCsv.append(",");
		rowCsv.append(a20);
		rowCsv.append(",");
		rowCsv.append(a21);
		rowCsv.append(",");
		rowCsv.append(a22);
		rowCsv.append(",");
		rowCsv.append(a23);
		rowCsv.append(",");
		rowCsv.append(a24);
		rowCsv.append(",");
		rowCsv.append(a25);
		rowCsv.append(",");
		rowCsv.append(a26);
		rowCsv.append(",");
		rowCsv.append(a27);
		rowCsv.append(",");
		rowCsv.append(a28);
		
		return rowCsv.toString();
	}


	@Override
	public String[] convertItemToArray() {
		return (new String[]{drugId, branchNumber,a3, a4, a5, a6, a7, a8, a9, yjCode, a11, a12, a13, a14, a15, a16, a17,
				a18, String.valueOf(a19), a20, String.valueOf(a21), String.valueOf(a22), a23, a24, String.valueOf(a25), String.valueOf(a26), String.valueOf(a27), String.valueOf(a28)});
	}

}
