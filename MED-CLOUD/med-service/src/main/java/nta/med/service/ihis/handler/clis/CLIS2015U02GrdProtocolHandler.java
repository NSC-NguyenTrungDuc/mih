package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.model.ihis.clis.CLIS2015U02GrdProtocolInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02GrdProtocolRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02GrdProtocolResponse;

@Service
@Scope("prototype")
public class CLIS2015U02GrdProtocolHandler extends ScreenHandler<ClisServiceProto.CLIS2015U02GrdProtocolRequest, ClisServiceProto.CLIS2015U02GrdProtocolResponse> {
	@Resource
	private ClisProtocolRepository clisProtocolRepository;

	@Override
	@Transactional(readOnly = true)
	public CLIS2015U02GrdProtocolResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CLIS2015U02GrdProtocolRequest request)
					throws Exception {
            ClisServiceProto.CLIS2015U02GrdProtocolResponse.Builder response = ClisServiceProto.CLIS2015U02GrdProtocolResponse.newBuilder();
            
            List<CLIS2015U02GrdProtocolInfo> listInfo = clisProtocolRepository.getCLIS2015U02GrdProtocolInfo(getHospitalCode(vertx, sessionId), 
            		getClisSmoId(vertx, sessionId), request.getPatientCode(), request.getProtocolCode(), request.getProtocolName(),
            				request.getProtocolStatus(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD));
            if(!CollectionUtils.isEmpty(listInfo)){
            	for(CLIS2015U02GrdProtocolInfo info: listInfo){
            		ClisModelProto.CLIS2015U02GrdProtocolInfo.Builder builder = ClisModelProto.CLIS2015U02GrdProtocolInfo.newBuilder();
            		BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
            		response.addGrdProtocolList(builder);
            	}
            }
		return response.build();
	}
}
