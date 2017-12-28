package nta.med.service.ihis.handler.ocso;

import java.text.ParseException;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1023Repository;
import nta.med.data.model.ihis.ocso.Ocs1023U00GrdOcs1023Info;
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
public class OCS1023U00GrdOCS1023Handler extends ScreenHandler<OcsoServiceProto.OCS1023U00GrdOCS1023Request, OcsoServiceProto.OCS1023U00GrdOCS1023Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS1023U00GrdOCS1023Handler.class);                                    
	@Resource                                                                                                       
	private Ocs1023Repository ocs1023Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCS1023U00GrdOCS1023Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1023U00GrdOCS1023Request request) throws Exception {
		OcsoServiceProto.OCS1023U00GrdOCS1023Response.Builder response = OcsoServiceProto.OCS1023U00GrdOCS1023Response.newBuilder(); 
		List<Ocs1023U00GrdOcs1023Info> list = ocs1023Repository.getOcs1023U00GrdOcs1023Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),
				request.getGenericYn(), request.getGwa(), request.getInputTab());
		if(!CollectionUtils.isEmpty(list)){
			for(Ocs1023U00GrdOcs1023Info item : list){
				OcsoModelProto.OCS1023U00GrdOCS1023Info.Builder info = OcsoModelProto.OCS1023U00GrdOCS1023Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				String buyoCheck = "N";
				buyoCheck = fnOcsBulyongCheckOut(item, buyoCheck);
				info.setBulyongCheck(buyoCheck);
				response.addListInfo(info);
			}
		}
		return response.build();
	}  
	
	private String fnOcsBulyongCheckOut(Ocs1023U00GrdOcs1023Info item,
			String buyoCheck) throws ParseException {
		Date date = DateUtil.toDate(item.getBulyongCheck(), DateUtil.PATTERN_YYMMDD);
		if(StringUtils.isEmpty(item.getBulyongCheck()) || ( date.equals(new Date()) || date.after(new Date()))){
			buyoCheck = "N";
		}else{
			buyoCheck = "Y";
		}
		return buyoCheck;
	}
	
}