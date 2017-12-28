package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocso.OCSACTGrdPaListInfo;
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
public class OCSACTGrdPaListHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdPaListRequest, OcsoServiceProto.OCSACTGrdPaListResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdPaListHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;  
	@Resource
	private Out0101Repository out0101Repository;
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCSACTGrdPaListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTGrdPaListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdPaListRequest request) throws Exception {
		OcsoServiceProto.OCSACTGrdPaListResponse.Builder response = OcsoServiceProto.OCSACTGrdPaListResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//get Jundal_part_param
		List<String> rtnVal = new ArrayList<String>();
		if("%".equals(request.getCboVal())){
			if("NURO".equalsIgnoreCase(request.getSystemId()) || "NURI".equalsIgnoreCase(request.getSystemId()) || "TSTS".equalsIgnoreCase(request.getSystemId())){
				rtnVal = ocs0132Repository.getCodebyCodeTypeAndGroupKey(hospCode, language, request.getCboSystem(), "NUR");
			}else{
				rtnVal = ocs0132Repository.getCodebyCodeTypeAndGroupKey(hospCode, language, request.getCboSystem(), request.getSystemId());
			}
		}else{
			rtnVal.add(request.getCboPart()); 
		}
		//get OCSACTGrdPaListInfo 
		// rtnVal = jundal_part_param
		List<OCSACTGrdPaListInfo> listGrd = out0101Repository.getOCSACTGrdPaListInfo(hospCode, language, request.getBunho(),DateUtil.toDate(request.getFromDate(),DateUtil.PATTERN_YYMMDD), 
				DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD), request.getActGubun(), request.getCboSystem(), rtnVal, request.getIoGubun());
		if (!CollectionUtils.isEmpty(listGrd)) {
			for (OCSACTGrdPaListInfo item : listGrd) {
				OcsoModelProto.OCSACTGrdPaListInfo.Builder info = OcsoModelProto.OCSACTGrdPaListInfo
						.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdPaLst(info);
			}
		}
		return response.build();
	}                                                                                                                 
}