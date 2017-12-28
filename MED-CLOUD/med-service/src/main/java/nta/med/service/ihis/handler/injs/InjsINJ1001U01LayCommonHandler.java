package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01LayCommonHandler extends ScreenHandler<InjsServiceProto.INJ1001U01LayCommonRequest, InjsServiceProto.INJ1001U01LayCommonResponse>{
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01LayCommonHandler.class);
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1001U01LayCommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01LayCommonRequest request) throws Exception {
		InjsServiceProto.INJ1001U01LayCommonResponse.Builder response = InjsServiceProto.INJ1001U01LayCommonResponse.newBuilder();
		List<String> userNameList=adm3200Repository.getUserNameList(getHospitalCode(vertx, sessionId),request.getUserId());
		if(!CollectionUtils.isEmpty(userNameList)){
			for(String userName : userNameList){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(userName);
				response.addItemInfo(info);
			}
		}
		return response.build();
	}

}
