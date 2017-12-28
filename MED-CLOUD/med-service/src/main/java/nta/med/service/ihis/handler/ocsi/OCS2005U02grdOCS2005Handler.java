package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U02grdOCS2005Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02grdOCS2005Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02grdOCS2005Response;

@Service
@Scope("prototype")
public class OCS2005U02grdOCS2005Handler extends ScreenHandler<OcsiServiceProto.OCS2005U02grdOCS2005Request, OcsiServiceProto.OCS2005U02grdOCS2005Response>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02grdOCS2005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02grdOCS2005Request request) throws Exception{
		OcsiServiceProto.OCS2005U02grdOCS2005Response.Builder response = OcsiServiceProto.OCS2005U02grdOCS2005Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<OCS2005U02grdOCS2005Info> result = ocs2005Repository.getOCS2005U02grdOCS2005Info(hospCode, request.getJaewonYn(), request.getBunho(),
				CommonUtils.parseDouble(request.getFkinp1001()), request.getBldGubun(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(OCS2005U02grdOCS2005Info item : result){
				OcsiModelProto.OCS2005U02grdOCS2005Info.Builder info = OcsiModelProto.OCS2005U02grdOCS2005Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
