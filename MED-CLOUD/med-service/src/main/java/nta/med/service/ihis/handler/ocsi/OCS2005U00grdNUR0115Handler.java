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
import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR0115Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdNUR0115Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdNUR0115Response;

@Service
@Scope("prototype")
public class OCS2005U00grdNUR0115Handler extends ScreenHandler<OcsiServiceProto.OCS2005U00grdNUR0115Request, OcsiServiceProto.OCS2005U00grdNUR0115Response>{
	@Resource
	private Nur0115Repository nur0115Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00grdNUR0115Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00grdNUR0115Request request) throws Exception {
		OcsiServiceProto.OCS2005U00grdNUR0115Response.Builder response = OcsiServiceProto.OCS2005U00grdNUR0115Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<OCS2005U00grdNUR0115Info> list = nur0115Repository.getOCS2005U00grdNUR0115Info(hospCode, language, request.getNurGrCode(), request.getNurMdCode(), request.getNurSoCode(), startNum, CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS2005U00grdNUR0115Info item : list) {
				OcsiModelProto.OCS2005U00grdNUR0115Info.Builder info = OcsiModelProto.OCS2005U00grdNUR0115Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListNur0115(info);
			}
		}
        return response.build();
	}

}
