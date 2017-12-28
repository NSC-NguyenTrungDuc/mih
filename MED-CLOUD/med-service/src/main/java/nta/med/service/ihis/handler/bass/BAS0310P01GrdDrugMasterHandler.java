package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9992;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9992Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdDrugMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdDrugMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class BAS0310P01GrdDrugMasterHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdDrugMasterRequest, BassServiceProto.BAS0310P01GrdDrugMasterResponse> {                    
	@Resource                                                                                                       
	private Adm9992Repository adm9992Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdDrugMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdDrugMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdDrugMasterResponse.Builder response = BassServiceProto.BAS0310P01GrdDrugMasterResponse.newBuilder();
		Page<Adm9992> listResult = adm9992Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9992 info : listResult){
				BassModelProto.BAS0310P01GrdDrugMasterInfo.Builder builder = BassModelProto.BAS0310P01GrdDrugMasterInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}     
}
