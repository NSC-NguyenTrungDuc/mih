package nta.med.service.ihis.handler.cpls;
import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.PrCplSpecimenInfoResultListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00PrCplSpecimenInfoResultHandler extends ScreenHandler<CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultRequest, CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	public CPL3020U00PrCplSpecimenInfoResultResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00PrCplSpecimenInfoResultRequest request) throws Exception{
        CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultResponse.Builder response = CplsServiceProto.CPL3020U00PrCplSpecimenInfoResultResponse.newBuilder();
        PrCplSpecimenInfoResultListItemInfo item = cpl2010Repository.prCplSpecimenInfoResult(getHospitalCode(vertx, sessionId), request.getSpecimentSer());
        CplsModelProto.CPL3020U00PrCplSpecimenInfoResultListItemInfo.Builder info = CplsModelProto.CPL3020U00PrCplSpecimenInfoResultListItemInfo.newBuilder();
        BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        response.setResultList(info);
        return response.build();
	}
}
