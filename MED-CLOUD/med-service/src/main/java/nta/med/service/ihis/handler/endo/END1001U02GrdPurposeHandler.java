package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.pfe.Pfe0102Repository;
import nta.med.data.model.ihis.endo.END1001U02GrdPurposeInfo;
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
public class END1001U02GrdPurposeHandler extends ScreenHandler<EndoServiceProto.END1001U02GrdPurposeRequest, EndoServiceProto.END1001U02GrdPurposeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02GrdPurposeHandler.class);                                    
	@Resource                                                                                                       
	private Pfe0102Repository pfe0102Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02GrdPurposeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02GrdPurposeRequest request) throws Exception {
		EndoServiceProto.END1001U02GrdPurposeResponse.Builder response = EndoServiceProto.END1001U02GrdPurposeResponse.newBuilder();  
		List<END1001U02GrdPurposeInfo> listResult = pfe0102Repository.getEND1001U02GrdPurposeInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(END1001U02GrdPurposeInfo item : listResult){
				EndoModelProto.END1001U02GrdPurposeInfo.Builder info = EndoModelProto.END1001U02GrdPurposeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addGrdPurposeItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}