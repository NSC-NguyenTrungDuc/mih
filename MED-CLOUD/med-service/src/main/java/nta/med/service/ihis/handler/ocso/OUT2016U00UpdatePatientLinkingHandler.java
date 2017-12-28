package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out2016;
import nta.med.core.glossary.LinkType;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto.OUT2016U00PatientLinkingContentInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;


@Transactional
@Service                                                                                                        
@Scope("prototype")                                                                                 
public class OUT2016U00UpdatePatientLinkingHandler extends ScreenHandler<OcsoServiceProto.OUT2016U00UpdatePatientLinkingRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUT2016U00UpdatePatientLinkingHandler.class);                                    
	@Resource                                                                                                       
	private Out2016Repository out2016Repository;                                                                    
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUT2016U00UpdatePatientLinkingRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = request.getHospCode();
		String bunho = request.getBunho();
		LOGGER.info("hospCode: " + hospCode + ", bunho: " + bunho);
		List<OUT2016U00PatientLinkingContentInfo> listRequest = request.getPhrPatientLinkingContentList();
		if(!listRequest.isEmpty()){
			for (OUT2016U00PatientLinkingContentInfo out2016u00PatientLinkingContentInfo : listRequest) {
				int updateStatus = out2016Repository.updateExistingLinkOUT2016(LinkType.PHR.getValue(), hospCode, bunho, out2016u00PatientLinkingContentInfo.getHospCodeLink(), out2016u00PatientLinkingContentInfo.getBunhoLink());
				if(updateStatus <= 0){
					insertOut2016(hospCode, bunho, out2016u00PatientLinkingContentInfo.getHospCodeLink(),
									out2016u00PatientLinkingContentInfo.getBunhoLink(), getUserId(vertx, sessionId), getUserId(vertx, sessionId));
				}
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	private boolean insertOut2016(String hospCode, String bunho, String hospCodeLink, String bunhoLink, String userId, String sysId){
		Out2016 out2016 = new Out2016();
		out2016.setHospCode(hospCode);
		out2016.setBunho(bunho);
		out2016.setHospCodeLink(hospCodeLink);
		out2016.setBunhoLink(bunhoLink);
		out2016.setLinkType(LinkType.PHR.getValue());
		out2016.setEmrLinkFlg(BigDecimal.ONE);
		out2016.setActiveFlg(BigDecimal.ONE);
		out2016.setUpdId(userId);
		out2016.setSysId(sysId);
		out2016Repository.save(out2016);
		return true;
	}
}