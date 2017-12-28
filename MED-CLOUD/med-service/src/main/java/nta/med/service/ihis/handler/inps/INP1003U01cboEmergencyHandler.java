package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.inps.INP1003U01cboEmergencyInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01cboEmergencyRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01cboEmergencyResponse;

@Service
@Scope("prototype")
public class INP1003U01cboEmergencyHandler extends ScreenHandler<InpsServiceProto.INP1003U01cboEmergencyRequest, InpsServiceProto.INP1003U01cboEmergencyResponse>{
	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly=true)
	public INP1003U01cboEmergencyResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01cboEmergencyRequest request) throws Exception {
		InpsServiceProto.INP1003U01cboEmergencyResponse.Builder response = InpsServiceProto.INP1003U01cboEmergencyResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP1003U01cboEmergencyInfo> listInfo = bas0102Repository.getINP1003U01cboEmergencyInfo(hospCode);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1003U01cboEmergencyInfo info : listInfo) {
			InpsModelProto.INP1003U01cboEmergencyInfo.Builder infoProto = InpsModelProto.INP1003U01cboEmergencyInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addCboEmer(infoProto);
		}
	
		return response.build();
	}

}
