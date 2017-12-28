package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.data.model.ihis.bass.BAS0210U00grdBAS0210ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00grdBAS0210Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00grdBAS0210Response;

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
public class BAS0210U00grdBAS0210Handler extends ScreenHandler<BassServiceProto.BAS0210U00grdBAS0210Request, BassServiceProto.BAS0210U00grdBAS0210Response> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0210U00grdBAS0210Handler.class);                                        
	@Resource                                                                                                       
	private Bas0210Repository bas0210Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public BAS0210U00grdBAS0210Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0210U00grdBAS0210Request request) throws Exception {
  	   	BassServiceProto.BAS0210U00grdBAS0210Response.Builder response = BassServiceProto.BAS0210U00grdBAS0210Response.newBuilder();                      
		List<BAS0210U00grdBAS0210ItemInfo> listGrdBas0210=bas0210Repository.getBAS0210U00grdBAS0210ItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD),request.getGubunCode());
		if(!CollectionUtils.isEmpty(listGrdBas0210)){
			for(BAS0210U00grdBAS0210ItemInfo item:listGrdBas0210){
				BassModelProto.BAS0210U00grdBAS0210ItemInfo.Builder info= BassModelProto.BAS0210U00grdBAS0210ItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdBas0210(info);
			}
		}
			                                                                                     
		return response.build();
	}     
		
	@Override
	public boolean isValid(BassServiceProto.BAS0210U00grdBAS0210Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
}