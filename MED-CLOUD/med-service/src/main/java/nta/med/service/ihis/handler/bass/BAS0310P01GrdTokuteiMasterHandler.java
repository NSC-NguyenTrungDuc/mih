package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9993;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9993Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdTokuteiMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdTokuteiMasterResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310P01GrdTokuteiMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdTokuteiMasterRequest, BassServiceProto.BAS0310P01GrdTokuteiMasterResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(BAS0310P01GrdTokuteiMasterHandler.class);                                    
	@Resource                                                                                                       
	private Adm9993Repository adm9993Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdTokuteiMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdTokuteiMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdTokuteiMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdTokuteiMasterResponse.newBuilder();
		Page<Adm9993> listResult = adm9993Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9993 info : listResult){
				BassModelProto.BAS0310P01GrdTokuteiMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdTokuteiMasterInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}