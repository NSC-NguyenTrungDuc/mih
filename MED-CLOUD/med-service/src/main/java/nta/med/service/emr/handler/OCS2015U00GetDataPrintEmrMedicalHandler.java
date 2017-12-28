package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.data.model.ihis.emr.InsuranceProviderInfo;
import nta.med.data.model.ihis.emr.OCS2015U00DosageInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetDataInsPersonInfo;
import nta.med.data.model.ihis.emr.OCS2015U00GetOrderReportInfo;
import nta.med.data.model.ihis.ocsa.PatientLinkingFwkDoctorInfo;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;

@Service                                                                                                          
@Scope("prototype")     
public class OCS2015U00GetDataPrintEmrMedicalHandler extends ScreenHandler<EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalRequest, EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U00GetDataPrintEmrMedicalHandler.class);  
	@Resource                                                                                                       
	private Bas0210Repository bas0210Repository;
	
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;
	
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;
	
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Resource                                                                                                       
	private Out0105Repository out0105Repository;
	
	@Resource                                                                                                       
	private Out0102Repository out0102Repository;
	
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
		
	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalRequest request) throws Exception {
		EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalResponse.Builder response = EmrServiceProto.OCS2015U00GetDataPrintEmrMedicalResponse.newBuilder();
	
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//Insurance_Classification
		String insurance = bas0210Repository.getOcs2015U00InsuranceInfo(hospCode, request.getBunho(), language);
		if(!StringUtils.isEmpty(insurance)){
			response.setInsuranceClassification(insurance);
		}
		//EMR_No
		Integer emrNo = emrRecordRepository.getOcs2015U00EmrNoInfo(hospCode, request.getBunho());
		if(emrNo != null){
			response.setEmrNo(emrNo.toString());
		}
		
		//Doctor_Name
		List<PatientLinkingFwkDoctorInfo> listDoctor = bas0270Repository.getOcs2015U00DoctorNameInfo(hospCode); 
		for (PatientLinkingFwkDoctorInfo item : listDoctor) {
			EmrModelProto.OCS2015U00GetDataDoctorInfo.Builder info = EmrModelProto.OCS2015U00GetDataDoctorInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addDoctorInfo(info);
		}
		
		//Dosage
		List<OCS2015U00DosageInfo> listDosage = drg0120Repository.getOcs2015U00DosageInfo(hospCode, request.getBunho(), language);
		for (OCS2015U00DosageInfo item : listDosage) {
			EmrModelProto.OCS2015U00GetDataDosageInfo.Builder info = EmrModelProto.OCS2015U00GetDataDosageInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			response.addDosageInfo(info);
		}
		//HospitalName
		Bas0001 bas0001 = bas0001Repository.getByHospCode(hospCode);
		if (bas0001 != null) {
			response.setHospitalName(bas0001.getYoyangName() == null ? "" : bas0001.getYoyangName());
			response.setHospitalAddress(bas0001.getAddress() == null ? "" : bas0001.getAddress());
			response.setHospitalTel(bas0001.getTel() == null ? "" : bas0001.getTel());
			response.setHospitalFax(bas0001.getFax() == null ? "" : bas0001.getFax());
			response.setHospitalLogo(" ");
			response.setHospitalWebsite(bas0001.getHomepage()== null ? "" : bas0001.getHomepage());
		}
		
		//Insurance Person
		List<OCS2015U00GetDataInsPersonInfo> listInsPersonFirst = out0105Repository.getOCS2015U00GetDataInsPersonInfo(hospCode, request.getBunho(), request.getFirstExaminationDate(), request.getLastExaminationDate(), "1");
		if(!CollectionUtils.isEmpty(listInsPersonFirst)){
			for(OCS2015U00GetDataInsPersonInfo item : listInsPersonFirst){
				EmrModelProto.OCS2015U00GetDataInsPersonInfo.Builder info = EmrModelProto.OCS2015U00GetDataInsPersonInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInsPersionInfoFirst(info);
			}
		}
		
		List<OCS2015U00GetDataInsPersonInfo> listInsPersonSecond = out0105Repository.getOCS2015U00GetDataInsPersonInfo(hospCode, request.getBunho(), request.getFirstExaminationDate(), request.getLastExaminationDate(), "2");
		if(!CollectionUtils.isEmpty(listInsPersonSecond)){
			for(OCS2015U00GetDataInsPersonInfo item : listInsPersonSecond){
				EmrModelProto.OCS2015U00GetDataInsPersonInfo.Builder info = EmrModelProto.OCS2015U00GetDataInsPersonInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInsPersionInfoSecond(info);
			}
		}
		
		//Insurance Provider
		List<InsuranceProviderInfo> listInsProvider = out0102Repository.getOCS2015U00GetDataInsProviderInfo(hospCode, request.getBunho(), request.getFirstExaminationDate(), request.getLastExaminationDate()); 
			for (InsuranceProviderInfo item : listInsProvider) {
				EmrModelProto.OCS2015U00GetDataInsProviderInfo.Builder info = EmrModelProto.OCS2015U00GetDataInsProviderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInsProviderInfo(info);
			}
			
		//
		List<OCS2015U00GetOrderReportInfo> listOrderReportInfo = ocs1003Repository.getOCS2015U00OrderReportInfo(hospCode, language, request.getBunho()); 
			for (OCS2015U00GetOrderReportInfo item : listOrderReportInfo) {
				EmrModelProto.OCS2015U00GetOrderReportInfo.Builder info = EmrModelProto.OCS2015U00GetOrderReportInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOrderReportInfo(info);
			}
			
		return response.build();
	}

}
