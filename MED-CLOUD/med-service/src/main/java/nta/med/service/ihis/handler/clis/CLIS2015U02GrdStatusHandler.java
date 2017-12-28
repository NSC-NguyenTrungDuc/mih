package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.clis.ClisProtocolStatusRepository;
import nta.med.data.model.ihis.clis.CLIS2015U02GrdStatusInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02GrdStatusRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02GrdStatusResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U02GrdStatusHandler extends ScreenHandler<ClisServiceProto.CLIS2015U02GrdStatusRequest, ClisServiceProto.CLIS2015U02GrdStatusResponse> {
	@Resource
	private ClisProtocolStatusRepository clisProtocolStatusRepository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U02GrdStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CLIS2015U02GrdStatusRequest request)
					throws Exception {
            ClisServiceProto.CLIS2015U02GrdStatusResponse.Builder response = ClisServiceProto.CLIS2015U02GrdStatusResponse.newBuilder();
            String hospCode = getHospitalCode(vertx, sessionId);
            String language = getLanguage(vertx, sessionId);
            if(!StringUtils.isEmpty(request.getProtocolId())){
            	List<CLIS2015U02GrdStatusInfo> listInfo = clisProtocolStatusRepository.getCLIS2015U02GrdStatusInfo(CommonUtils.parseInteger(request.getProtocolId()), hospCode, language);
            	 if(!CollectionUtils.isEmpty(listInfo)){
                 	for(CLIS2015U02GrdStatusInfo info: listInfo){
                 		ClisModelProto.CLIS2015U02GrdStatusInfo.Builder builder = ClisModelProto.CLIS2015U02GrdStatusInfo.newBuilder();
                 		BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
                 		response.addGrdStatusList(builder);
                 	}
                 }
            }else{
            	List<Bas0102> listInfo = bas0102Repository.getByCodeType(hospCode, "CLIS_STATUS", language);
            	if(!CollectionUtils.isEmpty(listInfo)){
                 	for(Bas0102 info: listInfo){
                 		ClisModelProto.CLIS2015U02GrdStatusInfo.Builder builder = ClisModelProto.CLIS2015U02GrdStatusInfo.newBuilder();
                 		builder.setStatusCode(info.getCode());
                 		builder.setStatusName(info.getCodeName());
                 		response.addGrdStatusList(builder);
                 	}
            	}
            }
            
		return response.build();
	}
}
