package nta.med.service.ihis.handler.drgs;

import nta.med.core.domain.inv.Inv0102;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01ConstantInfoHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01ConstantInfoRequest, DrgsServiceProto.DrgsDRG5100P01ConstantInfoResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01ConstantInfoHandler.class);
	@Resource
	private Inv0102Repository inv0102Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01ConstantInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01ConstantInfoRequest request) throws Exception {
		List<Inv0102> listObject = inv0102Repository.findByCodeType(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
		DrgsServiceProto.DrgsDRG5100P01ConstantInfoResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01ConstantInfoResponse.newBuilder();
		if(!CollectionUtils.isEmpty(listObject)) {
			for(Inv0102 item : listObject) {
				DrgsModelProto.DrgsDRG5100P01ConstantInfo.Builder info = DrgsModelProto.DrgsDRG5100P01ConstantInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				if (!StringUtils.isEmpty(item.getCodeValue())) {
					info.setCodeValue(item.getCodeValue());
				}
				response.addConstantInfoList(info);
			}
		}
		return response.build();
	}
}
