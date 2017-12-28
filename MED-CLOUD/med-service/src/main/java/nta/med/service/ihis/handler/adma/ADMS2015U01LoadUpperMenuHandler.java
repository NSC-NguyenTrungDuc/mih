package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm4100Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.adma.ADMS2015U01MenuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01LoadUpperMenuRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01LoadUpperMenuResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class ADMS2015U01LoadUpperMenuHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U01LoadUpperMenuRequest, AdmaServiceProto.ADMS2015U01LoadUpperMenuResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U01LoadUpperMenuHandler.class);                                    
	@Resource                                                                                                       
	private Adm4100Repository adm4100Repository;
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	@Override                     
	@Transactional(readOnly = true)
	public ADMS2015U01LoadUpperMenuResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ADMS2015U01LoadUpperMenuRequest request) throws Exception {
  	   	AdmaServiceProto.ADMS2015U01LoadUpperMenuResponse.Builder response = AdmaServiceProto.ADMS2015U01LoadUpperMenuResponse.newBuilder();
  	    List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
  	    String language = bas0001List.size() > 0 ? bas0001List.get(0).getLanguage() : "";
		List<ADMS2015U01MenuInfo> list =  adm4100Repository.getADMS2015U01LoadUpperMenu(request.getSysId(), request.getHospCode(), language);
		if(!CollectionUtils.isEmpty(list)){
			for(ADMS2015U01MenuInfo item : list){
				AdmaModelProto.ADMS2015U01MenuInfo.Builder info = AdmaModelProto.ADMS2015U01MenuInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getSelectFlg() != null){
					info.setSelectFlg(item.getSelectFlg().toString());
				}else{
					info.setSelectFlg("0");
				}
				response.addMenuInfo(info);
			}
		}
		return response.build();
	} 

}
