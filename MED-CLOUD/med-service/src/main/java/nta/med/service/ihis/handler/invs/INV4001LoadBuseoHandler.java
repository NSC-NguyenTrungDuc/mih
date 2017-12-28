package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001LoadBuseoRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001LoadBuseoResponse;

@Service
@Scope("prototype")
public class INV4001LoadBuseoHandler extends ScreenHandler<InvsServiceProto.INV4001LoadBuseoRequest, InvsServiceProto.INV4001LoadBuseoResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV4001LoadBuseoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001LoadBuseoRequest request) throws Exception {
		InvsServiceProto.INV4001LoadBuseoResponse.Builder response = InvsServiceProto.INV4001LoadBuseoResponse.newBuilder();
		List<ComboListItemInfo> buseos = bas0260Repository.getINV4001LoadBuseo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(buseos)){
			for(ComboListItemInfo item : buseos){
				InvsModelProto.INV4001LoadBuseoInfo.Builder info = InvsModelProto.INV4001LoadBuseoInfo.newBuilder();
            	if(!StringUtils.isEmpty(item.getCode())){
            		info.setBuseoCode(item.getCode());
            	}
            	if(!StringUtils.isEmpty(item.getCodeName())){
            		info.setBuseoName(item.getCodeName());
            	}
            	response.addLst(info);
			}
		}
		return response.build();
	}

}
