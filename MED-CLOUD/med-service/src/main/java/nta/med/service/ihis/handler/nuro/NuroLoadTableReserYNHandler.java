package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroLoadTableReserYNHandler extends ScreenHandler<NuroServiceProto.NuroLoadTableReserYNRequest, NuroServiceProto.NuroLoadTableReserYNResponse> {
	private static final Log LOG = LogFactory.getLog(NuroLoadTableReserYNHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroLoadTableReserYNResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroLoadTableReserYNRequest request) throws Exception {
		NuroServiceProto.NuroLoadTableReserYNResponse.Builder response = NuroServiceProto.NuroLoadTableReserYNResponse.newBuilder();
		List<String> listItem = out1001Repository.getNuroLoadTableReserYN(getHospitalCode(vertx, sessionId), request.getBunho(), request.getGwa(), request.getNaewonDate(), request.getDoctor());
    	if(listItem != null && listItem.size() > 0){
    		for(String item : listItem){
    			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
    			if(!StringUtils.isEmpty(item)){
           			info.setDataValue(item);
               	}
               	response.addJubsuTime(info);  
    		}
    	}
		return response.build();
	}

}
