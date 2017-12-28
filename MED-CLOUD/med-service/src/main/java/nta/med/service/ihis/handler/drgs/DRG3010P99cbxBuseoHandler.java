package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99cbxBuseoHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99cbxBuseoRequest, SystemServiceProto.ComboResponse>{
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
    @Override
    @Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99cbxBuseoRequest request) throws Exception{
	
    	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
    	
    	String hospCode = getHospitalCode(vertx, sessionId);
    	String language = getLanguage(vertx, sessionId);
    	
    	List<ComboListItemInfo> result = bas0260Repository.getDRG3010P99cbxBuseo(hospCode, language, "2");
    	
    	if(!CollectionUtils.isEmpty(result)){
    		for(ComboListItemInfo item : result){
    			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, language);
    			response.addComboItem(info);
    		}
    	}
    	
		return response.build();
	}
}
