package nta.med.service.emr.handler;

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
import nta.med.core.domain.emr.EmrRecord;
import nta.med.core.domain.emr.EmrTag;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.EMRGetByPatientCodeAndHospCodeRequest;
import nta.med.service.emr.proto.EmrServiceProto.EMRGetByPatientCodeAndHospCodeResponse;

@Service                                                                                                          
@Scope("prototype")
public class EMRGetByPatientCodeAndHospCodeHandler extends ScreenHandler<EmrServiceProto.EMRGetByPatientCodeAndHospCodeRequest, EmrServiceProto.EMRGetByPatientCodeAndHospCodeResponse>{

	private static final Log LOGGER = LogFactory.getLog(EMRGetByPatientCodeAndHospCodeHandler.class);
	
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;

	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private EmrTagRepository emrTagRepository;
	
	@Override
    @Transactional
    @Route(global = true)
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, EMRGetByPatientCodeAndHospCodeRequest request) throws Exception {
        List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
        if(!CollectionUtils.isEmpty(bas0001List)){
            Bas0001 bas0001 = bas0001List.get(0);
            setSessionInfo(vertx, sessionId,
                    SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(), bas0001.getLanguage(), "", 1, ""));
        }
        else{
            LOGGER.info("EMRGetByPatientCodeAndHospCodeRequest preHandle not found hosp code");
        }
    }
	
	@Override
	@Transactional(readOnly = true)
	public EMRGetByPatientCodeAndHospCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			EMRGetByPatientCodeAndHospCodeRequest request) throws Exception {
		
		EmrServiceProto.EMRGetByPatientCodeAndHospCodeResponse.Builder response = EmrServiceProto.EMRGetByPatientCodeAndHospCodeResponse.newBuilder(); 
		List<EmrRecord> emrRecordList = emrRecordRepository.getByActiveBunho(request.getPatientCode(), request.getHospCode());
		if(!CollectionUtils.isEmpty(emrRecordList)){
			response.setContent(emrRecordList.get(0).getContent());
			response.setVersion(String.valueOf(emrRecordList.get(0).getVersion()));
		}
		
		List<EmrTag> listEmrTag = emrTagRepository.getByActiveHospital(request.getHospCode());
		if(!CollectionUtils.isEmpty(listEmrTag)){
			for (EmrTag emrTag : listEmrTag) {
				EmrModelProto.EmrTagInfo.Builder info = EmrModelProto.EmrTagInfo.newBuilder();
				BeanUtils.copyProperties(emrTag, info, getLanguage(vertx, sessionId));
				response.addEmrTagInfo(info);
			}
		}
		return response.build();
	}
	
	
}
