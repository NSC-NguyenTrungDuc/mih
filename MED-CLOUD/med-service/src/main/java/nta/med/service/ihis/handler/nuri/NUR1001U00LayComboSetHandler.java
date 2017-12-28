package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.nuri.NUR1001U00LayComboSetInfo;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00LayComboSetHandler extends ScreenHandler<NuriServiceProto.NUR1001U00LayComboSetRequest, NuriServiceProto.NUR1001U00LayComboSetResponse> {
	
	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00LayComboSetResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00LayComboSetRequest request) throws Exception {
				
		NuriServiceProto.NUR1001U00LayComboSetResponse.Builder response = NuriServiceProto.NUR1001U00LayComboSetResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1001U00LayComboSetInfo> result = nur0102Repository.getNUR1001U00LayComboSetInfo(hospCode, language);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001U00LayComboSetInfo item : result){
				NuriModelProto.NUR1001U00LayComboSetInfo.Builder info = NuriModelProto.NUR1001U00LayComboSetInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addCboList(info);
			}
		}
		
		return response.build();
	}
}