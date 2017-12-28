package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getPkocskeyRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getPkocskeyResponse;

@Service
@Scope("prototype")
public class OCS2003U03getPkocskeyHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getPkocskeyRequest, OcsiServiceProto.OCS2003U03getPkocskeyResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getPkocskeyResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getPkocskeyRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getPkocskeyResponse.Builder response = OcsiServiceProto.OCS2003U03getPkocskeyResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DataStringListItemInfo> layList = ocs2003Repository.getOCS2003U03getPkocskey(CommonUtils.parseDouble(request.getPkOcs2003()), request.getWorkGubun(), hospCode);
		
		if(!CollectionUtils.isEmpty(layList)){
			for(DataStringListItemInfo item : layList){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				//BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setDataValue(item.getItem());
				response.addGrdDrug(info);
			}
		}
		return response.build();
	}
}
