package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint3Info;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvOrderPrint3Request;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvOrderPrint3Response;

@Service
@Scope("prototype")
public class DRG3010P10DsvOrderPrint3Handler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10DsvOrderPrint3Request, DrgsServiceProto.DRG3010P10DsvOrderPrint3Response> {

	@Resource
	private Drg3010Repository drg3010Repository;

	@Override
	@Transactional(readOnly = true)
	public DRG3010P10DsvOrderPrint3Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10DsvOrderPrint3Request request) throws Exception {
		DrgsServiceProto.DRG3010P10DsvOrderPrint3Response.Builder response = DrgsServiceProto.DRG3010P10DsvOrderPrint3Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String serialV = request.getSerialV();
		String fkocs2003 = request.getFkocs2003();
		
        List<DRG3010P10DsvOrderPrint3Info> listInfo = drg3010Repository.getDRG3010P10DsvOrderPrint3Info(hospCode, language, serialV, fkocs2003);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3010P10DsvOrderPrint3Info item : listInfo) {
                DrgsModelProto.DRG3010P10DsvOrderPrint3Info.Builder info = DrgsModelProto.DRG3010P10DsvOrderPrint3Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addTblList(info);
            }
        }
        return response.build();
	}

}
