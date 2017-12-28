package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00grdMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U00grdMasterResponse;

@Service
@Scope("prototype")
public class BAS0101U00grdMasterHandler extends ScreenHandler<BassServiceProto.BAS0101U00grdMasterRequest, BassServiceProto.BAS0101U00grdMasterResponse>{
	private static final Log LOGGER = LogFactory.getLog(BAS0101U00grdMasterHandler.class);
	
	@Resource
	private Bas0101Repository bas0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BAS0101U00grdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0101U00grdMasterRequest request)
			throws Exception {
		
		LOGGER.info("[START] BAS0101U00grdMasterHandler");
        
		BassServiceProto.BAS0101U00grdMasterResponse.Builder response=BassServiceProto.BAS0101U00grdMasterResponse.newBuilder();
		List<ComboListItemInfo> listGrdMaster = bas0101Repository.listGrdMaster(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
		
		if(listGrdMaster != null && !listGrdMaster.isEmpty()){
			for(ComboListItemInfo item : listGrdMaster){
				BassModelProto.BAS0101U00GrdMasterItemInfo.Builder info = BassModelProto.BAS0101U00GrdMasterItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())){
					info.setCodeType(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())){
					info.setCodeTypeName(item.getCodeName());
				}
				response.addGrdMaster(info);
			}	
		}
		
		return response.build();
	}

}
