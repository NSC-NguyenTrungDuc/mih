package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj0102Repository;
import nta.med.data.model.ihis.injs.INJ0101U01GrdDetailItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class INJ0101U01GrdDetailHandler extends ScreenHandler<InjsServiceProto.INJ0101U01GrdDetailRequest, InjsServiceProto.INJ0101U01GrdDetailResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ0101U01GrdDetailHandler.class);                                    
	@Resource                                                                                                       
	private Inj0102Repository inj0102Repository;                                                                    

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0101U01GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U01GrdDetailRequest request) throws Exception {
		InjsServiceProto.INJ0101U01GrdDetailResponse.Builder response = InjsServiceProto.INJ0101U01GrdDetailResponse.newBuilder();     
		List<INJ0101U01GrdDetailItemInfo> listResult =  inj0102Repository.getInj0101U01GrdDetailListItemInfo(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(INJ0101U01GrdDetailItemInfo item : listResult){
				InjsModelProto.INJ0101U01GrdDetailItemInfo.Builder info = InjsModelProto.INJ0101U01GrdDetailItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDetailItemInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}