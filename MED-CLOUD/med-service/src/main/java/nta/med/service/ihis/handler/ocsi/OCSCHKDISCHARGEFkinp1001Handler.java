package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Response;

@Service
@Scope("prototype")
public class OCSCHKDISCHARGEFkinp1001Handler extends ScreenHandler<OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Request, OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Response> {
	private static final Log LOGGER = LogFactory.getLog(OCSCHKDISCHARGEFkinp1001Handler.class);
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override         
	@Transactional(readOnly = true)
	public OCSCHKDISCHARGEFkinp1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSCHKDISCHARGEFkinp1001Request request) throws Exception {
		
		OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Response.Builder response = OcsiServiceProto.OCSCHKDISCHARGEFkinp1001Response.newBuilder();
		
		String bunho = request.getBunho();
		
		DataStringListItemInfo infoObject = bas0260Repository.getOCSCHKDISCHARGEFkinp1001(bunho);
		
		if(infoObject != null){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			if(!StringUtils.isEmpty(infoObject.getItem())){
				info.setDataValue(infoObject.getItem());
				response.setItem(info);
			}
		}
		
		return response.build();
		
	}

}