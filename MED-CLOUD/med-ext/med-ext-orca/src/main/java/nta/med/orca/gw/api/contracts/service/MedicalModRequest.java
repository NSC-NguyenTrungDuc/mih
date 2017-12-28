package nta.med.orca.gw.api.contracts.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.util.CollectionUtils;

import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.ext.support.proto.OrderModelProto;
import nta.med.ext.support.proto.OrderServiceProto;
import nta.med.orca.gw.api.contracts.message.DiagnosisInformation;
import nta.med.orca.gw.api.contracts.message.DiseaseInformation;
import nta.med.orca.gw.api.contracts.message.HealthInsuranceInfo;
import nta.med.orca.gw.api.contracts.message.MedicalInformation;
import nta.med.orca.gw.api.contracts.message.MedicationInfo;
import nta.med.orca.gw.api.contracts.message.PublicInsuranceInfo;

/**
 * @author dainguyen.
 */
public class MedicalModRequest extends AbstractRequest {

    private String inOut;
    private String patientID;
    private String performDate;
    private String performTime;
    private String medicalUid;
    private DiagnosisInformation diagnosisInformation;
    private String requestClass;
    
    public String getInOut() {
        return inOut;
    }

    public void setInOut(String inOut) {
        this.inOut = inOut;
    }

    public String getPatientID() {
        return patientID;
    }

    public void setPatientID(String patientID) {
        this.patientID = patientID;
    }

    public String getPerformDate() {
        return performDate;
    }

    public void setPerformDate(String performDate) {
        this.performDate = performDate;
    }

    public String getPerformTime() {
        return performTime;
    }

    public void setPerformTime(String performTime) {
        this.performTime = performTime;
    }

    public String getMedicalUid() {
        return medicalUid;
    }

    public void setMedicalUid(String medicalUid) {
        this.medicalUid = medicalUid;
    }

    public DiagnosisInformation getDiagnosisInformation() {
        return diagnosisInformation;
    }

    public void setDiagnosisInformation(DiagnosisInformation diagnosisInformation) {
        this.diagnosisInformation = diagnosisInformation;
    }
    
	public String getRequestClass() {
		return requestClass;
	}

	public void setRequestClass(String requestClass) {
		this.requestClass = requestClass;
	}
    
    public void copyFromProto(OrderServiceProto.OrderTranferRequest rq){
    	this.inOut = rq.getInOut();
    	
    	String orcaPatientId = String.valueOf(CommonUtils.parseInteger(rq.getPatientId()));
    	this.patientID = orcaPatientId;
    	this.performDate = rq.getPerformDate();
    	this.performTime = rq.getPerformTime();
    	this.medicalUid = rq.getMedicalUid();
    	
		if (rq.getAction() == OrderServiceProto.OrderTranferRequest.Action.SEND_ORDER_DISEASE
				|| rq.getAction() == OrderServiceProto.OrderTranferRequest.Action.SEND_DISEASE_ONLY
				|| rq.getAction() == OrderServiceProto.OrderTranferRequest.Action.CANCEL_ORDER) {
    		
			this.requestClass = "01";
    	} else if(rq.getAction() == OrderServiceProto.OrderTranferRequest.Action.RETRANSFER_ORDER){
    		this.requestClass = "04";
    	}
    	
    	if(rq.hasDiagnosisInformation()){
    		OrderModelProto.DiagnosisInformation diProto = rq.getDiagnosisInformation();
    		this.diagnosisInformation = new DiagnosisInformation();
    		this.diagnosisInformation.setDepartmentCode(diProto.getDepartmentCode());
    		this.diagnosisInformation.setPhysicianCode(diProto.getPhysicianCode());
    		
    		// Setting Insurance
    		if(diProto.hasHealthInsuranceInfo()){
    			OrderModelProto.HealthInsuranceInfo hiProto = diProto.getHealthInsuranceInfo();
    			HealthInsuranceInfo hiApi = new HealthInsuranceInfo();
    			BeanUtils.copyProperties(hiProto, hiApi, Language.JAPANESE.toString());
    			if(!CollectionUtils.isEmpty(hiProto.getPublicInsuranceList())){
    				List<PublicInsuranceInfo> piApiList = new ArrayList<>();
    				for (OrderModelProto.PublicInsuranceInfo piProto : hiProto.getPublicInsuranceList()) {
    					PublicInsuranceInfo piApi = new PublicInsuranceInfo();
    					BeanUtils.copyProperties(piProto, piApi, Language.JAPANESE.toString());
    					piApiList.add(piApi);
					}
    				
    				hiApi.setPublicInsuranceInformation(piApiList);
    			}
    			
    			this.diagnosisInformation.setHealthInsuranceInfo(hiApi);
    		}
    		
    		// Setting MedicalInformation
    		if(!CollectionUtils.isEmpty(diProto.getMedicalInformationList())){
    			List<MedicalInformation> miApiList = new ArrayList<>();
    			for (OrderModelProto.MedicalInformation miProto : diProto.getMedicalInformationList()) {
    				MedicalInformation miApi = new MedicalInformation();
    				BeanUtils.copyProperties(miProto, miApi, Language.JAPANESE.toString());
    				if(!CollectionUtils.isEmpty(miProto.getMedicationInfoList())){
    					List<MedicationInfo> medicationApiList = new ArrayList<>();
    					for (OrderModelProto.MedicationInfo medicationProto : miProto.getMedicationInfoList()) {
    						MedicationInfo medicationApi = new MedicationInfo();
    						BeanUtils.copyProperties(medicationProto, medicationApi, Language.JAPANESE.toString());
    						medicationApiList.add(medicationApi);
						}
    					
    					miApi.setMedicationInfos(medicationApiList);
    				}
    				
    				miApiList.add(miApi);
				}
    			
    			this.diagnosisInformation.setMedicalInformation(miApiList);
    		}
    		
    		// Setting DiseaseInformation
    		if(!CollectionUtils.isEmpty(diProto.getDiseaseInformationList())){
    			List<DiseaseInformation> diseaseApiList = new ArrayList<>();
    			for (OrderModelProto.DiseaseInformation diseaseProto : diProto.getDiseaseInformationList()) {
    				DiseaseInformation diseaseApi = new DiseaseInformation();
    				BeanUtils.copyProperties(diseaseProto, diseaseApi, Language.JAPANESE.toString());
    				diseaseApiList.add(diseaseApi);
				}
    			
    			this.diagnosisInformation.setDiseaseInformation(diseaseApiList);
    		}
    	}
    }
    
}
