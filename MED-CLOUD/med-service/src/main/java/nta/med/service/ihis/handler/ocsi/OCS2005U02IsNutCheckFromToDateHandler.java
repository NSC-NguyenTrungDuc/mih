package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02IsNutCheckFromToDateRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02IsNutCheckFromToDateResponse;

@Service
@Scope("prototype")
public class OCS2005U02IsNutCheckFromToDateHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02IsNutCheckFromToDateRequest, OcsiServiceProto.OCS2005U02IsNutCheckFromToDateResponse> {
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	public OCS2005U02IsNutCheckFromToDateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02IsNutCheckFromToDateRequest request) throws Exception {
		OcsiServiceProto.OCS2005U02IsNutCheckFromToDateResponse.Builder response = OcsiServiceProto.OCS2005U02IsNutCheckFromToDateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<DataStringListItemInfo> result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
		if(CollectionUtils.isEmpty(result)){
			info.setCode("0");
			response.setObjItem(info);
		} else {
			info.setCode("1");
		}
		
		String fkinp1001 = CollectionUtils.isEmpty(result) ? "0" : result.get(0).getItem();
		String strCheck = ocs2005Repository.getOCS2005U02IsNutCheckFromToDate(hospCode
				, DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD)
				, request.getBunho()
				, request.getBldGubun()
				, request.getPkocs2005()
				, fkinp1001);
		
		info.setCode("1");
		info.setCodeName(strCheck);
		
		response.setObjItem(info);
		return response.build();
	}
}
