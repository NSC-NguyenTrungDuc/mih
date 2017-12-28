package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj0101Repository;
import nta.med.data.model.ihis.injs.INJ0101U01GrdMasterItemInfo;
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
public class INJ0101U01GrdMasterHandler extends ScreenHandler<InjsServiceProto.INJ0101U01GrdMasterRequest, InjsServiceProto.INJ0101U01GrdMasterResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ0101U01GrdMasterHandler.class);                                    
	@Resource                                                                                                       
	private Inj0101Repository inj0101Repository;                                                                    

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ0101U01GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ0101U01GrdMasterRequest request) throws Exception {
		InjsServiceProto.INJ0101U01GrdMasterResponse.Builder response = InjsServiceProto.INJ0101U01GrdMasterResponse.newBuilder();             
		List<INJ0101U01GrdMasterItemInfo> listResult = inj0101Repository.getINJ0101U01GrdMasterItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(INJ0101U01GrdMasterItemInfo item : listResult){
				InjsModelProto.INJ0101U01GrdMasterItemInfo.Builder info = InjsModelProto.INJ0101U01GrdMasterItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItemInfo(info);
			}
		}
		return response.build();
	}	                                                                                                                 
}