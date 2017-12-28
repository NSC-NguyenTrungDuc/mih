package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01UserNmByBuseoNameHandler extends ScreenHandler<NuriServiceProto.NUR6011U01UserNmByBuseoNameRequest, SystemServiceProto.ComboResponse> {   
	
	@Resource                                   
	private Adm3200Repository adm3200Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01UserNmByBuseoNameRequest request) throws Exception {
				
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> result = adm3200Repository.getNUR6011U01UserNmByBuseoName(hospCode, request.getBuseoName());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}
}
