package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0001Repository;
import nta.med.data.model.ihis.cpls.CPL0001U00GrdSlipInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdSlipRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdSlipResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0001U00GrdSlipHandler extends ScreenHandler<CPL0001U00GrdSlipRequest, CPL0001U00GrdSlipResponse> {
	@Resource
	private Cpl0001Repository cpl0001Repository;

	@Override
	@Transactional(readOnly = true)
	public CPL0001U00GrdSlipResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0001U00GrdSlipRequest request)
			throws Exception {
		CPL0001U00GrdSlipResponse.Builder response = CPL0001U00GrdSlipResponse.newBuilder();
		List<CPL0001U00GrdSlipInfo> list = cpl0001Repository.getCPL0001U00GrdSlipInfo(getHospitalCode(vertx, sessionId), request.getFSlipCode());
		if(!CollectionUtils.isEmpty(list)){
			for(CPL0001U00GrdSlipInfo item : list){
				CplsModelProto.CPL0001U00GrdSlipInfo.Builder info = CplsModelProto.CPL0001U00GrdSlipInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDt(info);
			}
		}
		return response.build();
	}

}
