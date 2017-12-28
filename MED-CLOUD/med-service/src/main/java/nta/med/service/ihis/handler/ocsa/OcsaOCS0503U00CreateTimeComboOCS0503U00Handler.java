package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.ocsa.OcsaOCS0503U00CreateTimeComboInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00CreateTimeComboRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503U00CreateTimeComboResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OcsaOCS0503U00CreateTimeComboOCS0503U00Handler
	extends ScreenHandler<OcsaServiceProto.OCS0503U00CreateTimeComboRequest, OcsaServiceProto.OCS0503U00CreateTimeComboResponse> {
	@Resource
	private Res0102Repository res0102Repository;

	@Override
	@Transactional(readOnly = true)
	public OCS0503U00CreateTimeComboResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503U00CreateTimeComboRequest request) throws Exception {
		OcsaServiceProto.OCS0503U00CreateTimeComboResponse.Builder response = OcsaServiceProto.OCS0503U00CreateTimeComboResponse.newBuilder();
    	List<OcsaOCS0503U00CreateTimeComboInfo> listTime = res0102Repository.createTimeComboOCS0503U00(getHospitalCode(vertx, sessionId),request.getDoctor(), request.getIntweek(),DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD));
		if (!CollectionUtils.isEmpty(listTime)) {
			for(OcsaOCS0503U00CreateTimeComboInfo item:listTime){
				OcsaModelProto.OCS0503U00CreateTimeComboInfo.Builder info = OcsaModelProto.OCS0503U00CreateTimeComboInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCreateTime(info);
			}	
		}
		return response.build();
	}

}
