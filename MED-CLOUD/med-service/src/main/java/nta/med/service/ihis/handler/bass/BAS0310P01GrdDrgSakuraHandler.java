package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9982;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9982Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdDrgSakuraRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdDrgSakuraResponse;

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
public class BAS0310P01GrdDrgSakuraHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdDrgSakuraRequest, BassServiceProto.BAS0310P01GrdDrgSakuraResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(BAS0310P01GrdDrgSakuraHandler.class);                                    
	@Resource                                                                                                       
	private Adm9982Repository adm9982Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdDrgSakuraResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdDrgSakuraRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdDrgSakuraResponse.Builder response = BassServiceProto.BAS0310P01GrdDrgSakuraResponse.newBuilder();
		Page<Adm9982> listResult = adm9982Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9982 info : listResult){
				BassModelProto.BAS0310P01GrdDrgSakuraInfo.Builder builder = BassModelProto.BAS0310P01GrdDrgSakuraInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}