package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cpl.Cplreq1;
import nta.med.data.dao.medi.cpl.Cplreq1Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01IsWriteFileSelectOrUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL3010U01IsWriteFileSelectOrUpdateHandler extends ScreenHandler <CplsServiceProto.CPL3010U01IsWriteFileSelectOrUpdateRequest, SystemServiceProto.UpdateResponse>{
	@Resource
	private Cplreq1Repository cplReq1Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U01IsWriteFileSelectOrUpdateRequest request) {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		try {

			Integer result;
			if (request.getRetVal() != null && request.getRetVal().equals("Y")) {
				result = cplReq1Repository.updateCPL3010U01IsWriteFileSelectOrUpdate(request.getUserId(),
						request.getBunho(), request.getJubsuDate(), request.getJubsuTime(), request.getHangmogCnt(), request.getUrine(), request.getSendYn(), request.getRequestKey());
			} else {
				result = insertCplreq1(request);
			}
			if (result > 0) {
				response.setResult(true);
			} else {
				response.setResult(false);
			}
		} catch (Exception e) {
			response.setResult(false);
			throw new ExecutionException(response.build());
		}

		return response.build();
	}

	public Integer insertCplreq1(CplsServiceProto.CPL3010U01IsWriteFileSelectOrUpdateRequest request){
		try {
			Cplreq1 cplreq1= new Cplreq1();
			cplreq1.setSysDate(new Date());
			cplreq1.setSysId(request.getUserId());
			cplreq1.setUpdDate(new Date());
			cplreq1.setUpdId(request.getUserId());
			cplreq1.setRequestKey(request.getRequestKey());
			cplreq1.setRequestDate(new Date());
			cplreq1.setRequestId(request.getUserId());
			cplreq1.setBunho(request.getBunho());
			cplreq1.setJubsuDate(request.getJubsuDate());
			cplreq1.setJubsuTime(request.getJubsuTime());
			cplreq1.setHangmogCnt(request.getHangmogCnt());
			cplreq1.setUrine(request.getUrine());
			cplreq1.setSendYn(request.getSendYn());
			cplreq1.setCurSendYn(request.getSendYn());
			cplReq1Repository.save(cplreq1);
			return 1;
		} catch (Exception e) {
			throw new ExecutionException(e.getMessage(),e);
		}
	}
}
