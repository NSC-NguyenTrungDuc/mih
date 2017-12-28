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
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOrderdateInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdOrderdateRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdOrderdateResponse;


@Service
@Scope("prototype")
public class OCS2003U03grdOrderdateHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03grdOrderdateRequest, OcsiServiceProto.OCS2003U03grdOrderdateResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03grdOrderdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03grdOrderdateRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03grdOrderdateResponse.Builder response = OcsiServiceProto.OCS2003U03grdOrderdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<OCS2003U03grdOrderdateInfo> layList = ocs2003Repository.getOCS2003U03grdOrderdateInfo(hospCode, request.getFkinp1001()
				, request.getBunho(), request.getOrderDate(), request.getInputGubun(), request.getGaiyouYn(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003U03grdOrderdateInfo item : layList){
				OcsiModelProto.OCS2003U03grdOrderdateInfo.Builder info = OcsiModelProto.OCS2003U03grdOrderdateInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOrder(info);
			}
		}
		return response.build();
	}


}
