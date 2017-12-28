package nta.med.service.ihis.handler.inps;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;

@Service
@Scope("prototype")
public class INP3003U00SakuraToiwonInputHandler extends
		ScreenHandler<InpsServiceProto.INP3003U00SakuraToiwonInputRequest, InpsServiceProto.INP3003U00SakuraToiwonInputResponse> {
	private static final Log LOGGER = LogFactory.getLog(INP3003U00SakuraToiwonInputHandler.class);
	
	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public InpsServiceProto.INP3003U00SakuraToiwonInputResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, InpsServiceProto.INP3003U00SakuraToiwonInputRequest request) throws Exception {
		InpsServiceProto.INP3003U00SakuraToiwonInputResponse.Builder response = InpsServiceProto.INP3003U00SakuraToiwonInputResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		Double pkinp1001 = CommonUtils.parseDouble(request.getPkinp1001());
		String result = inp1002Repository.getINP3003U00GrdMasterItem(hospCode, pkinp1001);
		if (!StringUtils.isEmpty(result)) {
			CommonModelProto.DataStringListItemInfo.Builder infoProto = CommonModelProto.DataStringListItemInfo.newBuilder();
			BeanUtils.copyProperties(result, infoProto, getLanguage(vertx, sessionId));
			infoProto.setDataValue(result);
			response.addGrdMasterItem(infoProto);
		}
		return response.build();
	}
}
