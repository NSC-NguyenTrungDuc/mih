package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp5001Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U02getMagamStatus1Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02getMagamStatus1Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02getMagamStatus1Response;

@Service
@Scope("prototype")
public class OCS2005U02getMagamStatus1Handler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02getMagamStatus1Request, OcsiServiceProto.OCS2005U02getMagamStatus1Response> {
	
	@Resource
	private Inp5001Repository inp5001Repository;
	
	@Override
	public OCS2005U02getMagamStatus1Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02getMagamStatus1Request request) throws Exception {
		
		OcsiServiceProto.OCS2005U02getMagamStatus1Response.Builder response = OcsiServiceProto.OCS2005U02getMagamStatus1Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<OCS2005U02getMagamStatus1Info> result = inp5001Repository.getOCS2005U02getMagamStatus1(hospCode, request.getMagamDate(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(OCS2005U02getMagamStatus1Info item : result){
				OcsiModelProto.OCS2005U02getMagamStatus1Info.Builder info = OcsiModelProto.OCS2005U02getMagamStatus1Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayItem(info);
			}
		}
		
		return response.build();
	}

	
}
