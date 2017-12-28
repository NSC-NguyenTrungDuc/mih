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
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U03grdOcs2017Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdOcs2017Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03grdOcs2017Response;

@Service
@Scope("prototype")
public class OCS2003U03grdOcs2017Handler extends ScreenHandler<OcsiServiceProto.OCS2003U03grdOcs2017Request, OcsiServiceProto.OCS2003U03grdOcs2017Response>{
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03grdOcs2017Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03grdOcs2017Request request) throws Exception {
		OcsiServiceProto.OCS2003U03grdOcs2017Response.Builder response = OcsiServiceProto.OCS2003U03grdOcs2017Response.newBuilder();
		
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OCS2003U03grdOcs2017Info> list = ocs2003Repository.getOCS2003U03grdOcs2017Info(hospCode, language, request.getPkocs2003(), startNum, CommonUtils.parseInteger(offset));
		
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2003U03grdOcs2017Info item : list) {
				OcsiModelProto.OCS2003U03grdOcs2017Info.Builder info = OcsiModelProto.OCS2003U03grdOcs2017Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
			}
		}
		
		return response.build();
	}

}
