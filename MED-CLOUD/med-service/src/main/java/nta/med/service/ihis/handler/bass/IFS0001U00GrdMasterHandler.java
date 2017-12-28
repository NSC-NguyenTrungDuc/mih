package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs0001Repository;
import nta.med.data.model.ihis.adma.IFS0001U00GrdMasterInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00GrdMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00GrdMasterResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0001U00GrdMasterHandler extends ScreenHandler<BassServiceProto.IFS0001U00GrdMasterRequest, BassServiceProto.IFS0001U00GrdMasterResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0001U00GrdMasterHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0001Repository ifs0001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IFS0001U00GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, IFS0001U00GrdMasterRequest request)
					throws Exception {
  	   	BassServiceProto.IFS0001U00GrdMasterResponse.Builder response = BassServiceProto.IFS0001U00GrdMasterResponse.newBuilder();                      
		List<IFS0001U00GrdMasterInfo> listGrd =  ifs0001Repository.getIFS0001U00GrdMasterInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getAcctType());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(IFS0001U00GrdMasterInfo item : listGrd){
				BassModelProto.IFS0001U00GrdMasterInfo.Builder info = BassModelProto.IFS0001U00GrdMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMstItem(info);
			}
		}
        return response.build();
	}

}