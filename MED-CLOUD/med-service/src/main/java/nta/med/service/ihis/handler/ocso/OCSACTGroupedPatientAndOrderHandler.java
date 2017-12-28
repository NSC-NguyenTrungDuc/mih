package nta.med.service.ihis.handler.ocso;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0313Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OCSACTDefaultJearyoInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdJearyoInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdOrderInfo;
import nta.med.data.model.ihis.ocso.OCSACTGrdPaListInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTGroupedPatientAndOrderRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTGroupedPatientAndOrderResponse;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")
public class OCSACTGroupedPatientAndOrderHandler extends ScreenHandler<OcsoServiceProto.OCSACTGroupedPatientAndOrderRequest, OcsoServiceProto.OCSACTGroupedPatientAndOrderResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCSACTGroupedPatientAndOrderHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;  
	@Resource
	private Out0101Repository out0101Repository;
	@Resource                                                                                                       
	private Ocs0313Repository ocs0313Repository;
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCSACTGroupedPatientAndOrderRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	} 
	
	@Override
	@Transactional(readOnly = true)
	public OCSACTGroupedPatientAndOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACTGroupedPatientAndOrderRequest request) throws Exception {
		OcsoServiceProto.OCSACTGroupedPatientAndOrderResponse.Builder response = OcsoServiceProto.OCSACTGroupedPatientAndOrderResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
//		get OCSACTGrdPaListRequest
		List<String> rtnVal = new ArrayList<String>();
		if(CommonEnum.PERCENTAGE.getValue().equals(request.getCboVal())){
			if(CommonEnum.SYSTEM_ID_NURO.getValue().equalsIgnoreCase(request.getSystemId()) 
					|| CommonEnum.SYSTEM_ID_NURI.getValue().equalsIgnoreCase(request.getSystemId()) 
					||  CommonEnum.SYSTEM_ID_TSTS.getValue().equalsIgnoreCase(request.getSystemId())){
				rtnVal = ocs0132Repository.getCodebyCodeTypeAndGroupKey(hospCode, language, request.getCboSystem(), "NUR");
			}else{
				rtnVal = ocs0132Repository.getCodebyCodeTypeAndGroupKey(hospCode, language, request.getCboSystem(), request.getSystemId());
			}
		}else{
			rtnVal.add(request.getCboPart());
		}
		List<OCSACTGrdPaListInfo> grdPatients = out0101Repository.getOCSACTGrdPaListInfo(hospCode, language, request.getBunho(),DateUtil.toDate(request.getFromDate(),DateUtil.PATTERN_YYMMDD), 
				DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD), request.getActGubun(), request.getCboSystem(), rtnVal, request.getIoGubun());
		if (!CollectionUtils.isEmpty(grdPatients)) {
			for (OCSACTGrdPaListInfo item : grdPatients) {
				OcsoModelProto.OCSACTGrdPaListInfo.Builder info = OcsoModelProto.OCSACTGrdPaListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdPaLst(info);
			}
//			get OCSACTGrdOrderRequest
			List<OCSACTGrdOrderInfo> grdOrders = out0101Repository.getOCSACTGrdOrderInfo(hospCode, language, grdPatients.get(0).getBunho(),
					request.getCboSystem(), rtnVal, grdPatients.get(0).getInOutGubun(), DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD),
					DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD), grdPatients.get(0).getGwa(), grdPatients.get(0).getDoctor(), true, false);
			if (!CollectionUtils.isEmpty(grdOrders)) {
				for (OCSACTGrdOrderInfo item : grdOrders) {
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
					response.addGrdOrderLst(info);
				}
//				get OCSACTDefaultJearyoRequest
				List<OCSACTDefaultJearyoInfo> listInfo = ocs0313Repository.getOCSACTDefaultJearyoInfo(hospCode, language, grdOrders.get(0).getHangmogCode());
				if(!CollectionUtils.isEmpty(listInfo)){
					for(OCSACTDefaultJearyoInfo item : listInfo){
						OcsoModelProto.OCSACTDefaultJearyoInfo.Builder info = OcsoModelProto.OCSACTDefaultJearyoInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addGrdDefaultLst(info);
					}
				}
//				get OCSACTGrdJearyoRequest
				List<OCSACTGrdJearyoInfo> list = ocs1003Repository.getOCSACTGrdJearyoInfo(grdOrders.get(0).getBunho(), DateUtil.toString(grdOrders.get(0).getOrderDate(), DateUtil.PATTERN_YYMMDD),
						grdOrders.get(0).getInOutGubun(), grdOrders.get(0).getJundalPart(), grdOrders.get(0).getPkocs1003(), hospCode, language);
				if (!CollectionUtils.isEmpty(list)) {
					for (OCSACTGrdJearyoInfo item : list) {
						OcsoModelProto.OCSACTGrdJearyoInfo.Builder info = OcsoModelProto.OCSACTGrdJearyoInfo.newBuilder();
						BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						if (item.getSuryang().contains(".")) {
							info.setSuryang(item.getSuryang().split("\\.")[0]);
						}
						if (item.getPkinv1001() != null) {
							info.setPkinv1001(String.format("%.0f", item.getPkinv1001()));
						}
						if (item.getInOutGubun() != null) {
							info.setInOutGubun(String.format("%.0f", item.getInOutGubun()));
						}
						if (item.getNalsu() != null) {
							info.setNalsu(String.format("%.0f", item.getNalsu()));
						}
						if (item.getIoGubunPkocs() != null) {
							info.setIoGubunPkocs(String.format("%.0f", item.getIoGubunPkocs()));
						}

						response.addGrdJearyoLst(info);
					}
				}
//				get OCSACTGrdSangByungRequest
				List<String> listResult = outsangRepository.getOCSACTGrdSangByungInfo(hospCode, grdOrders.get(0).getBunho(), grdOrders.get(0).getOrderDate());
				if(!CollectionUtils.isEmpty(listResult)){
					for(String item : listResult){
						OcsoModelProto.OCSACTGrdSangByungInfo.Builder info = OcsoModelProto.OCSACTGrdSangByungInfo.newBuilder();
						if(!StringUtils.isEmpty(item)){
							info.setSangName(item);
						}
						response.addGrdSangLst(info);
					}
				}
			}
		}
		return response.build();
	}

}
