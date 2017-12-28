package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTemplateTypeRepository;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTemplateTypeInfo;
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
public class OCS2015U31EmrTemplateTypeHandler extends ScreenHandler<EmrServiceProto.OCS2015U31EmrTemplateTypeRequest, EmrServiceProto.OCS2015U31EmrTemplateTypeResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U31EmrTemplateTypeHandler.class);                                    
	@Resource                                                                                                       
	private EmrTemplateTypeRepository emrTemplateTypeRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U31EmrTemplateTypeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U31EmrTemplateTypeRequest request) throws Exception {
		EmrServiceProto.OCS2015U31EmrTemplateTypeResponse.Builder response = EmrServiceProto.OCS2015U31EmrTemplateTypeResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		List<OCS2015U31EmrTemplateTypeInfo> list = emrTemplateTypeRepository.getTemplateTyeListItemInfo(language);
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U31EmrTemplateTypeInfo item : list){
				EmrModelProto.OCS2015U31EmrTemplateTypeInfo.Builder info = EmrModelProto.OCS2015U31EmrTemplateTypeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addEmrTemplateTypeInfo(info);
			}
		}
		return response.build();
	}
}