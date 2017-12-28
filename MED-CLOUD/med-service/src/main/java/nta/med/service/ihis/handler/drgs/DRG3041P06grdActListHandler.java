package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.drg.Drg3041Repository;
import nta.med.data.model.ihis.drgs.DRG3041P06grdActListInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06grdActListRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3041P06grdActListResponse;

@Service
@Scope("prototype")
public class DRG3041P06grdActListHandler extends ScreenHandler<DrgsServiceProto.DRG3041P06grdActListRequest, DrgsServiceProto.DRG3041P06grdActListResponse> {

	@Resource
	private Drg3041Repository drg3041Repository;

	@Override
	public DRG3041P06grdActListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3041P06grdActListRequest request) throws Exception {
		
		DrgsServiceProto.DRG3041P06grdActListResponse.Builder response = DrgsServiceProto.DRG3041P06grdActListResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String ipgoDate = request.getIpgoDate();
		String bunho = request.getBunho();
		String bunryu1 = request.getBunryu1();
		String hoDong = request.getHoDong();
		
        List<DRG3041P06grdActListInfo> listInfo = drg3041Repository.getDRG3041P06grdActListInfo(hospCode, ipgoDate, bunho, bunryu1, hoDong);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG3041P06grdActListInfo item : listInfo) {
                DrgsModelProto.DRG3041P06grdActListInfo.Builder info = DrgsModelProto.DRG3041P06grdActListInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addItems(info);
            }
        }
        return response.build();
	}

}
