package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL3020U02PrCplResultMatchProcInfo;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02PrCplResultMatchProcRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL3020U02PrCplResultMatchProcHandler extends ScreenHandler<CPL3020U02PrCplResultMatchProcRequest, UpdateResponse>{
	
	@Resource
	private Cpl3020Repository cpl3020Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U02PrCplResultMatchProcRequest request) throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		
		List<CPL3020U02PrCplResultMatchProcInfo> list = request.getInfoListList();
		if(!CollectionUtils.isEmpty(list)){
			for(CPL3020U02PrCplResultMatchProcInfo item : list){
				String result = cpl3020Repository.callPrCplResultMatchProc(item.getProcGubun() , getHospitalCode(vertx, sessionId), item.getSpecimenSer(), item.getHangmogCode(),
						item.getResultVal(), item.getJangbiCode(), item.getResultDate(), item.getSampleId(), item.getResultCode(), "");
				if(!StringUtils.isEmpty(result)){
					response.setResult(true);
				}else{
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
		}
		return response.build();
	}

}
