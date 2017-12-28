package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9990;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9990Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdSangMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdSangMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310P01GrdSangMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdSangMasterRequest, BassServiceProto.BAS0310P01GrdSangMasterResponse> {                    
	@Resource                                                                                                       
	private Adm9990Repository adm9990Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdSangMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdSangMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdSangMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdSangMasterResponse.newBuilder();
		Page<Adm9990> listResult = adm9990Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9990 item : listResult){
				BassModelProto.BAS0310P01GrdSangMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdSangMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}