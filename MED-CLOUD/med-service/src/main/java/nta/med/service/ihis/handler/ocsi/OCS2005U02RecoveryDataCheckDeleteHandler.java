package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp5001Repository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02RecoveryDataCheckDeleteInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteResponse;

@Service
@Scope("prototype")
public class OCS2005U02RecoveryDataCheckDeleteHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteRequest, OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteResponse> {
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Resource
	private Inp5001Repository inp5001Repository;
	
	@Override
	public OCS2005U02RecoveryDataCheckDeleteResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS2005U02RecoveryDataCheckDeleteRequest request) throws Exception {
		
		OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteResponse.Builder response = OcsiServiceProto.OCS2005U02RecoveryDataCheckDeleteResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> result = ocs2015Repository.OCS2005U02getMinMaxDate(hospCode, CommonUtils.parseDouble(request.getPkocs2005())
				, request.getDrtFromDate(), request.getDrtToDate());
		
		if(!CollectionUtils.isEmpty(result)){
			String minDate = result.get(0).getCode();
			String maxDate = result.get(0).getCodeName();
			
			if(minDate != ""){
				if(maxDate == "")
					maxDate = "9999/12/31";
			}else{
				minDate = request.getDrtFromDate();
				if(request.getDrtToDate() == "")
					maxDate = "9999/12/31";
				else
					maxDate = request.getDrtToDate();
			}
			
			List<OCS2005U02RecoveryDataCheckDeleteInfo> result1 = inp5001Repository.getOCS2005U02RecoveryDataCheckDeleteInfo(hospCode, minDate, maxDate);
			if(!CollectionUtils.isEmpty(result1)){
				for(OCS2005U02RecoveryDataCheckDeleteInfo item : result1){
					OcsiModelProto.OCS2005U02RecoveryDataCheckDeleteInfo.Builder info = OcsiModelProto.OCS2005U02RecoveryDataCheckDeleteInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addDelItem(info);
				}
			}
		}
		return response.build();
	}

	
}
