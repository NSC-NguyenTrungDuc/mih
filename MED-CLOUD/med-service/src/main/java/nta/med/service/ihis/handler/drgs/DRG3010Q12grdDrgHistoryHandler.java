package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg9005Repository;
import nta.med.data.model.ihis.drgs.DRG3010Q12grdDrgHistoryInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12grdDrgHistoryRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12grdDrgHistoryResponse;

@Service
@Scope("prototype")
public class DRG3010Q12grdDrgHistoryHandler extends
		ScreenHandler<DrgsServiceProto.DRG3010Q12grdDrgHistoryRequest, DrgsServiceProto.DRG3010Q12grdDrgHistoryResponse> {
	
	@Resource
	private Drg9005Repository drg9005Repository;

	@Override
	public DRG3010Q12grdDrgHistoryResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010Q12grdDrgHistoryRequest request) throws Exception {
		
		DrgsServiceProto.DRG3010Q12grdDrgHistoryResponse.Builder response = DrgsServiceProto.DRG3010Q12grdDrgHistoryResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = 200;
		Integer startNum = StringUtils.isEmpty(200) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), "200");
		
		List<DRG3010Q12grdDrgHistoryInfo> result = drg9005Repository.getDRG3010Q12grdDrgHistoryInfo(hospCode, language, request.getYyyymm(), request.getBunho(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for (DRG3010Q12grdDrgHistoryInfo item : result){
				DrgsModelProto.DRG3010Q12grdDrgHistoryInfo.Builder info = DrgsModelProto.DRG3010Q12grdDrgHistoryInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		
		return response.build();
	}

}
