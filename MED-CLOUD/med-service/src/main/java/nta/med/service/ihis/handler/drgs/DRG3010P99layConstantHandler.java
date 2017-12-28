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
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.system.LayConstantInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99layConstantHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99layConstantRequest, DrgsServiceProto.DRG3010P99layConstantResponse>{
	
	@Resource
	private Inv0102Repository inv0102Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99layConstantResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99layConstantRequest request) throws Exception{
		
		DrgsServiceProto.DRG3010P99layConstantResponse.Builder response = DrgsServiceProto.DRG3010P99layConstantResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);		
		
		List<LayConstantInfo> result = inv0102Repository.getLayConstantInfo(hospCode, language, request.getNameControl());
		
		if(!CollectionUtils.isEmpty(result)){
			for(LayConstantInfo item : result){
				DrgsModelProto.DRG3010P99layConstantInfo.Builder info = DrgsModelProto.DRG3010P99layConstantInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListLayconstant(info);
			}
		}
	
		return response.build();
	}
}