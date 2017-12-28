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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.data.model.ihis.ocsi.OCS2005U02SetTabInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02SetTabRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02SetTabResponse;

@Service
@Scope("prototype")
public class OCS2005U02SetTabHandler
		extends ScreenHandler<OcsiServiceProto.OCS2005U02SetTabRequest, OcsiServiceProto.OCS2005U02SetTabResponse> {

	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	public OCS2005U02SetTabResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02SetTabRequest request) throws Exception {
		OcsiServiceProto.OCS2005U02SetTabResponse.Builder response = OcsiServiceProto.OCS2005U02SetTabResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1001 = "0";
		String msg = "";
		
		List<DataStringListItemInfo> result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		if(CollectionUtils.isEmpty(result)){
			fkinp1001 ="0";
			msg = "0";
		}else{
			fkinp1001 = result.get(0).getItem();
			msg = "1";
		}
				
		List<OCS2005U02SetTabInfo> result1 = ocs2005Repository.getOCS2005U02SetTabInfo(hospCode, request.getBunho(), 
				request.getMpressedJaewonYn(), request.getBldGubun(), CommonUtils.parseDouble(fkinp1001));
		
		if(!CollectionUtils.isEmpty(result1)){
			for(OCS2005U02SetTabInfo item : result1){
				OcsiModelProto.OCS2005U02SetTabInfo.Builder info = OcsiModelProto.OCS2005U02SetTabInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setMsg(msg);
				response.addTabItem(info);
			}
		} else {
			OCS2005U02SetTabInfo item = new OCS2005U02SetTabInfo(CommonUtils.parseDouble("0"), "", "", "", "", "0");
			OcsiModelProto.OCS2005U02SetTabInfo.Builder info = OcsiModelProto.OCS2005U02SetTabInfo.newBuilder();
			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			info.setMsg(msg);
			response.addTabItem(info);
		}
		
		return response.build();
	}
}
