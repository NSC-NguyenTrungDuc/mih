package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
public class InjsINJ1001U01AllergyListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01AllergyListRequest, InjsServiceProto.InjsINJ1001U01AllergyListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01AllergyListHandler.class);                                        
	@Resource                                                                                                       
	private Nur1016Repository nur1016Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01AllergyListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getQueryDate()) && DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01AllergyListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01AllergyListRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01AllergyListResponse.Builder response = InjsServiceProto.InjsINJ1001U01AllergyListResponse.newBuilder(); 
		List<String> listAllergy =nur1016Repository.getInjsINJ1001U01AllergyList(getHospitalCode(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD) );
		if(!CollectionUtils.isEmpty(listAllergy)){
			for(String item : listAllergy){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item)) {
					info.setDataValue(item);
				}
				response.addAllergyInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}