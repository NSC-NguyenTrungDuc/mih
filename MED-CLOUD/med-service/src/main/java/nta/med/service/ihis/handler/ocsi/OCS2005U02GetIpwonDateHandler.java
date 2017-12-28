package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02GetIpwonDateRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02GetIpwonDateResponse;

@Service
@Scope("prototype")
public class OCS2005U02GetIpwonDateHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02GetIpwonDateRequest, OcsiServiceProto.OCS2005U02GetIpwonDateResponse> {
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02GetIpwonDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02GetIpwonDateRequest request) throws Exception {
		OcsiServiceProto.OCS2005U02GetIpwonDateResponse.Builder response = OcsiServiceProto.OCS2005U02GetIpwonDateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<DataStringListItemInfo> result = inp1001Repository.getInpwonDateOcs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserDate(hospCode, request.getBunho(), "0");
			if(!CollectionUtils.isEmpty(result)){
				for(DataStringListItemInfo item : result){
					CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
					info.setDataValue(item.getItem());
					response.setIwondateItem(info);
				}
			}
		}else{
			for(DataStringListItemInfo item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item.getItem());
				response.setIwondateItem(info);
			}
		}
		
		return response.build();
	}

	
}
