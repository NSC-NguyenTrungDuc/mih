package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00PaqryGrdPaRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00PaqryGrdPaResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00PaqryGrdPaCPL2010Handler extends ScreenHandler <CplsServiceProto.CPL2010U00PaqryGrdPaRequest, CplsServiceProto.CPL2010U00PaqryGrdPaResponse>{
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00PaqryGrdPaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00PaqryGrdPaRequest request) throws Exception {
		 CplsServiceProto.CPL2010U00PaqryGrdPaResponse.Builder response=CplsServiceProto.CPL2010U00PaqryGrdPaResponse.newBuilder();
		 String hospCode = getHospitalCode(vertx, sessionId);
		 String language = getLanguage(vertx, sessionId);
		 if(request.getMJubsuYn().equals("Y")){
			 List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> listPaqryGrdPa=cpl2010Repository.getCPL2010U00PaqryGrdPaListItemInfo(hospCode,language,request.getOrderDate(),request.getJubsuYn(),
						request.getBunho(),request.getSuname(),request.getGwaName(),request.getOrderTime());
			 if(listPaqryGrdPa !=null && !listPaqryGrdPa.isEmpty()){
				 for(CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo item : listPaqryGrdPa){
					 CplsModelProto.CPL2010U00PaqryGrdPaListItemInfo.Builder info= CplsModelProto.CPL2010U00PaqryGrdPaListItemInfo.newBuilder();
					 	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addGrdPaList(info);
				 }
			 }
		 }else{
			 List<CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo> listPaqryGrdPa2=cpl2010Repository.getCPL2010U00PaqryGrdPaListItemInfo2(hospCode,language,request.getOrderDate(),request.getJubsuYn(),
						request.getBunho(),request.getSuname(),request.getGwaName(),request.getOrderTime());
			 if(listPaqryGrdPa2 !=null && !listPaqryGrdPa2.isEmpty()){
				 for(CplsCPL2010U00PaqryGrdPaCPL2010ListItemInfo item : listPaqryGrdPa2){
					 CplsModelProto.CPL2010U00PaqryGrdPaListItemInfo.Builder info= CplsModelProto.CPL2010U00PaqryGrdPaListItemInfo.newBuilder();
					    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addGrdPaList(info);
				 }
			 }
		 }
		 return response.build();
	}
}
