package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00LayBarcodeTemp2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00LayBarcodeTemp2Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010U00LayBarcodeTemp2Handler extends ScreenHandler<CplsServiceProto.CPL2010U00LayBarcodeTemp2Request, CplsServiceProto.CPL2010U00LayBarcodeTemp2Response> {                     
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public CPL2010U00LayBarcodeTemp2Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL2010U00LayBarcodeTemp2Request request) throws Exception {                                                                   
  	   	CplsServiceProto.CPL2010U00LayBarcodeTemp2Response.Builder response = CplsServiceProto.CPL2010U00LayBarcodeTemp2Response.newBuilder();                      
		 //list lay bar code 2
		 List<CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo> listLayBarcode2=cpl2010Repository.getCplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo2(getHospitalCode(vertx, sessionId),
				 getLanguage(vertx, sessionId),request.getSpecimentSer());
		 if(listLayBarcode2 !=null && !listLayBarcode2.isEmpty()){
			 for(CplsCPL2010U00LayBarcodeTempCPL2010ListItemInfo item:listLayBarcode2){
				 CplsModelProto.CPL2010U00LayBarcodeTempListItemInfo.Builder info= CplsModelProto.CPL2010U00LayBarcodeTempListItemInfo.newBuilder();
				    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addLayList(info);
			 }
		 }
		 return response.build();
	}
}