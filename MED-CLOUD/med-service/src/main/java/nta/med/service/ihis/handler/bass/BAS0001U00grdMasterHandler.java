package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00grdMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00grdMasterResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")
public class BAS0001U00grdMasterHandler extends ScreenHandler<BassServiceProto.BAS0001U00grdMasterRequest, BassServiceProto.BAS0001U00grdMasterResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0001U00grdMasterHandler.class);                                        
	@Resource                                                                                                       
	private Bas0101Repository bas0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0001U00grdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0001U00grdMasterRequest request)
			throws Exception{                                                                   
  	   	BassServiceProto.BAS0001U00grdMasterResponse.Builder response = BassServiceProto.BAS0001U00grdMasterResponse.newBuilder();                      
		List<ComboListItemInfo> listGrdMaster = bas0101Repository.getListBAS0001U00grdMaster(request.getHospCode(), getLanguage(vertx, sessionId), request.getCodeType()); 
		if(!CollectionUtils.isEmpty(listGrdMaster)){	
			for(ComboListItemInfo item :listGrdMaster){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMaster(info);
			}
		}
        return response.build();   
	}                                                                                                                                                   

}