package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9997;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9997Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdGenDrgMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdGenDrgMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class BAS0310P01GrdGenDrgMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdGenDrgMasterRequest, BassServiceProto.BAS0310P01GrdGenDrgMasterResponse> {                    
	@Resource                                                                                                       
	private Adm9997Repository adm9997Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdGenDrgMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdGenDrgMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdGenDrgMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdGenDrgMasterResponse.newBuilder();
		Page<Adm9997> listResult = adm9997Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9997 info : listResult){
				BassModelProto.BAS0310P01GrdGenDrgMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdGenDrgMasterInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}  
}
