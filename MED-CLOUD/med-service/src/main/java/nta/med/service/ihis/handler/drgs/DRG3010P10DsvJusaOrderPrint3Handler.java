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
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaOrderPrint3Info;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Request;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Response;

@Service
@Scope("prototype")
public class DRG3010P10DsvJusaOrderPrint3Handler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Request, DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Response> {
	@Resource
	private Drg3010Repository drg3010Repository;

	@Override
	@Transactional(readOnly = true)
	public DRG3010P10DsvJusaOrderPrint3Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10DsvJusaOrderPrint3Request request) throws Exception {
		DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Response.Builder response = DrgsServiceProto.DRG3010P10DsvJusaOrderPrint3Response.newBuilder();
		List<DRG3010P10DsvJusaOrderPrint3Info> list = drg3010Repository.getDRG3010P10DsvJusaOrderPrint3Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getSerialV(), request.getFkocs2003());
		if (!CollectionUtils.isEmpty(list)) {
			for (DRG3010P10DsvJusaOrderPrint3Info item : list) {
				DrgsModelProto.DRG3010P10DsvJusaOrderPrint3Info.Builder info = DrgsModelProto.DRG3010P10DsvJusaOrderPrint3Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				if (item.getNalsu() != null) {
					info.setNalsu(String.format("%.0f",item.getNalsu()));
				}
				
				if (item.getOrderSuryang() != null) {
					info.setOrderSuryang(String.format("%.0f",item.getOrderSuryang()));
				}
				
				if (item.getSubulSuryang() != null) {
					info.setSubulSuryang(String.format("%.0f",item.getSubulSuryang()));
				}
				
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				
				if (item.getDv1() != null) {
					info.setDv1(String.format("%.0f",item.getDv1()));
				}
				
				if (item.getDv2() != null) {
					info.setDv2(String.format("%.0f",item.getDv2()));
				}
				
				if (item.getDv3() != null) {
					info.setDv3(String.format("%.0f",item.getDv3()));
				}
				
				if (item.getDv4() != null) {
					info.setDv4(String.format("%.0f",item.getDv4()));
				}
				
				if (item.getDv5() != null) {
					info.setDv5(String.format("%.0f",item.getDv5()));
				}
				
				if (item.getFkocs2003() != null) {
					info.setFkocs2003(String.format("%.0f",item.getFkocs2003()));
				}
				
				response.addTblList(info);
			}
		}
		return response.build();
	}

}
