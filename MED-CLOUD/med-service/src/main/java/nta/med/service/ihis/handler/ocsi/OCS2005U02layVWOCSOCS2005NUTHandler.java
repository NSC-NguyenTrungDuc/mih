package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.beans.BeanUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U02layVWOCSOCS2005NUTInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTResponse;

@Service
@Scope("prototype")
public class OCS2005U02layVWOCSOCS2005NUTHandler extends ScreenHandler<OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTRequest, OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02layVWOCSOCS2005NUTResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02layVWOCSOCS2005NUTRequest request) throws Exception{
		
		OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTResponse.Builder  response = OcsiServiceProto.OCS2005U02layVWOCSOCS2005NUTResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<OCS2005U02layVWOCSOCS2005NUTInfo> result = ocs2005Repository.getOCS2005U02layVWOCSOCS2005NUTInfo(hospCode, request.getBunho(), 
				CommonUtils.parseDouble(request.getFkinp1001()), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(OCS2005U02layVWOCSOCS2005NUTInfo item : result){
				OcsiModelProto.OCS2005U02layVWOCSOCS2005NUTInfo.Builder info = OcsiModelProto.OCS2005U02layVWOCSOCS2005NUTInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLayvwItem(info);
			}
		}
		return response.build();
	}
}
