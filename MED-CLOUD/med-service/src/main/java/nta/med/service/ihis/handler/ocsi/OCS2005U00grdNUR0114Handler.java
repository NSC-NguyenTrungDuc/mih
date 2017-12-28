package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur0114Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U00grdNUR0114Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdNUR0114Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U00grdNUR0114Response;

@Service
@Scope("prototype")
public class OCS2005U00grdNUR0114Handler extends ScreenHandler<OcsiServiceProto.OCS2005U00grdNUR0114Request, OcsiServiceProto.OCS2005U00grdNUR0114Response>{
	@Resource
	private Nur0114Repository nur0114Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U00grdNUR0114Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U00grdNUR0114Request request) throws Exception {
		OcsiServiceProto.OCS2005U00grdNUR0114Response.Builder response = OcsiServiceProto.OCS2005U00grdNUR0114Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        List<OCS2005U00grdNUR0114Info> list = nur0114Repository.getOCS2005U00grdNur0114Info(getHospitalCode(vertx, sessionId), request.getNurGrCode(), request.getNurMdCode(), "Y", startNum, CommonUtils.parseInteger(offset));
        if (!CollectionUtils.isEmpty(list)) {
        	for (OCS2005U00grdNUR0114Info item : list) {
        		OcsiModelProto.OCS2005U00grdNUR0114Info.Builder info = OcsiModelProto.OCS2005U00grdNUR0114Info.newBuilder();
        		info.setNurSoCode(item.getNurSoCode());
        		info.setNurSoName(item.getNurSoName());
        		response.addListNur0114(info);
			}
        }
		return response.build();
	}

}
