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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02ProcDailyNutRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02ProcDailyNutResponse;

@Service
@Scope("prototype")
public class OCS2005U02ProcDailyNutHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02ProcDailyNutRequest, OcsiServiceProto.OCS2005U02ProcDailyNutResponse> {
	
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional
	public OCS2005U02ProcDailyNutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02ProcDailyNutRequest request) throws Exception {
		
		OcsiServiceProto.OCS2005U02ProcDailyNutResponse.Builder response = OcsiServiceProto.OCS2005U02ProcDailyNutResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1001 = "0";
		
		List<DataStringListItemInfo> result;
		result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		if(CollectionUtils.isEmpty(result)){
			fkinp1001 ="0";
		}else{
			for(DataStringListItemInfo item : result){
				fkinp1001 = item.getItem();
			}
		}
		
		String result1 = ocs2005Repository.OCS2005U02ProcDailyNut(request.getUpdId(), hospCode, request.getBunho(), fkinp1001, request.getChargeDate(), request.getWorkGubun());
		
		if(result1 == null){
			result1 = "";
		}
		
		ComboListItemInfo item;
		if(fkinp1001 == "0")
			item = new ComboListItemInfo("0", result1);
		else
			item = new ComboListItemInfo("", result1);
		
		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		response.setProcItem(info);		
		
		return response.build();
	}

}
