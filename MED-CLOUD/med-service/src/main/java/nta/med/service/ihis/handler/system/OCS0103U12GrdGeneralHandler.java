package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.model.ihis.system.OCS0103U12GrdGeneralInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0103U12GrdGeneralRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0103U12GrdGeneralResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12GrdGeneralHandler extends ScreenHandler <SystemServiceProto.OCS0103U12GrdGeneralRequest, SystemServiceProto.OCS0103U12GrdGeneralResponse> {                     
	@Resource                                                                                                       
	private Ocs0102Repository ocs0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OCS0103U12GrdGeneralResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U12GrdGeneralRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.OCS0103U12GrdGeneralResponse.Builder response = SystemServiceProto.OCS0103U12GrdGeneralResponse.newBuilder();   
  	    String offset =  "0" ;
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<OCS0103U12GrdGeneralInfo> listResult = ocs0102Repository.getOCS0103U12GrdGeneralListItem(getHospitalCode(vertx, sessionId), request.getFilter(),
				request.getYakKijunCode(),request.getOrderDate(),request.getHangmogCode(), startNum, CommonUtils.parseInteger(offset), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0103U12GrdGeneralInfo item : listResult){
				CommonModelProto.OCS0103U12GrdGeneralInfo.Builder info = CommonModelProto.OCS0103U12GrdGeneralInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInfo1(info);
			}
		}
		return response.build();
	}
}