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

import nta.med.common.util.Strings;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.model.ihis.invs.INV4001U00ExportCSVInfo;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00ExportCSVRequest;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001U00ExportCSVResponse;

@Service
@Scope("prototype")
public class INV4001U00ExportCSVHandler extends ScreenHandler<InvsServiceProto.INV4001U00ExportCSVRequest, InvsServiceProto.INV4001U00ExportCSVResponse>{
	private static final Log LOGGER = LogFactory.getLog(INV4001U00ExportCSVHandler.class);
	@Resource
	private Inv4001Repository inv4001Repository;
	@Override
	@Transactional(readOnly = true)
	public INV4001U00ExportCSVResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001U00ExportCSVRequest request) throws Exception {
//		Date fromDate = DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD);
//        Date toDate = DateUtil.toDate(request.getEndDate(), DateUtil.PATTERN_YYMMDD);
        
        Date fromDate = DateUtil.toDate(request.getStartDate() + " 00:00:00", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
        Date toDate = DateUtil.toDate(request.getEndDate() + " 23:59:59", DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS);
		InvsServiceProto.INV4001U00ExportCSVResponse.Builder response = InvsServiceProto.INV4001U00ExportCSVResponse.newBuilder();
		List<INV4001U00ExportCSVInfo> exportCSVlist = inv4001Repository.getINV4001U00ExportCSVInfo(getHospitalCode(vertx, sessionId), fromDate, toDate, getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(exportCSVlist)){
			for(INV4001U00ExportCSVInfo item : exportCSVlist){
				InvsModelProto.INV4001U00ExportCSVInfo.Builder info = InvsModelProto.INV4001U00ExportCSVInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
   			 	
   			 	response.addCsvItem(info);         
			}
		}else{
			LOGGER.info("INV4001U00ExportCSVHandler handler not found list of INV4001U00ExportCSVInfo");
		}
		return response.build();
	}

}
