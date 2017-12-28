package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01LaySpecimenInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01LaySpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01LaySpecimenResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01LaySpecimenHandler extends ScreenHandler<CplsServiceProto.CPL3010U01LaySpecimenRequest, CplsServiceProto.CPL3010U01LaySpecimenResponse> {                     
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public CPL3010U01LaySpecimenResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		CPL3010U01LaySpecimenRequest request) throws Exception {                                                                   
  	   	CplsServiceProto.CPL3010U01LaySpecimenResponse.Builder response = CplsServiceProto.CPL3010U01LaySpecimenResponse.newBuilder();                      
  	   	//list listLaySpecimen
		 List<CPL3010U01LaySpecimenInfo> listLaySpecimen= cpl0101Repository.getCPL3010U01LaySpecimenInfoListItemInfo(getHospitalCode(vertx, sessionId),
				 getLanguage(vertx, sessionId),request.getSpecimenSer());
		 if(!CollectionUtils.isEmpty(listLaySpecimen)){
			 for(CPL3010U01LaySpecimenInfo item:listLaySpecimen){
				CplsModelProto.CPL3010U01LaySpecimenInfo.Builder info= CplsModelProto.CPL3010U01LaySpecimenInfo.newBuilder();
			    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLaySpecimenLst(info);
			 }
		 }
		 return response.build();
	}
}