package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9995;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9995Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdJinryoMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdJinryoMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;
@Service                                                                                                          
@Scope("prototype")
public class BAS0310P01GrdJinryoMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdJinryoMasterRequest, BassServiceProto.BAS0310P01GrdJinryoMasterResponse> {                    
	@Resource                                                                                                       
	private Adm9995Repository adm9995Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdJinryoMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdJinryoMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdJinryoMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdJinryoMasterResponse.newBuilder();
		Page<Adm9995> listResult = adm9995Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9995 info : listResult){
				BassModelProto.BAS0310P01GrdJinryoMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdJinryoMasterInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	} 
}
