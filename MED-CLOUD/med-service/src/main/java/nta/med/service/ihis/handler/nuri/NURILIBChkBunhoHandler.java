package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.bass.INP1003ChkBunhoListItemInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBChkBunhoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NURILIBChkBunhoResponse;

@Service
@Scope("prototype")
public class NURILIBChkBunhoHandler extends ScreenHandler<NuriServiceProto.NURILIBChkBunhoRequest, NuriServiceProto.NURILIBChkBunhoResponse>{
	@Resource
	Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NURILIBChkBunhoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NURILIBChkBunhoRequest request) throws Exception {
		NuriServiceProto.NURILIBChkBunhoResponse.Builder response = NuriServiceProto.NURILIBChkBunhoResponse.newBuilder();
		List<INP1003ChkBunhoListItemInfo> list  =  out0101Repository.getINP1003ChkBunhoListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if (!CollectionUtils.isEmpty(list)) {
			for (INP1003ChkBunhoListItemInfo item : list) {
				NuriModelProto.NURILIBChkBunhoInfo.Builder info = NuriModelProto.NURILIBChkBunhoInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addBunhoRes(info);
			}
		}
		return response.build();
	}

}
