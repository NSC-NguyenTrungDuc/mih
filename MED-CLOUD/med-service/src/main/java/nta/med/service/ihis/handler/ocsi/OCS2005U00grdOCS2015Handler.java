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
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdOCS2015Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdOCS2015Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdOCS2015Response;

@Service
@Scope("prototype")
public class OCS2005U00grdOCS2015Handler extends ScreenHandler<OcsiServiceProto.OCS2005U00grdOCS2015Request, OcsiServiceProto.OCS2005U00grdOCS2015Response>{
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00grdOCS2015Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00grdOCS2015Request request) throws Exception {
		OcsiServiceProto.OCS2005U00grdOCS2015Response.Builder response = OcsiServiceProto.OCS2005U00grdOCS2015Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<OCS2005U00grdOCS2015Info> list = ocs2015Repository.getOCS2005U00grdOCS2015Info(hospCode, request.getPkSeq(), request.getInputGubun(), request.getFkinp1001(), request.getBunho(), startNum, CommonUtils.parseInteger(offset));
        if (!CollectionUtils.isEmpty(list)) {
        	for (OCS2005U00grdOCS2015Info item : list) {
				OcsiModelProto.OCS2005U00grdOCS2015Info.Builder info = OcsiModelProto.OCS2005U00grdOCS2015Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListOcs2015(info);
			}
        }
		return response.build();
	}

}
