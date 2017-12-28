package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocso.OCSACTGrdJearyoInfo;
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
public class OCSACTGrdJearyoHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdJearyoRequest, OcsoServiceProto.OCSACTGrdJearyoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdJearyoHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override
	public boolean isValid(OcsoServiceProto.OCSACTGrdJearyoRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTGrdJearyoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdJearyoRequest request) throws Exception {
		OcsoServiceProto.OCSACTGrdJearyoResponse.Builder response = OcsoServiceProto.OCSACTGrdJearyoResponse
				.newBuilder();
		String bunho = request.getBunho();
		String ioGubun = request.getIoGubun();
		String jundalPart = request.getJundalPart();
		Double fkocs = CommonUtils.parseDouble(request.getFkocs());
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCSACTGrdJearyoInfo> list = ocs1003Repository
				.getOCSACTGrdJearyoInfo(bunho, request.getOrderDate(), ioGubun,
						jundalPart, fkocs, hospCode, language);
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
					info.setInOutGubun(String.format("%.0f",
							item.getInOutGubun()));
				}
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f", item.getNalsu()));
				}
				if (item.getIoGubunPkocs() != null) {
					info.setIoGubunPkocs(String.format("%.0f",
							item.getIoGubunPkocs()));
				}

				response.addGrdJearyoLst(info);
			}
		}
		return response.build();
	}                                                                                 
}