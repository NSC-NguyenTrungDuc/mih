package nta.med.service;

import java.lang.reflect.Field;

import nta.med.data.model.ihis.common.ComboListItemInfo;


public class GenerateCheckNullForModelInfo {	
	public static <T> void generateCheckNullModelInfo(Class<T> clazz) {
	   for(Field field : clazz.getDeclaredFields()) {
		   if (field.getType().getSimpleName().equals("String")) {
		       System.out.println("if (!StringUtils.isEmpty(item.get" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "())) {");
		       System.out.println("\tinfo.set" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "(item.get" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "());");
		   } else if (field.getType().getSimpleName().equals("Date") || field.getType().getSimpleName().equals("Timestamp")) {
			   System.out.println("if (item.get" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "() != null) {");
		       System.out.println("\tinfo.set" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "(DateUtil.toString(item.get" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "(), DateUtil.PATTERN_YYMMDD));");
		   } else {
			   System.out.println("if (item.get" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "() != null) {");
			   System.out.println("\tinfo.set" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "(item.get" + Character.toUpperCase((field.getName().charAt(0))) + field.getName().substring(1) + "().toString());");
		   }
		   
		   System.out.println("}");
	   }
	}
	public static void main(String[] args) {
		generateCheckNullModelInfo(ComboListItemInfo.class);
	}
}
