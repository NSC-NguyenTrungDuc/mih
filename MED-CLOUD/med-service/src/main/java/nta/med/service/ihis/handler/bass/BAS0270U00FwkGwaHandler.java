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

import nta.med.core.domain.bas.Bas0260;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00FwkGwaRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00FwkGwaResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")
public class BAS0270U00FwkGwaHandler extends ScreenHandler<BassServiceProto.BAS0270U00FwkGwaRequest, BassServiceProto.BAS0270U00FwkGwaResponse> {                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00FwkGwaHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00FwkGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0270U00FwkGwaRequest request)
					throws Exception {
		BassServiceProto.BAS0270U00FwkGwaResponse.Builder response = BassServiceProto.BAS0270U00FwkGwaResponse.newBuilder();
		List<Bas0260> listBas060 = bas0260Repository.getBas0270ComboListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCode() +"%", request.getBuseoYmd(), request.getFind1() + "%");
		
		if(!CollectionUtils.isEmpty(listBas060)) {
			for (Bas0260 item : listBas060) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getGwa())) {
					info.setCode(item.getGwa());
				}
				if(!StringUtils.isEmpty(item.getGwaName())) {
					info.setCodeName(item.getGwaName());
				}
				response.addFwkList(info);
			}
		}

		return response.build();
	}                                                                                                               
}                                                                                                                 
