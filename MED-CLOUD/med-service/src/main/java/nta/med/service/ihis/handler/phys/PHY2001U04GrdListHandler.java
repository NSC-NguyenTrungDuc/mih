package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04GrdListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdListRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04GrdListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04GrdListHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04GrdListRequest, PhysServiceProto.PHY2001U04GrdListResponse> {                     
	@Resource                                                                                                       
	private Inj1001Repository inj1001Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly=true)
	public PHY2001U04GrdListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY2001U04GrdListRequest request)
			throws Exception {                                                                  
  	   	PhysServiceProto.PHY2001U04GrdListResponse.Builder response = PhysServiceProto.PHY2001U04GrdListResponse.newBuilder();                      
    	Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
		List<PHY2001U04GrdListInfo> listGrd = inj1001Repository.getPHY2001U04GrdListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getBunho(), request.getStatFlg(), naewonDate, request.getGwa(), request.getDoctor(), request.getGubun());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(PHY2001U04GrdListInfo item : listGrd){
				PhysModelProto.PHY2001U04GrdListInfo.Builder info = PhysModelProto.PHY2001U04GrdListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdListItem(info);
			}
		}
		return response.build();
	}

}