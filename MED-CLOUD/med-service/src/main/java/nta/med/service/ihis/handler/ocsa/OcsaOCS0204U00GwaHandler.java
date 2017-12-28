package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00GwaRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsaOCS0204U00GwaResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsaOCS0204U00GwaHandler
	extends ScreenHandler<OcsaServiceProto.OcsaOCS0204U00GwaRequest, OcsaServiceProto.OcsaOCS0204U00GwaResponse> {                     
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    
	                                                                                                                
	@Override              
	@Transactional(readOnly = true)
	public OcsaOCS0204U00GwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OcsaOCS0204U00GwaRequest request)
			throws Exception {                                                                                                 
   	OcsaServiceProto.OcsaOCS0204U00GwaResponse.Builder response = OcsaServiceProto.OcsaOCS0204U00GwaResponse.newBuilder();
   	String hospCode = getHospitalCode(vertx, sessionId);
   	String language = getLanguage(vertx, sessionId);
	//1 LoadColumnCodeNameInfo 
	CommonModelProto.LoadColumnCodeNameInfo loadCodeNameinfo=request.getRequestValue();
	if(loadCodeNameinfo != null){
		String codeName =OrderBizHelper.getLoadColumnCodeName(hospCode, language,loadCodeNameinfo);
		if(!StringUtils.isEmpty(codeName)){
			response.setColumnCodeName(codeName);
		}
	}
	//2 ComboListItemInfo 
	 List<ComboListItemInfo> listOcsaComboListItemInfo = bas0260Repository.getComboListItemOcsaOCS0204U00CommonData(hospCode, language, request.getSabun());
        if (listOcsaComboListItemInfo != null && !listOcsaComboListItemInfo.isEmpty()) {
            for (ComboListItemInfo item : listOcsaComboListItemInfo) {
            	CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboList(info);
            }
        }
        return response.build();
	}

}