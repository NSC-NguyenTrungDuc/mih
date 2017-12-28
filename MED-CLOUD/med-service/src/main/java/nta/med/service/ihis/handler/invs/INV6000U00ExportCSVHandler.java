package nta.med.service.ihis.handler.invs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.common.util.DateTimes;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.invs.INV6000U00ExportCSVInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV6000U00ExportCSVRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV6000U00ExportCSVResponse;

@Service
@Scope("prototype")
public class INV6000U00ExportCSVHandler extends ScreenHandler<InvsServiceProto.INV6000U00ExportCSVRequest, InvsServiceProto.INV6000U00ExportCSVResponse>  {

	@Resource                                                                                                       
	private Inv0110Repository inv0110Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INV6000U00ExportCSVResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV6000U00ExportCSVRequest request) throws Exception {
		InvsServiceProto.INV6000U00ExportCSVResponse.Builder response = InvsServiceProto.INV6000U00ExportCSVResponse.newBuilder();
		Date fromDate = DateUtil.toDate(request.getMonth(), DateUtil.PATTERN_YYYYMM_BLANK);
		Date toDate = new Date(DateTimes.addSeconds(DateTimes.addMonths(DateTimes.parse(DateUtil.PATTERN_YYYYMM_BLANK, request.getMonth()), 1), -1));;
		List<INV6000U00ExportCSVInfo> exportDatas =  inv0110Repository.getINV6000U00ExportCSVInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), fromDate, toDate);
		if(!CollectionUtils.isEmpty(exportDatas)){
			for(INV6000U00ExportCSVInfo item : exportDatas){
				 InvsModelProto.INV6000U00ExportCSVInfo.Builder info = InvsModelProto.INV6000U00ExportCSVInfo.newBuilder();
    			 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                 response.addCsvItem(info);
			}
		}
		return response.build();
	}

}
