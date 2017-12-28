package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.drgs.DRG3010Q12AntibioticListgrdAntibioticListInfo;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListResponse;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010Q12AntibioticListgrdAntibioticListHandler extends 
		ScreenHandler<DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListRequest, DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListResponse>{
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	public DRG3010Q12AntibioticListgrdAntibioticListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010Q12AntibioticListgrdAntibioticListRequest request) throws Exception{
		
		DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListResponse.Builder response = DrgsServiceProto.DRG3010Q12AntibioticListgrdAntibioticListResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010Q12AntibioticListgrdAntibioticListInfo> result = ocs0103Repository.getDRG3010Q12AntibioticListgrdAntibioticListInfo(hospCode, language);
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010Q12AntibioticListgrdAntibioticListInfo item : result){
				DrgsModelProto.DRG3010Q12AntibioticListgrdAntibioticListInfo.Builder info = DrgsModelProto.DRG3010Q12AntibioticListgrdAntibioticListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		return response.build();
		
	}
}
