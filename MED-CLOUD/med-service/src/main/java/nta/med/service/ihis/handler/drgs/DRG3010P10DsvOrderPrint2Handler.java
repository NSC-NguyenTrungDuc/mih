package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.drgs.DRG3010P10DsvOrderPrint2Info;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvOrderPrint2Request;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10DsvOrderPrint2Response;

@Service
@Scope("prototype")
public class DRG3010P10DsvOrderPrint2Handler extends
		ScreenHandler<DrgsServiceProto.DRG3010P10DsvOrderPrint2Request, DrgsServiceProto.DRG3010P10DsvOrderPrint2Response> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public DRG3010P10DsvOrderPrint2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10DsvOrderPrint2Request request) throws Exception {
		DrgsServiceProto.DRG3010P10DsvOrderPrint2Response.Builder response = DrgsServiceProto.DRG3010P10DsvOrderPrint2Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P10DsvOrderPrint2Info> items = inp1001Repository.getDRG3010P10DsvOrderPrint2Info(hospCode, language
				, request.getSerialText()
				, request.getJubsuDate()
				, CommonUtils.parseDouble(request.getDrgBunho()));
		
		for (DRG3010P10DsvOrderPrint2Info item : items) {
			DrgsModelProto.DRG3010P10DsvOrderPrint2Info.Builder info = DrgsModelProto.DRG3010P10DsvOrderPrint2Info.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			
			if (item.getDrgBunho() != null) {
				info.setDrgBunho(String.format("%.0f",item.getDrgBunho()));
			}
			
			if (item.getGroupSer() != null) {
				info.setGroupSer(String.format("%.0f",item.getGroupSer()));
			}
			
			if (item.getNalsu() != null) {
				info.setNalsu(String.format("%.0f",item.getNalsu()));
			}
			
			if (item.getOrdSuryang() != null) {
				info.setOrdSuryang(String.format("%.0f",item.getOrdSuryang()));
			}
			
			if (item.getOrderSuryang() != null) {
				info.setOrderSuryang(String.format("%.0f",item.getOrderSuryang()));
			}
			
			if (item.getDv() != null) {
				info.setDv(String.format("%.0f",item.getDv()));
			}
			
			if (item.getFkocs2003() != null) {
				info.setFkocs2003(String.format("%.0f",item.getFkocs2003()));
			}
			
			if (item.getSubulSuryang() != null) {
				info.setSubulSuryang(String.format("%.0f",item.getSubulSuryang()));
			}
			
			response.addTblList(info);
		}
		
		return response.build();
	}

}
