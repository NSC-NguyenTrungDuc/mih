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
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS1003DloCheckLayoutHandler extends ScreenHandler<OcsoServiceProto.OCS1003DloCheckLayoutRequest, OcsoServiceProto.OCS1003DloCheckLayoutResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1003DloCheckLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCS1003DloCheckLayoutRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1003DloCheckLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003DloCheckLayoutRequest request) throws Exception {
		OcsoServiceProto.OCS1003DloCheckLayoutResponse.Builder response = OcsoServiceProto.OCS1003DloCheckLayoutResponse.newBuilder(); 
		List<OCS1003Q09GridOUT1001Info> list = out1001Repository.getOCS1003Q09GridOUT1001ListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "",
				request.getInputGubun(), request.getTelYn(), "", "", "", request.getBunho(),
				DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getGwa());
		if(!CollectionUtils.isEmpty(list)){
			for(OCS1003Q09GridOUT1001Info item : list){
				OcsoModelProto.OCS1003Q09GridOUT1001Info.Builder info = OcsoModelProto.OCS1003Q09GridOUT1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGridout1001Info(info);
			}
		}
		return response.build();
	}                                                                                                                 
}