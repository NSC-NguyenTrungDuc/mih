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
import nta.med.data.model.ihis.drgs.DRG3010P99JusaLabelInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99JusaLabelHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99JusaLabelRequest, DrgsServiceProto.DRG3010P99JusaLabelResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99JusaLabelResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99JusaLabelRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99JusaLabelResponse.Builder response = DrgsServiceProto.DRG3010P99JusaLabelResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99JusaLabelInfo> result = drg3010Repository.getDRG3010P99JusaLabelInfo(hospCode, language, request.getJubsuDate(), CommonUtils.parseDouble(request.getDrgBunho()));
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99JusaLabelInfo item : result){
				DrgsModelProto.DRG3010P99JusaLabelInfo.Builder info = DrgsModelProto.DRG3010P99JusaLabelInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListJusalabel(info);
			}
		}
		
		return response.build();
	}
}