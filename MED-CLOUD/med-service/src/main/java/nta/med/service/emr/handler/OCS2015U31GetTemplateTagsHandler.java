package nta.med.service.emr.handler;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U31GetTemplateTagsInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31GetTemplateTagsRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31GetTemplateTagsResponse;

/**
 * @author DEV_HieuTT
 *
 */
@Service
@Scope("prototype")
public class OCS2015U31GetTemplateTagsHandler extends ScreenHandler<OCS2015U31GetTemplateTagsRequest, OCS2015U31GetTemplateTagsResponse>{
	@Resource
	private EmrTagRepository emrTagRepository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U31GetTemplateTagsResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS2015U31GetTemplateTagsRequest request) throws Exception {
		EmrServiceProto.OCS2015U31GetTemplateTagsResponse.Builder response = EmrServiceProto.OCS2015U31GetTemplateTagsResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		List<OCS2015U31GetTemplateTagsInfo> listParent = emrTagRepository.getOCS2015U31GetTemplateTagsParentListInfo(getHospitalCode(vertx, sessionId), request.getEmrTemplateId());
		if(!CollectionUtils.isEmpty(listParent)){
			for(OCS2015U31GetTemplateTagsInfo item : listParent){
				EmrModelProto.OCS2015U31GetTemplateTagsInfo.Builder info = EmrModelProto.OCS2015U31GetTemplateTagsInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addTemTagRootItemInfo(info);
			}
		}
		
		List<OCS2015U31GetTemplateTagsInfo> listChild = emrTagRepository.getOCS2015U31GetTemplateTagsChildListInfo(getHospitalCode(vertx, sessionId), request.getEmrTemplateId());
		if(!CollectionUtils.isEmpty(listChild)){
			for(OCS2015U31GetTemplateTagsInfo item : listChild){
				EmrModelProto.OCS2015U31GetTemplateTagsInfo.Builder info = EmrModelProto.OCS2015U31GetTemplateTagsInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addTemTagNodeItemInfo(info);
			}
		}
		return response.build();
	}

}
