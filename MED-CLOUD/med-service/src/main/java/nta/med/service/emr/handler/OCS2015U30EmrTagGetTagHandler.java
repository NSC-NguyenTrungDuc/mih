package nta.med.service.emr.handler;

import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U30EmrTagGetTagInfo;
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
public class OCS2015U30EmrTagGetTagHandler extends ScreenHandler<EmrServiceProto.OCS2015U30EmrTagGetTagRequest, EmrServiceProto.OCS2015U30EmrTagGetTagResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U30EmrTagGetTagHandler.class);                                    
	@Resource
	private EmrTagRepository emrTagRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U30EmrTagGetTagResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U30EmrTagGetTagRequest request) throws Exception {
		EmrServiceProto.OCS2015U30EmrTagGetTagResponse.Builder response = EmrServiceProto.OCS2015U30EmrTagGetTagResponse.newBuilder();
		String userGroup = emrTagRepository.getUserGroup(request.getSysId());
		List<OCS2015U30EmrTagGetTagInfo> list = emrTagRepository.getOCS2015U30EmrTagGetTagInfo(request.getTagLevel(), getHospitalCode(vertx, sessionId), request.getSysId(), userGroup);
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U30EmrTagGetTagInfo item : list){
				EmrModelProto.OCS2015U30EmrTagGetTagInfo.Builder info = EmrModelProto.OCS2015U30EmrTagGetTagInfo.newBuilder();
				if (item.getTagId() != null) {
					info.setTagId(item.getTagId().toString());
				}
				if (!StringUtils.isEmpty(item.getTagCode())) {
					info.setTagCode(item.getTagCode());
				}
				if (!StringUtils.isEmpty(item.getTagName())) {
					info.setTagName(item.getTagName());
				}
				if (!StringUtils.isEmpty(item.getTagDisplayText())) {
					info.setTagDisplayText(item.getTagDisplayText());
				}
				if (!StringUtils.isEmpty(item.getDescription())) {
					info.setDescription(item.getDescription());
				}
				if (!StringUtils.isEmpty(item.getTagLevel())) {
					info.setTagLevel(item.getTagLevel());
				}
				if (item.getFilterFlg() != null) {
					info.setFilterFlg(item.getFilterFlg().toString());
				}
				if (!StringUtils.isEmpty(item.getTagParent())) {
					info.setTagParent(item.getTagParent());
				}
				if (!StringUtils.isEmpty(item.getSysId())) {
					info.setSysId(item.getSysId());
				}
				response.addGridTagItemInfo(info);
			}
		}
		return response.build();
	}
}