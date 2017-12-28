package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect1ListItemInfo;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q01layBmlUrlInfoRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q01layBmlUrlInfoResponse;

@Service                                                                                                          
@Scope("prototype")
public class CPL0000Q01layBmlUrlInfoHandler extends ScreenHandler<CplsServiceProto.CPL0000Q01layBmlUrlInfoRequest, CplsServiceProto.CPL0000Q01layBmlUrlInfoResponse>{
	@Resource
	private Ocs0132Repository ocs0132Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public CPL0000Q01layBmlUrlInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CPL0000Q01layBmlUrlInfoRequest request) throws Exception {
		CplsServiceProto.CPL0000Q01layBmlUrlInfoResponse.Builder response = CplsServiceProto.CPL0000Q01layBmlUrlInfoResponse.newBuilder();
		List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> list = ocs0132Repository.getCPL0000Q00GetSigeyulDataSelect1ListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(list)) {
			for (CPL0000Q00GetSigeyulDataSelect1ListItemInfo item : list) {
				CplsModelProto.CPL0000Q01layBmlUrlInfoInfo.Builder info = CplsModelProto.CPL0000Q01layBmlUrlInfoInfo.newBuilder();
				info.setServerIp(StringUtils.isEmpty(item.getJubsuDate()) ? "" : item.getJubsuDate());
				info.setUserId(StringUtils.isEmpty(item.getJubsuTime()) ? "" : item.getJubsuTime());
				info.setPassword(StringUtils.isEmpty(item.getJubsuTime2()) ? "" : item.getJubsuTime2());
				response.addLayItem(info);
			}
		}
		return response.build();
	}

}
