package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3041P05LabelInfo;
import nta.med.data.model.ihis.drgs.DRG3041P05SerialInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P05LabelRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P05LabelResponse;

@Service
@Scope("prototype")
public class DRG3041P05LabelHandler extends ScreenHandler<DrgsServiceProto.DRG3041P05LabelRequest, DrgsServiceProto.DRG3041P05LabelResponse> {

	@Resource
	private Drg3010Repository drg3010Repository;

	@Override
	public DRG3041P05LabelResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P05LabelRequest request) throws Exception {
		
		DrgsServiceProto.DRG3041P05LabelResponse.Builder response = DrgsServiceProto.DRG3041P05LabelResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String jubsuDate = request.getJubsuDate();
		String drgBunho = request.getDrgBunho();
		String rp = request.getRp();
		String seq = request.getSeq();
		
		// get list master
		List<DRG3041P05LabelInfo> listDataInfo = drg3010Repository.getDRG3041P05LabelInfo(hospCode, language, jubsuDate, drgBunho, rp); // 323/JA	2/24/2012 12:00:00 AM		8001/1
		
		if(CollectionUtils.isEmpty(listDataInfo)){
			return response.build();
		}
		
		// get list detail for each master item
		for (DRG3041P05LabelInfo item : listDataInfo) {
			DrgsModelProto.DRG3041P05LabelInfo.Builder masterInfo = DrgsModelProto.DRG3041P05LabelInfo.newBuilder();
			BeanUtils.copyProperties(item, masterInfo, language);
			
			String k = seq;																				// 323; JA; 		1; 		1; 		11/18/2011 12:00:00 AM; 3006; 1
			List<DRG3041P05SerialInfo> listSerialInfo = drg3010Repository.getDRG3041P05SerialInfo(hospCode, language, k, item.getCnt(), jubsuDate, drgBunho, item.getSerialText());
			if(!CollectionUtils.isEmpty(listSerialInfo)) {
				for (DRG3041P05SerialInfo detailItem : listSerialInfo) {
					DrgsModelProto.DRG3041P05SerialInfo.Builder detailInfo = DrgsModelProto.DRG3041P05SerialInfo.newBuilder();
					BeanUtils.copyProperties(detailItem, detailInfo, language);
					masterInfo.addSerials(detailInfo);
				}
			}
			
			response.addItems(masterInfo);
		}
		
		return response.build();
	}

}
