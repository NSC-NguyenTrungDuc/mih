package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisSmoRepository;
import nta.med.data.model.ihis.clis.Clis2015U09ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09GrdRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U09GrdResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class Clis2015U09GrdHandler extends ScreenHandler<CLIS2015U09GrdRequest, CLIS2015U09GrdResponse>{
	@Resource
	private ClisSmoRepository clisSmoRepository;
	
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U09GrdResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CLIS2015U09GrdRequest request)
			throws Exception {
		CLIS2015U09GrdResponse.Builder response = CLIS2015U09GrdResponse.newBuilder();
		List<Clis2015U09ItemInfo> list = clisSmoRepository.getClis2015U09ItemInfo(getHospitalCode(vertx, sessionId), "DODOBUHYEUN_NO",getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(Clis2015U09ItemInfo item : list){
				ClisModelProto.CLIS2015U09ItemInfo.Builder info = ClisModelProto.CLIS2015U09ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDt(info);
			}
		}
		return response.build();
	}

}
