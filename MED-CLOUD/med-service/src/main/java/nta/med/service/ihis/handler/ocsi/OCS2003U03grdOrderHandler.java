package nta.med.service.ihis.handler.ocsi;

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
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOrderInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdOrderRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdOrderResponse;

@Service
@Scope("prototype")
public class OCS2003U03grdOrderHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03grdOrderRequest, OcsiServiceProto.OCS2003U03grdOrderResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03grdOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03grdOrderRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03grdOrderResponse.Builder response = OcsiServiceProto.OCS2003U03grdOrderResponse.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String hospCode = getHospitalCode(vertx, sessionId);
		List<OCS2003U03grdOrderInfo> list = ocs2003Repository.getOCS2003U03grdOrderInfo(hospCode, request.getKijunDate(), request.getBunho(), request.getFkinp1001(), request.getOrderDate(), request.getInputDoctor(), startNum, CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U03grdOrderInfo item : list) {
				OcsiModelProto.OCS2003U03grdOrderInfo.Builder info = OcsiModelProto.OCS2003U03grdOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdListorder(info);
			}
		}
		return response.build();
	}

}
