package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrRecordRepository;
import nta.med.data.model.ihis.emr.OCS2015U06EmrRecordInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U06EmrRecordHandler extends ScreenHandler<EmrServiceProto.OCS2015U06EmrRecordRequest, EmrServiceProto.OCS2015U06EmrRecordResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U06EmrRecordHandler.class);                                    
	@Resource                                                                                                       
	private EmrRecordRepository emrRecordRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U06EmrRecordResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U06EmrRecordRequest request) throws Exception {
		EmrServiceProto.OCS2015U06EmrRecordResponse.Builder response = EmrServiceProto.OCS2015U06EmrRecordResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCode())){
			hospCode = request.getHospCode();
		}
		List<OCS2015U06EmrRecordInfo> list = emrRecordRepository.getOCS2015U06EmrRecordInfo(request.getBunho(), hospCode);
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U06EmrRecordInfo item : list){
				EmrModelProto.OCS2015U06EmrRecordInfo.Builder info = EmrModelProto.OCS2015U06EmrRecordInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addEmrRecordList(info);
			}
		}
		return response.build();
	}
}