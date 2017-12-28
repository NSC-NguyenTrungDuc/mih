package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DoubleMultiCboRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01DoubleMultiCboResponse;

@Service
@Scope("prototype")
public class INP1001U01DoubleMultiCboHandler extends ScreenHandler<InpsServiceProto.INP1001U01DoubleMultiCboRequest, InpsServiceProto.INP1001U01DoubleMultiCboResponse>{
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001U01DoubleMultiCboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01DoubleMultiCboRequest request) throws Exception {
		InpsServiceProto.INP1001U01DoubleMultiCboResponse.Builder response = InpsServiceProto.INP1001U01DoubleMultiCboResponse.newBuilder();
		List<ComboListItemInfo> listIpwonType =  bas0102Repository.getCodeCodeNameListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "IPWON_TYPE");
		if (!CollectionUtils.isEmpty(listIpwonType)) {
			for (ComboListItemInfo item : listIpwonType) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.addCboHiAge(info);
			} 
		}	
		
		List<ComboListItemInfo> listHiAge =  bas0102Repository.getCodeCodeNameListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "HI_AGE_GUBUN");
		if (!CollectionUtils.isEmpty(listHiAge)) {
			for (ComboListItemInfo item : listHiAge) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				info.setCode(item.getCode());
				info.setCodeName(item.getCodeName());
				response.addCboHiAge(info);
			} 
		}
		return response.build();
	}

}
