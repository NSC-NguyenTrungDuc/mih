package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00DrugUserRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00DrugUserResponse;

@Service
@Scope("prototype")
public class INV4001U00DrugUserHandler extends ScreenHandler<InvsServiceProto.INV4001U00DrugUserRequest, InvsServiceProto.INV4001U00DrugUserResponse> {

	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV4001U00DrugUserResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00DrugUserRequest request) throws Exception {
		InvsServiceProto.INV4001U00DrugUserResponse.Builder response = InvsServiceProto.INV4001U00DrugUserResponse.newBuilder();
		List<ComboListItemInfo> drgUsers = adm3200Repository.getDRG0201U00CbxActor(getHospitalCode(vertx, sessionId), "DRG", true);
		if (!CollectionUtils.isEmpty(drgUsers)) {
            for (ComboListItemInfo item : drgUsers) {
            	InvsModelProto.INV4001U00DrugUserInfo.Builder info = InvsModelProto.INV4001U00DrugUserInfo.newBuilder();
            	if(!StringUtils.isEmpty(item.getCode())){
            		info.setUserId(item.getCode());
            	}
            	if(!StringUtils.isEmpty(item.getCodeName())){
            		info.setUserNm(item.getCodeName());
            	}
            	response.addLst(info);
            }
        }
		return response.build();
	}

}
