package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0801Repository;
import nta.med.data.model.ihis.endo.END1001U02DsvLDOCS0801Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class END1001U02DsvLDOCS0801Handler extends ScreenHandler<EndoServiceProto.END1001U02DsvLDOCS0801Request, EndoServiceProto.END1001U02DsvLDOCS0801Response> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02DsvLDOCS0801Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0801Repository ocs0801Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02DsvLDOCS0801Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02DsvLDOCS0801Request request) throws Exception {
		EndoServiceProto.END1001U02DsvLDOCS0801Response.Builder response = EndoServiceProto.END1001U02DsvLDOCS0801Response.newBuilder(); 
		List<END1001U02DsvLDOCS0801Info> listResult = ocs0801Repository.getEND1001U02DsvLDOCS0801Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId) , request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(END1001U02DsvLDOCS0801Info item : listResult){
				EndoModelProto.END1001U02DsvLDOCS0801Info.Builder info = EndoModelProto.END1001U02DsvLDOCS0801Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addDsvLdocs0801Item(info);
			}
		}
		return response.build();
	}                                                                                                                 
}