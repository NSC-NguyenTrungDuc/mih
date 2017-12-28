package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3010U01IsWriteFileSelectCodeValueHandler extends ScreenHandler <CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueRequest,CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueResponse>{
	@Resource
	private Cpl0109Repository cpl0109Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL3010U01IsWriteFileSelectCodeValueResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3010U01IsWriteFileSelectCodeValueRequest request)
			throws Exception  {
		 CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueResponse.Builder response=CplsServiceProto.CPL3010U01IsWriteFileSelectCodeValueResponse.newBuilder();
		 String selectCode=cpl0109Repository.getCPL3020U02SetAutoConfirmChecked(getHospitalCode(vertx, sessionId),getLanguage(vertx, sessionId),"IF","IFPATH");
		 if(!StringUtils.isEmpty(selectCode)){
			 response.setCodeValue(selectCode);
		 }
		 return response.build();
	}
}
