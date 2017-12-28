package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.data.model.ihis.bass.BAS0110U00GrdJohapListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00GrdJohapRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00GrdJohapResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00GrdJohapHandler extends ScreenHandler<BassServiceProto.BAS0110U00GrdJohapRequest,BassServiceProto.BAS0110U00GrdJohapResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00GrdJohapHandler.class);                                        
	@Resource                                                                                                       
	private Bas0110Repository bas0110Repository; 
	
	@Override
	public boolean isValid(BassServiceProto.BAS0110U00GrdJohapRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public BAS0110U00GrdJohapResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0110U00GrdJohapRequest request)
			throws Exception {                                                                   
  	   	BassServiceProto.BAS0110U00GrdJohapResponse.Builder response = BassServiceProto.BAS0110U00GrdJohapResponse.newBuilder();                      
		List<BAS0110U00GrdJohapListItemInfo> listJohap = bas0110Repository.getBAS0110U00GrdJohapListItem(request.getJohapGubun(), request.getJohap(), request.getStartDate(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listJohap)){
			for(BAS0110U00GrdJohapListItemInfo item : listJohap){
				BassModelProto.BAS0110U00GrdJohapListItemInfo.Builder info = BassModelProto.BAS0110U00GrdJohapListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListGrdJohap(info);
			}
		}
		return response.build();
	}                                                                                                                 
}