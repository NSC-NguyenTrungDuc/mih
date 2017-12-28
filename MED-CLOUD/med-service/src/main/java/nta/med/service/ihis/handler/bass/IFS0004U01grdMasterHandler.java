package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs0004Repository;
import nta.med.data.model.ihis.bass.IFS0004U01grdMasterListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0004U01grdMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0004U01grdMasterResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0004U01grdMasterHandler extends ScreenHandler<BassServiceProto.IFS0004U01grdMasterRequest, BassServiceProto.IFS0004U01grdMasterResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0004U01grdMasterHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0004Repository ifs0004Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public IFS0004U01grdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, IFS0004U01grdMasterRequest request)
					throws Exception {
  	   	BassServiceProto.IFS0004U01grdMasterResponse.Builder response = BassServiceProto.IFS0004U01grdMasterResponse.newBuilder();                      
		List<IFS0004U01grdMasterListItemInfo> list = ifs0004Repository.getIfs0004U01grdMasterListItem(getHospitalCode(vertx, sessionId), request.getNuGubun(),
				request.getNuYmd());
		if(!CollectionUtils.isEmpty(list)){
			for(IFS0004U01grdMasterListItemInfo item : list){
				BassModelProto.IFS0004U01grdMasterListItemInfo.Builder info = BassModelProto.IFS0004U01grdMasterListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}                                                                                                            
}