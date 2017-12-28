package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inp.Inp1008;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1008Repository;
import nta.med.service.ihis.proto.InpsModelProto.INPORDERTRANSSetProcessGongbiInfo;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSetProcessGongbiRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class INPORDERTRANSSetProcessGongbiHandler extends ScreenHandler<InpsServiceProto.INPORDERTRANSSetProcessGongbiRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Inp1008Repository inp1008Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSSetProcessGongbiRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1002 = request.getPkinp1002();
		List<String> ifExist = inp1008Repository.getYByPkinp1002(hospCode, fkinp1002);
		if(!CollectionUtils.isEmpty(ifExist)){
			Integer result = inp1008Repository.deleteInp1008ByPkout1001(hospCode, fkinp1002);
			if(result < 0){
				response.setMsg("Not found item on INP1008");
				response.setResult(false);
				throw new ExecutionException(response.build());
			}
		}
		if(!CollectionUtils.isEmpty(request.getInsertListList())){
			for(INPORDERTRANSSetProcessGongbiInfo item : request.getInsertListList()){
				insertInp1008(hospCode, request.getBunho(), fkinp1002, request.getSysId(), item);
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	public void insertInp1008(String hospCode, String bunho, String fkinp1002, String userId, INPORDERTRANSSetProcessGongbiInfo info){
		Inp1008 inp1008 = new Inp1008();
		Double priority = CommonUtils.parseDouble(info.getPriority());
		inp1008.setSysDate(new Date());
		inp1008.setUpdDate(new Date());
		inp1008.setSysId(userId);
		inp1008.setUpdId(userId);
		inp1008.setHospCode(hospCode);
		inp1008.setFkinp1002(fkinp1002);
		inp1008.setGongbiCode(info.getGongbiCode());
		inp1008.setPriority(priority);
		inp1008Repository.save(inp1008);
	}

}
