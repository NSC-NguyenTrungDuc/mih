package nta.med.orca.gw.model.patient.impl;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.springframework.util.StringUtils;
import org.w3c.dom.Document;

import nta.med.core.utils.CommonUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.PatientInfo;
import nta.med.orca.gw.glossary.OrcaPath;
import nta.med.orca.gw.model.patient.SyncPatient;
import nta.med.orca.gw.xpath.XPathAPI;

/**
 * @author DEV-TiepNM
 */
public class SyncPatientImpl implements SyncPatient {

    private String bunho;
    private String suname;
    private String sex;
    private String birth;
    private String zipCode1;
    private String zipCode2;
    private String address1;
    private String address2;
    private String tel;
    private String tel1;
    private String type;
    private String telHp;
    private String email;
    private String gubunName;
    private String dongName;
    private String suname2;
    private String age;
    private String telType;
    private String telType2;
    private String telType3;
    private String deleteYn;
    private String paceMakerYn;
    private String selfPaceMaker;
    private String patientType ;
    private String retrieveYn;
    private String iuGubun;
    
    @Override
    public PatientModelProto.SyncPatient toProto() {

        PatientModelProto.SyncPatient.Builder builder = PatientModelProto.SyncPatient.newBuilder();
        builder.setBunho(org.apache.commons.lang3.StringUtils.leftPad(bunho, 9, "0"));
        builder.setSuname(suname);
        builder.setSex(sex);
        builder.setBirth(birth);
        builder.setZipCode1(zipCode1);
        builder.setZipCode2(zipCode2);
        builder.setAddress1(address1);
        builder.setAddress2(address2);
        builder.setTel(tel);
        builder.setTel1(tel1);
        builder.setType(type);
        builder.setTelHp(telHp);
        builder.setEmail(email);
        builder.setGubunName(gubunName);
        builder.setDongName(dongName);
        builder.setSuname2(suname2);
        builder.setAge(age);
        builder.setTelType(telType);
        builder.setTelType2(telType2);
        builder.setTelType3(telType3);
        builder.setDeleteYn(deleteYn);
        builder.setPaceMakerYn(paceMakerYn);
        builder.setSelfPaceMaker(selfPaceMaker);
        builder.setPatientType(patientType);
        builder.setRetrieveYn(retrieveYn);
        builder.setIuGubun(iuGubun);
        
        return builder.build();
    }

    @Override
    public SyncPatient copyFromPatientInfo(PatientInfo pt) throws Exception{
    	int tmpAge = 0;
    	String tmpBirth = pt.getBirthDate();
    	String tmpZipCode1 = "";
    	String tmpZipCode2 = "";
    	String tmpAddress1 = "";
    	String tmpAddress2 = "";
    	String tmpType = "";
    	String tmpTel = "";
    	String tmpTel1 = "";
    	String tmpTelHp = "";
    	String tmpPatientType = "";
    	
    	if(!StringUtils.isEmpty(tmpBirth)){
			DateFormat df = new SimpleDateFormat("yyyy-MM-dd");
			Date date = df.parse(tmpBirth);
			tmpAge = (CommonUtils.getAge(date));
			tmpBirth = tmpBirth.replace("-", "/");
		} else {
			tmpBirth = "";
		}
    	
    	if(pt.getHomeAddressInformation() != null){
    		if(pt.getHomeAddressInformation().getAddressZipCode() != null && !StringUtils.isEmpty(pt.getHomeAddressInformation().getAddressZipCode())){
    			tmpZipCode1 = pt.getHomeAddressInformation().getAddressZipCode().substring(0, 3);
    			tmpZipCode2 = pt.getHomeAddressInformation().getAddressZipCode().substring(3, 7);
    		}
    		
    		if(pt.getHomeAddressInformation().getPhoneNumber1() != null && !StringUtils.isEmpty(pt.getHomeAddressInformation().getPhoneNumber1())){
    			tmpTel = pt.getHomeAddressInformation().getPhoneNumber1();
    		}
    		
    		if(pt.getHomeAddressInformation().getPhoneNumber2() != null && !StringUtils.isEmpty(pt.getHomeAddressInformation().getPhoneNumber2())){
    			tmpTel1 = pt.getHomeAddressInformation().getPhoneNumber2();
    		}
    		
    		if(pt.getHomeAddressInformation().getWholeAddress1() != null){
    			tmpAddress1 = pt.getHomeAddressInformation().getWholeAddress1();
    		}
    		
    		if(pt.getHomeAddressInformation().getWholeAddress2() != null){
    			tmpAddress2 = pt.getHomeAddressInformation().getWholeAddress2();
    		}
    	}
    	
    	if(pt.getWorkPlaceInformation() != null){
    		if(pt.getWorkPlaceInformation().getPhoneNumber() != null){
    			tmpTelHp = pt.getWorkPlaceInformation().getPhoneNumber();
    		}
    	}
    	
    	tmpPatientType = !StringUtils.isEmpty(pt.getPatientType()) ? pt.getPatientType() : "";
    	
    	this.setBunho(pt.getPatientId());
		this.setSuname(pt.getWholeName());
		this.setSuname2(pt.getWholeNameInKana());
		this.setSex(pt.getSex());
		this.setBirth(tmpBirth);
		this.setZipCode1(tmpZipCode1);
		this.setZipCode2(tmpZipCode2);
		this.setAddress1(tmpAddress1);
		this.setAddress2(tmpAddress2);
		this.setType(tmpType);
		this.setTel(tmpTel);
		this.setTel1(tmpTel1);
		this.setTelHp(tmpTelHp);
		this.setEmail("");
		this.setGubunName("");
		this.setDongName("");
		this.setAge(String.valueOf(tmpAge));
		this.setTelType("1");
//		this.setTelType2("5");
//		this.setTelType3("3");
		this.setTelType2("7");
		this.setTelType3("2");
		this.setDeleteYn("N");
		this.setPaceMakerYn("N");
		this.setSelfPaceMaker("N");
		this.setPatientType("0");
		this.setRetrieveYn("N");
		this.setIuGubun("");
    	this.setPatientType(tmpPatientType);
		
    	return this;
    }
    
	@Override
	public SyncPatient toModel(Document doc) throws Exception {
		
		String bunho = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.BUNHO_PATH.getPath());
		String suname = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.SUNAME_PATH.getPath());
		String sex = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.SEX_PATH.getPath());
		String tel = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.TEL_PATH.getPath());
		String email = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.EMAIL_PATH.getPath());
		String suname2 = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.SUNAME2_PATH.getPath());
		// type is gubun
		String type = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.GUBUN1_PATH.getPath());
		bunho = bunho == null ? "" : CommonUtils.formatMmlString(bunho);
		suname = suname == null ? "" : CommonUtils.formatMmlString(suname);
		sex = sex == null ? "" : CommonUtils.formatMmlString(sex);
		
		tel = tel == null ? "" : CommonUtils.formatMmlString(tel);
		email = email == null ? "" : CommonUtils.formatMmlString(email);
		suname2 = suname2 == null ? "" : CommonUtils.formatMmlString(suname2);
		type = type == null ? "" : CommonUtils.formatMmlString(type);
		if(type.equals(OrcaPath.GUBUN_DEFAULT.getPath()))
		{
			type = "";
		}
		String address1 = "";
		String address2 = "";
		String fullAddress = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.FULL_ADDRESS_PATH.getPath());
		fullAddress = fullAddress == null ? "" : CommonUtils.formatMmlString(fullAddress);
		if(fullAddress.indexOf("　") > 0){
			address1 = CommonUtils.formatMmlString(fullAddress.substring(0, fullAddress.indexOf("　")));
			address2 = CommonUtils.formatMmlString(fullAddress.substring(fullAddress.indexOf("　") + 1, fullAddress.length()));
		} else{
			address1 = fullAddress;
		}
		
		String zipCode1 = "";
		String zipCode2 = "";
		String zipCode = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.ZIPCODE_PATH.getPath());
		if(zipCode != null && zipCode.indexOf("-") > 0){
			zipCode1 = CommonUtils.formatMmlString(zipCode.substring(0, zipCode.indexOf("-")));
			zipCode2 = CommonUtils.formatMmlString(zipCode.substring(zipCode.indexOf("-") + 1, zipCode.length()));
		}
		
		int age = 0;
		String birth = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.BIRTH_PATH.getPath());
		birth = CommonUtils.formatMmlString(birth);
		if(birth != null){
			DateFormat df = new SimpleDateFormat("yyyy-MM-dd");
			Date date = df.parse(birth);
			age = (CommonUtils.getAge(date));
			birth = birth.replace("-", "/");
		} else {
			birth = "";
		}
		
		this.setBunho(bunho);
		this.setSuname(suname);
		this.setSex(sex);
		this.setBirth(birth);
		this.setZipCode1(zipCode1);
		this.setZipCode2(zipCode2);
		this.setAddress1(address1);
		this.setType(type);
		this.setAddress2(address2);
		this.setTel(tel);
		this.setTel1("");
		this.setTelHp("");
		this.setEmail(email);
		this.setGubunName("");
		this.setDongName("");
		this.setSuname2(suname2);
		this.setAge(String.valueOf(age));
		this.setTelType("1");
		this.setTelType2("");
		this.setTelType3("");
		this.setDeleteYn("N");
		this.setPaceMakerYn("N");
		this.setSelfPaceMaker("N");
		this.setPatientType("0");
		this.setRetrieveYn("N");
		this.setIuGubun("");
		
    	return this;
	}
    
    @Override
    public String getBunho() {
        return bunho;
    }

    @Override
    public void setBunho(String bunho) {
        this.bunho = bunho;
    }

    @Override
    public String getSuname() {
        return suname;
    }

    @Override
    public void setSuname(String suname) {
        this.suname = suname;
    }

    @Override
    public String getSex() {
        return sex;
    }

    @Override
    public void setSex(String sex) {
        this.sex = sex;
    }

    @Override
    public String getBirth() {
        return birth;
    }

    @Override
    public void setBirth(String birth) {
        this.birth = birth;
    }

    @Override
    public String getZipCode1() {
        return zipCode1;
    }

    @Override
    public void setZipCode1(String zipCode1) {
        this.zipCode1 = zipCode1;
    }

    @Override
    public String getZipCode2() {
        return zipCode2;
    }

    @Override
    public void setZipCode2(String zipCode2) {
        this.zipCode2 = zipCode2;
    }

    @Override
    public String getAddress1() {
        return address1;
    }

    @Override
    public void setAddress1(String address1) {
        this.address1 = address1;
    }

    @Override
    public String getAddress2() {
        return address2;
    }

    @Override
    public void setAddress2(String address2) {
        this.address2 = address2;
    }

    @Override
    public String getTel() {
        return tel;
    }

    @Override
    public void setTel(String tel) {
        this.tel = tel;
    }

    @Override
    public String getTel1() {
        return tel1;
    }

    @Override
    public void setTel1(String tel1) {
        this.tel1 = tel1;
    }

    @Override
    public String getType() {
        return type;
    }

    @Override
    public void setType(String type) {
        this.type = type;
    }

    @Override
    public String getTelHp() {
        return telHp;
    }

    @Override
    public void setTelHp(String telHp) {
        this.telHp = telHp;
    }

    @Override
    public String getEmail() {
        return email;
    }

    @Override
    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public String getGubunName() {
        return gubunName;
    }

    @Override
    public void setGubunName(String gubunName) {
        this.gubunName = gubunName;
    }

    @Override
    public String getDongName() {
        return dongName;
    }

    @Override
    public void setDongName(String dongName) {
        this.dongName = dongName;
    }

    @Override
    public String getSuname2() {
        return suname2;
    }
    
    @Override
    public void setSuname2(String suname2) {
        this.suname2 = suname2;
    }

    @Override
    public String getAge() {
        return age;
    }

    @Override
    public void setAge(String age) {
        this.age = age;
    }

    @Override
    public String getTelType() {
        return telType;
    }

    @Override
    public void setTelType(String telType) {
        this.telType = telType;
    }

    @Override
    public String getTelType2() {
        return telType2;
    }

    @Override
    public void setTelType2(String telType2) {
        this.telType2 = telType2;
    }

    @Override
    public String getTelType3() {
        return telType3;
    }

    @Override
    public void setTelType3(String telType3) {
        this.telType3 = telType3;
    }

    @Override
    public String getDeleteYn() {
        return deleteYn;
    }

    @Override
    public void setDeleteYn(String deleteYn) {
        this.deleteYn = deleteYn;
    }

    @Override
    public String getPaceMakerYn() {
        return paceMakerYn;
    }

    @Override
    public void setPaceMakerYn(String paceMakerYn) {
        this.paceMakerYn = paceMakerYn;
    }

    @Override
    public String getSelfPaceMaker() {
        return selfPaceMaker;
    }

    @Override
    public void setSelfPaceMaker(String selfPaceMaker) {
        this.selfPaceMaker = selfPaceMaker;
    }

    @Override
    public String getPatientType() {
        return patientType;
    }

    @Override
    public void setPatientType(String patientType) {
        this.patientType = patientType;
    }

    @Override
    public String getRetrieveYn() {
        return retrieveYn;
    }

    @Override
    public void setRetrieveYn(String retrieveYn) {
        this.retrieveYn = retrieveYn;
    }

    @Override
	public String getIuGubun() {
		return iuGubun;
	}

    @Override
	public void setIuGubun(String iuGubun) {
		this.iuGubun = iuGubun;
	}
}
