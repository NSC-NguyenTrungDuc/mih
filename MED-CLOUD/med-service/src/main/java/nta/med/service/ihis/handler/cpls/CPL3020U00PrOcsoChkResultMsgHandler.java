package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur1040Repository;
import nta.med.data.model.ihis.cpls.PrOcsoChkResultMsgListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00PrOcsoChkResultMsgRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00PrOcsoChkResultMsgResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00PrOcsoChkResultMsgHandler extends ScreenHandler <CplsServiceProto.CPL3020U00PrOcsoChkResultMsgRequest, CplsServiceProto.CPL3020U00PrOcsoChkResultMsgResponse> {
	@Resource
	private Nur1040Repository nur1040Repository;
	
	@Override
	public CPL3020U00PrOcsoChkResultMsgResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00PrOcsoChkResultMsgRequest request) throws Exception{
        CplsServiceProto.CPL3020U00PrOcsoChkResultMsgResponse.Builder response = CplsServiceProto.CPL3020U00PrOcsoChkResultMsgResponse.newBuilder();
        CplsModelProto.CPL3020U00PrOcsoChkResultMsgListItemInfo.Builder info = CplsModelProto.CPL3020U00PrOcsoChkResultMsgListItemInfo.newBuilder();
        PrOcsoChkResultMsgListItemInfo item = nur1040Repository.prOcsoChkResultMsg(getHospitalCode(vertx, sessionId), request.getOcskey(), request.getUserId()); 
        BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        response.setResultList(info);
        return response.build();
	}
}
