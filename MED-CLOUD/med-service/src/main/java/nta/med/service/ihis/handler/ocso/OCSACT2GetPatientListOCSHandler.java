package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
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

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocso.OCSACT2GetPatientListOCSInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetPatientListOCSRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetPatientListOCSResponse;

@Service                                                                                                          
@Scope("prototype")
public class OCSACT2GetPatientListOCSHandler extends ScreenHandler<OcsoServiceProto.OCSACT2GetPatientListOCSRequest, OcsoServiceProto.OCSACT2GetPatientListOCSResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCSACT2GetPatientListOCSHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;  
	@Resource
	private Out0101Repository out0101Repository;
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCSACT2GetPatientListOCSRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OCSACT2GetPatientListOCSResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2GetPatientListOCSRequest request) throws Exception {
		OcsoServiceProto.OCSACT2GetPatientListOCSResponse.Builder response = OcsoServiceProto.OCSACT2GetPatientListOCSResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//get Jundal_part_param
		List<String> rtnVal = new ArrayList<String>();
		if(CommonEnum.PERCENTAGE.getValue().equals(request.getCboVal())){
			if(CommonEnum.SYSTEM_ID_NURO.getValue().equalsIgnoreCase(request.getSystemId()) 
					|| CommonEnum.SYSTEM_ID_NURI.getValue().equalsIgnoreCase(request.getSystemId()) 
					|| CommonEnum.SYSTEM_ID_TSTS.getValue().equalsIgnoreCase(request.getSystemId())){
				rtnVal = ocs0132Repository.getCodebyCodeTypeAndGroupKey(hospCode, language, request.getCboSystem(), "NUR");
			}else{
				rtnVal = ocs0132Repository.getCodebyCodeTypeAndGroupKey(hospCode, language, request.getCboSystem(), request.getSystemId());
			}
		}else{
			rtnVal.add(request.getCboPart()); 
		}
		//get OCSACTGrdPaListInfo 
		// rtnVal = jundal_part_param
		List<OCSACT2GetPatientListOCSInfo> listGrd = out0101Repository.getOCSACT2GetPatientListOCSInfo(hospCode, language, request.getBunho(),DateUtil.toDate(request.getFromDate(),DateUtil.PATTERN_YYMMDD), 
				DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD), request.getActGubun(), request.getCboSystem(), rtnVal, request.getIoGubun());
		if (!CollectionUtils.isEmpty(listGrd)) {
			for (OCSACT2GetPatientListOCSInfo item : listGrd) {
				OcsoModelProto.OCSACT2GetPatientListOCSInfo.Builder info = OcsoModelProto.OCSACT2GetPatientListOCSInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkocs1003() != null) {
					info.setPkocs1003(String.format("%.0f",item.getPkocs1003()));
        		}
        		if (item.getPkout1001() != null) {
					info.setPkout1001(String.format("%.0f",item.getPkout1001()));
        		}
				response.addPatOcsItem(info);
			}
		}
		return response.build();
	}

}
