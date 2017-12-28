package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2004Q00grdHoCodeListRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP2004Q00grdHoCodeListResponse;

@Service
@Scope("prototype")
public class INP2004Q00grdHoCodeListHandler extends ScreenHandler<InpsServiceProto.INP2004Q00grdHoCodeListRequest, InpsServiceProto.INP2004Q00grdHoCodeListResponse>{
	@Resource
	Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP2004Q00grdHoCodeListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2004Q00grdHoCodeListRequest request) throws Exception {
		InpsServiceProto.INP2004Q00grdHoCodeListResponse.Builder response = InpsServiceProto.INP2004Q00grdHoCodeListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<String> result = bas0250Repository.getINP2004Q00grdHoCodeListInfo(hospCode, request.getHoDong(), request.getJukyongDate());
		if(CollectionUtils.isEmpty(result)){
			return response.build();
		}
		
		for (String item : result) {
			InpsModelProto.INP2004Q00grdHoCodeListInfo.Builder info = InpsModelProto.INP2004Q00grdHoCodeListInfo.newBuilder();
			info.setHoCode(item);
			response.addGrdMasterItem(info);
		}
		
		return response.build();
	} 

}
