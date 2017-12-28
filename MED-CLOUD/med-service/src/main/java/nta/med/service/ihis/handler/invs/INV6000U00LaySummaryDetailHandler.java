package nta.med.service.ihis.handler.invs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv6000Repository;
import nta.med.data.model.ihis.invs.INV6000U00LaySummaryDetailInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class INV6000U00LaySummaryDetailHandler extends ScreenHandler<InvsServiceProto.INV6000U00LaySummaryDetailRequest, InvsServiceProto.INV6000U00LaySummaryDetailResponse> {
	@Resource
	private Inv6000Repository inv6000Repository;
	
	@Override
	@Transactional(readOnly = true)
    public InvsServiceProto.INV6000U00LaySummaryDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, 
    		InvsServiceProto.INV6000U00LaySummaryDetailRequest request) throws Exception {
		InvsServiceProto.INV6000U00LaySummaryDetailResponse.Builder response = InvsServiceProto.INV6000U00LaySummaryDetailResponse.newBuilder();
		List<INV6000U00LaySummaryDetailInfo> laySumaryDetails = inv6000Repository.getINV6000U00LaySummaryDetailInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getMagamMonth());
		if(!CollectionUtils.isEmpty(laySumaryDetails)){
			for(INV6000U00LaySummaryDetailInfo item : laySumaryDetails){
				InvsModelProto.INV6000U00LaySummaryDetailInfo.Builder info = InvsModelProto.INV6000U00LaySummaryDetailInfo.newBuilder();
   			 	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addLaySummaryD(info);
			}
		}
        return response.build();
    }
}
