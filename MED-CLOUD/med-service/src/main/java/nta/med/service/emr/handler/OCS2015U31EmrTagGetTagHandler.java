package nta.med.service.emr.handler;

import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U31EmrTagGetTagInfo;
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
public class OCS2015U31EmrTagGetTagHandler extends ScreenHandler<EmrServiceProto.OCS2015U31EmrTagGetTagRequest, EmrServiceProto.OCS2015U31EmrTagGetTagResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U31EmrTagGetTagHandler.class);
	@Resource
	private EmrTagRepository emrTagRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U31EmrTagGetTagResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U31EmrTagGetTagRequest request) throws Exception {
		EmrServiceProto.OCS2015U31EmrTagGetTagResponse.Builder response = EmrServiceProto.OCS2015U31EmrTagGetTagResponse.newBuilder();
			List<OCS2015U31EmrTagGetTagInfo> list = emrTagRepository.getOCS2015U31EmrTagGetTagInfo(getHospitalCode(vertx, sessionId),request.getTagLevel());
			if(!CollectionUtils.isEmpty(list)){
				for (OCS2015U31EmrTagGetTagInfo item:list){
					EmrModelProto.OCS2015U31EmrTagGetTagInfo.Builder info = EmrModelProto.OCS2015U31EmrTagGetTagInfo.newBuilder();
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
					response.addGridTagItemInfo(info);
				}
			}
			return response.build();
	}
}