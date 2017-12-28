package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00MlayConstantCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00MlayConstantInfoRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00MlayConstantInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00MlayConstantCPL2010Handler extends ScreenHandler <CplsServiceProto.CPL2010U00MlayConstantInfoRequest, CplsServiceProto.CPL2010U00MlayConstantInfoResponse> {
	@Resource
	private Cpl0109Repository cpl0109Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00MlayConstantInfoResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00MlayConstantInfoRequest request) throws Exception {
		 CplsServiceProto.CPL2010U00MlayConstantInfoResponse.Builder response = CplsServiceProto.CPL2010U00MlayConstantInfoResponse.newBuilder();
		 List<CplsCPL2010U00MlayConstantCPL2010ListItemInfo> listConstant = cpl0109Repository.getCPL2010U00MlayConstantInfo(getHospitalCode(vertx, sessionId),
				 getLanguage(vertx, sessionId), request.getCodeType());
		 if(!CollectionUtils.isEmpty(listConstant)){
			 for(CplsCPL2010U00MlayConstantCPL2010ListItemInfo item : listConstant){
				CplsModelProto.CPL2010U00MlayConstantInfoListItemInfo.Builder info = CplsModelProto.CPL2010U00MlayConstantInfoListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addMLayConstantInfoList(info);
			 }
		  }
		 return response.build();
	}
}
