package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.OUT1001P01GrdOUT1001ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUT1001P01GrdOUT1001Handler extends ScreenHandler<NuroServiceProto.OUT1001P01GrdOUT1001Request, NuroServiceProto.OUT1001P01GrdOUT1001Response> {                             
	private static final Log LOGGER = LogFactory.getLog(OUT1001P01GrdOUT1001Handler.class);                                        
	@Resource                                                                                                       
	private Out1001Repository  out1001Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(NuroServiceProto.OUT1001P01GrdOUT1001Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001P01GrdOUT1001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P01GrdOUT1001Request request) throws Exception {
		NuroServiceProto.OUT1001P01GrdOUT1001Response.Builder response = NuroServiceProto.OUT1001P01GrdOUT1001Response.newBuilder();
		List<OUT1001P01GrdOUT1001ListItemInfo> listResult = out1001Repository.getOUT1001P01GrdOUT1001(getHospitalCode(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD), CommonUtils.parseDouble(request.getPkout1001()), getLanguage(vertx, sessionId));
    	if(listResult != null && !listResult.isEmpty()){
    		for(OUT1001P01GrdOUT1001ListItemInfo item : listResult){
    			NuroModelProto.OUT1001P01GrdOUT1001ListItemInfo.Builder info = NuroModelProto.OUT1001P01GrdOUT1001ListItemInfo.newBuilder();
        		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		response.addGrdOUT1001List(info);
    		}
    	}
		return response.build();
	}                                                                                                               
}                                                                                                                 
