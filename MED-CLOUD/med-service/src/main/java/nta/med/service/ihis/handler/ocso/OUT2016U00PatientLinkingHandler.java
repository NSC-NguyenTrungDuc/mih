package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out2016;
import nta.med.core.glossary.LinkType;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;


@Transactional
@Service                                                                                                        
@Scope("prototype")                                                                                 
public class OUT2016U00PatientLinkingHandler extends ScreenHandler<OcsoServiceProto.OUT2016U00PatientLinkingRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUT2016U00PatientLinkingHandler.class);                                    
	@Resource                                                                                                       
	private Out2016Repository out2016Repository;                                                                    
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUT2016U00PatientLinkingRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = request.getHospCode();
        String bunho = request.getBunho();
        String linkType = request.getLinkType();
        String hospCodeLink = request.getHospCodeLink();
        String bunhoLink = request.getBunhoLink();
        String password = request.getPassword();
        LOGGER.info("linkType: " + linkType + ", " + "hospCode: " + hospCode + ", " + "bunho: " + bunho + ", " + "hospCodeLink: " + hospCodeLink + ", " + "bunhoLink: " + bunhoLink + ", " + "password: " + password);
        
        String emrLinkFlg = out2016Repository.getEmrLinkFlg(hospCode, bunho, hospCodeLink, bunhoLink);
        if(!StringUtils.isEmpty(emrLinkFlg) && "1".equals(emrLinkFlg)){
        	response.setMsg("ERC001");
        	response.setResult(false);
        	return response.build();
        }
        
        boolean verifyKcckAccount = out2016Repository.verifyKcckAccount(hospCodeLink, bunhoLink, password);
        if(verifyKcckAccount){
        	if(!StringUtils.isEmpty(emrLinkFlg) && "0".equals(emrLinkFlg)){
        		out2016Repository.updateExistingLinkOUT2016(LinkType.KCCK.getValue(), hospCode, bunho, hospCodeLink, bunhoLink);
        		out2016Repository.updateExistingLinkOUT2016(LinkType.KCCK.getValue(), hospCodeLink, bunhoLink, hospCode, bunho);
        	} else {
        		insertOut2016(hospCode, bunho, hospCodeLink, bunhoLink, getUserId(vertx, sessionId), getUserId(vertx, sessionId));
        		insertOut2016(hospCodeLink, bunhoLink,hospCode, bunho, getUserId(vertx, sessionId), getUserId(vertx, sessionId));
        	}
    		response.setMsg("ERC003");
    		response.setResult(true);
    		return response.build();
        }
        
        response.setMsg("ERC002");
        response.setResult(false);
    	return response.build();
	}
	
	private boolean insertOut2016(String hospCode, String bunho, String hospCodeLink, String bunhoLink, String userId, String sysId){
		Out2016 out2016 = new Out2016();
		out2016.setHospCode(hospCode);
		out2016.setBunho(bunho);
		out2016.setHospCodeLink(hospCodeLink);
		out2016.setBunhoLink(bunhoLink);
		out2016.setLinkType(LinkType.KCCK.getValue());
		out2016.setEmrLinkFlg(BigDecimal.ONE);
		out2016.setActiveFlg(BigDecimal.ONE);
		out2016.setUpdId(userId);
		out2016.setSysId(sysId);
		out2016Repository.save(out2016);
		return true;
	}
}