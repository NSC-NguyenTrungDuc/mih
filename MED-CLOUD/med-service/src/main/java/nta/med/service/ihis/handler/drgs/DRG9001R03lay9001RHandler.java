package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.res.Res0101Repository;
import nta.med.data.model.ihis.drgs.DRG9001R03lay9001RInfo;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG9001R03lay9001RRequest;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG9001R03lay9001RResponse;

@Service
@Scope("prototype")
public class DRG9001R03lay9001RHandler
		extends ScreenHandler<DrgsServiceProto.DRG9001R03lay9001RRequest, DrgsServiceProto.DRG9001R03lay9001RResponse> {

	@Resource
	private Res0101Repository res0101Repository;

	@Override
	public DRG9001R03lay9001RResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG9001R03lay9001RRequest request) throws Exception {
		
		DrgsServiceProto.DRG9001R03lay9001RResponse.Builder response = DrgsServiceProto.DRG9001R03lay9001RResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String date = request.getDate();
		String hoDong = request.getHoDong();
		
        List<DRG9001R03lay9001RInfo> listInfo = res0101Repository.getDRG9001R03lay9001RInfo(hospCode, date, hoDong);
        if (!CollectionUtils.isEmpty(listInfo)) {
            for (DRG9001R03lay9001RInfo item : listInfo) {
                DrgsModelProto.DRG9001R03lay9001RInfo.Builder info = DrgsModelProto.DRG9001R03lay9001RInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addItems(info);
            }
        }
        return response.build();
	}
	
}
