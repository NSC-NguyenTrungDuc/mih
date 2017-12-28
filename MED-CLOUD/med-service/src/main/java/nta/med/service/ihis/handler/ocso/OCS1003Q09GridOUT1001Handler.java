package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.ocsa.OCS1003Q09GridOUT1001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003Q09GridOUT1001Handler extends ScreenHandler<OcsoServiceProto.OCS1003Q09GridOUT1001Request, OcsoServiceProto.OCS1003Q09GridOUT1001Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003Q09GridOUT1001Handler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003Q09GridOUT1001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003Q09GridOUT1001Request request) throws Exception {
		OcsoServiceProto.OCS1003Q09GridOUT1001Response.Builder response = OcsoServiceProto.OCS1003Q09GridOUT1001Response.newBuilder(); 
		List<OCS1003Q09GridOUT1001Info> list = out1001Repository.getOCS1003Q09GridOUT1001ListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getKijun(),
				request.getInputGubun(), request.getTelYn(), request.getInputTab(), request.getIoGubun(), request.getSelectedInputTab(), request.getBunho(),
				DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getGwa());
		if(!CollectionUtils.isEmpty(list)){
			for(OCS1003Q09GridOUT1001Info item : list){
				OcsoModelProto.OCS1003Q09GridOUT1001Info.Builder info = OcsoModelProto.OCS1003Q09GridOUT1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGridOut1001Info(info);
			}
		}
		return response.build();
	}                                                                                                                 
}