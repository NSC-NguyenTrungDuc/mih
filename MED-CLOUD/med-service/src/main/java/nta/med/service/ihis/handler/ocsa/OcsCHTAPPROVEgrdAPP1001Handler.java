package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inp.App1001Repository;
import nta.med.data.model.ihis.ocsa.OcsCHTAPPROVEgrdAPP1001Info;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Response;

@Service
@Scope("prototype")
public class OcsCHTAPPROVEgrdAPP1001Handler extends
		ScreenHandler<OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Request, OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Response> {

	private static final Log LOGGER = LogFactory.getLog(OcsCHTAPPROVEgrdAPP1001Handler.class);  
	
	@Resource
	private App1001Repository app1001Repository;
	
	@Override
	public OcsCHTAPPROVEgrdAPP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsCHTAPPROVEgrdAPP1001Request request) throws Exception {
		OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Response.Builder response = OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<OcsCHTAPPROVEgrdAPP1001Info> lstInfo = app1001Repository.getOcsCHTAPPROVEgrdAPP1001Info(hospCode, language,
				request.getOutsangYn(), request.getBunho(), request.getDoctor(), request.getIoGubun(),
				request.getApproveYn(), request.getPrePostGubun(), request.getAllSangYn(),
				DateUtil.toDate(request.getGijunDate(), DateUtil.PATTERN_YYMMDD));
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (OcsCHTAPPROVEgrdAPP1001Info info : lstInfo) {
			OcsaModelProto.OcsCHTAPPROVEgrdAPP1001Info.Builder protoInfo = OcsaModelProto.OcsCHTAPPROVEgrdAPP1001Info.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addGrdApp(protoInfo);
		}
		
		return response.build();
	}
	
}
