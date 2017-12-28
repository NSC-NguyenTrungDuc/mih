package nta.med.service.ihis.handler.invs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.model.ihis.invs.INV2003U00ExportCSVInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV2003U00ExportCSVRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV2003U00ExportCSVResponse;

@Service
@Scope("prototype")
public class INV2003U00ExportCSVHandler extends ScreenHandler<InvsServiceProto.INV2003U00ExportCSVRequest, InvsServiceProto.INV2003U00ExportCSVResponse>{
	private static final Log LOGGER = LogFactory.getLog(INV2003U00ExportCSVHandler.class);
	@Resource
	private Inv2003Repository inv2003Repository;
	@Override
	@Transactional(readOnly = true)
	public INV2003U00ExportCSVResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV2003U00ExportCSVRequest request) throws Exception {
        
        Date fromDate = DateUtil.toDate(request.getStartDate() + " 00:00:00", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
        Date toDate = DateUtil.toDate(request.getEndDate() + " 23:59:59", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
		InvsServiceProto.INV2003U00ExportCSVResponse.Builder response = InvsServiceProto.INV2003U00ExportCSVResponse.newBuilder();
		List<INV2003U00ExportCSVInfo> exportCSVlist = inv2003Repository.getINV2003U00ExportCSVInfo(getHospitalCode(vertx, sessionId), fromDate, toDate, getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(exportCSVlist)){
			for(INV2003U00ExportCSVInfo item : exportCSVlist){
				InvsModelProto.INV2003U00ExportCSVInfo.Builder info = InvsModelProto.INV2003U00ExportCSVInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
   			 	
   			 	response.addListInfo(info);           
			}
		}else{
			LOGGER.info("INV2003U00ExportCSVHandler handler not found list of INV2003U00ExportCSVInfo");
		}
		
		return response.build();
	}
}
