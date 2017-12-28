package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class ADM103LayLoginSysListHandler extends ScreenHandler<AdmaServiceProto.ADM103LayLoginSysListRequest, AdmaServiceProto.ADM103LayLoginSysListResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM103LayLoginSysListHandler.class);                                    
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;                                                                    
	                                                                                                                
	@Override                                  
	@Transactional(readOnly = true)
	public AdmaServiceProto.ADM103LayLoginSysListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103LayLoginSysListRequest request) throws Exception {
		AdmaServiceProto.ADM103LayLoginSysListResponse.Builder response = AdmaServiceProto.ADM103LayLoginSysListResponse.newBuilder();
		List<ComboListItemInfo> listItem = adm0200Repository.getLayLogSysList(request.getHospCode(), getLanguage(vertx, sessionId), request.getUserId());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ComboListItemInfo item : listItem) {
				AdmaModelProto.ADM103LayLoginSysListInfo.Builder builder = AdmaModelProto.ADM103LayLoginSysListInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					builder.setSysId(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					builder.setSysNm(item.getCodeName());
				}
				response.addItemInfo(builder);
			}
		}
		return response.build();
	}
}
