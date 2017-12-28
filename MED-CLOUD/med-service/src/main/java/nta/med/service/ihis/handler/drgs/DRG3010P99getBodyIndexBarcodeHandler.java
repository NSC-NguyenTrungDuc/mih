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
import nta.med.data.model.ihis.drgs.DRG3010P99getBodyIndexBarcodeInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99getBodyIndexBarcodeHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99getBodyIndexBarcodeRequest, DrgsServiceProto.DRG3010P99getBodyIndexBarcodeResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99getBodyIndexBarcodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99getBodyIndexBarcodeRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99getBodyIndexBarcodeResponse.Builder response = DrgsServiceProto.DRG3010P99getBodyIndexBarcodeResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99getBodyIndexBarcodeInfo> result = drg3010Repository.getDRG3010P99getBodyIndexBarcodeInfo(hospCode, request.getBunho());
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99getBodyIndexBarcodeInfo item : result){
				DrgsModelProto.DRG3010P99getBodyIndexBarcodeInfo.Builder info = DrgsModelProto.DRG3010P99getBodyIndexBarcodeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListBodyindex(info);
			}
		}
		
		return response.build();
	}
}