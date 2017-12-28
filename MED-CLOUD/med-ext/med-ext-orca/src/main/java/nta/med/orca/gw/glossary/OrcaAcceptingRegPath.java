package nta.med.orca.gw.glossary;

public enum OrcaAcceptingRegPath {
	DEPARTMENT_CODE ("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlDp:Department/mmlCm:Id"),
	DOCTOR_CODE ("/Mml/MmlBody/MmlModuleItem/docInfo[@contentModuleType='claim']/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	INSUR_CODE ("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:insuranceClass/@mmlHi:ClassCode"),
	PATIENT_CODE ("/Mml/MmlHeader/masterId/mmlCm:Id"),
	COMING_DATE ("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:registTime"),
	RECEPTION_TIME ("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/@claim:registTime"),
	SYS_ID ("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	UPD_ID ("/Mml/MmlHeader/mmlCi:CreatorInfo/mmlPsi:PersonalizedInfo/mmlCm:Id"),
	GONGBI_NAME ("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem/mmlHi:providerName"),
	PRIORITY ("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem/@mmlHi:priority"),
	CODE_NAME ("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:information/claim:appoint/claim:memo"),
	EXAM_STATUS ("/Mml/MmlBody/MmlModuleItem/content/claim:ClaimModule/claim:bundle/@claim:classCode"),
	
	GONGBI_NAME1_PATH	("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='1']/mmlHi:providerName"),
	GONGBI_NAME2_PATH	("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='2']/mmlHi:providerName"),
	GONGBI_NAME3_PATH	("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='3']/mmlHi:providerName"),
	GONGBI_NAME4_PATH	("/Mml/MmlBody/MmlModuleItem/content/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='4']/mmlHi:providerName"),
	
	GONGBI_NAME1_SUB_PATH	("/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='1']/mmlHi:providerName"),
	GONGBI_NAME2_SUB_PATH	("/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='2']/mmlHi:providerName"),
	GONGBI_NAME3_SUB_PATH	("/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='3']/mmlHi:providerName"),
	GONGBI_NAME4_SUB_PATH	("/mmlHi:HealthInsuranceModule/mmlHi:publicInsurance/mmlHi:publicInsuranceItem[@mmlHi:priority='4']/mmlHi:providerName"),
	
	;

	private String path;
	
	OrcaAcceptingRegPath(String path) {
        this.path = path;
    }
	
	public String getPath(){
		return path;
	}
}
