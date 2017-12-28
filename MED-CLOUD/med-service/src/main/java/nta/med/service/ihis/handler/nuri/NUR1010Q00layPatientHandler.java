package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1010Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00layPatientInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00layPatientHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00layPatientRequest, NuriServiceProto.NUR1010Q00layPatientResponse> {   
	
	@Resource                                   
	private Nur1010Repository nur1010Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00layPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00layPatientRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00layPatientResponse.Builder response = NuriServiceProto.NUR1010Q00layPatientResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1010Q00layPatientInfo> result = nur1010Repository.getNUR1010Q00layPatientInfo(hospCode, language, request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00layPatientInfo item : result){
				NuriModelProto.NUR1010Q00layPatientInfo.Builder info = NuriModelProto.NUR1010Q00layPatientInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				
				if (item.getPkinp1001() != null) {
					info.setPkinp1001(String.format("%.0f",item.getPkinp1001()));
				}
				
				response.addLayPatient(info);
			}
		}
		
		return response.build();
	}
}
