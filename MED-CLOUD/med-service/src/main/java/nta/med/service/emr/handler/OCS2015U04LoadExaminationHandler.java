package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.emr.OCS2015U04LoadExaminationInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
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
public class OCS2015U04LoadExaminationHandler extends ScreenHandler<EmrServiceProto.OCS2015U04LoadExaminationRequest, EmrServiceProto.OCS2015U04LoadExaminationResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U04LoadExaminationHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U04LoadExaminationResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U04LoadExaminationRequest request) throws Exception {
		EmrServiceProto.OCS2015U04LoadExaminationResponse.Builder response = EmrServiceProto.OCS2015U04LoadExaminationResponse.newBuilder();
		List<OCS2015U04LoadExaminationInfo> list = out1001Repository.getOCS2015U04LoadExaminationInfo(getHospitalCode(vertx, sessionId), request.getPatientCode());
		if (!CollectionUtils.isEmpty(list)) {
			for(OCS2015U04LoadExaminationInfo item:list){
				EmrModelProto.OCS2015U04LoadExaminationInfo.Builder info = EmrModelProto.OCS2015U04LoadExaminationInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setPkout1001(String.format("%.0f", item.getPkout1001()));
				response.addEmrLoadExaminationList(info);
			}
		}
		return response.build();
	}
}