package nta.med.orca.gw.model.patient;

import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.PatientInfo;

import org.w3c.dom.Document;

/**
 * @author DEV-TiepNM
 */
public interface SyncPatient {


    public PatientModelProto.SyncPatient toProto();
    
    public SyncPatient toModel(Document doc) throws Exception;
    
    public SyncPatient copyFromPatientInfo(PatientInfo pt) throws Exception;
    
    public String getBunho();

    public void setBunho(String bunho);

    public String getSuname();

    public void setSuname(String suname);

    public String getSex();

    public void setSex(String sex);

    public String getBirth();

    public void setBirth(String birth);

    public String getZipCode1();

    public void setZipCode1(String zipCode1);

    public String getZipCode2();

    public void setZipCode2(String zipCode2);

    public String getAddress1();

    public void setAddress1(String address1);

    public String getAddress2();

    public void setAddress2(String address2);

    public String getTel();

    public void setTel(String tel);

    public String getTel1();

    public void setTel1(String tel1);

    public String getType();

    public void setType(String type);

    public String getTelHp();

    public void setTelHp(String telHp);

    public String getEmail();

    public void setEmail(String email);

    public String getGubunName();

    public void setGubunName(String gubunName);

    public String getDongName();

    public void setDongName(String dongName);

    public String getSuname2();

    public void setSuname2(String suname2);

    public String getAge();

    public void setAge(String age);

    public String getTelType();

    public void setTelType(String telType);

    public String getTelType2();

    public void setTelType2(String telType2);

    public String getTelType3();

    public void setTelType3(String telType3);

    public String getDeleteYn();

    public void setDeleteYn(String deleteYn);

    public String getPaceMakerYn();

    public void setPaceMakerYn(String paceMakerYn);

    public String getSelfPaceMaker();

    public void setSelfPaceMaker(String selfPaceMaker);

    public String getPatientType();

    public void setPatientType(String patientType);

    public String getRetrieveYn();

    public void setRetrieveYn(String retrieveYn);
    
	public String getIuGubun();
	
	public void setIuGubun(String iuGubun);
	
}
