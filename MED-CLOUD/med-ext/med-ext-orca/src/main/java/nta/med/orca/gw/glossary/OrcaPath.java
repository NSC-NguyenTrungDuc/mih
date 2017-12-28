package nta.med.orca.gw.glossary;

public enum OrcaPath {
	
	CREATE_DATE_PATH		("/Mml/@createDate"),
	
	FULL_ADDRESS_PATH		("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:addresses/mmlAd:Address/mmlAd:full"),
	BIRTH_PATH				("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:birthday"),
	BUNHO_PATH				("/Mml/MmlHeader/masterId/mmlCm:Id"),
	
	EMAIL_PATH 				("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:emailAddresses/mmlCm:email"),
	GUBUN1_PATH 			("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:insuranceClass/@mmlHi:ClassCode"),
	GUBUN_NAME1_PATH 		("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:insuranceClass"),

	SEX_PATH 				("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:sex"),
	SUNAME_PATH 			("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:personName/mmlNm:Name[@mmlNm:repCode='I']/mmlNm:fullname"),
	SUNAME2_PATH 			("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:personName/mmlNm:Name[@mmlNm:repCode='P']/mmlNm:fullname"),
	STARD_DATE_PATH 		("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:startDate"),

	ZIPCODE_PATH 			("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:addresses/mmlAd:Address/mmlAd:zip"),
	TEL_PATH 				("/Mml/MmlBody/MmlModuleItem/content/mmlPi:PatientModule/mmlPi:phones/mmlPh:Phone/mmlPh:memo"),

	GONGBI_CODE_PATH 		("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:insuranceClass/@mmlHi:ClassCode"),
	END_DATE_INS_PATH		("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem/mmlHi:expiredDate"),
	CLAIM_STATUS			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:status"),
	USER_ID					("/Mml/MmlBody/MmlModuleItem/docInfo/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	ORCA_GIGWAN_CODE		("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlFc:Facility/mmlCm:Id"),
	GWA_PATH 				("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlDp:Department/mmlCm:Id"),
	//DOCTOR_PATH 			("/Mml/MmlBody/MmlModuleItem/docInfo/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	DOCTOR_PATH 			("/Mml/MmlBody/MmlModuleItem/docInfo[@contentModuleType='claim']/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	ORDER_TIME_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:orderTime"),
	APP_TIME_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:appointTime"),
	REGIST_TIME_PATH		("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:registTime"),
	PERFORM_TIME_PATH		("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:performTime"),
	IO_FLAG_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:admitFlag"),
	TIME_CLASS_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:timeClass"),
	BUND_NUM_CLASS			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:bundle/claim:bundleNumber"),
	CLASS_CODE_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:bundle/@claim:classCode"),
	SUB_CODE_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:bundle/claim:item/@claim:subclassCode"),
	ACT_CODE_PATH			("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:bundle/claim:item/@claim:code"),
	SYS_ID_PATH				("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	UDP_ID_PATH				("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	
	HEALTH_INSURANCE_MODULE_PATH			("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule"),
	HEALTH_INSURANCE_ITEM_STARD_DATE_PATH	("/mmlHi:HealthInsuranceModule/mmlHi:startDate"),
	HEALTH_INSURANCE_ITEM_END_DATE_PATH		("/mmlHi:HealthInsuranceModule/mmlHi:expiredDate"),
	HEALTH_INSURANCE_ITEM_GUBUN1_PATH		("/mmlHi:HealthInsuranceModule/mmlHi:insuranceClass/@mmlHi:ClassCode"),
	HEALTH_INSURANCE_ITEM_GUBUN_NAME1_PATH	("/mmlHi:HealthInsuranceModule/mmlHi:insuranceClass"),
	HEALTH_INSURANCE_JOHAP_PATH				("/mmlHi:HealthInsuranceModule/mmlHi:insuranceNumber"),
	HEALTH_INSURANCE_BUDAMJA_BUNHO_PATH		("/mmlHi:HealthInsuranceModule/mmlHi:insuranceNumber"),
	
	IU_GUBUN_PATH					("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:admitFlag"),
	PUBLIC_INSURANCE_ITEM_PATH		("/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem"),
	PUBLIC_INSURANCE_ITEM_START_DATE_PATH	("/mmlHi:publicInsuranceItem/mmlHi:startDate"),
	PUBLIC_INSURANCE_ITEM_END_DATE_PATH		("/mmlHi:publicInsuranceItem/mmlHi:expiredDate"),
	PUBLIC_INSURANCE_ITEM_GONGBI_NAME_PATH	("/mmlHi:publicInsuranceItem/mmlHi:providerName"),
	PUBLIC_INSURANCE_BUDAMJA_BUNHO_PATH		("/mmlHi:publicInsuranceItem/mmlHi:provider"),
	PUBLIC_INSURANCE_SUGUBJA_BUNHO  		("/mmlHi:publicInsuranceItem/mmlHi:recipient"),
	INSURANCE_NUMBER_DEFAULT("9999"),
	GUBUN_DEFAULT("XX"),
	MIKINYU("mikinyu");
	
	private String path;
	
	OrcaPath(String path) {
        this.path = path;
    }
	
	public String getPath(){
		return path;
	}
	
}
