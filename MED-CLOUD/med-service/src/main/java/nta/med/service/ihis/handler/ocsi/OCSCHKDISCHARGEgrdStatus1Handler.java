package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Response;

@Service
@Scope("prototype")
public class OCSCHKDISCHARGEgrdStatus1Handler extends ScreenHandler<OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Request, OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Response> {
	
	private static final Log LOGGER = LogFactory.getLog(OCSCHKDISCHARGEgrdStatus1Handler.class);
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override         
	@Transactional(readOnly = true)
	public OCSCHKDISCHARGEgrdStatus1Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSCHKDISCHARGEgrdStatus1Request request) throws Exception {
		
		OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Response.Builder response = OcsiServiceProto.OCSCHKDISCHARGEgrdStatus1Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String fkinp1001 = request.getFkinp1001();
		String kijundate = request.getKijundate();
		String bunho = request.getBunho();
		
		List<ComboListItemInfo> list = bas0260Repository.getOCSCHKDISCHARGEgrdStatus1(hospCode, fkinp1001, kijundate, bunho);
		if(!CollectionUtils.isEmpty(list)) {
			for(ComboListItemInfo item : list) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}

}