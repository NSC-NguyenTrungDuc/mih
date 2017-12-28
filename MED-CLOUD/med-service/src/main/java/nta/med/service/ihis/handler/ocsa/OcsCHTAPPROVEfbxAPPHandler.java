package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.inps.INP1003U01fbxInp1003Info;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToGwaInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEfbxAPPRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEfbxAPPResponse;

@Service
@Scope("prototype")
public class OcsCHTAPPROVEfbxAPPHandler extends
		ScreenHandler<OcsaServiceProto.OcsCHTAPPROVEfbxAPPRequest, OcsaServiceProto.OcsCHTAPPROVEfbxAPPResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsCHTAPPROVEfbxAPPHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsCHTAPPROVEfbxAPPResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsCHTAPPROVEfbxAPPRequest request) throws Exception {
		OcsaServiceProto.OcsCHTAPPROVEfbxAPPResponse.Builder response = OcsaServiceProto.OcsCHTAPPROVEfbxAPPResponse.newBuilder();
		String controlName = request.getNameControl();
		if (StringUtils.isEmpty(controlName))
			return response.build(); 
		
		if ("gwa".equals(controlName)) {
			List<OUTSANGU00findBoxToGwaInfo> list = bas0260Repository.getOUTSANGU00findBoxToGwaInfo(getHospitalCode(vertx, sessionId), DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD), request.getFind1(), getLanguage(vertx, sessionId));
			if (!CollectionUtils.isEmpty(list)) {
				for (OUTSANGU00findBoxToGwaInfo item : list) {
					OcsaModelProto.OcsCHTAPPROVEfbxAPPInfo.Builder info = OcsaModelProto.OcsCHTAPPROVEfbxAPPInfo.newBuilder();
					info.setOutput1(item.getGwa());
					info.setOutput2(item.getGwaName());
					info.setOutput3(item.getBuseoCode());
					response.addOutput(info);
				}
			}
		} else {
			List<INP1003U01fbxInp1003Info> list = bas0270Repository.getINP1003U01fbxInp1003Info(getHospitalCode(vertx, sessionId), request.getFind1(), "", request.getGwa(), request.getDate(), "fbxDoctor");
			if (!CollectionUtils.isEmpty(list)) {
				for (INP1003U01fbxInp1003Info item : list) {
					OcsaModelProto.OcsCHTAPPROVEfbxAPPInfo.Builder info = OcsaModelProto.OcsCHTAPPROVEfbxAPPInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addOutput(info);
				}
			}
		}
		return response.build();
	}

	
}
