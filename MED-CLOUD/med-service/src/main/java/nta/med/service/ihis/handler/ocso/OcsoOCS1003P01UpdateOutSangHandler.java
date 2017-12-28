package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class OcsoOCS1003P01UpdateOutSangHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01UpdateOutSangRequest, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(OcsoOCS1003P01UpdateOutSangHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01UpdateOutSangRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = updateOutsang(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean updateOutsang(OcsoServiceProto.OcsoOCS1003P01UpdateOutSangRequest request, String hospCode) {
			Date sangStartDate = DateUtil.toDate(request.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
			Date sangEndDate = DateUtil.toDate(request.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
			Date updDate = DateUtil.toDate(request.getUpdDate(), DateUtil.PATTERN_YYMMDD);
			Date sangJindanDate = DateUtil.toDate(request.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
			Double pkSeq = CommonUtils.parseDouble(request.getPkSeq());
			Double ser = CommonUtils.parseDouble(request.getSer());
			
			if( outsangRepository.updateOcsoOCS1003P01UpdateOutSang(request.getJuSangYn(), request.getSangName(), sangStartDate, sangEndDate, request.getSangEndSayu(),
					request.getPreModifier1(), request.getPreModifier2(), request.getPreModifier3(), request.getPreModifier4(), request.getPreModifier5(),
					request.getPreModifier6(), request.getPreModifier7(), request.getPreModifier8(), request.getPreModifier9(), request.getPreModifier10(),
					request.getPreModifierName(), request.getPostModifier1(), request.getPostModifier2(), request.getPostModifier3(), 
					request.getPostModifier4(), request.getPostModifier5(), request.getPostModifier6(), request.getPostModifier7(), 
					request.getPostModifier8(), request.getPostModifier9(), request.getPostModifier10(), request.getPostModifierName(),
					request.getUpdId(), updDate, sangJindanDate, request.getGwa(), request.getDataGubun(), pkSeq, ser, request.getBunho(), 
					request.getIoGubun(), hospCode) > 0)
				return true;
				return false;
	}
	
}

