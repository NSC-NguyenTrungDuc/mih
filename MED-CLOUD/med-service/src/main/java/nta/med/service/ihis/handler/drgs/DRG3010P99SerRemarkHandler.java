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
import nta.med.data.model.ihis.drgs.DRG3010P99SerRemarkInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99SerRemarkHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99SerRemarkRequest, DrgsServiceProto.DRG3010P99SerRemarkResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99SerRemarkResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99SerRemarkRequest request) throws Exception{
	
		DrgsServiceProto.DRG3010P99SerRemarkResponse.Builder response = DrgsServiceProto.DRG3010P99SerRemarkResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99SerRemarkInfo> result = drg3010Repository.getDRG3010P99SerRemarkInfo(hospCode, request.getJubsuDate(), CommonUtils.parseDouble(request.getDrgBunho()), request.getSerialText());
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99SerRemarkInfo item : result){
				DrgsModelProto.DRG3010P99SerRemarkInfo.Builder info = DrgsModelProto.DRG3010P99SerRemarkInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListSerremark(info);
			}
		}
		
		return response.build();
	}
}