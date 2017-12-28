package nta.med.service.ihis.handler.adma;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.AdmsMenu;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm4310Repository;
import nta.med.data.dao.medi.adm.AdmsMenuRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.ADMS2015U01SettingMenuInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U01SettingMenuRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")
public class ADMS2015U01SettingMenuHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U01SettingMenuRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U01SettingMenuHandler.class);
	
	@Resource                                                                                                       
	private AdmsMenuRepository admsMenuRepository;     
	@Resource
	private Adm4310Repository adm4310Repository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ADMS2015U01SettingMenuRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean save = false;
		List<ADMS2015U01SettingMenuInfo> listItem = request.getMenuInfoList();
		if(!CollectionUtils.isEmpty(listItem)){
			for(ADMS2015U01SettingMenuInfo item: listItem){
				Integer selectFlg = CommonUtils.parseInteger(item.getSelectFlg());
				String trId = item.getTrId();
				if(admsMenuRepository.updateADMS2015U01SettingMenu(selectFlg, request.getSystemId(), request.getHospCode(), trId) <= 0 ){
					AdmsMenu admsMenu = new AdmsMenu();
					admsMenu.setSystemId(request.getSystemId());
					admsMenu.setTrId(trId);
					admsMenu.setHospCode(request.getHospCode());
					admsMenu.setSysId(request.getUserId());
					admsMenu.setUpdId(request.getUserId());
					admsMenu.setCreated(new Date());
					admsMenu.setUpdated(new Date());
					admsMenu.setActiveFlg(1);
					admsMenu.setSelectFlg(selectFlg);
					admsMenuRepository.save(admsMenu);
				}
				save = updateAdm4310(request.getSystemId());
                if (!save) {
                    response.setResult(false);
                    response.setMsg("Failed");
                    throw new ExecutionException(response.build());
                }
			}
		}
		response.setResult(true);
		return response.build();
	}		
	 public boolean updateAdm4310(String sysId) {
	        if (adm4310Repository.updateAdm106UAdm4310("N", sysId) >= 0) {
	            return true;
	        } else {
	            return false;
	        }
	    }

}
