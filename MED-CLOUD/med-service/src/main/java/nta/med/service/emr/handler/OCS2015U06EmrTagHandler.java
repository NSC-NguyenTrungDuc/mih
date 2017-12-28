package nta.med.service.emr.handler;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U06EmrTagInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
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
public class OCS2015U06EmrTagHandler extends ScreenHandler<EmrServiceProto.OCS2015U06EmrTagRequest, EmrServiceProto.OCS2015U06EmrTagResponse> {
	@Resource                                                                                                       
	private EmrTagRepository emrTagRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U06EmrTagResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U06EmrTagRequest request) throws Exception {
		EmrServiceProto.OCS2015U06EmrTagResponse.Builder response = EmrServiceProto.OCS2015U06EmrTagResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCode())){
			hospCode = request.getHospCode();
		}
		List<OCS2015U06EmrTagInfo> list = emrTagRepository.getOCS2015U06EmrTagInfo(hospCode);
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U06EmrTagInfo item : list){
				EmrModelProto.OCS2015U06EmrTagInfo.Builder info = EmrModelProto.OCS2015U06EmrTagInfo.newBuilder();
				//BeanUtils.copyProperties(item, info);
				if (item.getTagId() != null) {
					info.setTagId(item.getTagId().toString());
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
				if (!StringUtils.isEmpty(item.getTagParent())) {
					info.setTagParent(item.getTagParent());
				}
				if (!StringUtils.isEmpty(item.getDescription())) {
					info.setDescription(item.getDescription());
				}
				if (!StringUtils.isEmpty(item.getUserId())) {
					info.setUserId(item.getUserId());
				}
				if (item.getFilterFlg() != null) {
					info.setFilterFlg(item.getFilterFlg().toString());
				}
				if (item.getCreated() != null) {
					info.setCreated(DateUtil.toString(item.getCreated(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getUpdated() != null) {
					info.setUpdated(DateUtil.toString(item.getUpdated(), DateUtil.PATTERN_YYMMDD));
				}
				response.addEmrTagList(info);
			}
		}
		return response.build();
	}
}