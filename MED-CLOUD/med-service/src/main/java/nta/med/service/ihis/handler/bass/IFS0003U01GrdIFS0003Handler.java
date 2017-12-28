package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.model.ihis.bass.Ifs0003U00GrdIFS0003Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01GrdIFS0003Request;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U01GrdIFS0003Response;

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
public class IFS0003U01GrdIFS0003Handler extends ScreenHandler<BassServiceProto.IFS0003U01GrdIFS0003Request, BassServiceProto.IFS0003U01GrdIFS0003Response> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U01GrdIFS0003Handler.class);                                    
	@Resource                                                                                                       
	private Ifs0003Repository ifs0003Repository;  
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IFS0003U01GrdIFS0003Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0003U01GrdIFS0003Request request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
  	   	BassServiceProto.IFS0003U01GrdIFS0003Response.Builder response = BassServiceProto.IFS0003U01GrdIFS0003Response.newBuilder();                      
		List<Ifs0003U00GrdIFS0003Info> list =  ifs0003Repository.getIfs0003U00GrdIFS0003ListItem(hospitalCode, request.getMapGubun(), 
				request.getMapGubunYmd(), null,null, false, null, null);
		if(!CollectionUtils.isEmpty(list)){
			for(Ifs0003U00GrdIFS0003Info item : list){
				BassModelProto.IFS0003U01GrdIFS0003Info.Builder info = BassModelProto.IFS0003U01GrdIFS0003Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				String ocsCodeName = commonRepository.callFnLoadOcsCodeName(hospitalCode, item.getMapGubun(), item.getOcsCode(), language);
				if(!StringUtils.isEmpty(ocsCodeName)){
					info.setOcsCodeName(ocsCodeName);
				}else{
					String elseOcsCodeName = info.getMapGubun() + "-" + info.getOcsCode() + " not found";
						info.setOcsCodeName(elseOcsCodeName);
				}
				response.addGrdIfsItem(info);
			}
		}
		return response.build();
	}    
	
}