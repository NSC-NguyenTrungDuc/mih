package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9991;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9991Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdSusikMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdSusikMasterResponse;

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
public class BAS0310P01GrdSusikMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdSusikMasterRequest, BassServiceProto.BAS0310P01GrdSusikMasterResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(BAS0310P01GrdSusikMasterHandler.class);                                    
	@Resource                                                                                                       
	private Adm9991Repository adm9991Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdSusikMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdSusikMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdSusikMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdSusikMasterResponse.newBuilder();
		Page<Adm9991> listResult = adm9991Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9991 item : listResult){
				BassModelProto.BAS0310P01GrdSusikMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdSusikMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}