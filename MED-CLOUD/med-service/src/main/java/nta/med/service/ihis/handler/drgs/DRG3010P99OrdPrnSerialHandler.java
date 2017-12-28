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
import nta.med.data.dao.medi.drg.Drg3011Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99OrdPrnSerialInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99OrdPrnSerialHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99OrdPrnSerialRequest, DrgsServiceProto.DRG3010P99OrdPrnSerialResponse>{
	
	@Resource
	private Drg3011Repository drg3011Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99OrdPrnSerialResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99OrdPrnSerialRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99OrdPrnSerialResponse.Builder response = DrgsServiceProto.DRG3010P99OrdPrnSerialResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99OrdPrnSerialInfo> result = drg3011Repository.getDRG3010P99OrdPrnSerialInfo(hospCode, language, CommonUtils.parseDouble(request.getDrgBunho()),
							request.getSerialText(), request.getJubsuDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99OrdPrnSerialInfo item : result){
				DrgsModelProto.DRG3010P99OrdPrnSerialInfo.Builder info = DrgsModelProto.DRG3010P99OrdPrnSerialInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				
				if (item.getSourceFkocs2003() != null) {
					info.setSourceFkocs2003(String.format("%.0f",item.getSourceFkocs2003()));
				}
				
				if (item.getFkocs2003() != null) {
					info.setFkocs2003(String.format("%.0f",item.getFkocs2003()));
				}
				
				response.addListOrdprnserial(info);
			}
		}
		
		return response.build();
	}
}