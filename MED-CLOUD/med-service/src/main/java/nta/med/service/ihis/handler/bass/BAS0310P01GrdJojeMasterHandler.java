package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9996;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9996Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310P01GrdJojeMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdJojeMasterRequest, BassServiceProto.BAS0310P01GrdJojeMasterResponse> {                    
	@Resource                                                                                                       
	private Adm9996Repository adm9996Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BassServiceProto.BAS0310P01GrdJojeMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BassServiceProto.BAS0310P01GrdJojeMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdJojeMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdJojeMasterResponse.newBuilder();
		Page<Adm9996> listResult = adm9996Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9996 item : listResult){
				BassModelProto.BAS0310P01GrdJojeMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdJojeMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}