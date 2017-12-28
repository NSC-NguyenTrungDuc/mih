package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00LoadCodeNameRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00LoadCodeNameResponse;

@Service
@Scope("prototype")
public class INV4001U00LoadCodeNameHandler extends ScreenHandler<InvsServiceProto.INV4001U00LoadCodeNameRequest, InvsServiceProto.INV4001U00LoadCodeNameResponse> {
	
	@Resource
	private Inv0102Repository inv0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV4001U00LoadCodeNameResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00LoadCodeNameRequest request) throws Exception {
		InvsServiceProto.INV4001U00LoadCodeNameResponse.Builder response = InvsServiceProto.INV4001U00LoadCodeNameResponse.newBuilder();
		List<ComboListItemInfo> codeNames = inv0102Repository.getINV4001U00LoadCodeName(getHospitalCode(vertx, sessionId), "IPGO_TYPE", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(codeNames)){
			for(ComboListItemInfo item : codeNames){
				InvsModelProto.INV4001U00LoadCodeNameInfo.Builder info = InvsModelProto.INV4001U00LoadCodeNameInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLst(info);
			}
		}
		return response.build();
	}

}
