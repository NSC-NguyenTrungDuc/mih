package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto.NUR2016U02DeleteLinkPatientInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02DeleteLinkPatientRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class NUR2016U02DeleteLinkPatientHandler extends ScreenHandler<NuroServiceProto.NUR2016U02DeleteLinkPatientRequest, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(NUR2016U02DeleteLinkPatientHandler.class);
	
	@Resource
	private Out2016Repository out2016Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016U02DeleteLinkPatientRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<NUR2016U02DeleteLinkPatientInfo> listInfo = request.getLinkPatItemList();
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		if(!CollectionUtils.isEmpty(listInfo)){
			for(NUR2016U02DeleteLinkPatientInfo info : listInfo){
				if(out2016Repository.updateOCSACTOcs1003ChangeNurSeRemarkAndUpdId(hospCode, info.getHospCodeLink(), bunho, info.getBunhoLink()) > 0
						&& out2016Repository.updateOCSACTOcs1003ChangeNurSeRemarkAndUpdId(info.getHospCodeLink(), hospCode, info.getBunhoLink(), bunho) > 0){
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
