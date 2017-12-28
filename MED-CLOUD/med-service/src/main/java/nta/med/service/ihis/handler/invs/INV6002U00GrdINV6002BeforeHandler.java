package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002BeforeInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002BeforeRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00grdINV6002BeforeResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class INV6002U00GrdINV6002BeforeHandler extends
		ScreenHandler<InvsServiceProto.INV6002U00GrdINV6002BeforeRequest, InvsServiceProto.INV6002U00grdINV6002BeforeResponse> {

	@Resource
    private Inv0110Repository inv0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV6002U00grdINV6002BeforeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6002U00GrdINV6002BeforeRequest request) throws Exception {
		InvsServiceProto.INV6002U00grdINV6002BeforeResponse.Builder response = InvsServiceProto.INV6002U00grdINV6002BeforeResponse.newBuilder();
		String offset = request.getOffset();
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<INV6002U00GrdINV6002BeforeInfo> itemList = inv0110Repository.getINV6002U00GrdINV6002BeforeInfo(getHospitalCode(vertx, sessionId), request.getMonth(), request.getJaeryoGubun(), getLanguage(vertx, sessionId), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(itemList)){
			for (INV6002U00GrdINV6002BeforeInfo item : itemList) {
				InvsModelProto.INV6002U00GrdINV6002BeforeInfo.Builder info = InvsModelProto.INV6002U00GrdINV6002BeforeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItem(info);
			}
		}
		
		return response.build();
	}

	
}
