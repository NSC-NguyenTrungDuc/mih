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
import nta.med.data.dao.medi.nur.Nur0113Repository;
import nta.med.data.model.ihis.ocsi.OCS6010U10PopupTAgrdNUR0114Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Response;

@Service
@Scope("prototype")
public class OCS6010U10frmDirectActinggrdNUR0113Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Request, OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Response> {
	@Resource
	private Nur0113Repository nur0113Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS6010U10frmDirectActinggrdNUR0113Response handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS6010U10frmDirectActinggrdNUR0113Request request) throws Exception {
		OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Response.Builder response = OcsiServiceProto.OCS6010U10frmDirectActinggrdNUR0113Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<OCS6010U10PopupTAgrdNUR0114Info> list = nur0113Repository.getOCS6010U10frmDirectActinggrdNUR0113Info(getHospitalCode(vertx, sessionId), request.getNurMdCode(), "Y", startNum, CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(list)) {
			for (OCS6010U10PopupTAgrdNUR0114Info item : list) {
				OcsiModelProto.OCS6010U10frmDirectActinggrdNUR0113Info.Builder info = OcsiModelProto.OCS6010U10frmDirectActinggrdNUR0113Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItems(info);
			}
		}
		return response.build();
	}

}
