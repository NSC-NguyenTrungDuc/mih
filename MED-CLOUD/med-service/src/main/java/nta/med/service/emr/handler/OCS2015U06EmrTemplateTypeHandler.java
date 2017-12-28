package nta.med.service.emr.handler;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.emr.EmrTemplateTypeRepository;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTemplateTypeInfo;
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
public class OCS2015U06EmrTemplateTypeHandler extends ScreenHandler<EmrServiceProto.OCS2015U06EmrTemplateTypeRequest, EmrServiceProto.OCS2015U06EmrTemplateTypeResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U06EmrTemplateTypeHandler.class);                                    
	@Resource                                                                                                       
	private EmrTemplateTypeRepository emrTemplateTypeRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U06EmrTemplateTypeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U06EmrTemplateTypeRequest request) throws Exception {

		EmrServiceProto.OCS2015U06EmrTemplateTypeResponse.Builder response = EmrServiceProto.OCS2015U06EmrTemplateTypeResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		List<OCS2015U06EmrTemplateTypeInfo> list = emrTemplateTypeRepository.getOCS2015U06EmrTemplateTypeInfo(language);
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U06EmrTemplateTypeInfo item : list){
				EmrModelProto.OCS2015U06EmrTemplateTypeInfo.Builder info = EmrModelProto.OCS2015U06EmrTemplateTypeInfo.newBuilder();
				if (item.getTemplateTypeId() != null) {
					info.setTemplateTypeId(item.getTemplateTypeId().toString());
				}
				if (!StringUtils.isEmpty(item.getTypeCode())) {
					info.setTypeCode(item.getTypeCode());
				}
				if (!StringUtils.isEmpty(item.getTypeName())) {
					info.setTypeName(item.getTypeName());
				}
				if (!StringUtils.isEmpty(item.getTypeTag())) {
					info.setTypeTag(item.getTypeTag());
				}
				if (!StringUtils.isEmpty(item.getDescription())) {
					info.setDescription(item.getDescription());
				}
				if (item.getActiveFlg() != null) {
					info.setActiveFlg(item.getActiveFlg().toString());
				}
				if (item.getCreated() != null) {
					info.setCreated(DateUtil.toString(item.getCreated(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getUpdated() != null) {
					info.setUpdated(DateUtil.toString(item.getUpdated(), DateUtil.PATTERN_YYMMDD));
				}
				response.addEmrTemplateTypeList(info);
			}
		}
		return response.build();
	}
}