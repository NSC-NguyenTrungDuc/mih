package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.INV6002U00GrdINV6002AfterInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002AfterRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV6002U00GrdINV6002AfterResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class INV6002U00GrdINV6002AfterHandler extends ScreenHandler<InvsServiceProto.INV6002U00GrdINV6002AfterRequest, InvsServiceProto.INV6002U00GrdINV6002AfterResponse>{

	@Resource
    private Inv0110Repository inv0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV6002U00GrdINV6002AfterResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6002U00GrdINV6002AfterRequest request) throws Exception {
		String offset = request.getOffset();
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		InvsServiceProto.INV6002U00GrdINV6002AfterResponse.Builder response = InvsServiceProto.INV6002U00GrdINV6002AfterResponse.newBuilder();
		List<INV6002U00GrdINV6002AfterInfo> itemList = inv0110Repository.getINV6002U00GrdINV6002AfterInfo(getHospitalCode(vertx, sessionId), request.getMonth(), request.getJaeryoGubun(), getLanguage(vertx, sessionId), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(itemList)){
			for (INV6002U00GrdINV6002AfterInfo item : itemList) {
				InvsModelProto.INV6002U00GrdINV6002AfterInfo.Builder info = InvsModelProto.INV6002U00GrdINV6002AfterInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItem(info);
			}
		}
		
		return response.build();
	}
	
}
