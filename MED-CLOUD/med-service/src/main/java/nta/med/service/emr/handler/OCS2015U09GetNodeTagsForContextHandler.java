package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U09GetTagsForContextInfo;
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
public class OCS2015U09GetNodeTagsForContextHandler extends ScreenHandler<EmrServiceProto.OCS2015U09GetNodeTagsForContextRequest, EmrServiceProto.OCS2015U09GetNodeTagsForContextResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U09GetNodeTagsForContextHandler.class);                                    
	@Resource                                                                                                       
	private EmrTagRepository emrTagRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U09GetNodeTagsForContextResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U09GetNodeTagsForContextRequest request) throws Exception {
		EmrServiceProto.OCS2015U09GetNodeTagsForContextResponse.Builder response = EmrServiceProto.OCS2015U09GetNodeTagsForContextResponse.newBuilder();
		List<OCS2015U09GetTagsForContextInfo> list = emrTagRepository.getOCS2015U09GetTagsNodeForContextInfo(getHospitalCode(vertx, sessionId), request.getFUserId(), request.getFParentTagCode());
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2015U09GetTagsForContextInfo item:list){
				EmrModelProto.OCS2015U09GetTagsForContextInfo.Builder info = EmrModelProto.OCS2015U09GetTagsForContextInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getEmRTagId() != null) {
					info.setEmrTagId(item.getEmRTagId().toString());
				}
				if (!StringUtils.isEmpty(item.getTagCode())) {
					info.setTagCode(item.getTagCode());
				}
				if (!StringUtils.isEmpty(item.getTagName())) {
					info.setTagName(item.getTagName());
				}
				if (!StringUtils.isEmpty(item.getTagLevel())) {
					info.setTagLevel(item.getTagLevel());
				}
				if (!StringUtils.isEmpty(item.getTagDisplayText())) {
					info.setTagDisplayText(item.getTagDisplayText());
				}
				if (!StringUtils.isEmpty(item.getTagParent())) {
					info.setTagParent(item.getTagParent());
				}
				if (!StringUtils.isEmpty(item.getDescription())) {
					info.setDescription(item.getDescription());
				}
				if (!StringUtils.isEmpty(item.getPermissionType())) {
					info.setPermissionType(item.getPermissionType());
				}
				if (!StringUtils.isEmpty(item.getSysId())) {
					info.setSysId(item.getSysId());
				}
				if (!StringUtils.isEmpty(item.getUpdId())) {
					info.setUpdId(item.getUpdId());
				}
				response.addRootTagList(info);
			}
		}
		return response.build();
	}
}