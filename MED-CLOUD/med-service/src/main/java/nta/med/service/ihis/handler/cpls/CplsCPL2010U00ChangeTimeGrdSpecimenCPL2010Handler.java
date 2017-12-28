package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00ChangeTimeGrdSpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00ChangeTimeGrdSpecimenResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00ChangeTimeGrdSpecimenCPL2010Handler extends ScreenHandler<CPL2010U00ChangeTimeGrdSpecimenRequest, CPL2010U00ChangeTimeGrdSpecimenResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00ChangeTimeGrdSpecimenResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00ChangeTimeGrdSpecimenRequest request) throws Exception {
		 CplsServiceProto.CPL2010U00ChangeTimeGrdSpecimenResponse.Builder response=CplsServiceProto.CPL2010U00ChangeTimeGrdSpecimenResponse.newBuilder();
		 List<CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo> listChangeTimeGrd=cpl2010Repository.getCPL2010U00ChangeTimeGrdSpecimenListItemInfo(
				 getHospitalCode(vertx, sessionId),request.getOrderDate(), 
					request.getBunho(),request.getGwa() ,request.getGubun(),request.getDoctor() ,request.getInOutGubun(), getLanguage(vertx, sessionId));
		 if(!CollectionUtils.isEmpty(listChangeTimeGrd)){
			 for(CplCPL2010U00ChangeTimeGrdSpecimenCPL2010ListItemInfo item : listChangeTimeGrd){
				 CplsModelProto.CPL2010U00ChangeTimeGrdSpecimenListItemInfo.Builder info=CplsModelProto.CPL2010U00ChangeTimeGrdSpecimenListItemInfo.newBuilder();
				 	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdSpecimenList(info);
			 }
		 }
		 return response.build();
	}
}
