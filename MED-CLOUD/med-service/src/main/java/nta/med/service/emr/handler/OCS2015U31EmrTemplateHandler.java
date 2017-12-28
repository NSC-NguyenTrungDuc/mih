package nta.med.service.emr.handler;

import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTemplateInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U31EmrTemplateHandler extends ScreenHandler<EmrServiceProto.OCS2015U31EmrTemplateRequest, EmrServiceProto.OCS2015U31EmrTemplateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U31EmrTemplateHandler.class);                                    
	@Resource                                                                                                       
	private EmrTemplateRepository emrTemplateRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U31EmrTemplateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U31EmrTemplateRequest request) throws Exception {
		EmrServiceProto.OCS2015U31EmrTemplateResponse.Builder response = EmrServiceProto.OCS2015U31EmrTemplateResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		List<OCS2015U31EmrTemplateInfo> list = emrTemplateRepository.getTemplateListItemInfo(getHospitalCode(vertx, sessionId), request.getSysId(), request.getUserGroup(), language);
		if(!CollectionUtils.isEmpty(list)){
			for (OCS2015U31EmrTemplateInfo item:list){
				EmrModelProto.OCS2015U31EmrTemplateInfo.Builder info = EmrModelProto.OCS2015U31EmrTemplateInfo.newBuilder();
				if (item.getTemplateId() != null) {
					info.setTemplateId(item.getTemplateId().toString());
				}
				if (item.getTemplateTypeId() != null) {
					info.setTemplateTypeId(item.getTemplateTypeId().toString());
				}
				if (!StringUtils.isEmpty(item.getTemplateName())) {
					info.setTemplateName(item.getTemplateName());
				}
				if (!StringUtils.isEmpty(item.getTemplateContent())) {
					info.setTemplateContent(item.getTemplateContent());
				}
				if (!StringUtils.isEmpty(item.getDescription())) {
					info.setDescription(item.getDescription());
				}
				if (!StringUtils.isEmpty(item.getPermissionType())) {
					info.setPermissionType(item.getPermissionType());
				}
				if (!StringUtils.isEmpty(item.getHospCode())) {
					info.setHospCode(item.getHospCode());
				}
				if (!StringUtils.isEmpty(item.getTypeName())) {
					info.setTypeName(item.getTypeName());
				}
				if (!StringUtils.isEmpty(item.getSysId())) {
					info.setSysId(item.getSysId());
				}
				response.addGridTemplateItemInfo(info);
			}
		}
		return response.build();
	}
}