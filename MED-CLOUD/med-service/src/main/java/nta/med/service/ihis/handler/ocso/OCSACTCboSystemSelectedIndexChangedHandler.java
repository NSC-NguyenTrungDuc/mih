package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTCboSystemSelectedIndexChangedHandler extends ScreenHandler<OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedRequest, OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTCboSystemSelectedIndexChangedHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;    
	@Resource
	private Adm3200Repository adm3200Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedRequest request) throws Exception {
		OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedResponse.Builder response = OcsoServiceProto.OCSACTCboSystemSelectedIndexChangedResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//1. Get cboPart
		List<ComboListItemInfo> listPart = new ArrayList<ComboListItemInfo>();
		if("NURO".equals(request.getSystemId())
				|| "NURI".equals(request.getSystemId())
				|| "TSTS".equals(request.getSystemId())) {
			listPart = ocs0132Repository.getCodeCodeNameWhereNURItemInfo(hospCode, language, request.getCodeType(), "NUR", true); 
		}else{
			listPart = ocs0132Repository.getCodeCodeNameWhereNURItemInfo(hospCode, language, request.getCodeType(), request.getSystemId(), true); 
		}
		if(!CollectionUtils.isEmpty(listPart)){
			for(ComboListItemInfo item : listPart){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboPartItem(info);
			}
		}
		//2. Get cbxActor 
		List<ComboListItemInfo> listActor = new ArrayList<ComboListItemInfo>();
		switch (request.getSystemId()) {
			case "NUTS":
				listActor = adm3200Repository.getUserIdUserNameInfo("NUT", "3", hospCode, false, "");
				break;
			case "CPLS":
				listActor = adm3200Repository.getUserIdUserNameInfo("CPL", "3", hospCode, false, "");
				break;
			case "PFES":
				listActor = adm3200Repository.getOcsactCboSystemSelectedIndexPfesCaseListItem(
						hospCode, "OCS", "SUBPART_DOCTOR", language);
				break;
			case "OPRS":
				listActor = adm3200Repository.getOcsactCboSystemSelectedIndexOprsCaseListItem(hospCode, "OCS", "1", "10000", true);
				break;
			case "TSTS":
				listActor = adm3200Repository.getOcsactCboSystemSelectedIndexOprsCaseListItem(hospCode,"NUR", "2", "30010", false);
				listActor.addAll(adm3200Repository.getOcsactCboSystemSelectedIndexNuriCaseListItem(hospCode,
						"NUR", "2", request.getHoDong(), language));
				break;
			case "NURO":
				listActor = adm3200Repository.getOcsactCboSystemSelectedIndexOprsCaseListItem(hospCode,"NUR", "2", "30010", true);
				break;
			case "NURI":
				listActor = adm3200Repository.getOcsactCboSystemSelectedIndexNuriCaseListItem(hospCode,"NUR", "2", request.getHoDong(), language);
				break;
			default:
				break;
		}
		if(!CollectionUtils.isEmpty(listActor)){
			for(ComboListItemInfo item : listActor){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCbxActorItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}