package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUR1016U00GetComboListHandler extends ScreenHandler<NuriServiceProto.NUR1016U00GetComboListRequest, NuriServiceProto.NUR1016U00GetComboListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1016U00GetComboListHandler.class);                                        
	@Resource                                                                                                       
	private Nur0102Repository nur0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1016U00GetComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1016U00GetComboListRequest request) throws Exception {
		NuriServiceProto.NUR1016U00GetComboListResponse.Builder response = NuriServiceProto.NUR1016U00GetComboListResponse.newBuilder();
		List<ComboListItemInfo> listEditGridCell = nur0102Repository.getNUR1016U00xEditGridCell7(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listEditGridCell)){
			for(ComboListItemInfo item : listEditGridCell){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXEditGridCell7List(info);
			}
		}
		
		List<ComboListItemInfo> listComboSetList = nur0102Repository.getNUR1016U00layComboSet(getHospitalCode(vertx, sessionId), request.getCodeTypeLayComboSet(),getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listComboSetList)){
			for(ComboListItemInfo item : listComboSetList){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayComboSetList(info);
			}
		}
		return response.build();
	}                                                                                                               
}                                                                                                                 
