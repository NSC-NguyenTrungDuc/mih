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
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.model.ihis.drgs.DRG3010P99grdDcOrderInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

@Service
@Scope("prototype")
public class DRG3010P99getFkocs2003Handler extends ScreenHandler<DrgsServiceProto.DRG3010P99getFkocs2003Request, DrgsServiceProto.DRG3010P99getFkocs2003Response>{
	
	@Resource
	private Drg3010Repository drg3010Repository;
	@Override
    @Transactional(readOnly = true)
	public DrgsServiceProto.DRG3010P99getFkocs2003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrgsServiceProto.DRG3010P99getFkocs2003Request request) throws Exception{
	DrgsServiceProto.DRG3010P99getFkocs2003Response.Builder response = DrgsServiceProto.DRG3010P99getFkocs2003Response.newBuilder();
	String hospCode = getHospitalCode(vertx, sessionId);
	Double drgBunho = Double.parseDouble(request.getDrgBunho());
	String jubsuDate = request.getJubsuDate();
	List<DataStringListItemInfo> result = drg3010Repository.getDRG3010P99getFkocs2003Info(hospCode, drgBunho, jubsuDate);
	
	if(!CollectionUtils.isEmpty(result)){
		for(DataStringListItemInfo item : result){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			//BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
			info.setDataValue(item.getItem());
			response.addFkocs2003(info);
		}
	}
		return response.build();
	}
}