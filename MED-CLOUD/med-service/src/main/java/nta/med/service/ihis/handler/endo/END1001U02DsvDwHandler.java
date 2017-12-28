package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.pfe.Pfe1000Repository;
import nta.med.data.model.ihis.endo.END1001U02DsvDwInfo;
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
public class END1001U02DsvDwHandler extends ScreenHandler<EndoServiceProto.END1001U02DsvDwRequest, EndoServiceProto.END1001U02DsvDwResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02DsvDwHandler.class);                                    
	@Resource                                                                                                       
	private Pfe1000Repository pfe1000Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02DsvDwResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02DsvDwRequest request) throws Exception {
		EndoServiceProto.END1001U02DsvDwResponse.Builder response = EndoServiceProto.END1001U02DsvDwResponse.newBuilder();
		Double fkocs = CommonUtils.parseDouble(request.getFkocs());
		List<END1001U02DsvDwInfo> listResult = pfe1000Repository.getEND1001U02DsvDwInfo(getHospitalCode(vertx, sessionId), fkocs);
		if(!CollectionUtils.isEmpty(listResult)){
			for(END1001U02DsvDwInfo item : listResult){
				EndoModelProto.END1001U02DsvDwInfo.Builder info = EndoModelProto.END1001U02DsvDwInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDsvDwItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}