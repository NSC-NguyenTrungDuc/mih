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
import nta.med.data.dao.medi.nur.Nur0112Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNur0112Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdNur0112Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdNur0112Response;

@Service
@Scope("prototype")
public class OCS2005U00grdNur0112Handler extends ScreenHandler<OcsiServiceProto.OCS2005U00grdNur0112Request, OcsiServiceProto.OCS2005U00grdNur0112Response>{
	@Resource
	private Nur0112Repository nur0112Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00grdNur0112Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00grdNur0112Request request) throws Exception {
		OcsiServiceProto.OCS2005U00grdNur0112Response.Builder response = OcsiServiceProto.OCS2005U00grdNur0112Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<OCS2005U00grdNur0112Info> list = nur0112Repository.getOCS2005U00grdNur0112Info(getHospitalCode(vertx, sessionId), request.getNurGrCode(), request.getNurMdCode(), "Y", startNum, CommonUtils.parseInteger(offset));
        if (!CollectionUtils.isEmpty(list)) {
        	for (OCS2005U00grdNur0112Info item : list) {
        		OcsiModelProto.OCS2005U00grdNur0112Info.Builder info = OcsiModelProto.OCS2005U00grdNur0112Info.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addListNur0112(info);
			}
        }
		return response.build();
	}

}
