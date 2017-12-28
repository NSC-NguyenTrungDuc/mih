package nta.med.service.ihis.handler.xrts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0106Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdComment3Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class XRT1002U00GrdComment3Handler extends ScreenHandler<XrtsServiceProto.XRT1002U00GrdComment3Request, XrtsServiceProto.XRT1002U00GrdComment3Response> {
	private static final Log LOGGER = LogFactory.getLog(XRT1002U00GrdComment3Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0106Repository ocs0106Repository;

	@Override
	public boolean isValid(XrtsServiceProto.XRT1002U00GrdComment3Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public XrtsServiceProto.XRT1002U00GrdComment3Response handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT1002U00GrdComment3Request request) throws Exception {
		XrtsServiceProto.XRT1002U00GrdComment3Response.Builder response = XrtsServiceProto.XRT1002U00GrdComment3Response.newBuilder();

		List<XRT1002U00GrdComment3Info> listItem = ocs0106Repository.getXRT1002U00GrdComment3Info(getHospitalCode(vertx, sessionId), request.getBunho(), request.getOrderDate());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (XRT1002U00GrdComment3Info item : listItem) {
				XrtsModelProto.XRT1002U00GrdComment3Info.Builder info = XrtsModelProto.XRT1002U00GrdComment3Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdCommentItem(info);
			}
		}
		return response.build();
	}
}