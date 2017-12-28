package nta.med.service.ihis.handler.drug;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.drug.DRG0102U00GrdDetailInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrugModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DRG0102U00GrdDetailHandler extends ScreenHandler<DrugServiceProto.DRG0102U00GrdDetailRequest, DrugServiceProto.DRG0102U00GrdDetailResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(DRG0102U00GrdDetailHandler.class);                                    
	@Resource                                                                                                       
	private Inv0102Repository inv0102Repository;  
	
	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRG0102U00GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0102U00GrdDetailRequest request) throws Exception {
		 DrugServiceProto.DRG0102U00GrdDetailResponse.Builder response = DrugServiceProto.DRG0102U00GrdDetailResponse.newBuilder(); 
		 List<DRG0102U00GrdDetailInfo> listDetail = inv0102Repository.getDRG0102U00GrdDetailInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
         if(!CollectionUtils.isEmpty(listDetail)) {
           	for(DRG0102U00GrdDetailInfo item : listDetail) {
           		DrugModelProto.DRG0102U00GrdDetailInfo.Builder info = DrugModelProto.DRG0102U00GrdDetailInfo.newBuilder();
           		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
           		response.addListInfo(info);
           	}
         }
		return response.build();
	}                                                                                                                 
}