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
import nta.med.data.model.ihis.drgs.DRG3010P99grdDcOrderInfo;
import nta.med.data.model.ihis.drgs.DRG3010P99grdJusaDcOrderInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99grdMagamJusaOrderHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99grdMagamJusaOrderRequest, DrgsServiceProto.DRG3010P99grdMagamJusaOrderResponse>{
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99grdMagamJusaOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99grdMagamJusaOrderRequest request) throws Exception{
		DrgsServiceProto.DRG3010P99grdMagamJusaOrderResponse.Builder response = DrgsServiceProto.DRG3010P99grdMagamJusaOrderResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<DRG3010P99grdJusaDcOrderInfo> result = drg3010Repository.getDRG3010P99grdMagamJusaOrderInfo(hospCode, language, request.getJubsuDate(), CommonUtils.parseDouble(request.getDrgGubun()), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99grdJusaDcOrderInfo item : result){
				DrgsModelProto.DRG3010P99grdMagamJusaOrderInfo.Builder info = DrgsModelProto.DRG3010P99grdMagamJusaOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListGrdmagamjusaorder(info);
			}
		}
		
		return response.build();
	}
}