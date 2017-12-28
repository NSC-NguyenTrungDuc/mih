package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01MultiGrdRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01MultiGrdResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01MultiGrdHandler 
	extends ScreenHandler<PhysServiceProto.PHY8002U01MultiGrdRequest, PhysServiceProto.PHY8002U01MultiGrdResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly=true)
	public PHY8002U01MultiGrdResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY8002U01MultiGrdRequest request)
			throws Exception {                                                                  
  	   	PhysServiceProto.PHY8002U01MultiGrdResponse.Builder response = PhysServiceProto.PHY8002U01MultiGrdResponse.newBuilder();
  		String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		// GRD_OT
		List<ComboListItemInfo> listgrdOT = ocs0132Repository.getPhy8002U01GrdOTListItemInfo(hospCode, "PHY_OT", "1", language);
		if(!CollectionUtils.isEmpty(listgrdOT)){
			for(ComboListItemInfo item : listgrdOT){
				PhysModelProto.PHY8002U01GrdOTListItemInfo.Builder info = PhysModelProto.PHY8002U01GrdOTListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeName(item.getCodeName());
				}
				info.setSelected("N");
				response.addGrdOTList(info);
			}
		}
		// GRD_PT
		List<ComboListItemInfo> listgrdPT = ocs0132Repository.getPhy8002U01GrdOTListItemInfo(hospCode, "PHY_PT", "1", language);
		if(!CollectionUtils.isEmpty(listgrdPT)){
			for(ComboListItemInfo item : listgrdPT){
				PhysModelProto.PHY8002U01GrdOTListItemInfo.Builder info = PhysModelProto.PHY8002U01GrdOTListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeName(item.getCodeName());
				}
				info.setSelected("N");
				response.addGrdPTList(info);
			}
		}
		// GRD_ST
		List<ComboListItemInfo> listgrdST = ocs0132Repository.getPhy8002U01GrdOTListItemInfo(hospCode, "PHY_ST", "1", language);
		if(!CollectionUtils.isEmpty(listgrdST)){
			for(ComboListItemInfo item : listgrdST){
				PhysModelProto.PHY8002U01GrdOTListItemInfo.Builder info = PhysModelProto.PHY8002U01GrdOTListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeName(item.getCodeName());
				}
				info.setSelected("N");
				response.addGrdSTList(info);
			}
		}
		return response.build();
	}
}