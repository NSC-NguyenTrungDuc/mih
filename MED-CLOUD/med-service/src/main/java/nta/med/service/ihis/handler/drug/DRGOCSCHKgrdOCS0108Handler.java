package nta.med.service.ihis.handler.drug;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.service.ihis.proto.DrugModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRGOCSCHKgrdOCS0108Request;
import nta.med.service.ihis.proto.DrugServiceProto.DRGOCSCHKgrdOCS0108Response;
import nta.med.data.model.ihis.drug.DRGOCSCHKgrdOCS0108Info;
import nta.med.data.model.ihis.ocsa.OCS0103U00SunalAndSubulInfo;

@Service
@Scope("prototype")
public class DRGOCSCHKgrdOCS0108Handler extends ScreenHandler<DrugServiceProto.DRGOCSCHKgrdOCS0108Request, DrugServiceProto.DRGOCSCHKgrdOCS0108Response>{
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKgrdOCS0108Handler.class);	
	@Resource
	private Ocs0108Repository ocs0108Repository;
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DRGOCSCHKgrdOCS0108Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRGOCSCHKgrdOCS0108Request request) throws Exception {
		String hospCode = request.getHospCode();
		Date hangmogStartDate = DateUtil.toDate(request.getHangmogStartdate(), DateUtil.PATTERN_YYMMDD);
		String sunal = null;
		String subul = null;
		DrugServiceProto.DRGOCSCHKgrdOCS0108Response.Builder response = DrugServiceProto.DRGOCSCHKgrdOCS0108Response.newBuilder();
		//start tuning performance
  	   	OCS0103U00SunalAndSubulInfo fnResult = ocs0103Repository.callFnOcsLoadSunalAndSubulDanuiName(hospCode, getLanguage(vertx, sessionId), 
  	   			request.getHangmogCode(), hangmogStartDate);
  	   	if(fnResult != null){
  	   		sunal = fnResult.getSunal();
  	   		subul = fnResult.getSubul();
  	   	}
  	   	//end tuning performance
		List<DRGOCSCHKgrdOCS0108Info> listGrdOCS0108Infos = ocs0108Repository.getDRGOCSCHKgrdOCS0108Info(hospCode, getLanguage(vertx, sessionId), request.getHangmogCode(), hangmogStartDate);
		if(!CollectionUtils.isEmpty(listGrdOCS0108Infos)){
			for(DRGOCSCHKgrdOCS0108Info item : listGrdOCS0108Infos){
				DrugModelProto.DRGOCSCHKgrdOCS0108Info.Builder info = DrugModelProto.DRGOCSCHKgrdOCS0108Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				//start tuning performance
				if(item.getChangeDanui1() != null){
					if(sunal != null){
						info.setChangeDanui1(item.getChangeDanui1().concat("/").concat(sunal));
					}else{
						info.setChangeDanui1(item.getChangeDanui1());
					}
				}
				if(item.getChangeDanui2() != null){
					if(subul != null){
						info.setChangeDanui2(item.getChangeDanui2().concat("/").concat(subul));	
					}else{
						info.setChangeDanui2(item.getChangeDanui2());
					}
				}
				//end tuning performance
				response.addListInfo(info);
			}
		}
		return response.build();
	}

}
