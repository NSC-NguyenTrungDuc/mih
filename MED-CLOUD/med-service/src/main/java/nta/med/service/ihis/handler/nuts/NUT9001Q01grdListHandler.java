package nta.med.service.ihis.handler.nuts;

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
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nut.Nut2010Repository;
import nta.med.data.model.ihis.nuts.NUT9001Q01grdListInfo;
import nta.med.service.ihis.proto.NutsModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001Q01grdListRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001Q01grdListResponse;

@Service
@Scope("prototype")
public class NUT9001Q01grdListHandler
		extends ScreenHandler<NutsServiceProto.NUT9001Q01grdListRequest, NutsServiceProto.NUT9001Q01grdListResponse> {

	@Resource
	private Nut2010Repository nut2010Repository;

	@Override
	@Transactional(readOnly = true)
	public NUT9001Q01grdListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001Q01grdListRequest request) throws Exception {
		NutsServiceProto.NUT9001Q01grdListResponse.Builder response = NutsServiceProto.NUT9001Q01grdListResponse
				.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUT9001Q01grdListInfo> infos = nut2010Repository.getNUT9001Q01grdListInfo(hospCode
				, DateUtil.toDate(request.getNutDate(), DateUtil.PATTERN_YYMMDD)
				, request.getBldGubun()
				, CommonUtils.parseDouble(request.getMagamSeq())
				, request.getHoDong());
		
		if(!CollectionUtils.isEmpty(infos)){
			for (NUT9001Q01grdListInfo info : infos) {
				NutsModelProto.NUT9001Q01grdListInfo.Builder pInfo = NutsModelProto.NUT9001Q01grdListInfo.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addGrdMasterItem(pInfo);
			}
		}
		
		return response.build();
	}
	
}
