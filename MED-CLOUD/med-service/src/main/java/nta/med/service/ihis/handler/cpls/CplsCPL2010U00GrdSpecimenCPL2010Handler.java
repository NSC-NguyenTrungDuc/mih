package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdSpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdSpecimenResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CplsCPL2010U00GrdSpecimenCPL2010Handler extends ScreenHandler<CplsServiceProto.CPL2010U00GrdSpecimenRequest, CplsServiceProto.CPL2010U00GrdSpecimenResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00GrdSpecimenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010U00GrdSpecimenRequest request) throws Exception {
    		 CplsServiceProto.CPL2010U00GrdSpecimenResponse.Builder response=CplsServiceProto.CPL2010U00GrdSpecimenResponse.newBuilder();
    		 String hospCode = getHospitalCode(vertx, sessionId);
    	 String language = getLanguage(vertx, sessionId);
    		 
		 if(request.getMJubsuYn().equals("2")){
			 List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> listGrdSpecimen=cpl2010Repository.getCPL2010U00GrdSpecimenListItemInfo(hospCode,language,DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), 
					request.getBunho(),request.getGwa() ,request.getOrderTime() ,request.getDoctor(),DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD),
					DateUtil.toDate( request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) ,request.getJubsuTime() ,request.getJubsuja() ,CommonUtils.parseDouble(request.getGroupSer()) ,request.getReserYn(),request.getEmergencyYn());
			 if(listGrdSpecimen !=null && !listGrdSpecimen.isEmpty()){
				 for(CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo item :listGrdSpecimen){
					 CplsModelProto.CPL2010U00GrdSpecimenListItemInfo.Builder info= CplsModelProto.CPL2010U00GrdSpecimenListItemInfo.newBuilder();
					 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					 response.addGrdSpecimenList(info);
	
				 }
			 }
		 }else{
			 List<CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo> listGrdSpecimen2=cpl2010Repository.getCPL2010U00GrdSpecimenListItemInfo2(hospCode,language,DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),CommonUtils.parseDouble(request.getGroupSer()),request.getBunho(),
					 request.getGwa(),request.getOrderTime(),request.getDoctor(), DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) , request.getJubsuTime(),request.getJubsuja(),request.getReserYn(),DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) ,request.getEmergencyYn());
			 if(listGrdSpecimen2 !=null && !listGrdSpecimen2.isEmpty()){
				 for(CplsCPL2010U00GrdSpecimenCPL2010ListItemInfo item :listGrdSpecimen2){
					 CplsModelProto.CPL2010U00GrdSpecimenListItemInfo.Builder info= CplsModelProto.CPL2010U00GrdSpecimenListItemInfo.newBuilder();
					 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					 response.addGrdSpecimenList(info);
				 }
			 }
		 }
		 return response.build();
	}
}
