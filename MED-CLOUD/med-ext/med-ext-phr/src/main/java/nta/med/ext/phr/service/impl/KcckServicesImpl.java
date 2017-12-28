package nta.med.ext.phr.service.impl;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.ext.phr.model.HospitalModel;
import nta.med.ext.phr.model.KcckAccountModel;
import nta.med.ext.phr.model.PatientDisease;
import nta.med.ext.phr.model.PatientDiseaseWrapper;
import nta.med.ext.phr.model.PatientMedicine;
import nta.med.ext.phr.model.PatientMedicineWrapper;
import nta.med.ext.phr.model.PatientModel;
import nta.med.ext.phr.service.KcckServices;
import nta.med.ext.support.proto.HospitalModelProto;
import nta.med.ext.support.proto.HospitalServiceProto;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.ext.support.proto.PatientServiceProto;
import nta.med.ext.support.service.hospital.HospitalRpcService;
import nta.med.ext.support.service.patient.PatientRpcService;
import nta.med.ext.support.service.system.SystemRpcService;

@Service
public class KcckServicesImpl implements KcckServices{
	
	@Resource
	private PatientRpcService patientRpcService;
	
	@Resource
	private SystemRpcService systemRpcService;
	
	@Resource
	private HospitalRpcService hospitalRpcService;
	
	@Override
	public PatientDiseaseWrapper getPatientDisease(String patientCode, String hospCode) {
		PatientDiseaseWrapper patientDiseaseWrapper = null;
		PatientServiceProto.GetPatientDiseaseRequest.Builder request = PatientServiceProto.GetPatientDiseaseRequest.newBuilder(); 
		request.setPatientCode(patientCode);
		request.setHospCode(hospCode);
		
		PatientServiceProto.GetPatientDiseaseResponse response = patientRpcService.getPatientDisease(request.build());
		if(response!= null && !StringUtils.isEmpty(response.getHospName())){
			patientDiseaseWrapper = new PatientDiseaseWrapper();
			patientDiseaseWrapper.setHospName(response.getHospName());
			List<PatientDisease> diseaseList = new ArrayList<PatientDisease>();
			List<PatientModelProto.PatientDiseaseInfo> rpDiseaseList = response.getPatientDiseaseList();
			
			if(CollectionUtils.isEmpty(rpDiseaseList)) return null;
			
			for (PatientModelProto.PatientDiseaseInfo info : rpDiseaseList) {
				PatientDisease item = new PatientDisease(info.getId(), info.getDatetimeRecord(), info.getDisease());
				diseaseList.add(item);
			}
			
			patientDiseaseWrapper.setDiseaseList(diseaseList);
		}
		
		return patientDiseaseWrapper;
	}
	
	@Override
	public PatientMedicineWrapper getPatientMedicine(String patientCode, String hospCode) {
		PatientMedicineWrapper patientMedicineWrapper = null;
		PatientServiceProto.GetPatientMedicineRequest.Builder request = PatientServiceProto.GetPatientMedicineRequest.newBuilder();
		request.setPatientCode(patientCode);
		request.setHospCode(hospCode);
		
		PatientServiceProto.GetPatientMedicineResponse response = patientRpcService.getPatientMedicine(request.build());
		if(response != null && !StringUtils.isEmpty(response.getHospName())){
			patientMedicineWrapper = new PatientMedicineWrapper();
			patientMedicineWrapper.setHospName(response.getHospName());
			List<PatientMedicine> medicineList = new ArrayList<>();
			List<PatientModelProto.PatientMedicineInfo> rpMedicineList = response.getPatientMedicineList();
			
			if(CollectionUtils.isEmpty(rpMedicineList)) return null;
			
			for (PatientModelProto.PatientMedicineInfo info : rpMedicineList) {
				PatientMedicine item = new PatientMedicine(info.getId(), info.getDatetimeRecord(),
						info.getPrescriptionName(), info.getMedicineName(), info.getDose(), info.getUnitCode(),
						info.getUnit(), info.getFrequency(), info.getDays(), info.getDosage(), info.getMedicineMethod(), info.getNeawonKey(), info.getHangmogCode()); 
				medicineList.add(item);
			}
			
			patientMedicineWrapper.setMedicineList(medicineList);
		}
		
		return patientMedicineWrapper;
	}

	@Override
	public List<HospitalModel> getHospitalList(String hospName, String address, String tel, String countryCode) {
		List<HospitalModel> hospList = null;
		HospitalServiceProto.SearchHospitalRequest request = HospitalServiceProto.SearchHospitalRequest
				.newBuilder()
				.setHospName(hospName)
				.setAddress(address)
				.setTel(tel)
				.setCountryCode(countryCode)
				.build();
		
		HospitalServiceProto.SearchHospitalResponse response = hospitalRpcService.searchHospitals(request);
		if(response != null){
			List<HospitalModelProto.HospitalDetailInfo> hospInfoList = response.getItemInfoList();
			if(!CollectionUtils.isEmpty(hospInfoList)){
				hospList = new ArrayList<>();
				for (HospitalModelProto.HospitalDetailInfo info : hospInfoList) {
					HospitalModel item = new HospitalModel();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					hospList.add(item);
				}
			}
		}
		
		return hospList;
	}
	
	@Override
	public PatientModel verifyKcckAccount(KcckAccountModel account){
		PatientModel patientModel = null;
		
		PatientServiceProto.VerifyPatientAccountRequest.Builder request = PatientServiceProto.VerifyPatientAccountRequest.newBuilder();
		request.setHospCode(account.getHospCode());
		request.setUsername(account.getUsername());
		request.setPassword(account.getPassword());
		
		PatientServiceProto.VerifyPatientAccountResponse response = patientRpcService.verifyPatientAccount(request.build());
		if(response != null && !StringUtils.isEmpty(response.getHospCode())){
			patientModel = new PatientModel();
			patientModel.setHospCode(response.getHospCode());
			patientModel.setHospName(response.getHospName());
			patientModel.setPatientCode(response.getPatientCode());
		}
		
		return patientModel;
	}
}
