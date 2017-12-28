package nta.med.service.ihis.handler.cpls;

import java.math.BigInteger;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00GrdPaCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdPaListRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdPaListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL2010U00GrdPaListHandler extends ScreenHandler<CplsServiceProto.CPL2010U00GrdPaListRequest, CplsServiceProto.CPL2010U00GrdPaListResponse>{
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL2010U00GrdPaListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL2010U00GrdPaListRequest request)
			throws Exception  {
		 CplsServiceProto.CPL2010U00GrdPaListResponse.Builder response=CplsServiceProto.CPL2010U00GrdPaListResponse.newBuilder();
		 String hospCode = getHospitalCode(vertx, sessionId);
		 String language = getLanguage(vertx, sessionId);
		 if(request.getRbxJubsuChecked()){
			 List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> listGrdPa= cpl2010Repository.getCplsCPL2010U00GrdPaCPL2010ListItemInfo(hospCode,language,
					 request.getFromDate(),request.getToDate(),request.getBunho());
			 if(!CollectionUtils.isEmpty(listGrdPa)){
				 for(CplsCPL2010U00GrdPaCPL2010ListItemInfo item : listGrdPa){
					 CplsModelProto.CPL2010U00GrdPaListItemInfo.Builder info= CplsModelProto.CPL2010U00GrdPaListItemInfo.newBuilder();
					 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					 if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
	        			info.setTrialYn("Y");
	        		 } else {
	        			info.setTrialYn("N");
	        		 }
					 response.addGrdPalistList(info);
				 }
			 }
		 }else{
			 List<CplsCPL2010U00GrdPaCPL2010ListItemInfo> listGrdPa1= cpl2010Repository.getCplsCPL2010U00GrdPaCPL2010ListItemInfo2(hospCode,language,
					 request.getFromDate(),request.getToDate(),request.getBunho());
			 if(!CollectionUtils.isEmpty(listGrdPa1)){
				 for(CplsCPL2010U00GrdPaCPL2010ListItemInfo item :listGrdPa1){
					 CplsModelProto.CPL2010U00GrdPaListItemInfo.Builder info= CplsModelProto.CPL2010U00GrdPaListItemInfo.newBuilder();
					 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					 if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
	        			info.setTrialYn("Y");
	        		 } else {
	        			info.setTrialYn("N");
	        		 }
					 response.addGrdPalistList(info);
				 }
			 }
		 }
		 return response.build();
	}
}
