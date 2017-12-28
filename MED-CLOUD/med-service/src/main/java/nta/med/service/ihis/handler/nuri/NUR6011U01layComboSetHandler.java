package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.system.TripleListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01layComboSetHandler extends ScreenHandler<NuriServiceProto.NUR6011U01layComboSetRequest, NuriServiceProto.NUR6011U01layComboSetResponse>{
	
	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01layComboSetResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01layComboSetRequest request) throws Exception {
		
		NuriServiceProto.NUR6011U01layComboSetResponse.Builder response = NuriServiceProto.NUR6011U01layComboSetResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<TripleListItemInfo> result = nur0102Repository.getNUR6011U01layComboSet(hospCode, language, request.getCodeType());
		
		if(!CollectionUtils.isEmpty(result)){
			for(TripleListItemInfo item : result){
				CommonModelProto.TripleListItemInfo.Builder info = CommonModelProto.TripleListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
