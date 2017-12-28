package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0210U00grdBAS0210GridColumnChangedHandler extends ScreenHandler<BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedRequest, BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0210U00grdBAS0210GridColumnChangedHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0210U00grdBAS0210GridColumnChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0210U00grdBAS0210GridColumnChangedRequest request)
					throws Exception {
  	   	BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedResponse.Builder response = BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedResponse.newBuilder();                      
		if("johap_gubun".equals(request.getColName())){
			List<ComboListItemInfo> listGridColumnChanged =bas0102Repository.getBAS0210U00grdBAS0210GridColumnChanged(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getCode());
			if(!CollectionUtils.isEmpty(listGridColumnChanged)){
				for(ComboListItemInfo item:listGridColumnChanged){
					BassModelProto.BAS0210U00grdBAS0210GridColumnChangedItemInfo.Builder info= BassModelProto.BAS0210U00grdBAS0210GridColumnChangedItemInfo.newBuilder();
					if (!StringUtils.isEmpty(item.getCode())) {
						info.setCode(item.getCode());
					}
					if (!StringUtils.isEmpty(item.getCodeName())) {
						info.setCodeName(item.getCodeName());
					}
					response.addGridColumnChanged(info);
				}
			}
		}
		return response.build();
	}                                                                                                                 
}