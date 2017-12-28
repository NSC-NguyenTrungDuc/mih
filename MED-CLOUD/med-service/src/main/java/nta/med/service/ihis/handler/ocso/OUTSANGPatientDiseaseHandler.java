package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.out.Outsang;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OUTSANGPatientDiseaseRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OUTSANGPatientDiseaseResponse;

@Service                                                                                                          
@Scope("prototype")
public class OUTSANGPatientDiseaseHandler extends ScreenHandler<OcsoServiceProto.OUTSANGPatientDiseaseRequest, OcsoServiceProto.OUTSANGPatientDiseaseResponse>{

	private static final Log LOGGER = LogFactory.getLog(OUTSANGPatientDiseaseHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OUTSANGPatientDiseaseRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else{
            LOGGER.info("OUTSANGPatientDiseaseHandler preHandle not found hosp code");
        }
    }
	
	@Override
	public OUTSANGPatientDiseaseResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OUTSANGPatientDiseaseRequest request) throws Exception {
		
		OcsoServiceProto.OUTSANGPatientDiseaseResponse.Builder response = OcsoServiceProto.OUTSANGPatientDiseaseResponse.newBuilder(); 
		
		List<Outsang> diseaseList = outsangRepository.findByBunhoAndHospCode(request.getPatientCode(), request.getHospCode());
		for (Outsang disease : diseaseList) {
			OcsoModelProto.PatientDiseaseInfo info = OcsoModelProto.PatientDiseaseInfo.newBuilder()
				.setId(String.valueOf(disease.getId()))
				.setDatetimeRecord(DateUtil.toString(disease.getSangStartDate(), DateUtil.PATTERN_YYMMDD))
				.setDisease(disease.getSangName())
				.build();
			
			response.addPatientDisease(info);
		}
		
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            response.setHospName(bas0001List.get(0).getYoyangName());
        }
		
		return response.build();
	}

}
