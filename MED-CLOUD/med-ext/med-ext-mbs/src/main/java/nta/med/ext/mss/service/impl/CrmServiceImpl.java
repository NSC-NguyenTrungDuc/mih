package nta.med.ext.mss.service.impl;


import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.ext.mss.model.PatientModel;
import nta.med.ext.mss.model.SearchPatientModel;
import nta.med.ext.mss.service.CrmService;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.patient.PatientRpcService;


@Service("crmService")
public class CrmServiceImpl implements CrmService {

	@Resource
	private PatientRpcService patientRpcService;

	@Override
	public SearchPatientModel getPatientDetailResultInfo(SearchPatientModel model) {
		
		PatientServiceProto.SearchPatientRequest.Builder patientRequest = PatientServiceProto.SearchPatientRequest.newBuilder();
		patientRequest.setHospCode(model.getHospCode() == null ? "" : model.getHospCode());
		patientRequest.setDiseaseName(model.getDiseaseName() == null ? "" : model.getDiseaseName());
		patientRequest.setStatusOfDisease(model.getStatusOfDisease() == null ? "" : model.getStatusOfDisease());
		patientRequest.setFromLastestGoHospital(model.getFromLastestGoHospital() == null ? "" : model.getFromLastestGoHospital());
		patientRequest.setToLastestGoHospital(model.getToLastestGoHospital() == null ? "" : model.getToLastestGoHospital());
		patientRequest.setPatientSex(model.getPatientSex() == null ? "" : model.getPatientSex());
		patientRequest.setFromPatientAge(model.getFromPatientAge() == null ? -1 : model.getFromPatientAge());
		patientRequest.setToPatientAge(model.getToPatientAge() == null ? -1 : model.getToPatientAge());
		patientRequest.setOrderField(model.getOrderField() == null ? "" : model.getOrderField());
		patientRequest.setOrderValue(model.getOrderValue() == null ? "" : model.getOrderValue());
		patientRequest.setPageSize(model.getPageSize());
		patientRequest.setPageIndex(model.getPageIndex());
		patientRequest.setPatientContact(model.getPatientContact() == null ? "" : model.getPatientContact());
    	PatientServiceProto.SearchPatientResponse patientResponse = patientRpcService.searchPatient(patientRequest.build());
		List<PatientModel> patientModels = new ArrayList<>();
		if(patientResponse != null){
			for(PatientModelProto.PatientDetail patientDetail : patientResponse.getPatientDetailsList())
			{
				PatientModel patientModel = new PatientModel();
				BeanUtils.copyProperties(patientDetail, patientModel, Language.JAPANESE.toString());
				patientModel.setPatientAge(patientDetail.getPatientAge());
				patientModels.add(patientModel);
			}
			model.setPatientModels(patientModels);
			model.setPageSize(patientResponse.getPageSize());
			model.setPageIndex(patientResponse.getPageIndex());
			model.setTotalRecords(patientResponse.getTotalRecords());
		}	
		return model;
	}
}
