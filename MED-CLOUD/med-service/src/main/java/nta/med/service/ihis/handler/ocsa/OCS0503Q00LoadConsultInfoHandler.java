package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocsa.OCS0503Q00LoadConsultInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00LoadConsultInfoRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0503Q00LoadConsultInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0503Q00LoadConsultInfoHandler
	extends ScreenHandler<OcsaServiceProto.OCS0503Q00LoadConsultInfoRequest, OcsaServiceProto.OCS0503Q00LoadConsultInfoResponse> {                     
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override                    
	@Transactional(readOnly = true)
	public OCS0503Q00LoadConsultInfoResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0503Q00LoadConsultInfoRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0503Q00LoadConsultInfoResponse.Builder response = OcsaServiceProto.OCS0503Q00LoadConsultInfoResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
        List<OCS0503Q00LoadConsultInfo> listItem = out0101Repository.getOCS0503Q00GrdConsultList(hospCode, language, request.getDoctor(),
        		request.getFromDate(), request.getToDate(), "", "", "", "");
        if (listItem != null && !listItem.isEmpty()) {
            for (OCS0503Q00LoadConsultInfo item : listItem) {
            	OcsaModelProto.OCS0503Q00LoadConsultInfo.Builder info = OcsaModelProto.OCS0503Q00LoadConsultInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addGridConsultInfo(info);
            }
        }
        List<OCS0503Q00LoadConsultInfo> list =  out0101Repository.getOcsaOCS0503Q00GrdRequestList(hospCode, language, request.getDoctor(),
        		request.getFromDate(), request.getToDate(), "", "", "", "");
        if (listItem != null && !listItem.isEmpty()) {
            for (OCS0503Q00LoadConsultInfo item : list) {
            	OcsaModelProto.OCS0503Q00LoadConsultInfo.Builder info = OcsaModelProto.OCS0503Q00LoadConsultInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addGridRequestOut1001Info(info);
            }
        }
		return response.build();		
	}

}