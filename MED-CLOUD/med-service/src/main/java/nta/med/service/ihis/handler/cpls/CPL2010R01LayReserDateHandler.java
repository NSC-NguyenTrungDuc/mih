package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R01LayReserDateRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R01LayReserDateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010R01LayReserDateHandler extends ScreenHandler<CplsServiceProto.CPL2010R01LayReserDateRequest, CplsServiceProto.CPL2010R01LayReserDateResponse> {                     
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override               
	@Transactional(readOnly = true)
	public CPL2010R01LayReserDateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL2010R01LayReserDateRequest request) throws Exception {                                                                   
	   	CplsServiceProto.CPL2010R01LayReserDateResponse.Builder response = CplsServiceProto.CPL2010R01LayReserDateResponse.newBuilder();                      
		List<String> listReserDate = cpl2010Repository.getCPL2010R01InitializeReserDateList(getHospitalCode(vertx, sessionId), request.getHoDong(), request.getFromDate(), request.getToDate());
		if(!CollectionUtils.isEmpty(listReserDate)) {
	    	for(String item : listReserDate) {
	    		if (!StringUtils.isEmpty(item)) {
	    			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
	    			info.setDataValue(item);
	    			response.addLayList(info);
	    		}
	
	    	}
	    }
		return response.build();
	}
}