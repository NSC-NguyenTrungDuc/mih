package nta.med.core.utils;

import org.springframework.util.StringUtils;

public class OrcaUtils {

	public static String getInsurCodeByClassCode(String classCode) {
		if(StringUtils.isEmpty(classCode)){
			return "";
		}
		
		String insurCode = "";
		if (classCode.equals("060")) {
			insurCode = "00";
		} else if (classCode.equals("971")) {
			insurCode = "R1";
		} else if (classCode.equals("973")) {
			insurCode = "R3";
		} else if (classCode.equals("975")) {
			insurCode = "K5";
		} else if (classCode.substring(0, 2).equals("98")) {
			insurCode = "Z" + classCode.substring(2, 3);
		} else if (classCode.substring(0, 2).equals("90")) {
			insurCode = "A" + classCode.substring(2, 3);
		} else if (classCode.substring(0, 2).equals("91")) {
			insurCode = "B" + classCode.substring(2, 3);
		} else {
			insurCode = classCode.substring(1, 3);
		}

		return insurCode;
	}
	
	public static String getClassCodeByInsurCode(String insCode){
		if(StringUtils.isEmpty(insCode)){
			return "";
		}
		
		String classCode = "";
		if(insCode.equals("00")){
			classCode = "060";
		} else if(insCode.equals("R1")){
			classCode = "971";
		} else if(insCode.equals("R3")){
			classCode = "973";
		} else if(insCode.equals("K5")){
			classCode = "975";
		} else if(insCode.equals("99")){
			classCode = "9999";
		} else if(insCode.equals("XX")){
			classCode = " ";
		} else if(insCode.substring(0, 1).equals("Z")){
			classCode = "98" + insCode.substring(1, 2);
		} else if(insCode.substring(0, 1).equals("A")){
			classCode = "90" + insCode.substring(1, 2);
		} else if(insCode.substring(0, 1).equals("B")){
			classCode = "91" + insCode.substring(1, 2);
		} else {
			classCode = "0" + insCode;
		}
		
		return classCode;
	}
	
}
