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

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.bas.Bas0260SRepository;
import nta.med.data.model.ihis.bass.LoadGrdBAS0260U01Info;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.LoadGrdBAS0260U01Request;
import nta.med.service.ihis.proto.BassServiceProto.LoadGrdBAS0260U01Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadGrdBAS0260U01Handler extends ScreenHandler<BassServiceProto.LoadGrdBAS0260U01Request, BassServiceProto.LoadGrdBAS0260U01Response> {                             
	
	private static final Log LOGGER = LogFactory.getLog(LoadGrdBAS0260U01Handler.class);                                        
	
	@Resource                                                                                                       
	private Bas0260SRepository bas0260SRepository;    
	
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;
	                                                                  
	@Override        
	@Transactional(readOnly = true)
	public LoadGrdBAS0260U01Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
		LoadGrdBAS0260U01Request request) throws Exception {
		BassServiceProto.LoadGrdBAS0260U01Response.Builder response = BassServiceProto.LoadGrdBAS0260U01Response.newBuilder();
		String buseoName =  request.getBuseoName();
		String gwaName =  request.getGwaName();
		String hospCode = getHospitalCode(vertx, sessionId);
		//String language = getLanguage(vertx, sessionId);
		String language = request.getLanguage();
		if(!StringUtils.isEmpty(buseoName) && Language.JAPANESE.toString().equalsIgnoreCase(language))
		{
			buseoName = adm0000Repository.callFnAdmConvertKanaFull(hospCode, buseoName);
		}
		if(!StringUtils.isEmpty(gwaName) && Language.JAPANESE.toString().equalsIgnoreCase(language))
		{
			gwaName = adm0000Repository.callFnAdmConvertKanaFull(hospCode, gwaName);
		}
		List<LoadGrdBAS0260U01Info> bas0260DepartmentInfos = bas0260SRepository.getBas0260SListGetDepartment(request.getLanguage(), buseoName, gwaName, "1", getHospitalCode(vertx, sessionId),request.getBuseoGubun());
		if(!CollectionUtils.isEmpty(bas0260DepartmentInfos)){
			for(LoadGrdBAS0260U01Info item : bas0260DepartmentInfos){
				BassModelProto.LoadGrdBAS0260U01Info.Builder info = BassModelProto.LoadGrdBAS0260U01Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				info.setId(item.getId().toString());
				response.addListInfo(info);
			}
		}
		return response.build();
	}
}
