package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00VSVJubsujaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00VSVJubsujaResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3010U00VSVJubsujaHandler extends ScreenHandler <CplsServiceProto.CPL3010U00VSVJubsujaRequest, CplsServiceProto.CPL3010U00VSVJubsujaResponse> {
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3010U00VSVJubsujaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00VSVJubsujaRequest request) throws Exception{
        CplsServiceProto.CPL3010U00VSVJubsujaResponse.Builder response = CplsServiceProto.CPL3010U00VSVJubsujaResponse.newBuilder();
    	List<String> listUserName = adm3200Repository.getUserNameList(getHospitalCode(vertx, sessionId), request.getUserId());
        if(!CollectionUtils.isEmpty(listUserName)) {
        	response.setUserName(listUserName.get(0));
        }
        return response.build();
	}
}
