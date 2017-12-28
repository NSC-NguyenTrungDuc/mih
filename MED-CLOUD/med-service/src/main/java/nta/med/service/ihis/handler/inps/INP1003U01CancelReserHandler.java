package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class INP1003U01CancelReserHandler extends ScreenHandler<InpsServiceProto.INP1003U01CancelReserRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, InpsServiceProto.INP1003U01CancelReserRequest request){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try{
			String hospCode = getHospitalCode(vertx, sessionId);
			response.setResult(updateINP1003U01CancelReser(request, hospCode));
		}
		catch (Exception e)
		{
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	
	public boolean updateINP1003U01CancelReser(InpsServiceProto.INP1003U01CancelReserRequest request, String hospCode){
		try {
			boolean updateResult = false;
			if(request.getIpwonsiOrderYn().equals("Y")){
				if(inp1003Repository.updateINP1003U01CancelReser(hospCode, CommonUtils.parseDouble(request.getPkinp1003()), "Y") >0)
					updateResult = true;
			}else if(request.getIpwonsiOrderYn().equals("N")){
				if(inp1003Repository.updateINP1003U01CancelReser(hospCode, CommonUtils.parseDouble(request.getPkinp1003()), "N") >0)
					updateResult = true;
			}
			return updateResult;
		} catch (Exception e) {
			throw new ExecutionException();
		}
	}

}
