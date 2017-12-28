package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs0005Repository;
import nta.med.data.model.ihis.bass.IFS0004U01grdDetailtListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0004U01grdDetailtRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0004U01grdDetailtResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0004U01grdDetailtHandler extends ScreenHandler<BassServiceProto.IFS0004U01grdDetailtRequest, BassServiceProto.IFS0004U01grdDetailtResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0004U01grdDetailtHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0005Repository ifs0005Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public IFS0004U01grdDetailtResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0004U01grdDetailtRequest request) throws Exception {
  	   	BassServiceProto.IFS0004U01grdDetailtResponse.Builder response = BassServiceProto.IFS0004U01grdDetailtResponse.newBuilder();                      
		List<IFS0004U01grdDetailtListItemInfo> list = ifs0005Repository.getIfs0004U01grdDetailtListItem(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getCurYmd(), request.getNuGubun(), request.getNuCode(), request.getNuYmd());
		if(!CollectionUtils.isEmpty(list)){
			for(IFS0004U01grdDetailtListItemInfo item : list){
				BassModelProto.IFS0004U01grdDetailtListItemInfo.Builder info = BassModelProto.IFS0004U01grdDetailtListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}                                                                                                            
}