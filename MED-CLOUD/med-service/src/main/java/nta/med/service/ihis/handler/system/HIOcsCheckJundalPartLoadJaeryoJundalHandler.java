package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.system.HIOcsCheckJundalPartLoadJaeryoJundalInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalRequest;
import nta.med.service.ihis.proto.SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class HIOcsCheckJundalPartLoadJaeryoJundalHandler
	extends ScreenHandler<SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalRequest, SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalResponse> {                     
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public HIOcsCheckJundalPartLoadJaeryoJundalResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			HIOcsCheckJundalPartLoadJaeryoJundalRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalResponse.Builder response = SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalResponse.newBuilder();                      
		List<HIOcsCheckJundalPartLoadJaeryoJundalInfo> listResult = bas0260Repository.getHIOcsCheckJundalPartLoadJaeryoJundalListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getIoGubun(),request.getHangmogCode(),request.getJundalTable(),request.getJundalPart(),
				DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) ,request.getInputPart());
		if(!CollectionUtils.isEmpty(listResult)){
			for(HIOcsCheckJundalPartLoadJaeryoJundalInfo item : listResult){
				CommonModelProto.HIOcsCheckJundalPartLoadJaeryoJundalInfo.Builder info = CommonModelProto.HIOcsCheckJundalPartLoadJaeryoJundalInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCheckJundalItem(info);
			}
		}
		return response.build();
	}
}