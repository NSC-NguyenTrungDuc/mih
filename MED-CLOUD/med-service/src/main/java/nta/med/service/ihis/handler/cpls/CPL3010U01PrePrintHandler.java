package nta.med.service.ihis.handler.cpls;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.model.ihis.cpls.CPL3010U01PrePrintInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01PrePrintRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U01PrePrintResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CPL3010U01PrePrintHandler extends ScreenHandler<CplsServiceProto.CPL3010U01PrePrintRequest, CplsServiceProto.CPL3010U01PrePrintResponse>{                     
	@Resource                                                                                                       
	private Cpl0101Repository cpl0101Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly = true)
	public CPL3010U01PrePrintResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U01PrePrintRequest request)
			throws Exception {                                                                   
       	CplsServiceProto.CPL3010U01PrePrintResponse.Builder response = CplsServiceProto.CPL3010U01PrePrintResponse.newBuilder();     
      	List<String> iraiStr = new ArrayList<String>();
      	if(!StringUtils.isEmpty(request.getIraiStr())) {
      		String getIraiStr = request.getIraiStr();
			String[] tags = getIraiStr.split(",");
			iraiStr.addAll(Arrays.asList(tags));
		}
      	
		List<CPL3010U01PrePrintInfo> listBtnPre=cpl0101Repository.getCPL3010U01BtnPrePrintClickCPL3010ListItemInfo(getHospitalCode(vertx, sessionId), 
				getLanguage(vertx, sessionId), iraiStr, request.getUitakCode());
		if(!CollectionUtils.isEmpty(listBtnPre)){
			for(CPL3010U01PrePrintInfo  item :listBtnPre){
				CplsModelProto.CPL3010U01PrePrintInfo .Builder info= CplsModelProto.CPL3010U01PrePrintInfo .newBuilder();
			    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addPrePrintLst(info);
			}
		}
		return response.build();
	}
}