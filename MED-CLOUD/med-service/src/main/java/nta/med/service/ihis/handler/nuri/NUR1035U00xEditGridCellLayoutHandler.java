package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1035U00xEditGridCellLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1035U00xEditGridCellLayoutRequest, NuriServiceProto.NUR1035U00xEditGridCellLayoutResponse> {   
	
	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1035U00xEditGridCellLayoutResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1035U00xEditGridCellLayoutRequest request) throws Exception {
				
		NuriServiceProto.NUR1035U00xEditGridCellLayoutResponse.Builder response = NuriServiceProto.NUR1035U00xEditGridCellLayoutResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> result = nur0102Repository.getNuroComboTime(language, hospCode, "METHOD_CODE", true);
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addXeditgridcell1(info);
			}
		}
		
		result = nur0102Repository.getNuroComboTime(language, hospCode, "CHECK_STATE", true);
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLaystate(info);
			}
		}
		
		result = nur0102Repository.getNUR1035U00layModifyLimit(hospCode, "NUR1035_MODIFY_LIMIT", language);
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLaymodifylimit(info);
			}
		}
		
		result = nur0102Repository.getNuroComboTime(language, hospCode, "CHECK_TIME", true);
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLaytime(info);
			}
		}
		
		return response.build();
	}
}
