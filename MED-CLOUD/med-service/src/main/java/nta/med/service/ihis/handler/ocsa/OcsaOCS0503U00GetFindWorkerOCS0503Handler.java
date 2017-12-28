package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.ocs.Ocs0503Repository;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00GetFindWorkerConsultGwaInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00GetFindWorkerRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00GetFindWorkerResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OcsaOCS0503U00GetFindWorkerOCS0503Handler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00GetFindWorkerRequest, OcsaServiceProto.OCS0503U00GetFindWorkerResponse>{
	@Resource
	private Res0102Repository res0102Repository;
	@Resource
	private Ocs0503Repository ocs0503Repository;
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS0503U00GetFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0503U00GetFindWorkerRequest request) throws Exception {
		OcsaServiceProto.OCS0503U00GetFindWorkerResponse.Builder response=OcsaServiceProto.OCS0503U00GetFindWorkerResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		response = getFindWorker(request, hospCode, language);
		return response.build();
	}
	
	public OcsaServiceProto.OCS0503U00GetFindWorkerResponse.Builder getFindWorker(OcsaServiceProto.OCS0503U00GetFindWorkerRequest request, String hospCode ,String language){
		OcsaServiceProto.OCS0503U00GetFindWorkerResponse.Builder response=OcsaServiceProto.OCS0503U00GetFindWorkerResponse.newBuilder();
		List<OcsaOCS0503U00GetFindWorkerConsultGwaInfo> listWorkerGwa = null;
		List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2> listWorkerDoctor2=null;
		List<OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1> listWorkerDoctor1=null;
		switch (request.getFindMode()) {
		case "consult_gwa":	
			listWorkerGwa=ocs0503Repository.getOcsaOCS0503U00GetFindWorkerListInfoProcess1(hospCode,language);
			if(listWorkerGwa != null && !listWorkerGwa.isEmpty()){
				for(OcsaOCS0503U00GetFindWorkerConsultGwaInfo worker : listWorkerGwa){
					OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.Builder info=OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.newBuilder();
					if(!StringUtils.isEmpty(worker.getHangmogName())){
						info.setHangmogName(worker.getHangmogName());
					}if(!StringUtils.isEmpty(worker.getHangmogCode())){
						info.setHangmogCode(worker.getHangmogCode());
					}
					response.addFindWorker(info);
				}
			}
			break;
		case "consult_doctor":
			if("O".equalsIgnoreCase(request.getMInOutGubun()) || "I".equalsIgnoreCase(request.getMInOutGubun())){
				if(DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null){
					listWorkerDoctor1=bas0270Repository.getOcsaOCS0503U00GetFindWorkerListInfoProcess2(hospCode, request.getRefCode());
					if(listWorkerDoctor1 !=null && !listWorkerDoctor1.isEmpty()){
						for(OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1 worker : listWorkerDoctor1){
							OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.Builder info=OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.newBuilder();
							if(!StringUtils.isEmpty(worker.getDoctorName())){
								info.setDoctorName(worker.getDoctorName());
							}if(!StringUtils.isEmpty(worker.getDoctor())){
								info.setDoctor(worker.getDoctor());
							}
							response.addFindWorker(info);
						}
					}
				}else{
					if(!(request.getNaewonDate().replace("/", "").replace("-", "").trim()).equalsIgnoreCase(DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD_BLANK).trim())  
							&& "O".equalsIgnoreCase(request.getMInOutGubun())){
						listWorkerDoctor2=res0102Repository.getOcsaOCS0503U00GetFindWorkerListInfoProcess3(hospCode, request.getNaewonDate(), request.getRefCode());
					}else{
						listWorkerDoctor2=res0102Repository.getOcsaOCS0503U00GetFindWorkerListInfoProcess4(hospCode, request.getNaewonDate(), request.getRefCode());
					}
					if(listWorkerDoctor2 !=null && !listWorkerDoctor2.isEmpty()){
						for(OcsaOCS0503U00GetFindWorkerConsultDoctorInfo2 worker : listWorkerDoctor2){
							OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.Builder info=OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.newBuilder();
							if(!StringUtils.isEmpty(worker.getDoctorName())){
								info.setDoctorName(worker.getDoctorName());
							}if(!StringUtils.isEmpty(worker.getDoctor())){
								info.setDoctor(worker.getDoctor());
							}if(!StringUtils.isEmpty(worker.getAmpm())){
								info.setAmpm(worker.getAmpm());
							}
							response.addFindWorker(info);
						}
					}
				}
			}else{
				listWorkerDoctor1=bas0270Repository.getOcsaOCS0503U00GetFindWorkerListInfoProcess2(language, request.getRefCode());
				if(listWorkerDoctor1 !=null && !listWorkerDoctor1.isEmpty()){
					for(OcsaOCS0503U00GetFindWorkerConsultDoctorInfo1 worker : listWorkerDoctor1){
						OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.Builder info=OcsaModelProto.OCS0503U00GetFindWorkerConsultGwaInfo.newBuilder();
						if(!StringUtils.isEmpty(worker.getDoctorName())){
							info.setDoctorName(worker.getDoctorName());
						}if(!StringUtils.isEmpty(worker.getDoctor())){
							info.setDoctor(worker.getDoctor());
						}
						response.addFindWorker(info);
					}
				}
			}
			
			break;
		}
		
		return response;
	}
}
