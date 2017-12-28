package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01layCommonRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUR2004U01layCommonHandler
		extends ScreenHandler<NuriServiceProto.NUR2004U01layCommonRequest, SystemServiceProto.ComboResponse> {
	
	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01layCommonRequest request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> result = inp2004Repository.getNUR2004U01layCommon(hospCode, CommonUtils.parseDouble(request.getFkinp1001()));
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}

}
