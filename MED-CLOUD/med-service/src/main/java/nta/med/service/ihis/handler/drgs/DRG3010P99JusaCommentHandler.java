package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99JusaKInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99JusaCommentHandler extends ScreenHandler<DrgsServiceProto.DRG3010P99JusaCommentRequest, DrgsServiceProto.DRG3010P99JusaCommentResponse>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99JusaCommentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99JusaCommentRequest request) throws Exception{
		
		DrgsServiceProto.DRG3010P99JusaCommentResponse.Builder response = DrgsServiceProto.DRG3010P99JusaCommentResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DRG3010P99JusaKInfo> result = drg3010Repository.getDRG3010P99JusaKInfo(hospCode, language, request.getK(), request.getCnt(),
								request.getSerialText(), request.getJubsuDate(), CommonUtils.parseDouble(request.getDrgBunho()), "B");
		
		if(!CollectionUtils.isEmpty(result)){
			for(DRG3010P99JusaKInfo item : result){
				DrgsModelProto.DRG3010P99JusaCommentInfo.Builder info = DrgsModelProto.DRG3010P99JusaCommentInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				
				if (item.getDv() != null) {
					info.setDv(String.format("%.0f",item.getDv()));
				}
				
				response.addListJusacomment(info);
			}
		}
		
		return response.build();
	}
}