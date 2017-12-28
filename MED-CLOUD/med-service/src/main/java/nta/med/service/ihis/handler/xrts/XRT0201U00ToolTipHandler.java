package nta.med.service.ihis.handler.xrts;

import javax.annotation.Resource;



import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.XrtsModelProto;
import nta.med.service.ihis.proto.XrtsServiceProto.XRT0201U00ToolTipRequest;
import nta.med.service.ihis.proto.XrtsServiceProto.XRT0201U00ToolTipResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class XRT0201U00ToolTipHandler extends ScreenHandler<XRT0201U00ToolTipRequest, XRT0201U00ToolTipResponse>{
	@Resource
	private ClisProtocolPatientRepository clisProtocolPatientRepository;
	
	@Override
	@Transactional(readOnly = true)
	public XRT0201U00ToolTipResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, XRT0201U00ToolTipRequest request)
			throws Exception {
		XRT0201U00ToolTipResponse.Builder response = XRT0201U00ToolTipResponse.newBuilder();
		String result = clisProtocolPatientRepository.getXRT0201U00ToolTipInfo(request.getHospCode(), request.getBunho());
		if(!StringUtils.isEmpty(result)){
			XrtsModelProto.XRT0201U00ToolTipInfo.Builder info = XrtsModelProto.XRT0201U00ToolTipInfo.newBuilder();
			info.setNumProtocol(result);
		}
		return response.build();
	}

}
