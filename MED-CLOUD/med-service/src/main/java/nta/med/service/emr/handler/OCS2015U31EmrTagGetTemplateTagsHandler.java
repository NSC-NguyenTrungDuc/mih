package nta.med.service.emr.handler;

import java.util.Arrays;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTagGetTemplateTagsInfo;
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

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U31EmrTagGetTemplateTagsHandler extends ScreenHandler<EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsRequest, EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U31EmrTagGetTemplateTagsHandler.class);                                    
	@Resource                                                                                                       
	private EmrTagRepository emrTagRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsRequest request) throws Exception {
		EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsResponse.Builder response = EmrServiceProto.OCS2015U31EmrTagGetTemplateTagsResponse.newBuilder();
		String[] tokens = request.getStrTagCode().split(",");
		List<OCS2015U31EmrTagGetTemplateTagsInfo> list = emrTagRepository.getOCS2015U31EmrTagGetTemplateTagsInfo(getHospitalCode(vertx, sessionId), Arrays.asList(tokens));
		if(!CollectionUtils.isEmpty(list)){
			for (OCS2015U31EmrTagGetTemplateTagsInfo item : list){
				EmrModelProto.OCS2015U31EmrTagGetTemplateTagsInfo.Builder info = EmrModelProto.OCS2015U31EmrTagGetTemplateTagsInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGridTagItemInfo(info);
			}
		}
		return response.build();
	}
}