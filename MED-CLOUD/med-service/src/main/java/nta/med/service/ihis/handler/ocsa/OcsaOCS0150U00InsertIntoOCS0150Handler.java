package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0150;
import nta.med.data.dao.medi.ocs.Ocs0150Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0150U00InsertIntoOCS0150Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsaOCS0150U00InsertIntoOCS0150Handler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0150U00InsertIntoOCS0150Request, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(OcsaOCS0150U00InsertIntoOCS0150Handler.class);
	
    @Resource
    private Ocs0150Repository ocs0150Repository;
    
    @Override
    @Transactional
    public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsaOCS0150U00InsertIntoOCS0150Request request) throws Exception {
		boolean result = insertOcs0150(request, getHospitalCode(vertx, sessionId));
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(result);
		return response.build();
	}

	private boolean insertOcs0150(OcsaServiceProto.OcsaOCS0150U00InsertIntoOCS0150Request request, String hospCode) throws Exception {
		try {
			Ocs0150 ocs0150 = new Ocs0150();
			ocs0150.setSysDate(new Date());
			ocs0150.setUpdDate(new Date());
			if(!StringUtils.isEmpty(request.getUserId())){
				ocs0150.setSysId(request.getUserId());
				ocs0150.setUpdId(request.getUserId());
			}
			if(!StringUtils.isEmpty(request.getDoctor())){
				ocs0150.setDoctor(request.getDoctor());
			}
			if(!StringUtils.isEmpty(request.getGwa())){
				ocs0150.setGwa(request.getGwa());
			}
			ocs0150.setHospCode(hospCode);
			if(!StringUtils.isEmpty(request.getIoGubun())){
				ocs0150.setIoGubun(request.getIoGubun());
			}
			if(!StringUtils.isEmpty(request.getAllergyPopYn())){
				ocs0150.setAllergyPopYn(request.getAllergyPopYn());
			}else{
				ocs0150.setAllergyPopYn("N");
			}
			if(!StringUtils.isEmpty(request.getDoOrderPopYn())){
				ocs0150.setDoOrderPopYn(request.getDoOrderPopYn());
			}else{
				ocs0150.setDoOrderPopYn("N");
			}
			if(!StringUtils.isEmpty(request.getDrgPrtYn())){
				ocs0150.setDrgPrtYn(request.getDrgPrtYn());
			}else{
				ocs0150.setDrgPrtYn("N");
			}
			if(!StringUtils.isEmpty(request.getEmrPopYn())){
				ocs0150.setEmrPopYn(request.getEmrPopYn());
			}else{
				ocs0150.setEmrPopYn("N");
			}
			if(!StringUtils.isEmpty(request.getReserPrtYn())){
				ocs0150.setReserPrtYn(request.getReserPrtYn());
			}else{
				ocs0150.setReserPrtYn("N");
			}
			if(!StringUtils.isEmpty(request.getSpecialwritePopYn())){
				ocs0150.setSpecialwritePopYn(request.getSpecialwritePopYn());
			}else{
				ocs0150.setSpecialwritePopYn("N");
			}
			if(!StringUtils.isEmpty(request.getVitalsignsPopYn())){
				ocs0150.setVitalsignsPopYn(request.getVitalsignsPopYn());
			}else{
				ocs0150.setVitalsignsPopYn("N");
			}
			if(!StringUtils.isEmpty(request.getXrtPrtYn())){
				ocs0150.setXrtPrtYn(request.getXrtPrtYn());
			}else{
				ocs0150.setXrtPrtYn("N");
			}
			if(!StringUtils.isEmpty(request.getSentouSearchYn())){
				ocs0150.setSentouSearchYn(request.getSentouSearchYn());
			}else{
				ocs0150.setSentouSearchYn("N");
			}
			if(!StringUtils.isEmpty(request.getOrderLabelPrtYn())){
				ocs0150.setOrderLabelPrtYn(request.getOrderLabelPrtYn());
			}else{
				ocs0150.setOrderLabelPrtYn("N");
			}
			if(!StringUtils.isEmpty(request.getGeneralDispYn())){
				ocs0150.setGeneralDispYn(request.getGeneralDispYn());
			}else{
				ocs0150.setGeneralDispYn("N");
			}
			if(!StringUtils.isEmpty(request.getSameNameCheckYn())){
				ocs0150.setSameNameCheckYn(request.getSameNameCheckYn());
			}else{
				ocs0150.setSameNameCheckYn("N");
			}
			LOGGER.info(ocs0150.toString());
			ocs0150Repository.save(ocs0150);
			return true;
		} catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
			return false;
		}
	}

}
