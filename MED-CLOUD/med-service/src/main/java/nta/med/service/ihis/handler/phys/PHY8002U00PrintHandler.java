package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0001;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00PrintRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00PrintResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U00PrintHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U00PrintRequest, PhysServiceProto.PHY8002U00PrintResponse> {                     
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly=true)
	public PHY8002U00PrintResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY8002U00PrintRequest request)
			throws Exception {                                                                
  	   	PhysServiceProto.PHY8002U00PrintResponse.Builder response = PhysServiceProto.PHY8002U00PrintResponse.newBuilder();       
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		List<String> listItem = bas0260Repository.getPHY8002U00SinryoukaInfo(hospCode, language, request.getGwa());
		if(!CollectionUtils.isEmpty(listItem)) {
			for (String item : listItem) {
				if(!StringUtils.isEmpty(item)) {
					CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
					info.setDataValue(item);
					response.addInfo(info);
				}
			}
		}
		List<Bas0001> listDtHosp = bas0001Repository.getPHY8002U00DtHospInfo(hospCode, language);
		if(!CollectionUtils.isEmpty(listDtHosp)) {
			for (Bas0001 item : listDtHosp) {
				PhysModelProto.PHY8002U00DtHospInfo.Builder info = PhysModelProto.PHY8002U00DtHospInfo.newBuilder(); 
				if (!StringUtils.isEmpty(item.getHomepage())) {
					info.setHomepage(item.getHomepage());
				}
				if (!StringUtils.isEmpty(item.getSimpleYoyangName())) {
					info.setSimpleYoyangName(item.getSimpleYoyangName());
				}
				if (!StringUtils.isEmpty(item.getTel())) {
					info.setTel(item.getTel());
				}
				if (!StringUtils.isEmpty(item.getYoyangName())) {
					info.setYoyangName(item.getYoyangName());
				}
				response.addDtInfo(info);
			}
		}
		return response.build();
	}

}