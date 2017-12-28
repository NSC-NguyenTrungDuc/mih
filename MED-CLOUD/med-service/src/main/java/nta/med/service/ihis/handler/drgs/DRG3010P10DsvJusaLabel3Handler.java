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
import nta.med.data.model.ihis.drgs.DRG3010P10DsvJusaLabel2Info;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvJusaLabel2Response;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvJusaLabel3Request;

@Service
@Scope("prototype")
public class DRG3010P10DsvJusaLabel3Handler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10DsvJusaLabel3Request, DrgsServiceProto.DRG3010P10DsvJusaLabel2Response> {
	@Resource
	private Drg3010Repository drg3010Repository;

	@Override
	@Transactional(readOnly = true)
	public DRG3010P10DsvJusaLabel2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10DsvJusaLabel3Request request) throws Exception {
		DrgsServiceProto.DRG3010P10DsvJusaLabel2Response.Builder response = DrgsServiceProto.DRG3010P10DsvJusaLabel2Response.newBuilder();
		List<DRG3010P10DsvJusaLabel2Info> list = drg3010Repository.getDRG3010P10DsvJusaLabel2Info(getHospitalCode(vertx, sessionId), 
							getLanguage(vertx, sessionId), 
							request.getKValue(), 
							request.getCnt(), 
							request.getJubsuDate(), 
							request.getDrgBunho(), 
							request.getSerialText(), 
							false);
		if (!CollectionUtils.isEmpty(list)) {
			for (DRG3010P10DsvJusaLabel2Info item : list) {
				DrgsModelProto.DRG3010P10DsvJusaLabel2Info.Builder info = DrgsModelProto.DRG3010P10DsvJusaLabel2Info.newBuilder();
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
				
				if (item.getOrdSuryang() != null) {
					info.setOrdSuryang(String.format("%.0f",item.getOrdSuryang()));
				}
				
				response.addTblList(info);
			}
		}
		
		return response.build();
	}

}
