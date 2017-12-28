package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02GetPkInp1001Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02GetPkInp1001Response;

@Service
@Scope("prototype")
public class OCS2005U02GetPkInp1001Handler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02GetPkInp1001Request, OcsiServiceProto.OCS2005U02GetPkInp1001Response> {
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02GetPkInp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02GetPkInp1001Request request) throws Exception {
		
		OcsiServiceProto.OCS2005U02GetPkInp1001Response.Builder response = OcsiServiceProto.OCS2005U02GetPkInp1001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<DataStringListItemInfo> result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		if(!CollectionUtils.isEmpty(result)){
			for(DataStringListItemInfo item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item.getItem());
				response.setPkinpItem(info);
			}
		}
		
		return response.build();
	}

	
}
