package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9998;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9998Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdGenDrgMapRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdGenDrgMapResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class BAS0310P01GrdGenDrgMapHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdGenDrgMapRequest, BassServiceProto.BAS0310P01GrdGenDrgMapResponse> {                    
	@Resource                                                                                                       
	private Adm9998Repository adm9998Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdGenDrgMapResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdGenDrgMapRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdGenDrgMapResponse.Builder response = BassServiceProto.BAS0310P01GrdGenDrgMapResponse.newBuilder();
		Page<Adm9998> listResult = adm9998Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9998 info : listResult){
				BassModelProto.BAS0310P01GrdGenDrgMapInfo.Builder builder = BassModelProto.BAS0310P01GrdGenDrgMapInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}  

}
