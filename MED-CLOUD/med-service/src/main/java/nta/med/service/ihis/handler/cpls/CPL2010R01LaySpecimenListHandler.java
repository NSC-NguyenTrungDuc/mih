package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.model.ihis.cpls.CPL2010R01LaySpecimenListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R01LaySpecimenListRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010R01LaySpecimenListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL2010R01LaySpecimenListHandler extends ScreenHandler<CplsServiceProto.CPL2010R01LaySpecimenListRequest, CplsServiceProto.CPL2010R01LaySpecimenListResponse> {                     
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public CPL2010R01LaySpecimenListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
		CPL2010R01LaySpecimenListRequest request) throws Exception {                                                                   
	   	CplsServiceProto.CPL2010R01LaySpecimenListResponse.Builder response = CplsServiceProto.CPL2010R01LaySpecimenListResponse.newBuilder();                      
		List<CPL2010R01LaySpecimenListItemInfo> listLaySpecimen = cpl2010Repository.getCPL2010R01LaySpecimenListItemInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getHoDong(), request.getReserDate());
	 	if(!CollectionUtils.isEmpty(listLaySpecimen)) {
        	for(CPL2010R01LaySpecimenListItemInfo item : listLaySpecimen) {
        		CplsModelProto.CPL2010R01LaySpecimenListItemInfo.Builder info = CplsModelProto.CPL2010R01LaySpecimenListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addLaySpecimenList(info);
        	}
	 	}
		return response.build(); 	
	}
}