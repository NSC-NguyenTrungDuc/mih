package nta.med.service.emr.handler;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateInfo;
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
public class OCS2015U06EmrTemplateHandler extends ScreenHandler<EmrServiceProto.OCS2015U06EmrTemplateRequest, EmrServiceProto.OCS2015U06EmrTemplateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U06EmrTemplateHandler.class);                                    
	@Resource                                                                                                       
	private EmrTemplateRepository emrTemplateRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U06EmrTemplateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U06EmrTemplateRequest request) throws Exception {

		EmrServiceProto.OCS2015U06EmrTemplateResponse.Builder response = EmrServiceProto.OCS2015U06EmrTemplateResponse.newBuilder();
		List<OCS2015U06EmrTemplateInfo> list = emrTemplateRepository.getOCS2015U06EmrTemplateInfo("", "");
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U06EmrTemplateInfo item : list){
				EmrModelProto.OCS2015U06EmrTemplateInfo.Builder info = EmrModelProto.OCS2015U06EmrTemplateInfo.newBuilder();
				//BeanUtils.copyProperties(item, info);
				if (item.getTemplateId() != null) {
					info.setTemplateId(item.getTemplateId().toString());
				}
				if (item.getTemplateTypeId() != null) {
					info.setTemplateTypeId(item.getTemplateTypeId().toString());
				}
				//if (!StringUtils.isEmpty(item.getTemplateCode())) {
				//info.setTemplateCode(item.getTemplateCode());
				info.setTemplateCode(item.getTemplateId().toString());
				//}
				if (!StringUtils.isEmpty(item.getTemplateName())) {
					info.setTemplateName(item.getTemplateName());
				}
				if (!StringUtils.isEmpty(item.getTemplateContent())) {
					info.setTemplateContent(item.getTemplateContent());
				}
				if (!StringUtils.isEmpty(item.getHospCode())) {
					info.setHospCode(item.getHospCode());
				}
				if (!StringUtils.isEmpty(item.getGwa())) {
					info.setGwa(item.getGwa());
				}
				if (!StringUtils.isEmpty(item.getUserId())) {
					info.setUserId(item.getUserId());
				}
				if (!StringUtils.isEmpty(item.getPermissionType())) {
					info.setPermissionType(item.getPermissionType());
				}
				if (item.getCreated() != null) {
					info.setCreated(DateUtil.toString(item.getCreated(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getUpdated() != null) {
					info.setUpdated(DateUtil.toString(item.getUpdated(), DateUtil.PATTERN_YYMMDD));
				}
				response.addEmrTemplateList(info);
			}
		}
		return response.build();
	}
}