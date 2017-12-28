package nta.med.service.ihis.handler.cpls;
import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ExecuteUpdateConfirmYNRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00ExecuteUpdateConfirmYNHandler extends ScreenHandler<CplsServiceProto.CPL3020U00ExecuteUpdateConfirmYNRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl3020Repository cpl3020Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U00ExecuteUpdateConfirmYNRequest request){

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try{
			String hospCode = getHospitalCode(vertx, sessionId);
			response.setResult(updateCPL3020ConfirmYN(request, hospCode));
		}
		catch (Exception e)
		{
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		return response.build();

	}

	public boolean updateCPL3020ConfirmYN(CplsServiceProto.CPL3020U00ExecuteUpdateConfirmYNRequest request, String hospCode){
		try {
			boolean updateResult = false;
			if(request.getConfirmYn().equals("Y")){
				if(cpl3020Repository.updateCPL3020U00Cpl3020ConfirmYN(request.getUserId(),"Y", new Date(), request.getGumsaja(), 
						hospCode,CommonUtils.parseDouble(request.getPkcpl3020()))>0)
				updateResult = true;
			}else if(request.getConfirmYn().equals("N")){
				if(cpl3020Repository.updateCPL3020U00Cpl3020ConfirmYN(request.getUserId(),"N", null, null, 
						hospCode,CommonUtils.parseDouble(request.getPkcpl3020()))>0)
				updateResult = true;
			}
			return updateResult;
		} catch (Exception e) {
			throw new ExecutionException();
		}
	}
}
