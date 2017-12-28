package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdTubeCPL2010ListItemInfo;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdTubeCPL2010ListItemInfo2;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdTubeQueryStartingRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdTubeQueryStartingResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00GrdTubeQueryStartingCPL2010Handler extends ScreenHandler <CplsServiceProto.CPL2010U00GrdTubeQueryStartingRequest, CplsServiceProto.CPL2010U00GrdTubeQueryStartingResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00GrdTubeQueryStartingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00GrdTubeQueryStartingRequest request) throws Exception {
		 CplsServiceProto.CPL2010U00GrdTubeQueryStartingResponse.Builder response=CplsServiceProto.CPL2010U00GrdTubeQueryStartingResponse.newBuilder();
		 String hospCode = getHospitalCode(vertx, sessionId);
		 String language = getLanguage(vertx, sessionId);
		 if(request.getRbxJubsuChecked()){
			 List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo> listGrdTube=cpl2010Repository.getCPL2010U00GrdTubeQueryStarting(hospCode,language,
					request.getOrderDate(),request.getOrderTime() ,request.getBunho());
			 if(listGrdTube !=null && !listGrdTube.isEmpty()){
				 for(CplsCPL2010U00GrdTubeCPL2010ListItemInfo item:listGrdTube){
					CplsModelProto.CPL2010U00GrdTubeListItemInfo.Builder info=CplsModelProto.CPL2010U00GrdTubeListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdTubeList(info);
				 }
			 }
		 }else{
			 List<CplsCPL2010U00GrdTubeCPL2010ListItemInfo2> listGrdTube2=cpl2010Repository.getCPL2010U00GrdTubeQueryStarting2(hospCode,language,
						request.getOrderDate(),request.getOrderTime() ,request.getBunho());
				 if(listGrdTube2 !=null && !listGrdTube2.isEmpty()){
					 for(CplsCPL2010U00GrdTubeCPL2010ListItemInfo2 item : listGrdTube2){
						CplsModelProto.CPL2010U00GrdTubeListItemInfo.Builder info=CplsModelProto.CPL2010U00GrdTubeListItemInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addGrdTubeList(info);
					 }
				 }
		 }
		 return response.build();
	}
}
