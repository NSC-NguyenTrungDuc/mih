package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99getBodyIndexInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99getBodyIndexHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99getBodyIndexRequest, DrgsServiceProto.DRG3010P99getBodyIndexResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99getBodyIndexResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99getBodyIndexRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99getBodyIndexResponse.Builder response = DrgsServiceProto.DRG3010P99getBodyIndexResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99getBodyIndexInfo> result = drg3010Repository.getDRG3010P99getBodyIndexInfo(hospCode, request.getBunho(), request.getComment());
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99getBodyIndexInfo item : result){
				DrgsModelProto.DRG3010P99getBodyIndexInfo.Builder info = DrgsModelProto.DRG3010P99getBodyIndexInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListBodyindex(info);
			}
		}
		
		return response.build();
	}
}