package nta.med.service.ihis.handler.nuts;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nut.Nut2011Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00grdINP5001QueryEndRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00grdINP5001QueryEndResponse;

@Service
@Scope("prototype")
public class NUT9001U00grdINP5001QueryEndHandler extends
		ScreenHandler<NutsServiceProto.NUT9001U00grdINP5001QueryEndRequest, NutsServiceProto.NUT9001U00grdINP5001QueryEndResponse> {

	@Resource
	private Nut2011Repository nut2011Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUT9001U00grdINP5001QueryEndResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00grdINP5001QueryEndRequest request) throws Exception {
		NutsServiceProto.NUT9001U00grdINP5001QueryEndResponse.Builder response = NutsServiceProto.NUT9001U00grdINP5001QueryEndResponse.newBuilder();
		String maxSeq = nut2011Repository.getMaxMagamSeqByHospCodeNutDateBldGubun(getHospitalCode(vertx, sessionId)
				, DateUtil.toDate(request.getNutDate(), DateUtil.PATTERN_YYMMDD)
				, request.getBldGubun());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder().setDataValue(StringUtils.isEmpty(maxSeq) ? "0" : maxSeq);
		response.setGrdItem(info);
		return response.build();
	}

}
