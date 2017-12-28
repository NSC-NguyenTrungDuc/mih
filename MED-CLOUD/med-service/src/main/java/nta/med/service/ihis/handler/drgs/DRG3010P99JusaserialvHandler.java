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
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaSerialInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99JusaserialvHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99JusaserialvRequest, DrgsServiceProto.DRG3010P99JusaserialvResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99JusaserialvResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99JusaserialvRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99JusaserialvResponse.Builder response = DrgsServiceProto.DRG3010P99JusaserialvResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99JusaSerialInfo> result = drg3010Repository.getDRG3010P99JusaserialvInfo(hospCode, language, request.getSerialV(), CommonUtils.parseDouble(request.getFkocs2003()));
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99JusaSerialInfo item : result){
				DrgsModelProto.DRG3010P99JusaserialvInfo.Builder info = DrgsModelProto.DRG3010P99JusaserialvInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				
				if (item.getFkocs2003() != null) {
					info.setFkocs2003(String.format("%.0f",item.getFkocs2003()));
				}
				
				response.addListJusaserialv(info);
			}
		}
		
		return response.build();
	}
}