package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05DiseaseListItemInfo;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05OrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OcsoOCS1003Q05GrdRowFocusChangedHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedRequest, OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003Q05GrdRowFocusChangedHandler.class);                                        
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;        
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedResponse.Builder response = OcsoServiceProto.OcsoOCS1003Q05GrdRowFocusChangedResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		//OcsoOCS1003Q05DiseaseListItemInfo
		List<OcsoOCS1003Q05DiseaseListItemInfo> listDisease = outsangRepository.getOcsoOCS1003Q05DiseaseList(hospCode, language, request.getIoGubun(), request.getJubsuNo(),
				request.getNaewonDate(), request.getGwa(), request.getDoctor(), request.getNaewonType(), request.getBunho());
		if (!CollectionUtils.isEmpty(listDisease)) {
			for (OcsoOCS1003Q05DiseaseListItemInfo item : listDisease) {
				OcsoModelProto.OcsoOCS1003Q05DiseaseListItemInfo.Builder info = OcsoModelProto.OcsoOCS1003Q05DiseaseListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDiseaseItem(info);
			}
		}
		
		// OcsoOCS1003Q05OrderListItemInfo
		List<OcsoOCS1003Q05OrderListItemInfo > listOrder = ocs1003Repository.getOcsoOCS1003Q05OrderList(hospCode, language,
				request.getGenericYn(), request.getPkOrder(), request.getInputTab(), request.getInputGubun(), request.getTelYn(), 
				request.getBunho(), request.getJubsuNo(), request.getKijun(), DateUtil.toDate(request.getNaewonDate(),DateUtil.PATTERN_YYMMDD), request.getGwa(), request.getDoctor());
		if (!CollectionUtils.isEmpty(listOrder)) {
			for (OcsoOCS1003Q05OrderListItemInfo  item : listOrder) {
				OcsoModelProto.OcsoOCS1003Q05OrderListItemInfo .Builder info = OcsoModelProto.OcsoOCS1003Q05OrderListItemInfo .newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOrderItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}