package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layHocodeBednoRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;


@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00layHocodeBednoHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layHocodeBednoRequest, SystemServiceProto.ComboResponse> {
	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Override	
	@Transactional(readOnly=true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layHocodeBednoRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = ComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String hoDong = request.getHoDong();
		String hoCode = request.getHoCode();
		
		List<ComboListItemInfo> listInfo = bas0253Repository.getNUR2004U00layHocodeBednoRequest(hospCode, hoDong, hoCode);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(ComboListItemInfo item : listInfo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info,language);
				response.addComboItem(info);
			}
		}
		
		return response.build();
	}

}
