package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003cRepository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01LayoutQueryInfo;
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
public class OcsoOCS1003P01LayoutQueryHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01LayoutQueryRequest, OcsoServiceProto.OcsoOCS1003P01LayoutQueryResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01LayoutQueryHandler.class);

	@Resource
	private Ocs1003Repository ocs1003Repository;

	@Resource
	private Ocs1003cRepository ocs1003cRepository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01LayoutQueryResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01LayoutQueryRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01LayoutQueryResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01LayoutQueryResponse.newBuilder();
		Double fkOu1001 = CommonUtils.parseDouble(request.getFkout1001());
		
		List<OcsoOCS1003P01LayoutQueryInfo> listObject = ocs1003Repository.getOcsoOCS1003P01LayoutQueryInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId),
				request.getBunho(), fkOu1001, request.getQueryGubun(), request.getInputGubun());
		
		List<OcsoOCS1003P01LayoutQueryInfo> listObjectBaseOnOcs1003C = ocs1003cRepository.getOcsoOCS1003P01LayoutQueryInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId),request.getBunho(), fkOu1001, request.getQueryGubun(), request.getInputGubun());
		
		
		if (listObject != null && !listObject.isEmpty()) {
			for (OcsoOCS1003P01LayoutQueryInfo item : listObject) {
				OcsoModelProto.OcsoOCS1003P01LayoutQueryInfo.Builder info = OcsoModelProto.OcsoOCS1003P01LayoutQueryInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addLayoutItem(info);
			}
		}
		
		if(!CollectionUtils.isEmpty(listObjectBaseOnOcs1003C)){
			for (OcsoOCS1003P01LayoutQueryInfo item : listObjectBaseOnOcs1003C) {
				OcsoModelProto.OcsoOCS1003P01LayoutQueryInfo.Builder info = OcsoModelProto.OcsoOCS1003P01LayoutQueryInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            	response.addLayoutItem(info);
			}
		}
		
		return response.build();
	}
}
