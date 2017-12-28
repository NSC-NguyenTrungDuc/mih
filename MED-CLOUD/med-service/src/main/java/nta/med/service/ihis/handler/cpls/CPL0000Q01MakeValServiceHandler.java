package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q01MakeValServiceRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q01MakeValServiceResponse;

@Service                                                                                                          
@Scope("prototype") 
public class CPL0000Q01MakeValServiceHandler extends ScreenHandler<CplsServiceProto.CPL0000Q01MakeValServiceRequest, CplsServiceProto.CPL0000Q01MakeValServiceResponse>{
	@Resource
	private Cpl0101Repository cpl0101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL0000Q01MakeValServiceResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL0000Q01MakeValServiceRequest request) throws Exception {
		CplsServiceProto.CPL0000Q01MakeValServiceResponse.Builder response = CplsServiceProto.CPL0000Q01MakeValServiceResponse.newBuilder();
		String result = cpl0101Repository.getCPL0101U00FbxHangmogCodeName(getHospitalCode(vertx, sessionId), request.getCode());
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setItem(info);
		}
		return response.build();
	}

}
