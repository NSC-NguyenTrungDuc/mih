package nta.med.service.ihis.handler.ocso;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocso.OCSACTGrdOrderInfo;
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
public class OCSACTGrdOrderHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdOrderRequest, OcsoServiceProto.OCSACTGrdOrderResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdOrderHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;  
	@Resource
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCSACTGrdOrderRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTGrdOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdOrderRequest request) throws Exception {
		OcsoServiceProto.OCSACTGrdOrderResponse.Builder response = OcsoServiceProto.OCSACTGrdOrderResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//1. Get jundal_part_param
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
		//2. Get OCSACTGrdOrderInfo 
		// rtnVal = jundal_part_param
		List<OCSACTGrdOrderInfo> listGrd = null;
		if (!CollectionUtils.isEmpty(rtnVal)) {
			if (request.getRbxNonAct() == true) {
				
				listGrd = out0101Repository.getOCSACTGrdOrderInfo(hospCode, language, request.getBunho(), request.getCboSystem(), 
						rtnVal, request.getIoGubun(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD),
						DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor(), true, false);
			} else if (request.getRbxAct() == true) {
				listGrd = out0101Repository.getOCSACTGrdOrderInfo(hospCode, language, request.getBunho(), request.getCboSystem(),
						rtnVal, request.getIoGubun(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD),
						DateUtil.toDate(request.getToDate(),DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor(), false, true);
			} else {
				listGrd = out0101Repository.getOCSACTGrdOrderInfo(hospCode, language, request.getBunho(), request.getCboSystem(),
						rtnVal, request.getIoGubun(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD),
						DateUtil.toDate(request.getToDate(),DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor(), false, false);
			}
		}
		if (!CollectionUtils.isEmpty(listGrd)) {
			for (OCSACTGrdOrderInfo item : listGrd) {
				OcsoModelProto.OCSACTGrdOrderInfo.Builder info = OcsoModelProto.OCSACTGrdOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkocs1003() != null) {
					info.setPkocs1003(String.format("%.0f", item.getPkocs1003()));
				}
				if (item.getFkout1001() != null) {
					info.setFkout1001(String.format("%.0f", item.getFkout1001()));
				}
				if (item.getSuryang() != null) {
					info.setSuryang(String.format("%.0f", item.getSuryang()));
				}
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f", item.getNalsu()));
				}
				response.addGrdOrderItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}