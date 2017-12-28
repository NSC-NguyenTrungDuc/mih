package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocso.OCS1003Q02GridOUT1001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

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
public class OCS1003Q02GridOUT1001Handler extends ScreenHandler<OcsoServiceProto.OCS1003Q02GridOUT1001Request, OcsoServiceProto.OCS1003Q02GridOUT1001Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003Q02GridOUT1001Handler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCS1003Q02GridOUT1001Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003Q02GridOUT1001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003Q02GridOUT1001Request request) throws Exception {
		OcsoServiceProto.OCS1003Q02GridOUT1001Response.Builder response = OcsoServiceProto.OCS1003Q02GridOUT1001Response.newBuilder(); 
		List<OCS1003Q02GridOUT1001Info> listGrd=out1001Repository.getOCS1003Q02GridOUT1001(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD),
    			request.getBunho(),request.getGwa(),request.getDoctor(),request.getNaewonYn());
    	if(!CollectionUtils.isEmpty(listGrd)){
    		for(OCS1003Q02GridOUT1001Info item: listGrd){
    			OcsoModelProto.OCS1003Q02GridOUT1001Info.Builder info= OcsoModelProto.OCS1003Q02GridOUT1001Info.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			if(item.getJubsuNo() != null){
    				info.setJubsuNo(String.format("%.0f",item.getJubsuNo()));
    			}
    			if(item.getPkNaewon() != null){
    				info.setPkNaewon(String.format("%.0f",item.getPkNaewon()));
    			}
				response.addGridOut1001Info(info);
    		}	
    	}
		return response.build();
	}                                                                                                                 
}