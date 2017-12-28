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
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99layOutOrderHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99layOutOrderRequest, DrgsServiceProto.DRG3010P99layOutOrderResponse>{
	
	@Resource
	private Drg2010Repository drg2010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99layOutOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99layOutOrderRequest request) throws Exception{
		
		DrgsServiceProto.DRG3010P99layOutOrderResponse.Builder response = DrgsServiceProto.DRG3010P99layOutOrderResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DataStringListItemInfo> result = drg2010Repository.getDRG3010P99layOutOrder(hospCode, request.getFromDate(), request.getToDate(), request.getGubun(),
							request.getWonyoiYn(), request.getGwa(), request.getBunho());
		
		if(!CollectionUtils.isEmpty(result)){
			for(DataStringListItemInfo item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addOutRes(info);
			}
		}
	
		return response.build();
	}
}