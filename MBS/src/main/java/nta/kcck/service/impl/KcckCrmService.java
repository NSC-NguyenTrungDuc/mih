package nta.kcck.service.impl;

import java.util.ArrayList;
import java.util.List;

import org.springframework.util.CollectionUtils;

import nta.kcck.model.KcckCrmModel;
import nta.kcck.model.KcckCrmPatientModel;
import nta.kcck.service.IKcckCrmService;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.enums.HospitalLocale;
import nta.mss.model.CrmModel;
import nta.mss.model.CrmPatientModel;

public class KcckCrmService implements IKcckCrmService {
	
	KcckApiService kcckApiService = new KcckApiService();
	
	@Override
	public CrmModel getListCrm(KcckCrmModel model) {
		CrmModel crmModel = new CrmModel();
		List<CrmPatientModel> listCrmPatientModel = new ArrayList<CrmPatientModel>();
		KcckCrmModel response =  kcckApiService.listCrm(model);
		if(CollectionUtils.isEmpty(response.getPatients())){
			return crmModel;
		}
		for (KcckCrmPatientModel kcckModel : response.getPatients()) {			
			CrmPatientModel crmPatientModel = new CrmPatientModel();
			crmPatientModel.setPatientName(kcckModel.getPatient_name());
			crmPatientModel.setDiseaseName(kcckModel.getDisease_name());
			crmPatientModel.setLastestGoHospital(kcckModel.getLast_go_hospital());
			crmPatientModel.setPatientAge(kcckModel.getPatient_age());
			crmPatientModel.setPatientSex(kcckModel.getPatient_sex());
			crmPatientModel.setPatientEmail(kcckModel.getPatient_email());
			crmPatientModel.setStatusOfDisease(kcckModel.getStatus_of_disease());
			crmPatientModel.setPatientTel(kcckModel.getPatient_tel());
			listCrmPatientModel.add(crmPatientModel);
		}
		crmModel.setListCrmPatientModel(listCrmPatientModel);
		crmModel.setTotalRecords(response.getTotal_records());
		return crmModel;

	}
}
