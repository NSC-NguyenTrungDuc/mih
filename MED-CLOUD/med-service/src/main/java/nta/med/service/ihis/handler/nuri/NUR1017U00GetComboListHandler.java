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
public class NUR1017U00GetComboListHandler extends ScreenHandler<NuriServiceProto.NUR1017U00GetComboListRequest, NuriServiceProto.NUR1017U00GetComboListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1017U00GetComboListHandler.class);                                        
	@Resource                                                                                                       
	private Nur0102Repository nur0102Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1017U00GetComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1017U00GetComboListRequest request) throws Exception {
		NuriServiceProto.NUR1017U00GetComboListResponse.Builder response=NuriServiceProto.NUR1017U00GetComboListResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listxEditGridCell1 = nur0102Repository.getNUR1017U00GetComboListItem(hospCode, request.getCodeTypeXEditGridCell1(), language);
		if(!CollectionUtils.isEmpty(listxEditGridCell1)){
			for(ComboListItemInfo item : listxEditGridCell1){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXEditGridCell1List(info);
			}
		}
		List<ComboListItemInfo> listxEditGridCell5 = nur0102Repository.getNUR1017U00GetComboListItem(hospCode, request.getCodeTypeXEditGridCell5(), language);
		if(!CollectionUtils.isEmpty(listxEditGridCell5)){
			for(ComboListItemInfo item : listxEditGridCell5){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXEditGridCell5List(info);
			}
		}
		List<ComboListItemInfo> listxEditGridCell6 = nur0102Repository.getNUR1017U00GetComboListItem(hospCode, request.getCodeTypeXEditGridCell6(), language);
		if(!CollectionUtils.isEmpty(listxEditGridCell6)){
			for(ComboListItemInfo item : listxEditGridCell6){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addXEditGridCell6List(info);
			}
		}
		List<ComboListItemInfo> listlayCombo = nur0102Repository.getNUR1017U00GetComboListItem(hospCode, request.getCodeTypeLayComboSet(), language);
		if(!CollectionUtils.isEmpty(listlayCombo)){
			for(ComboListItemInfo item : listlayCombo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayComboSetList(info);
			}
		}
		return response.build();
	}                                                                                                               
}                                                                                                                 
