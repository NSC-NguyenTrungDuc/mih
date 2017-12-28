package nta.med.data.model.ihis.system;

import javax.jws.soap.InitParam;

/**
 * The persistent class for the DRUG_DOSAGE database table.
 * 
 */

public class DrugDosageMasterInfo implements DrugKinkiInterface {
	
	// D1.DRUG_ID, D1.BRANCH_NUMBER, D1.DOSAGE_BRANCH_NUMBER
	private String drugId;
	private String branchNumber;
	private String dosageBranchNumber;

	// begin DRUG_DOSAGE
	private Integer a4;
	private Integer a5;
	private String adaptation;
	private String adaptationRelated;
	private String a8;
	private String ageClassification;
	private String appropriate;
	private String appropriateCondition;
	private String a12;
	private String a13;
	private String oneDose;

	// begin DRUG_DOSAGE_NORMAL
	private String dailyDose;
	private String dailyDoseContent;
	private String doseForm;
	private String dailyDoseForm;
	private String dosageFormUnit;
	private String dailyNumberDoses;
	private String a21;
	private String a22;
	private String a23;
	private String a24;
	private String a25;
	private String a26;
	private String a27;
	private String a28;
	private String a29;
	private String a30;
	private String a31;
	private String a32;
	private String a33;
	private String a34;
	private String a35;
	private String a36;
	private String a37;
	private String a38;
	private String a39;
	private String a40;
	private String a41;
	private String a42;
	private String a43;

	// begin DRUG_DOSAGE_STANDARD
	private String a44;
	private String a45;
	private String a46;
	private String a47;
	private String a48;
	private String a49;
	private String a50;
	private String a51;
	private String a52;
	private String a53;
	private String a54;
	private String a55;
	private String a56;
	private String a57;
	private String a58;
	private String a59;
	private String a60;
	private String a61;
	private String a62;
	private String a63;
	private String a64;
	private String a65;
	private String a66;
	private String a67;
	private String a68;
	private String a69;
	private String a70;
	private String a71;
	private String a72;

	// begin DRUG_DOSAGE_ADDITION
	private String a73;
	private String a74;
	private String a75;
	private String a76;
	private String a77;
	private String a78;
	private String a79;
	private String a80;
	private String a81;
	private String a82;
	private String a83;
	private String a84;
	private String a85;
	private String a86;
	private String a87;
	private String a88;
	private String a89;
	private String a90;
	private String a91;
	private String a92;
	private String a93;
	private String a94;
	private String a95;
	private String a96;
	private String a97;
	private String a98;
	private String a99;
	private String a100;
	private String a101;
	
	public DrugDosageMasterInfo(String drugId, String branchNumber,
			String dosageBranchNumber, Integer a4, Integer a5,
			String adaptation, String adaptationRelated, String a8,
			String ageClassification, String appropriate,
			String appropriateCondition, String a12, String a13,
			String oneDose, String dailyDose, String dailyDoseContent,
			String doseForm, String dailyDoseForm, String dosageFormUnit,
			String dailyNumberDoses, String a21, String a22, String a23,
			String a24, String a25, String a26, String a27, String a28,
			String a29, String a30, String a31, String a32, String a33,
			String a34, String a35, String a36, String a37, String a38,
			String a39, String a40, String a41, String a42, String a43,
			String a44, String a45, String a46, String a47, String a48,
			String a49, String a50, String a51, String a52, String a53,
			String a54, String a55, String a56, String a57, String a58,
			String a59, String a60, String a61, String a62, String a63,
			String a64, String a65, String a66, String a67, String a68,
			String a69, String a70, String a71, String a72, String a73,
			String a74, String a75, String a76, String a77, String a78,
			String a79, String a80, String a81, String a82, String a83,
			String a84, String a85, String a86, String a87, String a88,
			String a89, String a90, String a91, String a92, String a93,
			String a94, String a95, String a96, String a97, String a98,
			String a99, String a100, String a101) {
		super();
		this.drugId = drugId;
		this.branchNumber = branchNumber;
		this.dosageBranchNumber = dosageBranchNumber;
		this.a4 = a4;
		this.a5 = a5;
		this.adaptation = adaptation;
		this.adaptationRelated = adaptationRelated;
		this.a8 = a8;
		this.ageClassification = ageClassification;
		this.appropriate = appropriate;
		this.appropriateCondition = appropriateCondition;
		this.a12 = a12;
		this.a13 = a13;
		this.oneDose = oneDose;
		this.dailyDose = dailyDose;
		this.dailyDoseContent = dailyDoseContent;
		this.doseForm = doseForm;
		this.dailyDoseForm = dailyDoseForm;
		this.dosageFormUnit = dosageFormUnit;
		this.dailyNumberDoses = dailyNumberDoses;
		this.a21 = a21;
		this.a22 = a22;
		this.a23 = a23;
		this.a24 = a24;
		this.a25 = a25;
		this.a26 = a26;
		this.a27 = a27;
		this.a28 = a28;
		this.a29 = a29;
		this.a30 = a30;
		this.a31 = a31;
		this.a32 = a32;
		this.a33 = a33;
		this.a34 = a34;
		this.a35 = a35;
		this.a36 = a36;
		this.a37 = a37;
		this.a38 = a38;
		this.a39 = a39;
		this.a40 = a40;
		this.a41 = a41;
		this.a42 = a42;
		this.a43 = a43;
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
		this.a73 = a73;
		this.a74 = a74;
		this.a75 = a75;
		this.a76 = a76;
		this.a77 = a77;
		this.a78 = a78;
		this.a79 = a79;
		this.a80 = a80;
		this.a81 = a81;
		this.a82 = a82;
		this.a83 = a83;
		this.a84 = a84;
		this.a85 = a85;
		this.a86 = a86;
		this.a87 = a87;
		this.a88 = a88;
		this.a89 = a89;
		this.a90 = a90;
		this.a91 = a91;
		this.a92 = a92;
		this.a93 = a93;
		this.a94 = a94;
		this.a95 = a95;
		this.a96 = a96;
		this.a97 = a97;
		this.a98 = a98;
		this.a99 = a99;
		this.a100 = a100;
		this.a101 = a101;
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

	public Integer getA4() {
		return a4;
	}

	public void setA4(Integer a4) {
		this.a4 = a4;
	}

	public Integer getA5() {
		return a5;
	}

	public void setA5(Integer a5) {
		this.a5 = a5;
	}

	public String getAdaptation() {
		return adaptation;
	}

	public void setAdaptation(String adaptation) {
		this.adaptation = adaptation;
	}

	public String getAdaptationRelated() {
		return adaptationRelated;
	}

	public void setAdaptationRelated(String adaptationRelated) {
		this.adaptationRelated = adaptationRelated;
	}

	public String getA8() {
		return a8;
	}

	public void setA8(String a8) {
		this.a8 = a8;
	}

	public String getAgeClassification() {
		return ageClassification;
	}

	public void setAgeClassification(String ageClassification) {
		this.ageClassification = ageClassification;
	}

	public String getAppropriate() {
		return appropriate;
	}

	public void setAppropriate(String appropriate) {
		this.appropriate = appropriate;
	}

	public String getAppropriateCondition() {
		return appropriateCondition;
	}

	public void setAppropriateCondition(String appropriateCondition) {
		this.appropriateCondition = appropriateCondition;
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

	public String getOneDose() {
		return oneDose;
	}

	public void setOneDose(String oneDose) {
		this.oneDose = oneDose;
	}

	public String getDailyDose() {
		return dailyDose;
	}

	public void setDailyDose(String dailyDose) {
		this.dailyDose = dailyDose;
	}

	public String getDailyDoseContent() {
		return dailyDoseContent;
	}

	public void setDailyDoseContent(String dailyDoseContent) {
		this.dailyDoseContent = dailyDoseContent;
	}

	public String getDoseForm() {
		return doseForm;
	}

	public void setDoseForm(String doseForm) {
		this.doseForm = doseForm;
	}

	public String getDailyDoseForm() {
		return dailyDoseForm;
	}

	public void setDailyDoseForm(String dailyDoseForm) {
		this.dailyDoseForm = dailyDoseForm;
	}

	public String getDosageFormUnit() {
		return dosageFormUnit;
	}

	public void setDosageFormUnit(String dosageFormUnit) {
		this.dosageFormUnit = dosageFormUnit;
	}

	public String getDailyNumberDoses() {
		return dailyNumberDoses;
	}

	public void setDailyNumberDoses(String dailyNumberDoses) {
		this.dailyNumberDoses = dailyNumberDoses;
	}

	public String getA21() {
		return a21;
	}

	public void setA21(String a21) {
		this.a21 = a21;
	}

	public String getA22() {
		return a22;
	}

	public void setA22(String a22) {
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

	public String getA25() {
		return a25;
	}

	public void setA25(String a25) {
		this.a25 = a25;
	}

	public String getA26() {
		return a26;
	}

	public void setA26(String a26) {
		this.a26 = a26;
	}

	public String getA27() {
		return a27;
	}

	public void setA27(String a27) {
		this.a27 = a27;
	}

	public String getA28() {
		return a28;
	}

	public void setA28(String a28) {
		this.a28 = a28;
	}

	public String getA29() {
		return a29;
	}

	public void setA29(String a29) {
		this.a29 = a29;
	}

	public String getA30() {
		return a30;
	}

	public void setA30(String a30) {
		this.a30 = a30;
	}

	public String getA31() {
		return a31;
	}

	public void setA31(String a31) {
		this.a31 = a31;
	}

	public String getA32() {
		return a32;
	}

	public void setA32(String a32) {
		this.a32 = a32;
	}

	public String getA33() {
		return a33;
	}

	public void setA33(String a33) {
		this.a33 = a33;
	}

	public String getA34() {
		return a34;
	}

	public void setA34(String a34) {
		this.a34 = a34;
	}

	public String getA35() {
		return a35;
	}

	public void setA35(String a35) {
		this.a35 = a35;
	}

	public String getA36() {
		return a36;
	}

	public void setA36(String a36) {
		this.a36 = a36;
	}

	public String getA37() {
		return a37;
	}

	public void setA37(String a37) {
		this.a37 = a37;
	}

	public String getA38() {
		return a38;
	}

	public void setA38(String a38) {
		this.a38 = a38;
	}

	public String getA39() {
		return a39;
	}

	public void setA39(String a39) {
		this.a39 = a39;
	}

	public String getA40() {
		return a40;
	}

	public void setA40(String a40) {
		this.a40 = a40;
	}

	public String getA41() {
		return a41;
	}

	public void setA41(String a41) {
		this.a41 = a41;
	}

	public String getA42() {
		return a42;
	}

	public void setA42(String a42) {
		this.a42 = a42;
	}

	public String getA43() {
		return a43;
	}

	public void setA43(String a43) {
		this.a43 = a43;
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

	public String getA73() {
		return a73;
	}

	public void setA73(String a73) {
		this.a73 = a73;
	}

	public String getA74() {
		return a74;
	}

	public void setA74(String a74) {
		this.a74 = a74;
	}

	public String getA75() {
		return a75;
	}

	public void setA75(String a75) {
		this.a75 = a75;
	}

	public String getA76() {
		return a76;
	}

	public void setA76(String a76) {
		this.a76 = a76;
	}

	public String getA77() {
		return a77;
	}

	public void setA77(String a77) {
		this.a77 = a77;
	}

	public String getA78() {
		return a78;
	}

	public void setA78(String a78) {
		this.a78 = a78;
	}

	public String getA79() {
		return a79;
	}

	public void setA79(String a79) {
		this.a79 = a79;
	}

	public String getA80() {
		return a80;
	}

	public void setA80(String a80) {
		this.a80 = a80;
	}

	public String getA81() {
		return a81;
	}

	public void setA81(String a81) {
		this.a81 = a81;
	}

	public String getA82() {
		return a82;
	}

	public void setA82(String a82) {
		this.a82 = a82;
	}

	public String getA83() {
		return a83;
	}

	public void setA83(String a83) {
		this.a83 = a83;
	}

	public String getA84() {
		return a84;
	}

	public void setA84(String a84) {
		this.a84 = a84;
	}

	public String getA85() {
		return a85;
	}

	public void setA85(String a85) {
		this.a85 = a85;
	}

	public String getA86() {
		return a86;
	}

	public void setA86(String a86) {
		this.a86 = a86;
	}

	public String getA87() {
		return a87;
	}

	public void setA87(String a87) {
		this.a87 = a87;
	}

	public String getA88() {
		return a88;
	}

	public void setA88(String a88) {
		this.a88 = a88;
	}

	public String getA89() {
		return a89;
	}

	public void setA89(String a89) {
		this.a89 = a89;
	}

	public String getA90() {
		return a90;
	}

	public void setA90(String a90) {
		this.a90 = a90;
	}

	public String getA91() {
		return a91;
	}

	public void setA91(String a91) {
		this.a91 = a91;
	}

	public String getA92() {
		return a92;
	}

	public void setA92(String a92) {
		this.a92 = a92;
	}

	public String getA93() {
		return a93;
	}

	public void setA93(String a93) {
		this.a93 = a93;
	}

	public String getA94() {
		return a94;
	}

	public void setA94(String a94) {
		this.a94 = a94;
	}

	public String getA95() {
		return a95;
	}

	public void setA95(String a95) {
		this.a95 = a95;
	}

	public String getA96() {
		return a96;
	}

	public void setA96(String a96) {
		this.a96 = a96;
	}

	public String getA97() {
		return a97;
	}

	public void setA97(String a97) {
		this.a97 = a97;
	}

	public String getA98() {
		return a98;
	}

	public void setA98(String a98) {
		this.a98 = a98;
	}

	public String getA99() {
		return a99;
	}

	public void setA99(String a99) {
		this.a99 = a99;
	}

	public String getA100() {
		return a100;
	}

	public void setA100(String a100) {
		this.a100 = a100;
	}

	public String getA101() {
		return a101;
	}

	public void setA101(String a101) {
		this.a101 = a101;
	}

	@Override
	public String[] convertItemToArray() {
		return (new String[]{
				//
				drugId, branchNumber, dosageBranchNumber,
				// begin DRUG_DOSAGE
				String.valueOf(a4), String.valueOf(a5), adaptation, adaptationRelated, a8, ageClassification, appropriate, appropriateCondition, a12, a13, oneDose,
				// begin DRUG_DOSAGE_NORMAL
				dailyDose, dailyDoseContent, doseForm, dailyDoseForm, dosageFormUnit, dailyNumberDoses, a21, a22, a23, a24, a25, a26, a27, a28, 
				a29, a30, a31, a32, a33, a34, a35, a36, a37, a38, a39, a40, a41, a42, a43,
				// begin DRUG_DOSAGE_STANDARD
				a44, a45, a46, a47, a48, a49, a50, a51, a52, a53, a54, a55, a56, a57, a58, a59, a60, a61, a62, a63, a64, a65, a66, a67, a68, a69, a70, a71, a72,
				// begin DRUG_DOSAGE_ADDITION
				a73, a74, a75, a76, a77, a78, a79, a80, a81, a82, a83, a84, a85, a86, a87, a88, a89, a90, a91, a92, a93, a94, a95, a96, a97, a98, a99, a100, a101});
	}
}