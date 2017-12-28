package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class INJ1002U01LayReserDateHandler extends ScreenHandler<InjsServiceProto.INJ1002U01LayReserDateRequest, InjsServiceProto.INJ1002U01LayReserDateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ1002U01LayReserDateHandler.class);                                    
	@Resource                                                                                                       
	private Inj1002Repository inj1002Repository;                                                                    

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1002U01LayReserDateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1002U01LayReserDateRequest request) throws Exception {
		InjsServiceProto.INJ1002U01LayReserDateResponse.Builder response = InjsServiceProto.INJ1002U01LayReserDateResponse.newBuilder();  
		List<String> listReserDate = inj1002Repository.getINJ1002U01InitializeReserDate(getHospitalCode(vertx, sessionId), request.getBunho());
        if (!CollectionUtils.isEmpty(listReserDate)) {
        	for (String item : listReserDate) {
        		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
        		if(!StringUtils.isEmpty(item)) {
        			info.setDataValue(item);
        		}
        		response.addReserDate(info);
        	}
        }
		return response.build();
	}                                                                                                                 
}