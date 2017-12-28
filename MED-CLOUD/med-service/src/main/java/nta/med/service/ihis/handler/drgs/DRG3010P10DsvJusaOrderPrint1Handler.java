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
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint1Info;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Request;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Response;

@Service
@Scope("prototype")
public class DRG3010P10DsvJusaOrderPrint1Handler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Request, DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Response> {
	@Resource
	private Drg3010Repository drg3010Repository;

	@Override
	@Transactional(readOnly = true)
	public DRG3010P10DsvJusaOrderPrint1Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10DsvJusaOrderPrint1Request request) throws Exception {
		DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Response.Builder response = DrgsServiceProto.DRG3010P10DsvJusaOrderPrint1Response.newBuilder();
		List<DRG3010P10DsvJusaOrderPrint1Info> list = drg3010Repository.getDRG3010P10DsvJusaOrderPrint1Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
		if (!CollectionUtils.isEmpty(list)) {
			for (DRG3010P10DsvJusaOrderPrint1Info item : list) {
				DrgsModelProto.DRG3010P10DsvJusaOrderPrint1Info.Builder info = DrgsModelProto.DRG3010P10DsvJusaOrderPrint1Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTblList(info);
			}
		}
		return response.build();
	}

}
