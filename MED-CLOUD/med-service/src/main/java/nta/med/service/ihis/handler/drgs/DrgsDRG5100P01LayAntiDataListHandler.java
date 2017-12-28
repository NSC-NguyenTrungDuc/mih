package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg1000Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LayAntiDataListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01LayAntiDataListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01LayAntiDataListRequest, DrgsServiceProto.DrgsDRG5100P01LayAntiDataListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01LayAntiDataListHandler.class);
	@Resource
	private Drg1000Repository drg1000Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01LayAntiDataListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01LayAntiDataListRequest request) throws Exception {
		List<DrgsDRG5100P01LayAntiDataListItemInfo> listObject = drg1000Repository.getDrgsDRG5100P01LayAntiDataListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getFkocs());
		DrgsServiceProto.DrgsDRG5100P01LayAntiDataListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01LayAntiDataListResponse.newBuilder();
		if(!CollectionUtils.isEmpty(listObject)) {
			for(DrgsDRG5100P01LayAntiDataListItemInfo item : listObject) {
				DrgsModelProto.DrgsDRG5100P01LayAntiDataListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01LayAntiDataListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getDoctorName())) {
					info.setDoctorName(item.getDoctorName());
				}
				if (!StringUtils.isEmpty(item.getGwaName())) {
					info.setGwaName(item.getGwaName());
				}
				response.addAntiDataList(info);
			}
		}
		return response.build();
	}
}
