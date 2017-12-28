package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99grdMiMagamJusaOrderInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99grdMiMagamJusaOrderHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderRequest, DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderRequest request) throws Exception{
		
		DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderResponse.Builder response = DrgsServiceProto.DRG3010P99grdMiMagamJusaOrderResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<DRG3010P99grdMiMagamJusaOrderInfo> result = drg3010Repository.getDRG3010P99grdMiMagamJusaOrderInfo(hospCode, language, request.getOrderDate(),
				request.getHopeDate(), request.getBunho(), request.getHoDong(), request.getResident(), request.getMagamGubun(), startNum, offset, true);
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99grdMiMagamJusaOrderInfo item : result){
				DrgsModelProto.DRG3010P99grdMiMagamJusaOrderInfo.Builder info = DrgsModelProto.DRG3010P99grdMiMagamJusaOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListGrdmimagamjusaorder(info);
			}
		}
	
		return response.build();
	}
}