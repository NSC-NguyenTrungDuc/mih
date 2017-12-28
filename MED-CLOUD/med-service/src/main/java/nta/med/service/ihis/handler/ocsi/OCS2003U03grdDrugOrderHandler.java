package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdDrugOrderInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdDrugOrderRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdDrugOrderResponse;

@Service
@Scope("prototype")
public class OCS2003U03grdDrugOrderHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03grdDrugOrderRequest, OcsiServiceProto.OCS2003U03grdDrugOrderResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03grdDrugOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03grdDrugOrderRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03grdDrugOrderResponse.Builder response = OcsiServiceProto.OCS2003U03grdDrugOrderResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<OCS2003U03grdDrugOrderInfo> layList = ocs2003Repository.getOCS2003U03grdDrugOrderInfo(hospCode, language, request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001())
				, request.getGwa(), request.getDoctor(), request.getInputTab(), request.getQueryDate(), request.getQueryGubun(), request.getGaiyouYn(), request.getKijunDate(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003U03grdDrugOrderInfo item : layList){
				OcsiModelProto.OCS2003U03grdDrugOrderInfo.Builder info = OcsiModelProto.OCS2003U03grdDrugOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDrug(info);
			}
		}
		return response.build();
	}

}
