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
import nta.med.data.dao.medi.ocs.Ocs1024Repository;
import nta.med.data.model.ihis.ocsi.OCS1024U00grdOCS1024Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00grdOCS1024Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS1024U00grdOCS1024Response;

@Service
@Scope("prototype")
public class OCS1024U00grdOCS1024Handler extends ScreenHandler<OcsiServiceProto.OCS1024U00grdOCS1024Request , OcsiServiceProto.OCS1024U00grdOCS1024Response>{
	@Resource
	private Ocs1024Repository ocs1024Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS1024U00grdOCS1024Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS1024U00grdOCS1024Request request) throws Exception {
		OcsiServiceProto.OCS1024U00grdOCS1024Response.Builder response = OcsiServiceProto.OCS1024U00grdOCS1024Response.newBuilder();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<OCS1024U00grdOCS1024Info> grdList = ocs1024Repository.getOCS1024U00grdOCS1024(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getGenericYn(), request.getBunho(), request.getInputTab(), fkinp1001, startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(grdList)){
			for(OCS1024U00grdOCS1024Info item : grdList){
				OcsiModelProto.OCS1024U00grdOCS1024Info.Builder info = OcsiModelProto.OCS1024U00grdOCS1024Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}
